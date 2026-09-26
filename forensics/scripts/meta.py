# Full ECMA-335 metadata reader (all tables) + Mono 2.x instance field layout.
# Used by aotlift.py to name fields from the offsets found in AOT ARM code.
import struct, os

MD = r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\Data\Managed"

# coded index definitions: (tables, tagbits)
CI = {
    'TypeDefOrRef': ([2, 1, 0x1b], 2),
    'HasConstant': ([4, 8, 0x17], 2),
    'HasCustomAttribute': ([6, 4, 1, 2, 8, 9, 0xa, 0, 0xe, 0x17, 0x14, 0x11, 0x1a, 0x1b, 0x20, 0x23, 0x26, 0x27, 0x28, 0x2a, 0x2c, 0x2b], 5),
    'HasFieldMarshal': ([4, 8], 1),
    'HasDeclSecurity': ([2, 6, 0x20], 2),
    'MemberRefParent': ([2, 1, 0x1a, 6, 0x1b], 3),
    'HasSemantics': ([0x14, 0x17], 1),
    'MethodDefOrRef': ([6, 0xa], 1),
    'MemberForwarded': ([4, 6], 1),
    'Implementation': ([0x26, 0x23, 0x27], 2),
    'CustomAttributeType': ([6, 0xa], 3),
    'ResolutionScope': ([0, 0x1a, 0x23, 1], 2),
    'TypeOrMethodDef': ([2, 6], 1),
}
# table schemas: list of column kinds. 'u2','u4','s','g','b', ('t',table), ('c',codedname)
SCHEMA = {
    0x00: ['u2', 's', 'g', 'g', 'g'],
    0x01: [('c', 'ResolutionScope'), 's', 's'],
    0x02: ['u4', 's', 's', ('c', 'TypeDefOrRef'), ('t', 4), ('t', 6)],
    0x03: [('t', 4)],
    0x04: ['u2', 's', 'b'],
    0x05: [('t', 6)],
    0x06: ['u4', 'u2', 'u2', 's', 'b', ('t', 8)],
    0x07: [('t', 8)],
    0x08: ['u2', 'u2', 's'],
    0x09: [('t', 2), ('c', 'TypeDefOrRef')],
    0x0a: [('c', 'MemberRefParent'), 's', 'b'],
    0x0b: ['u2', ('c', 'HasConstant'), 'b'],
    0x0c: [('c', 'HasCustomAttribute'), ('c', 'CustomAttributeType'), 'b'],
    0x0d: [('c', 'HasFieldMarshal'), 'b'],
    0x0e: ['u2', ('c', 'HasDeclSecurity'), 'b'],
    0x0f: ['u2', 'u4', ('t', 2)],
    0x10: ['u4', ('t', 4)],
    0x11: ['b'],
    0x12: [('t', 2), ('t', 0x14)],
    0x13: [('t', 0x14)],
    0x14: ['u2', 's', ('c', 'TypeDefOrRef')],
    0x15: [('t', 2), ('t', 0x17)],
    0x16: [('t', 0x17)],
    0x17: ['u2', 's', 'b'],
    0x18: ['u2', ('t', 6), ('c', 'HasSemantics')],
    0x19: [('t', 2), ('c', 'MethodDefOrRef'), ('c', 'MethodDefOrRef')],
    0x1a: ['s'],
    0x1b: ['b'],
    0x1c: ['u2', ('c', 'MemberForwarded'), 's', ('t', 0x1a)],
    0x1d: ['u4', ('t', 4)],
    0x1e: ['u4', 'u4'],
    0x1f: ['u4'],
    0x20: ['u4', 'u2', 'u2', 'u2', 'u2', 'u4', 'b', 's', 's'],
    0x21: ['u4'],
    0x22: ['u4', 'u4', 'u4'],
    0x23: ['u2', 'u2', 'u2', 'u2', 'u4', 'b', 's', 's', 'b'],
    0x24: ['u4', ('t', 0x23)],
    0x25: ['u4', 'u4', 'u4', ('t', 0x23)],
    0x26: ['u4', 's', 'b'],
    0x27: ['u4', 'u4', 's', 's', ('c', 'Implementation')],
    0x28: ['u4', 'u4', 's', ('c', 'Implementation')],
    0x29: [('t', 2), ('t', 2)],
    0x2a: ['u2', 'u2', ('c', 'TypeOrMethodDef'), 's'],
    0x2b: [('c', 'MethodDefOrRef'), 'b'],
    0x2c: [('t', 0x2a), ('c', 'TypeDefOrRef')],
}

