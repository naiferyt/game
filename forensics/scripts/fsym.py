# Generic symbolic reader for Mono AOT ARM listings (Stage 3 helper, successor of armsym.py).
# Walks a condensed listing (forensics/scripts/condense.py output) in listing order and prints pseudo-code:
# float arithmetic is folded into expressions (vldr/vcvt/vadd/vmul/... through fp slots and registers),
# compares + conditional branches become "if (a < b) goto L", calls show their argument expressions and
# struct results written through a pointer (Vector3/Quaternion out-params) become name(...).x/.y/.z.
# It is straight-line: at labels the tracked state is kept (not merged), so read it together with the branches.
# Usage: python forensics/scripts/fsym.py <condensed listing> <first line> <last line> [this-name]
import re, sys

lines = open(sys.argv[1], encoding='utf-8').read().split('\n')
start = int(sys.argv[2]) - 1 if len(sys.argv) > 2 else 0
end = int(sys.argv[3]) if len(sys.argv) > 3 else len(lines)
THIS = sys.argv[4] if len(sys.argv) > 4 else 'this'

reg = {}      # core register -> expr (or ('addr', base, off))
freg = {}     # s/d register -> expr
mem = {}      # (base, off) -> expr
last_cmp = None
COND = {'eq': '==', 'ne': '!=', 'lt': '<', 'le': '<=', 'gt': '>', 'ge': '>=', 'mi': '<', 'pl': '>=',
        'hi': '>u', 'ls': '<=u', 'hs': '>=u', 'lo': '<u', 'vs': 'unordered', 'vc': 'ordered'}
ins_re = re.compile(r'^(L_\w+:)?\s+([0-9a-f]{5})\s+(\S+)\s*(.*?)\s*(;.*)?$')
out = []
CALLN = [0]
# calls whose first argument is a hidden return buffer (struct results); other calls taking a pointer in r0
# are instance methods on a struct (e.g. Vector3.get_magnitude(&v))
STRUCTRET = re.compile(r'(op_(Addition|Subtraction|Multiply|Division|UnaryNegation)|get_(zero|one|up|down|forward|back|'
                       r'right|left|position|localPosition|rotation|localRotation|eulerAngles|localEulerAngles|normalized|'
                       r'localScale|lossyScale|point|normal|identity|velocity|center|size|min|max|extents|white|clear|'
                       r'black|red|green|blue|yellow|gray|mousePosition)|Cross|Lerp|Slerp|Project|ProjectOnPlane|Reflect|Scale|'
                       r'Euler|LookRotation|AngleAxis|FromToRotation|Inverse|TransformDirection|TransformPoint|'
                       r'InverseTransformDirection|InverseTransformPoint|ClosestPointOnBounds|RotateTowards|MoveTowards|'
                       r'SmoothDamp|GetTrackPoint|GetWallOffsetForPoint|WorldToScreenPoint|ScreenToWorldPoint|'
                       r'WorldToViewportPoint|ViewportToWorldPoint|GetPoint|get_Now|op_Subtraction|FromSeconds|'
                       r'GetVelocity|GetAccel|Berp|get_ShadowPosition)$')


def emit(s):
    out.append(s)


def paren(e):
    e = str(e)
    return e if re.fullmatch(r'[\w.\[\]+()\-"\' ]*', e) and ' ' not in e.strip() else '(' + e + ')'


def rget(r):
    if r in ('sl',):
        pass
    v = reg.get(r)
    if v is None:
        return r
    if isinstance(v, tuple):
        return '&%s+%x' % (v[1], v[2])
    return v


def fieldname(comment):
    m = re.search(r'\(this-class: ([^)]+)\)', comment or '')
    return m.group(1) if m else None


def memkey(base, off):
    b = reg.get(base)
    if base == 'fp':
        return ('fp', off)
    if base == 'sp':
        return ('sp', off)
    if isinstance(b, tuple):
        return (b[1], b[2] + off)
    return (str(b if b is not None else base), off)


def memread(k, comment=None):
    if k in mem:
        return mem[k]
    if k[0] in ('fp', 'sp'):
        return '%s%x' % (k[0], k[1])
    fn = fieldname(comment)
    base = k[0]
    if fn and base in ('this', THIS):
        return '%s.%s' % (base, fn)
    return '%s.f%x%s' % (paren(base), k[1], ('{%s?}' % fn) if fn else '')


def operand(o):
    o = o.strip()
    if o.startswith('#'):
        return o[1:]
    return rget(o)


