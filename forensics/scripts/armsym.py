# Tiny symbolic evaluator for Mono AOT ARM float code (straight-line per listing order).
import re, sys
lines = open(sys.argv[1]).read().split('\n')
start = int(sys.argv[2]) if len(sys.argv) > 2 else 0
end = int(sys.argv[3]) if len(sys.argv) > 3 else len(lines)
NAMES = {}  # fp offset -> name (optional)
mem = {}    # ('fp',off) -> expr   ; also ('reg',rX,off) for [rX,#off] where rX holds address
reg = {'r6':'this'}    # core regs -> ('addr', base, off) or expr string
dreg = {}   # d/s regs -> expr
def fmt(e): return e
def addr(base, off):
    b = reg.get(base)
    if base == 'fp': return ('fp', off)
    if isinstance(b, tuple) and b[0] == 'addr': return (b[1], b[2] + off)
    return (str(b if b is not None else base), off)
OBJ = {('fp',0x20):'ins', ('fp',0xb24):'sprite'}
FIELDS = {'ins': {8:'top',0xc:'bottom',0x10:'right',0x14:'left'},
          'this': {0x28:'offset.x',0x2c:'offset.y',0x30:'offset.z',0x24:'flipH',0x25:'flipV'},
          'sprite': {0x48:'size.x',0x4c:'size.y',0x50:'size.z',0x68:'srcUV.x',0x6c:'srcUV.y',0x70:'srcUV.w',0x74:'srcUV.h',0x60:'pixW',0x64:'pixH',0x14:'pixIns'},
          'sprite.pixIns': {8:'top',0xc:'bottom',0x10:'right',0x14:'left'}}
SLOT = {0x2c:'scale.x',0x30:'scale.y',0x34:'outer.x',0x38:'outer.y',0x3c:'outer.w',0x40:'outer.h',0x44:'inner.x',0x48:'inner.y',0x4c:'inner.w',0x50:'inner.h',0x54:'uvIn.x',0x58:'uvIn.y',0x5c:'uvIn.w',0x60:'uvIn.h'}
def memget(a):
    if a in OBJ: return OBJ[a]
    if a[0] == 'fp' and a[1] in SLOT: return SLOT[a[1]]
    if a in mem: return mem[a]
    if a[0] in FIELDS and a[1] in FIELDS[a[0]]: return a[0] + '.' + FIELDS[a[0]][a[1]]
    if a[0] == 'fp' and a[1] in SLOT: return SLOT[a[1]]
    if a[0] == 'fp': return 'fp%x' % a[1]
    return '%s[+%x]' % (a[0], a[1])