PRIM = {0x02: ('bool', 1), 0x03: ('char', 2), 0x04: ('sbyte', 1), 0x05: ('byte', 1), 0x06: ('short', 2), 0x07: ('ushort', 2),
        0x08: ('int', 4), 0x09: ('uint', 4), 0x0a: ('long', 8), 0x0b: ('ulong', 8), 0x0c: ('float', 4), 0x0d: ('double', 8),
        0x18: ('IntPtr', 4), 0x19: ('UIntPtr', 4)}
PRIM_ALIGN = {1: 1, 2: 2, 4: 4, 8: 4}   # ARMv7 Mono 2.x: 8-byte types aligned to 4 inside objects (verified empirically below if needed)


class Assembly:
    def __init__(self, path, universe):
        self.u = universe
        self.path = path
        d = self.d = open(path, 'rb').read()
        pe = struct.unpack_from('<I', d, 0x3c)[0]
        nsec = struct.unpack_from('<H', d, pe + 6)[0]; opt = struct.unpack_from('<H', d, pe + 20)[0]
        optoff = pe + 24; magic = struct.unpack_from('<H', d, optoff)[0]
        ddoff = optoff + (96 if magic == 0x10b else 112)
        self.secs = []
        for i in range(nsec):
            name, vs, va, rs, ra = struct.unpack_from('<8sIIII', d, optoff + opt + i * 40)
            self.secs.append((va, vs, ra, rs))
        cli = self.off(struct.unpack_from('<I', d, ddoff + 14 * 8)[0])
        mrva = struct.unpack_from('<I', d, cli + 8)[0]
        m = self.off(mrva)
        vlen = struct.unpack_from('<I', d, m + 12)[0]
        p = m + 16 + vlen; ns = struct.unpack_from('<H', d, p + 2)[0]; p += 4
        self.streams = {}
        for i in range(ns):
            o, sz = struct.unpack_from('<II', d, p); p += 8
            e = d.index(b'\0', p); nm = d[p:e].decode(); p = (e + 4) & ~3
            self.streams[nm] = (m + o, sz)
        self._tables()
        self._types()

    def off(self, rva):
        for va, vs, ra, rs in self.secs:
            if va <= rva < va + max(vs, rs): return rva - va + ra
        raise KeyError(rva)

    def string(self, i):
        o = self.streams['#Strings'][0] + i; e = self.d.index(b'\0', o)
        return self.d[o:e].decode('utf8', 'replace')

    def blob(self, i):
        o = self.streams['#Blob'][0] + i; d = self.d; b = d[o]
        if b & 0x80 == 0: return d[o + 1:o + 1 + b]
        if b & 0x40 == 0: L = ((b & 0x3f) << 8) | d[o + 1]; return d[o + 2:o + 2 + L]
        L = ((b & 0x1f) << 24) | (d[o + 1] << 16) | (d[o + 2] << 8) | d[o + 3]; return d[o + 4:o + 4 + L]

    def us(self, off):
        o = self.streams['#US'][0] + off; d = self.d; b = d[o]
        if b & 0x80 == 0: L = b; o += 1
        elif b & 0x40 == 0: L = ((b & 0x3f) << 8) | d[o + 1]; o += 2
        else: L = ((b & 0x1f) << 24) | (d[o + 1] << 16) | (d[o + 2] << 8) | d[o + 3]; o += 4
        return d[o:o + L - 1].decode('utf-16le', 'replace') if L else ''

    def _tables(self):
        d = self.d; o = self.streams['#~'][0]
        hs = d[o + 6]; valid = struct.unpack_from('<Q', d, o + 8)[0]
        p = o + 24; rows = {}
        for t in range(64):
            if valid >> t & 1: rows[t] = struct.unpack_from('<I', d, p)[0]; p += 4
        self.rows = rows
        R = lambda t: rows.get(t, 0)
        sz = {'s': 4 if hs & 1 else 2, 'g': 4 if hs & 2 else 2, 'b': 4 if hs & 4 else 2, 'u2': 2, 'u4': 4}
        def colsize(c):
            if isinstance(c, str): return sz[c]
            if c[0] == 't': return 4 if R(c[1]) > 0xffff else 2
            tabs, bits = CI[c[1]]
            return 4 if max(R(t) for t in tabs) >= (1 << (16 - bits)) else 2
        self.T = {}
        for t in range(0x2d):
            cols = SCHEMA[t]; widths = [colsize(c) for c in cols]
            rs = sum(widths); n = R(t)
            recs = []
            for i in range(n):
                q = p + i * rs; rec = []
                for c, w in zip(cols, widths):
                    v = struct.unpack_from('<I' if w == 4 else '<H', d, q)[0]; q += w
                    if isinstance(c, tuple) and c[0] == 'c':
                        tabs, bits = CI[c[1]]
                        tag = v & ((1 << bits) - 1); idx = v >> bits
                        v = (tabs[tag] if tag < len(tabs) else None, idx)
                    rec.append(v)
                recs.append(rec)
            self.T[t] = recs
            p += rs * n

    def _types(self):
        T = self.T; self.name = self.string(T[0x20][0][7]) if T[0x20] else os.path.basename(self.path)
        nt = len(T[2]); nf = len(T[4]); nm = len(T[6])
        self.types = []
        for i, r in enumerate(T[2]):
            fl, nmi, nsi, ext, fstart, mstart = r
            fend = T[2][i + 1][4] if i + 1 < nt else nf + 1
            mend = T[2][i + 1][5] if i + 1 < nt else nm + 1
            self.types.append(dict(idx=i + 1, flags=fl, name=self.string(nmi), ns=self.string(nsi), extends=ext,
                                   fields=list(range(fstart, fend)), methods=list(range(mstart, mend)), nested_in=None))
        for enc_nested, enc in T[0x29]:
            self.types[enc_nested - 1]['nested_in'] = enc
        self.field_owner = {}; self.method_owner = {}
        for t in self.types:
            for f in t['fields']: self.field_owner[f] = t['idx']
            for m in t['methods']: self.method_owner[m] = t['idx']
        self.by_name = {}
        for t in self.types: self.by_name[self.fullname(t['idx'])] = t['idx']
        # constants for fields
        self.field_const = {}
        for typ, parent, val in T[0x0b]:
            if parent[0] == 4: self.field_const[parent[1]] = (typ, self.blob(val))

    def fullname(self, ti):
        t = self.types[ti - 1]
        if t['nested_in']: return self.fullname(t['nested_in']) + '/' + t['name']
        return (t['ns'] + '.' if t['ns'] else '') + t['name']

    def method_name(self, mi):
        return self.string(self.T[6][mi - 1][3])

    def method_fullname(self, mi):
        return self.fullname(self.method_owner[mi]) + '::' + self.method_name(mi)

    def field_name(self, fi):
        return self.string(self.T[4][fi - 1][1])

    # ---- signatures
    @staticmethod
    def cu(b, p):
        x = b[p]
        if x & 0x80 == 0: return x, p + 1
        if x & 0x40 == 0: return ((x & 0x3f) << 8) | b[p + 1], p + 2
        return ((x & 0x1f) << 24) | (b[p + 1] << 16) | (b[p + 2] << 8) | b[p + 3], p + 4

    def tdor(self, v):
        tag = v & 3; idx = v >> 2
        return ([2, 1, 0x1b][tag], idx)

    def parse_type(self, b, p):
        """returns (typedesc, newp). typedesc: ('prim',name,size) | ('ref',name) | ('vt',(asm,typeidx) or name) | ..."""
        e = b[p]; p += 1
        if e in PRIM: return ('prim',) + PRIM[e], p
        if e == 0x0e: return ('ref', 'string'), p
        if e == 0x1c: return ('ref', 'object'), p
        if e in (0x0f, 0x10):
            t, p = self.parse_type(b, p); return ('prim', 'ptr', 4), p
        if e in (0x11, 0x12):
            v, p = self.cu(b, p); tk = self.tdor(v)
            res = self.resolve_tdor(tk)
            if e == 0x12: return ('ref', res), p
            return ('vt', res), p
        if e in (0x13, 0x1e):
            n, p = self.cu(b, p); return ('var', n), p
        if e == 0x1d:
            t, p = self.parse_type(b, p); return ('ref', ('array', t)), p
        if e == 0x14:
            t, p = self.parse_type(b, p); rank, p = self.cu(b, p)
            nsz, p = self.cu(b, p)
            for _ in range(nsz): _, p = self.cu(b, p)
            nlb, p = self.cu(b, p)
            for _ in range(nlb): _, p = self.cu(b, p)
            return ('ref', ('array', t)), p
        if e == 0x15:
            kind = b[p]; gt, p = self.parse_type(b, p)
            n, p = self.cu(b, p); args = []
            for _ in range(n):
                a, p = self.parse_type(b, p); args.append(a)
            if gt[0] == 'ref': return ('ref', ('ginst', gt[1], args)), p
            return ('vt', ('ginst', gt[1], args)), p
        if e in (0x1f, 0x20):
            _, p = self.cu(b, p); return self.parse_type(b, p)
        if e == 0x16: return ('prim', 'typedref', 8), p
        if e == 0x1b: return ('prim', 'fnptr', 4), p
        raise ValueError('elem %x' % e)

    def resolve_tdor(self, tk):
        tab, idx = tk
        if tab == 2: return (self, idx)
        if tab == 1: return self.resolve_typeref(idx)
        if tab == 0x1b:
            b = self.blob(self.T[0x1b][idx - 1][0]); t, _ = self.parse_type(b, 0); return ('spec', t)
        return None

    def resolve_typeref(self, idx):
        rs, nmi, nsi = self.T[1][idx - 1]
        name = self.string(nmi); ns = self.string(nsi)
        full = (ns + '.' if ns else '') + name
        if rs[0] == 1:   # nested in another typeref
            outer = self.resolve_typeref(rs[1])
            if isinstance(outer, tuple) and isinstance(outer[0], Assembly):
                a = outer[0]; full = a.fullname(outer[1]) + '/' + name
                return (a, a.by_name.get(full)) if full in a.by_name else full
            return full
        if rs[0] == 0x23:
            aname = self.string(self.T[0x23][rs[1] - 1][6])
            a = self.u.get(aname)
            if a and full in a.by_name: return (a, a.by_name[full])
            return full
        if full in self.by_name: return (self, self.by_name[full])
        return full

    def field_sig(self, fi):
        b = self.blob(self.T[4][fi - 1][2])
        assert b[0] == 0x06
        p = 1
        while b[p] in (0x1f, 0x20): _, p = self.cu(b, p + 1)
        t, _ = self.parse_type(b, p)
        return t

    def is_static(self, fi): return self.T[4][fi - 1][0] & 0x10
    def is_literal(self, fi): return self.T[4][fi - 1][0] & 0x40


