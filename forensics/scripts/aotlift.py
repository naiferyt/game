# aotlift: annotated ARM listings of Mono AOT (format v66) methods from the DSSRacing binary.
# Usage: python aotlift.py <Assembly> <TypeName> [out.txt]     e.g. python aotlift.py Assembly-CSharp ProgressTriggerLogic
#        python aotlift.py --all <Assembly> <outdir>
import struct, re, os, sys, pickle, collections
import capstone
from meta import Universe, Assembly, tname

BIN = r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\DSSRacing"
HERE = os.path.dirname(os.path.abspath(__file__))

PATCH = {3: 'METHOD', 6: 'METHODCONST', 7: 'INTERNAL_METHOD', 8: 'SWITCH', 11: 'CLASS', 12: 'IMAGE', 13: 'FIELD', 14: 'VTABLE',
         15: 'CLASS_INIT', 16: 'SFLDA', 17: 'LDSTR', 18: 'LDTOKEN', 19: 'TYPE_FROM_HANDLE', 23: 'IID', 24: 'ADJUSTED_IID',
         30: 'DELEGATE_TRAMPOLINE', 31: 'ICALL_ADDR', 32: 'JIT_ICALL_ADDR', 33: 'INTERRUPTION_FLAG', 34: 'METHOD_RGCTX',
         35: 'RGCTX_FETCH', 36: 'GENERIC_CLASS_INIT', 37: 'MONITOR_ENTER', 38: 'MONITOR_EXIT', 39: 'SEQ_POINT_INFO'}
WRAPPERS = {1: 'delegate-invoke', 2: 'delegate-begin-invoke', 3: 'delegate-end-invoke', 4: 'runtime-invoke', 5: 'native-to-managed',
            6: 'managed-to-native', 7: 'managed-to-managed', 12: 'ldfld', 13: 'stfld', 16: 'synchronized', 18: 'isinst',
            19: 'castclass', 21: 'stelemref', 22: 'unbox', 23: 'ldflda', 24: 'write-barrier', 25: 'unknown', 28: 'alloc'}
VTABLE_BASE = 0x24     # offsetof(MonoVTable, vtable) on 32-bit Mono 2.x (verified by aotlift self-check)


class Binary:
    def __init__(self):
        self.d = open(BIN, 'rb').read()
        d = self.d
        ncmds = struct.unpack_from('<I', d, 16)[0]; p = 28; self.segs = []
        for i in range(ncmds):
            cmd, cs = struct.unpack_from('<II', d, p)
            if cmd == 1:
                vmaddr, vmsize, fo, fs = struct.unpack_from('<IIII', d, p + 24)
                self.segs.append((vmaddr, vmsize, fo, fs))
            p += cs

    def f(self, v):
        for va, vs, fo, fs in self.segs:
            if fs and va <= v < va + fs: return fo + (v - va)
        raise KeyError(hex(v))

    def u32(self, v): return struct.unpack_from('<I', self.d, self.f(v))[0]
    def i32(self, v): return struct.unpack_from('<i', self.d, self.f(v))[0]
    def cstr(self, v):
        o = self.f(v); e = self.d.index(b'\0', o); return self.d[o:e].decode('latin1')
    def bytes(self, v, n): o = self.f(v); return self.d[o:o + n]


def find_modules(b):
    d = b.d; mods = {}
    for m in re.finditer(b'mono_aot_assembly_name\0', d):
        # file offset -> vm address (text segment)
        sv = None
        for va, vs, fo, fs in b.segs:
            if fs and fo <= m.start() < fo + fs: sv = va + (m.start() - fo)
        for q in re.finditer(re.escape(struct.pack('<I', sv)), d):
            s = q.start()
            while True:
                np_ = struct.unpack_from('<I', d, s - 8)[0]
                try: ok = np_ and 0x20 <= d[b.f(np_)] < 0x7f
                except KeyError: ok = False
                if not ok: break
                s -= 8
            tab = {}; o = s
            while True:
                np_, vp = struct.unpack_from('<II', d, o)
                if np_ == 0: break
                try: tab[b.cstr(np_)] = vp
                except KeyError: break
                o += 8
            if 'mono_aot_assembly_name' in tab: mods[b.cstr(tab['mono_aot_assembly_name'])] = tab
    return mods


