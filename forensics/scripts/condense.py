# Condensed view of annotated AOT listings for translation work: drops prologue/epilogue boilerplate and the
# literal-pool mechanics (the GOT/float annotation on the following line carries the meaning).
# Usage: python condense.py <Assembly> <Type> [MethodRegex]
import sys, os, re
HERE = os.path.dirname(os.path.abspath(__file__))
LIST = os.path.join(HERE, '..', '..', 'recovery', 'aot_listings')
BOILER = re.compile(r'(mov\s+ip, sp$|push\s+\{r7, lr\}$|mov\s+r7, sp$|mov\s+fp, sp$|ldr\s+r7, \[sp, #8\]$|ldm\s+sp, \{sp, pc\}$|push\s+\{[^}]*fp, ip, lr\}$|pop\s+\{[^}]*fp\}$|add\s+sp, fp, #0x[0-9a-f]+$|add\s+sp, fp, #\d+$|sub\s+sp, sp, #)')


def condense(asm, typ, mrx=None):
    fn = re.sub(r'[<>`/\\:*?"|]', '_', typ) + '.txt'
    lines = open(os.path.join(LIST, asm, fn), encoding='utf8').read().split('\n')
    out = []; skip = 0; show = True
    for i, l in enumerate(lines):
        if l.startswith('== '):
            show = mrx is None or re.search(mrx, l) is not None
            if show: out.append(l)
            continue
        if not show or not l.strip(): continue
        if l.startswith('#') or l.startswith('   args'):
            if l.startswith('   args') or '+0x' in l or 'static' in l or 'vtable' in l or 'TYPE' in l: out.append(l)
            continue
        m = re.match(r'^(L_\w+:)?\s+([0-9a-f]{8})\s+(\S+)\s*(.*?)\s*(; .*)?$', l)
        if not m: out.append(l); continue
        lab, addr, mn, ops, note = m.group(1) or '', m.group(2), m.group(3), m.group(4), m.group(5) or ''
        if BOILER.search((mn + ' ' + ops).strip()) and not note: continue
        if mn == '.word' and 'literal' in note and not re.search(r'/ \S', note): continue
        if mn == 'ldr' and ops.endswith('[pc]') and i + 1 < len(lines) and re.search(r'\sb\s+#', lines[i + 1]): continue
        if mn == 'b' and i + 1 < len(lines) and '.word' in lines[i + 1] and not lab: continue
        if 'mono_arch_throw_corlib_exception' in note or (mn == 'mov' and ops == 'r1, lr'): continue
        if mn in ('andeq', 'andne') and not note: continue
        out.append('%-10s %s %-7s %-26s %s' % (lab, addr[-5:], mn, ops, note))
    return '\n'.join(out)


if __name__ == '__main__':
    print(condense(sys.argv[1], sys.argv[2], sys.argv[3] if len(sys.argv) > 3 else None))