def tname(t):
    if isinstance(t, tuple) and len(t) == 2 and isinstance(t[0], Assembly): return t[0].fullname(t[1]) if t[1] else '?'
    if isinstance(t, tuple):
        if t[0] == 'prim': return t[1]
        if t[0] in ('ref', 'vt'): return tname(t[1])
        if t[0] == 'array': return tname(t[1]) + '[]'
        if t[0] == 'ginst': return tname(t[1]) + '<' + ','.join(tname(a) for a in t[2]) + '>'
        if t[0] == 'spec': return tname(t[1])
        if t[0] == 'var': return '!%d' % t[1]
    return str(t)


class Universe:
    def __init__(self, folder=MD):
        self.asms = {}
        for f in ['mscorlib', 'System', 'System.Core', 'System.Xml', 'UnityEngine', 'Assembly-CSharp-firstpass', 'Assembly-CSharp', 'Assembly-UnityScript']:
            p = os.path.join(folder, f + '.dll')
            if os.path.exists(p): self.asms[f] = None; self._paths = getattr(self, '_paths', {}); self._paths[f] = p
        self._layout = {}

    def get(self, name):
        if name not in self.asms: return None
        if self.asms[name] is None: self.asms[name] = Assembly(self._paths[name], self)
        return self.asms[name]

    # ---- Mono 2.x layout (gc_aware_layout: reference fields first, then the rest; declaration order; natural alignment)
    def type_key(self, a, ti): return (a.name, ti)

    def parent(self, a, ti):
        ext = a.types[ti - 1]['extends']
        if ext[1] == 0: return None
        r = a.resolve_tdor(ext)
        if isinstance(r, tuple) and isinstance(r[0], Assembly) and r[1]: return r
        if isinstance(r, tuple) and r[0] == 'spec':  # generic base
            t = r[1]
            if t[0] in ('ref', 'vt') and isinstance(t[1], tuple) and t[1][0] == 'ginst':
                g = t[1][1]
                if isinstance(g, tuple) and isinstance(g[0], Assembly): return g
        return None

    def is_valuetype(self, a, ti):
        p = self.parent(a, ti)
        if not p: return False
        pn = p[0].fullname(p[1])
        if pn == 'System.Enum': return True
        if pn == 'System.ValueType': return a.fullname(ti) != 'System.Enum'
        return False

    def is_enum(self, a, ti):
        p = self.parent(a, ti)
        return bool(p) and p[0].fullname(p[1]) == 'System.Enum'

    def field_size_align(self, t):
        """size, align, is_ref for a field typedesc"""
        k = t[0]
        if k == 'prim': s = t[2]; return s, PRIM_ALIGN.get(s, 4), False
        if k == 'ref': return 4, 4, True
        if k == 'var': return 4, 4, True     # generic param: assume reference (approximation)
        if k == 'vt':
            r = t[1]
            if isinstance(r, tuple) and len(r) == 2 and isinstance(r[0], Assembly) and r[1]:
                lay = self.layout(r[0], r[1])
                return lay['vt_size'], lay['align'], lay['has_refs']
            return 4, 4, False
        return 4, 4, False

    def layout(self, a, ti):
        key = (a.name, ti)
        if key in self._layout: return self._layout[key]
        vt = self.is_valuetype(a, ti)
        if self.is_enum(a, ti):
            for fi in a.types[ti - 1]['fields']:
                if not a.is_static(fi):
                    s, al, _ = self.field_size_align(a.field_sig(fi))
                    res = dict(fields=[], size=8 + s, vt_size=s, align=al, has_refs=False); self._layout[key] = res; return res
        if vt: base = 8; parent_fields = []; align = 1; has_refs = False
        else:
            p = self.parent(a, ti)
            if p:
                pl = self.layout(*p); base = pl['size']; parent_fields = pl['fields']; has_refs = pl['has_refs']; align = pl['align']
            else:
                base = 8; parent_fields = []; has_refs = False; align = 4
        # explicit class layout?
        explicit = (a.types[ti - 1]['flags'] & 0x18) == 0x10
        seq = (a.types[ti - 1]['flags'] & 0x18) == 0x08
        inst = [fi for fi in a.types[ti - 1]['fields'] if not a.is_static(fi)]
        fields = list(parent_fields); off = base
        info = [(fi, a.field_sig(fi)) for fi in inst]
        passes = [True, False] if not (seq and vt) else [None]
        if explicit:
            fo = {f: o for o, f in a.T[0x10]}
            for fi, t in info:
                s, al, r = self.field_size_align(t)
                o = base + fo.get(fi, 0); fields.append((o, a.field_name(fi), tname(t), a.name, fi)); off = max(off, o + s)
                has_refs |= r; align = max(align, al)
        else:
            for pas in passes:
                for fi, t in info:
                    s, al, r = self.field_size_align(t)
                    if pas is not None and r != pas: continue
                    off = (off + al - 1) & ~(al - 1)
                    fields.append((off, a.field_name(fi), tname(t), a.name, fi))
                    off += s; has_refs |= r; align = max(align, al)
        size = off
        if not vt: size = (size + 3) & ~3
        vt_size = max(size - 8, 1) if vt else size
        if vt:
            vt_size = (vt_size + align - 1) & ~(align - 1) if vt_size > 0 else 1
        res = dict(fields=fields, size=size, vt_size=vt_size, align=max(align, 1), has_refs=has_refs)
        self._layout[key] = res
        return res

    def find(self, fullname):
        for n in self.asms:
            a = self.get(n)
            if fullname in a.by_name: return a, a.by_name[fullname]
        return None


if __name__ == '__main__':
    import sys
    u = Universe()
    for tn in (sys.argv[1:] or ['UnityEngine.Object', 'UnityEngine.MonoBehaviour', 'ProgressTriggerLogic', 'WaypointLogic', 'RaceManager']):
        r = u.find(tn)
        if not r: print('not found', tn); continue
        lay = u.layout(*r)
        print('==', tn, 'size', hex(lay['size']))
        for o, n, t, an, fi in lay['fields']: print('   0x%02x %-28s %s' % (o, n, t))