class Module:
    def __init__(self, b, u, name, g):
        self.b = b; self.u = u; self.name = name; self.g = g
        self.asm = u.get(name)
        fi = g['mono_aot_file_info']
        self.plt_got_base, self.got_size, self.plt_size, self.nmethods = [b.u32(fi + 4 * i) for i in range(4)]
        self.got = b.u32(g['mono_aot_got_addr'])
        self.gi = g['got_info']
        self.images = self._image_table()
        self.maddr = [b.u32(g['method_addresses'] + 4 * i) for i in range(self.nmethods)]
        self.moff = [b.i32(g['method_offsets'] + 4 * i) for i in range(self.nmethods)]
        self.ndefs = len(self.asm.T[6])
        self.addr2idx = {}
        for i in range(self.nmethods):
            if self.moff[i] != -1: self.addr2idx.setdefault(self.maddr[i], i)
        starts = sorted(self.addr2idx) + [g['methods_end']]
        self.msize = {starts[i]: starts[i + 1] - starts[i] for i in range(len(starts) - 1)}
        self._extra_off = None; self._extra_cache = {}
        self._got_cache = {}; self._plt = None

    # ---------- encodings
    def dv(self, v):
        b = self.b.bytes(v, 5); x = b[0]
        if x & 0x80 == 0: return x, v + 1
        if x & 0x40 == 0: return ((x & 0x3f) << 8) | b[1], v + 2
        if x != 0xff: return ((x & 0x1f) << 24) | (b[1] << 16) | (b[2] << 8) | b[3], v + 4
        return (b[1] << 24) | (b[2] << 16) | (b[3] << 8) | b[4], v + 5

    def _image_table(self):
        v = self.g['mono_image_table']; n = self.b.u32(v); v += 4; out = []
        for i in range(n):
            names = []
            for _ in range(4):
                s = self.b.cstr(v); names.append(s); v += len(s.encode('latin1')) + 1
            v = (v + 7) & ~7; v += 4 * 5
            out.append(names[0])
        return out

    def img(self, i):
        if i < len(self.images): return self.u.get(self.images[i])
        return None

    def klass(self, p):
        tok, p = self.dv(p)
        if tok == 0: return 'null', p
        tab = tok >> 24
        if tab == 0:
            ii, p = self.dv(p); a = self.img(ii)
            return (a.fullname(tok) if a and tok <= len(a.types) else '%s:typedef%x' % (self.images[ii] if ii < len(self.images) else ii, tok)), p
        if tok == 0x1b000000:
            ty, p = self.dv(p)
            if ty == 0x15:
                gk, p = self.klass(p); args, p = self.ginst(p)
                return '%s<%s>' % (gk, ','.join(args)), p
            if ty in (0x13, 0x1e):
                num, p = self.dv(p); ism, p = self.dv(p)
                if ism: owner, p = self.method_ref(p)
                else: owner, p = self.klass(p)
                return '%s%d' % ('!!' if ty == 0x1e else '!', num), p
            return 'typespec?%x' % ty, p
        if tab == 0x1b:
            ii, p = self.dv(p); a = self.img(ii)
            try:
                t = a.resolve_tdor((0x1b, tok & 0xffffff)); return tname(t), p
            except Exception:
                return 'typespec%x' % tok, p
        if tok == 0x02000000:
            ii, p = self.dv(p); rank, p = self.dv(p); ek, p = self.klass(p)
            return ek + '[' + ',' * (rank - 1) + ']', p
        return 'klass?%x' % tok, p

    def ginst(self, p):
        n, p = self.dv(p); out = []
        for _ in range(n):
            k, p = self.klass(p); out.append(k)
        return out, p

    def gctx(self, p):
        """Unity Mono AOT v66: has_class_inst, [ginst], has_method_inst, [ginst]"""
        f, p = self.dv(p); ci = []
        if f: ci, p = self.ginst(p)
        f, p = self.dv(p); mi = []
        if f: mi, p = self.ginst(p)
        return ci, mi, p

    def mname_tok(self, a, tok):
        tab = tok >> 24; idx = tok & 0xffffff
        if a is None: return 'tok%x' % tok
        try:
            if tab == 6: return a.method_fullname(idx)
            if tab == 0x0a:
                par, nmi, sig = a.T[0x0a][idx - 1]
                nm = a.string(nmi)
                if par[0] in (1, 2, 0x1b): return tname(a.resolve_tdor(par)) + '::' + nm
                if par[0] == 6: return a.method_fullname(par[1])
                return '?::' + nm
            if tab == 0x2b:
                meth, inst = a.T[0x2b][idx - 1]
                base = self.mname_tok(a, (meth[0] << 24) | meth[1])
                b = a.blob(inst); n, q = Assembly.cu(b, 1); args = []
                for _ in range(n):
                    t, q = a.parse_type(b, q); args.append(tname(t))
                return base + '<' + ','.join(args) + '>'
        except Exception as e:
            return 'tok%x(%s)' % (tok, e)
        return 'tok%x' % tok

    def method_ref(self, p):
        """Unity Mono AOT v66 method-ref encoding (verified against the binary):
           value>>24 < 240 : image index, value&0xffffff = MethodDef index
           252 : flag (no AOT trampoline), followed by a normal method ref
           253 : wrapper: wrapper_type [+ klass / method / subtype]
           254 : method of generic instance: klass, image, methoddef token, generic context
           255 : image, token (MemberRef 0x0a / MethodSpec 0x2b)"""
        v, p = self.dv(p)
        ii = v >> 24
        if ii == 252:
            return self.method_ref(p)
        if ii == 253:
            wt, p = self.dv(p); wn = WRAPPERS.get(wt, 'wrapper%d' % wt)
            if wt in (12, 13, 18, 19, 20, 22, 23, 1, 2, 3):
                k, p = self.klass(p); return 'wrapper %s(%s)' % (wn, k), p
            if wt in (4, 6, 8, 9, 10, 16):
                r, p = self.method_ref(p); return 'wrapper %s(%s)' % (wn, r), p
            if wt in (25, 28, 7):
                s, p = self.dv(p); return 'wrapper %s(%d)' % (wn, s), p
            return 'wrapper ' + wn, p
        if ii == 254:
            k, p = self.klass(p); im, p = self.dv(p); tok, p = self.dv(p)
            ci, mi, p = self.gctx(p)
            a = self.img(im)
            nm = a.method_name(tok & 0xffffff) if a and (tok >> 24) == 6 else 'tok%x' % tok
            return '%s::%s%s' % (k, nm, ('<' + ','.join(mi) + '>') if mi else ''), p
        if ii == 255:
            im, p = self.dv(p); tok, p = self.dv(p)
            return self.mname_tok(self.img(im), tok), p
        if ii >= 240:
            return 'methodref?%d' % ii, p
        a = self.img(ii)
        return self.mname_tok(a, 0x06000000 | (v & 0xffffff)), p

    def field(self, p):
        k, p = self.klass(p); fi, p = self.dv(p)
        # field index is relative to the klass image: find by name in any loaded asm
        nm = None
        for an in list(self.u.asms):
            a = self.u.get(an)
            try:
                if a.fullname(a.field_owner.get(fi, 0) or 1) == k.split('<')[0]:
                    nm = a.field_name(fi); break
            except Exception: pass
        return '%s::%s' % (k, nm or ('field%x' % fi)), p

    def patch(self, off):
        p = self.gi + off
        t, p = self.dv(p)
        tn = PATCH.get(t, 'T%d' % t)
        try:
            if t in (3, 6, 31, 34):
                r, p = self.method_ref(p); return tn, r
            if t in (7, 32):
                n, p = self.dv(p); return tn, self.b.bytes(p, n).decode('latin1')
            if t == 17:
                im, p = self.dv(p); tok, p = self.dv(p); a = self.img(im)
                return tn, repr(a.us(tok) if a else tok)
            if t in (18, 19):
                im, p = self.dv(p); tok, p = self.dv(p); a = self.img(im)
                tab = tok >> 24
                if tab == 2: return tn, 'typeof(%s)' % a.fullname(tok & 0xffffff)
                if tab == 1: return tn, 'typeof(%s)' % tname(a.resolve_typeref(tok & 0xffffff))
                if tab == 0x1b: return tn, 'typeof(%s)' % tname(a.resolve_tdor((0x1b, tok & 0xffffff)))
                if tab == 4: return tn, 'fieldof %s' % a.field_name(tok & 0xffffff)
                return tn, 'tok%x' % tok
            if t in (11, 14, 15, 23, 24, 30, 36):
                k, p = self.klass(p); return tn, k
            if t in (13, 16):
                r, p = self.field(p); return tn, r
            if t == 8:
                n, p = self.dv(p); return tn, 'switch table[%d]' % n
            if t == 12:
                im, p = self.dv(p); return tn, self.images[im] if im < len(self.images) else im
            return tn, ''
        except Exception as e:
            return tn, 'decode-error %r' % e

    def got_slot(self, i):
        if i in self._got_cache: return self._got_cache[i]
        if i < self.plt_got_base:
            off = self.b.u32(self.g['got_info_offsets'] + 4 * i)
            r = self.patch(off)
        else:
            r = ('PLTSLOT', str(i - self.plt_got_base))
        self._got_cache[i] = r
        return r

    def plt(self):
        if self._plt is None:
            self._plt = {}
            for k, a in enumerate(range(self.g['plt'], self.g['plt_end'], 16)):
                if k == 0: continue
                self._plt[a] = self.patch(self.b.u32(a + 12))
        return self._plt

    def extra_name(self, midx):
        if self._extra_off is None:
            self._extra_off = {}
            o = self.g['extra_method_info_offsets']; n = self.b.u32(o)
            for i in range(n):
                self._extra_off[self.b.u32(o + 4 + 8 * i)] = self.b.u32(o + 8 + 8 * i)
        if midx in self._extra_cache: return self._extra_cache[midx]
        ioff = self._extra_off.get(midx)
        if ioff is None: r = 'extra#%d' % midx
        else:
            p = self.g['extra_method_info'] + ioff
            kind, p = self.dv(p)
            if kind == 1:
                wt, p = self.dv(p); r = 'wrapper %s %s' % (WRAPPERS.get(wt, wt), self.b.cstr(p))
            else:
                try: r, _ = self.method_ref(p)
                except Exception as e: r = 'extra#%d(%r)' % (midx, e)
        self._extra_cache[midx] = r
        return r

    def method_name_at(self, addr):
        i = self.addr2idx.get(addr)
        if i is None: return None
        if i < self.ndefs: return self.asm.method_fullname(i + 1)
        return self.extra_name(i)