out = []
SHOWSET = True
ins_re = re.compile(r'^(L_\w+:)?\s+([0-9a-f]{5})\s+(\S+)\s*(.*?)\s*(; .*)?$')
for ln in lines[start:end]:
    m = ins_re.match(ln)
    if not m:
        if ln.startswith('=='): out.append(ln)
        continue
    lab, a, mn, ops, note = m.groups(); note = note or ''
    if lab: out.append(lab)
    ops_ = [o.strip() for o in re.split(r',(?![^\[]*\])', ops)]
    try:
        if mn == 'vldr':
            d = ops_[0]; mm = re.match(r'\[(\w+)(?:, #(-?0x[0-9a-f]+|-?\d+))?\]', ops_[1])
            if mm and mm.group(1) == 'pc':
                fv = re.search(r'float (\S+)', note); dreg[d] = fv.group(1) if fv else '?lit'
            else:
                off = int(mm.group(2), 0) if mm.group(2) else 0
                dreg[d] = memget(addr(mm.group(1), off))
        elif mn == 'vstr':
            d = ops_[0]; mm = re.match(r'\[(\w+)(?:, #(-?0x[0-9a-f]+|-?\d+))?\]', ops_[1])
            off = int(mm.group(2), 0) if mm.group(2) else 0
            if mm.group(1) == 'sp': mem[('sp', off)] = dreg.get(d, d)
            else:
                ad = addr(mm.group(1), off)
                if ad[0] == 'fp':
                    mem[ad] = dreg.get(d, d)
                    if SHOWSET and ad[1] < 0x250: out.append('   SET fp%x = %s' % (ad[1], dreg.get(d, d)))
                else: out.append('   STORE %s.%s = %s' % (ad[0], FIELDS.get(ad[0], {}).get(ad[1], hex(ad[1])), dreg.get(d, d)))
        elif mn.startswith('vcvt'):
            dreg[ops_[0]] = dreg.get(ops_[1], ops_[1])
        elif mn == 'vmov.f64' or (mn == 'vmov' and ops_[0][0] in 'sd' and ops_[1][0] in 'sd' and len(ops_) == 2):
            dreg[ops_[0]] = dreg.get(ops_[1], ops_[1])
        elif mn == 'vmov' and ops_[0][0] == 's' and ops_[1][0] == 'r':
            dreg[ops_[0]] = reg.get(ops_[1], ops_[1]) if not isinstance(reg.get(ops_[1]), tuple) else '?'
        elif mn == 'vmov' and ops_[0][0] == 'r':
            reg[ops_[0]] = dreg.get(ops_[1], ops_[1])
        elif mn in ('vadd.f64', 'vsub.f64', 'vmul.f64', 'vdiv.f64'):
            op = {'vadd.f64': '+', 'vsub.f64': '-', 'vmul.f64': '*', 'vdiv.f64': '/'}[mn]
            dreg[ops_[0]] = '(%s %s %s)' % (dreg.get(ops_[1], ops_[1]), op, dreg.get(ops_[2], ops_[2]))
        elif mn == 'vcmp.f64':
            out.append('   CMP %s vs %s' % (dreg.get(ops_[0]), dreg.get(ops_[1])))
        elif mn == 'add' and ops_[1] in ('fp', 'sp') and ops_[2].startswith('#'):
            v = ops_[2][1:]; parts = [p.strip('# ') for p in ops_[2:]]
            if len(parts) == 2: val = (int(parts[0], 0) >> int(parts[1])) | ((int(parts[0], 0) << (32 - int(parts[1]))) & 0xffffffff)
            else: val = int(parts[0], 0)
            reg[ops_[0]] = ('addr', ops_[1], val)
        elif mn == 'add' and ops_[2].startswith('#') and isinstance(reg.get(ops_[1]), tuple):
            b = reg[ops_[1]]; reg[ops_[0]] = ('addr', b[1], b[2] + int(ops_[2][1:], 0))
        elif mn == 'add' and ops_[2].startswith('#'):
            reg[ops_[0]] = ('addr', str(reg.get(ops_[1], ops_[1])), int(ops_[2][1:], 0))
        elif mn == 'ldr':
            mm = re.match(r'\[(\w+)(?:, #(-?0x[0-9a-f]+|-?\d+))?\]', ops_[1])
            if mm and mm.group(1) != 'pc':
                off = int(mm.group(2), 0) if mm.group(2) else 0
                reg[ops_[0]] = memget(addr(mm.group(1), off)) if mm.group(1) != 'sp' else mem.get(('sp', off), 'sp%x' % off)
            else:
                reg[ops_[0]] = note.strip('; ')[:60]
        elif mn == 'ldrb':
            mm = re.match(r'\[(\w+)(?:, #(-?0x[0-9a-f]+|-?\d+))?\]', ops_[1]); off = int(mm.group(2), 0) if mm.group(2) else 0
            reg[ops_[0]] = memget(addr(mm.group(1), off))
        elif mn == 'cmp':
            out.append('   CMPI %s vs %s' % (reg.get(ops_[0], ops_[0]), ops_[1]))
        elif mn == 'str':
            mm = re.match(r'\[(\w+)(?:, #(-?0x[0-9a-f]+|-?\d+))?\]', ops_[1])
            off = int(mm.group(2), 0) if mm.group(2) else 0
            if mm.group(1) == 'sp': mem[('sp', off)] = reg.get(ops_[0], ops_[0])
            else: mem[addr(mm.group(1), off)] = reg.get(ops_[0], ops_[0])
        elif mn == 'mov' and ops_[1].startswith('#'):
            reg[ops_[0]] = ops_[1]
        elif mn == 'mov':
            reg[ops_[0]] = reg.get(ops_[1], ops_[1])
        elif mn == 'bl':
            if 'Vector3::.ctor' in note:
                d = reg['r0']; b = ('fp', d[2]) if isinstance(d, tuple) else None
                args = [reg.get('r1'), reg.get('r2'), reg.get('r3')]
                if b: mem[b] = args[0]; mem[(b[0], b[1] + 4)] = args[1]; mem[(b[0], b[1] + 8)] = args[2]
                out.append('   V3 fp%x = (%s, %s, %s)' % (d[2] if b else -1, *args))
            elif 'Rect::.ctor' in note:
                d = reg['r0']
                if isinstance(d, tuple):
                    for i, v in enumerate([reg.get('r1'), reg.get('r2'), reg.get('r3'), mem.get(('sp', 0))]): mem[('fp', d[2] + 4 * i)] = v
                    out.append('   RECT fp%x = (%s, %s, %s, %s)' % (d[2], reg.get('r1'), reg.get('r2'), reg.get('r3'), mem.get(('sp', 0))))
            elif 'MakeQuad' in note:
                a = [reg.get('r0'), reg.get('r1'), reg.get('r2'), reg.get('r3')] + [mem.get(('sp', o), '?') for o in range(0, 0x18, 4)]
                out.append('   QUAD TL=(%s, %s, %s) TLuv=(%s, %s) BR=(%s, %s, %s) BRuv=(%s, %s)' % tuple(a))
            else:
                if 'lossyScale' in note or 'get_ScreenSize' in note:
                    d = reg['r0']
                    if isinstance(d, tuple):
                        nm = 'lossy' if 'lossy' in note else 'screen'
                        for i, c in enumerate('xyz'): mem[('fp', d[2] + 4 * i)] = nm + '.' + c
                out.append('   ' + note.strip('; '))
        elif mn in ('beq', 'bne', 'b', 'bmi', 'bge', 'blt', 'bgt', 'ble', 'bvs'):
            out.append('   %s %s' % (mn, note.strip('; ')))
    except Exception as e:
        out.append('   !! %s %s %s (%s)' % (mn, ops, note, e))
print('\n'.join(out))