for idx in range(start, min(end, len(lines))):
    ln = lines[idx]
    if ln.startswith('==') or ln.startswith('#'):
        emit(ln)
        reg.clear(); freg.clear(); mem.clear(); last_cmp = None
        continue
    if ln.strip().startswith('args:'):
        # argument registers: r0 = this for instance methods; r1..r3 = incoming words (a struct such as a
        # Vector3 argument spans several registers/stack words, so they are named by register, not by name)
        names = [x.strip() for x in ln.strip()[5:].split(',') if x.strip()]
        inst = bool(names) and names[0].endswith('this')
        reg['r0'] = THIS if inst else 'in_r0'
        for r in ('r1', 'r2', 'r3'):
            reg[r] = 'in_' + r
        emit('   (args: %s)' % ', '.join(names))
        continue
    m = ins_re.match(ln)
    if not m:
        continue
    label, addr_, op, args, comment = m.groups()
    comment = comment or ''
    if label:
        emit('%s' % label)
    a = [x.strip() for x in re.split(r',\s*(?![^\[]*\])', args)] if args else []
    cond = ''
    # --- literals and pc-relative loads
    if op == 'ldr' and '[pc' in args:
        lit = re.search(r"LDSTR (.*)$", comment)
        if lit:
            reg[a[0]] = lit.group(1).strip()
        else:
            g = re.search(r'; (.*)$', comment)
            reg[a[0]] = '<%s>' % (g.group(1).strip() if g else 'pc')
        continue
    if op in ('vldr',) and 'float' in comment:
        v = re.search(r'float (\S+)', comment).group(1)
        try:
            fv = float(v); v = ('%.7g' % fv) + ('' if '.' in ('%.7g' % fv) or 'e' in ('%.7g' % fv) or 'inf' in v else '.0')
        except ValueError:
            pass
        freg[a[0]] = v + 'f' if v[0].isdigit() or v[0] == '-' else v
        continue
    if op == '.word':
        continue
    # --- moves
    if op in ('mov', 'mvn') and len(a) == 2:
        if a[1].startswith('#'):
            val = int(a[1][1:], 0)
            reg[a[0]] = str(~val if op == 'mvn' else val)
        else:
            reg[a[0]] = reg.get(a[1], a[1])
        continue
    if op in ('moveq', 'movne'):
        emit('   %s %s = %s' % (op, a[0], operand(a[1])))
        continue
    if op == 'add' and len(a) >= 3 and a[1] in ('fp', 'sp') and a[2].startswith('#'):
        val = int(a[2][1:], 0)
        if len(a) == 4 and a[3].startswith('#'):          # rotated immediate: imm ror n
            n = int(a[3][1:], 0)
            val = ((val >> n) | (val << (32 - n))) & 0xffffffff
        reg[a[0]] = ('addr', a[1], val)
        continue
    if op == 'add' and len(a) == 3 and a[2].startswith('#') and isinstance(reg.get(a[1]), tuple):
        b = reg[a[1]]
        reg[a[0]] = ('addr', b[1], b[2] + int(a[2][1:], 0))
        continue
    if op == 'add' and len(a) == 3 and a[2].startswith('#') and a[1] not in ('fp', 'sp', 'pc'):
        base = rget(a[1])
        reg[a[0]] = ('addr', str(base), int(a[2][1:], 0))
        continue
    if op in ('add', 'sub', 'mul', 'lsl', 'asr', 'and', 'orr') and len(a) == 3:
        sym = {'add': '+', 'sub': '-', 'mul': '*', 'lsl': '<<', 'asr': '>>', 'and': '&', 'orr': '|'}[op]
        reg[a[0]] = '%s %s %s' % (paren(operand(a[1])), sym, paren(operand(a[2])))
        continue
    # --- core loads / stores
    mm = re.match(r'\[(\w+)(?:, #(-?0x[0-9a-f]+|-?\d+))?\]', a[1]) if len(a) > 1 else None
    if op == 'ldr' and mm and mm.group(1) == 'sp' and ('sp', int(mm.group(2) or '0', 0)) not in mem:
        reg[a[0]] = 'in_sp%x' % int(mm.group(2) or '0', 0)      # incoming stack argument word
        continue
    if op in ('ldr', 'ldrb', 'ldrh', 'ldrsb') and mm and a[0] != 'lr':
        base, off = mm.group(1), int(mm.group(2) or '0', 0)
        k = memkey(base, off)
        reg[a[0]] = memread(k, comment)
        continue
    if op == 'ldr' and a and a[0] == 'lr' and not (mm and mm.group(1) == 'sp'):
        continue
    if op in ('str', 'strb', 'strh') and mm:
        base, off = mm.group(1), int(mm.group(2) or '0', 0)
        k = memkey(base, off)
        val = operand(a[0])
        mem[k] = val
        if k[0] not in ('fp', 'sp'):
            fn = fieldname(comment)
            emit('   SET %s = %s' % (('%s.%s' % (k[0], fn)) if fn and k[0] == THIS else '%s.f%x' % (paren(k[0]), k[1]), val))
        continue
    # --- VFP
    if op == 'vldr' and mm:
        base, off = mm.group(1), int(mm.group(2) or '0', 0)
        k = memkey(base, off)
        freg[a[0]] = memread(k, comment)
        continue
    if op == 'vstr' and mm:
        base, off = mm.group(1), int(mm.group(2) or '0', 0)
        k = memkey(base, off)
        val = freg.get(a[0], a[0])
        mem[k] = val
        if a[0].startswith('d') and k[0] in ('fp', 'sp'):
            mem[(k[0], k[1] + 4)] = val + '.hi'
        if k[0] not in ('fp', 'sp'):
            fn = fieldname(comment)
            emit('   SET %s = %s' % (('%s.%s' % (k[0], fn)) if fn and k[0] == THIS else '%s.f%x' % (paren(k[0]), k[1]), val))
        continue
    if op.startswith('vcvt'):
        freg[a[0]] = freg.get(a[1], a[1]) if not a[1].startswith('r') else rget(a[1])
        if '.s32' in op and op.endswith('.f64') is False and op.startswith('vcvt.s32'):
            freg[a[0]] = '(int)' + paren(freg.get(a[1], a[1]))
        elif op.startswith('vcvt.f32.s32') or op.startswith('vcvt.f64.s32'):
            freg[a[0]] = '(float)' + paren(freg.get(a[1], a[1]))
        continue
    if op == 'vmov' and len(a) == 2:
        if a[0].startswith(('s', 'd')) and a[1].startswith('r'):
            freg[a[0]] = rget(a[1])
        elif a[0].startswith('r'):
            reg[a[0]] = freg.get(a[1], a[1])
            if a[0] == 'r0':
                emit('   r0 <- %s   (float result?)' % reg['r0'])
        continue
    if op == 'vmov.f64':
        freg[a[0]] = freg.get(a[1], a[1])
        continue
    if op in ('vadd.f64', 'vsub.f64', 'vmul.f64', 'vdiv.f64', 'vadd.f32', 'vsub.f32', 'vmul.f32', 'vdiv.f32'):
        sym = {'vadd': '+', 'vsub': '-', 'vmul': '*', 'vdiv': '/'}[op[:4]]
        freg[a[0]] = '%s %s %s' % (paren(freg.get(a[1], a[1])), sym, paren(freg.get(a[2], a[2])))
        continue
    if op in ('vneg.f64', 'vneg.f32'):
        freg[a[0]] = '-' + paren(freg.get(a[1], a[1]))
        continue
    if op in ('vsqrt.f64', 'vsqrt.f32', 'vabs.f64', 'vabs.f32'):
        freg[a[0]] = '%s(%s)' % (op[1:5], freg.get(a[1], a[1]))
        continue
    if op in ('vcmp.f64', 'vcmp.f32', 'vcmpe.f64'):
        last_cmp = (paren(freg.get(a[0], a[0])), paren(freg.get(a[1], a[1])) if len(a) > 1 else '0')
        continue
    if op == 'vmrs':
        continue
    if op == 'cmp':
        last_cmp = (paren(operand(a[0])), paren(operand(a[1])))
        continue
    if op == 'tst':
        last_cmp = ('%s & %s' % (operand(a[0]), operand(a[1])), '0')
        continue
    # --- branches and calls
    if op.startswith('b') and not op.startswith('bl') and op not in ('bic',):
        tgt = re.search(r'-> (L_\w+)', comment)
        tgt = tgt.group(1) if tgt else a[0] if a else '?'
        c = op[1:]
        if c in ('', 'al'):
            emit('   goto %s' % tgt)
        else:
            x, y = last_cmp or ('?', '?')
            emit('   if (%s %s %s) goto %s' % (x, COND.get(c, c), y, tgt))
        continue
    if op.startswith('bl'):
        name = re.search(r'CALL (.*?)(?: \(direct\))?$', comment)
        name = name.group(1).strip() if name else ('THROW' if 'THROW' in comment else a[0])
        if 'THROW' in comment:
            continue
        cargs = [rget(r) for r in ('r0', 'r1', 'r2', 'r3')]
        stk = [mem.get(('sp', o)) for o in (0, 4, 8, 0xc, 0x10)]
        stk = [s for s in stk if s is not None]
        emit('   CALL %s(%s)%s' % (name, ', '.join(str(c) for c in cargs), ('  stack[%s]' % ', '.join(stk)) if stk else ''))
        r0 = reg.get('r0')
        CALLN[0] += 1
        res = '%s#%d' % (name.split('::')[-1].split('(')[0], CALLN[0])
        if isinstance(r0, tuple) and STRUCTRET.search(name):   # struct result written through r0
            for i, comp in enumerate(('x', 'y', 'z', 'w')):
                mem[(r0[1], r0[2] + 4 * i)] = '%s.%s' % (res, comp)
        reg['r0'] = res
        freg['s0'] = res
        freg['d0'] = res
        for r in ('r1', 'r2', 'r3'):
            reg.pop(r, None)
        for k in [k for k in mem if k[0] == 'sp']:
            del mem[k]
        continue
    if op == 'mov' and a[0] == 'pc':
        emit('   (switch/return)')
        continue
    if op in ('push', 'pop', 'sub', 'ldm', 'stm'):
        continue
    emit('   ?? %s %s' % (op, args))

print('\n'.join(out))