class World:
    def __init__(self):
        self.b = Binary(); self.u = Universe()
        g = find_modules(self.b)
        self.mods = {n: Module(self.b, self.u, n, g[n]) for n in ('Assembly-CSharp', 'Assembly-CSharp-firstpass', 'Assembly-UnityScript') if n in g}
        self.addr_names = {}
        for m in self.mods.values():
            for a, i in m.addr2idx.items():
                self.addr_names.setdefault(a, (m, i))
        self._vt = {}

    def name_at(self, addr):
        r = self.addr_names.get(addr)
        if not r: return None
        return r[0].method_name_at(addr)

    # ---- vtable slots (Mono: parent slots, then interface slots of new interfaces, then new virtual methods)
    def vtable(self, a, ti):
        key = (a.name, ti)
        if key in self._vt: return self._vt[key]
        p = self.u.parent(a, ti)
        slots = list(self.vtable(*p)) if p else []
        # interfaces implemented by this type not already in parent
        parent_ifaces = self._ifaces(*p) if p else set()
        for cls, itf in a.T[9]:
            if cls != ti: continue
            r = a.resolve_tdor(itf)
            ia = None
            if isinstance(r, tuple) and isinstance(r[0], Assembly): ia = r
            elif isinstance(r, tuple) and r[0] == 'spec' and isinstance(r[1][1], tuple) and r[1][1][0] == 'ginst':
                g = r[1][1][1]
                if isinstance(g, tuple) and isinstance(g[0], Assembly): ia = g
            if not ia: continue
            if (ia[0].name, ia[1]) in parent_ifaces: continue
            for mi in ia[0].types[ia[1] - 1]['methods']:
                slots.append('%s::%s' % (ia[0].fullname(ia[1]), ia[0].method_name(mi)))
        # Empirically (EffectManager/BaseEffect, boxed enum ToString): this Mono assigns the new
        # virtual slots of a class in REVERSE metadata order; vtable[0] is at MonoVTable+0x24.
        for mi in reversed(a.types[ti - 1]['methods']):
            flags = a.T[6][mi - 1][2]
            if not flags & 0x40: continue      # virtual
            nm = a.method_name(mi); full = a.fullname(ti) + '::' + nm
            if flags & 0x100 or not any(s.split('::')[-1] == nm for s in slots):
                slots.append(full)
            else:
                for k in range(len(slots) - 1, -1, -1):
                    if slots[k].split('::')[-1] == nm: slots[k] = full; break
        self._vt[key] = slots
        return slots

    def slot_candidates(self, off):
        if not hasattr(self, '_slotmap'):
            self._slotmap = collections.defaultdict(set)
            for mn, m in self.mods.items():
                a = m.asm
                for t_ in a.types:
                    try: vt = self.vtable(a, t_['idx'])
                    except Exception: continue
                    for k, s in enumerate(vt):
                        self._slotmap[VTABLE_BASE + 4 * k].add(s)
        c = sorted(self._slotmap.get(off, ()))
        if off <= 0x30: c = [s for s in c if s.startswith('System.Object') or s.startswith('UnityEngine.Object')] or c
        return c

    def throw_thunk(self, t):
        try:
            if self.b.u32(t) == 0xe1a0100e and self.b.u32(t + 4) == 0xe59f0000:
                tok = self.b.u32(t + 12)
                ms = self.u.get('mscorlib')
                if tok >> 24 == 2: return ms.fullname(tok & 0xffffff)
                return 'tok%x' % tok
        except Exception: pass
        return None

    def _ifaces(self, a, ti):
        s = set()
        p = self.u.parent(a, ti)
        if p: s |= self._ifaces(*p)
        for cls, itf in a.T[9]:
            if cls == ti:
                r = a.resolve_tdor(itf)
                if isinstance(r, tuple) and isinstance(r[0], Assembly): s.add((r[0].name, r[1]))
        return s


def lift_method(w, mod, mi, out, fieldmap):
    """mi: MethodDef index (1-based) in mod.asm"""
    a = mod.asm; i = mi - 1
    if mod.moff[i] == -1:
        out.append('== %s  token 0x%08x : (no native code: abstract/extern)\n' % (a.method_fullname(mi), 0x06000000 + mi)); return
    addr = mod.maddr[i]; size = mod.msize[addr]
    b = w.b
    code = b.bytes(addr, size)
    md = capstone.Cs(capstone.CS_ARCH_ARM, capstone.CS_MODE_ARM); md.detail = True
    flags = a.T[6][i][2]
    out.append('== %s  token 0x%08x @0x%08x (%d bytes)%s' % (a.method_fullname(mi), 0x06000000 + mi, addr, size, ' static' if flags & 0x10 else ''))
    # params
    ps, pe = a.T[6][i][5], (a.T[6][i + 1][5] if i + 1 < len(a.T[6]) else len(a.T[8]) + 1)
    pnames = [a.string(a.T[8][k - 1][2]) for k in range(ps, pe) if a.T[8][k - 1][1] > 0]
    out.append('   args: %s%s' % ('' if flags & 0x10 else 'r0=this, ', ', '.join(pnames)))
    insns = list(md.disasm(code, addr))
    # detect inline literal words (ldr rX,[pc] ; b +4 ; .word)
    lit = {}
    targets = set()
    k = 0
    listing = []
    covered = set()
    idx = 0
    pos = addr
    litpos = set()
    while pos < addr + size:
        ins = next(md.disasm(code[pos - addr:pos - addr + 4], pos), None)
        if pos in litpos: ins = None
        elif ins is not None and ins.mnemonic in ('ldr', 'vldr') and re.match(r'\w+, \[pc\]$', ins.op_str):
            nxt = next(md.disasm(code[pos - addr + 4:pos - addr + 8], pos + 4), None)
            if nxt is not None and nxt.mnemonic == 'b' and nxt.op_str == '#0x%x' % (pos + 12): litpos.add(pos + 8)
        if ins is None:
            w_ = struct.unpack_from('<I', code, pos - addr)[0]
            listing.append((pos, '.word 0x%08x' % w_, '', w_)); pos += 4; continue
        listing.append((pos, ins.mnemonic, ins.op_str, ins)); pos += 4
    # annotate
    reglit = {}
    lines = []
    for j, (pc, mn, ops, ins) in enumerate(listing):
        note = ''
        if isinstance(ins, int):
            f = struct.unpack('<f', struct.pack('<I', ins))[0]
            note = 'literal %d / %s' % (ins if ins < 0x80000000 else ins - (1 << 32), ('%.6g' % f) if 1e-6 < abs(f) < 1e7 or f == 0 else '')
            lines.append((pc, '.word', '0x%08x' % ins, note)); continue
        if mn.startswith('b') and not mn.startswith('bic') and ops.startswith('#'):
            t = int(ops[1:], 16)
            if mn in ('bl', 'blx') or mn.startswith('bl') and len(mn) <= 4 and mn not in ('bls', 'blt', 'ble', 'blo'):
                if t in mod.plt():
                    tn, desc = mod.plt()[t]; note = 'CALL %s' % desc if tn in ('METHOD', 'ICALL_ADDR') else 'CALL [%s] %s' % (tn, desc)
                else:
                    nm = w.name_at(t)
                    th = None if nm else w.throw_thunk(t)
                    note = ('CALL %s (direct)' % nm) if nm else (('THROW %s%s' % (th, ' (if %s)' % mn[2:] if len(mn) > 2 else '')) if th else 'CALL 0x%x' % t)
            else:
                targets.add(t); note = '-> L_%x' % t
        m = re.match(r'(\w+), \[pc\]$', ops)
        if mn == 'ldr' and m and j + 2 < len(listing) and isinstance(listing[j + 2][3], int):
            reglit[m.group(1)] = listing[j + 2][3]
        m2 = re.match(r'(\w+), \[pc, (\w+)\]$', ops)
        if mn == 'ldr' and m2 and m2.group(2) in reglit:
            gaddr = pc + 8 + reglit[m2.group(2)]
            slot = (gaddr - mod.got) // 4
            if 0 <= slot < mod.got_size // 4:
                tn, desc = mod.got_slot(slot); note = 'GOT[%d] %s %s' % (slot, tn, desc)
            else:
                note = 'pc-rel data 0x%x' % gaddr
        m3 = re.search(r'\[(\w+), #(-?0x[0-9a-f]+|-?\d+)\]', ops)
        if mn == 'ldr' and ops.startswith('pc, [') and m3:
            off = int(m3.group(2), 0)
            if off < 0:
                im = next((l[3] for l in reversed(lines[-6:]) if 'METHODCONST' in l[3] or 'IID' in l[3]), '')
                note = 'INTERFACE CALL %s' % (im.split('METHODCONST ')[-1] if im else 'imt%d' % off)
            else:
                c = w.slot_candidates(off)
                note = 'VIRTUAL CALL slot +0x%x: %s' % (off, ' | '.join(c[:8]) + (' ...(%d)' % len(c) if len(c) > 8 else ''))
            m3 = None
        if m3 and not note and m3.group(1) not in ('sp', 'fp', 'pc') and int(m3.group(2), 0) >= 0:
            off = int(m3.group(2), 0)
            if m3.group(1) != 'ip':
                cands = fieldmap.get(off)
                note = 'field+0x%x %s' % (off, ('(this-class: %s)' % cands) if cands else '')
            else:
                note = 'vtable?+0x%x slot %d' % (off, (off - VTABLE_BASE) // 4) if off >= VTABLE_BASE else 'imt/+0x%x' % off
        if mn.startswith('vldr') and ops.endswith('[pc]') and j + 2 < len(listing) and isinstance(listing[j + 2][3], int):
            wv = listing[j + 2][3]
            note = 'float %r' % struct.unpack('<f', struct.pack('<I', wv))[0] if ops.startswith('s') else 'double-lo 0x%x' % wv
        elif mn.startswith('vldr') and '[pc' in ops:
            mm = re.search(r'\[pc, #(-?0x[0-9a-f]+|-?\d+)\]', ops)
            if mm:
                la = (pc + 8 & ~3) + int(mm.group(1), 0)
                try:
                    if ops.startswith('d'):
                        note = 'double %r' % struct.unpack('<d', b.bytes(la, 8))[0]
                    else:
                        note = 'float %r' % struct.unpack('<f', b.bytes(la, 4))[0]
                except Exception: pass
        lines.append((pc, mn, ops, note))
    for pc, mn, ops, note in lines:
        lab = 'L_%x:' % pc if pc in targets else ''
        out.append('%-10s %08x  %-8s %-28s %s' % (lab, pc, mn, ops, ('; ' + note) if note else ''))
    out.append('')


def lift_type(w, asmname, tname_, out):
    mod = w.mods[asmname]; a = mod.asm
    matches = [t for t in a.types if a.fullname(t['idx']) == tname_ or a.fullname(t['idx']).startswith(tname_ + '/')]
    for t in matches:
        ti = t['idx']
        lay = w.u.layout(a, ti)
        fieldmap = collections.defaultdict(list)
        for o, n, ty, an, fi in lay['fields']: fieldmap[o].append(n)
        fieldmap = {k: '|'.join(v) for k, v in fieldmap.items()}
        out.append('#' * 100)
        out.append('# TYPE %s  (instance size 0x%x)' % (a.fullname(ti), lay['size']))
        for o, n, ty, an, fi in lay['fields']:
            if o >= 8: out.append('#   +0x%02x %-30s %s' % (o, n, ty))
        for fi in t['fields']:
            if a.is_static(fi):
                c = a.field_const.get(fi)
                out.append('#   static %s %s%s' % (tname(a.field_sig(fi)), a.field_name(fi), ('  = const ' + c[1].hex()) if c else ''))
        try:
            vt = w.vtable(a, ti)
            out.append('#   vtable slots: ' + ', '.join('%d:%s' % (k, s.split('::')[-1]) for k, s in enumerate(vt) if s.split('::')[0] == a.fullname(ti)))
        except Exception as e:
            out.append('#   vtable: n/a (%s)' % e)
        out.append('#' * 100)
        for mi in t['methods']:
            lift_method(w, mod, mi, out, fieldmap)


if __name__ == '__main__':
    w = World()
    if sys.argv[1] == '--all':
        asmname, outdir = sys.argv[2], sys.argv[3]
        os.makedirs(outdir, exist_ok=True)
        a = w.mods[asmname].asm
        for t in a.types:
            if t['nested_in'] or t['name'] == '<Module>': continue
            out = []
            lift_type(w, asmname, a.fullname(t['idx']), out)
            fn = re.sub(r'[<>`/\\:*?"|]', '_', a.fullname(t['idx'])) + '.txt'
            open(os.path.join(outdir, fn), 'w', encoding='utf8').write('\n'.join(out))
        print('done', len(a.types))
    else:
        out = []
        lift_type(w, sys.argv[1], sys.argv[2], out)
        txt = '\n'.join(out)
        if len(sys.argv) > 3: open(sys.argv[3], 'w', encoding='utf8').write(txt)
        else: print(txt)
