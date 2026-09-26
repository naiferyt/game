# Stage 0.4 — turn the decompiled (IL-less) C# of the recovery project into a compilable skeleton.
# Every stub body becomes   RecoveryPending.Hit("Type.Member");  [+ out-param defaults] [+ return default / yield break]
# so that running the game logs exactly which original method must be translated next (RECUPERADO-AOT).
# Files whose body is already recovered carry the marker "// RECUPERADO-AOT" and are never touched.
# iOS/external service classes are deleted (user decision, report §11.2) — list in SERVICE_FILES.
import os, re, sys, glob, json
HERE = os.path.dirname(os.path.abspath(__file__))
PROJ = os.path.join(HERE, '..', '..', 'recovery', 'DSSRacer_U6')
SCRIPT_DIRS = ['Assets/Scripts/Assembly-CSharp', 'Assets/Scripts/Assembly-UnityScript', 'Assets/Plugins/Assembly-CSharp-firstpass']

SERVICE_PREFIXES = ('StoreKit', 'GameCenter', 'iCloud', 'JCloud', 'GravCloud', 'P31', 'Burstly', 'GDMO', 'MoreGames')
SERVICE_EXACT = {'Email', 'ResultLogger', 'MoreDisneyLogic', 'AgeGatePopup', 'DebugMoreCoinsPublisher'}

STUB_LINE = re.compile(r'^\s*(/\*Error:[^*]*\*/;?)?\s*$')
KEYWORDS_CONTAINER = re.compile(r'\b(class|struct|interface|enum|namespace)\b')


def is_service(name):
    return name.startswith(SERVICE_PREFIXES) or name in SERVICE_EXACT


def split_params(s):
    depth = 0; cur = ''; out = []
    for ch in s:
        if ch in '<([': depth += 1
        elif ch in '>)]': depth -= 1
        if ch == ',' and depth == 0: out.append(cur.strip()); cur = ''
        else: cur += ch
    if cur.strip(): out.append(cur.strip())
    return out


def analyse_header(h):
    """returns dict(kind, name, rettype, outs, is_ctor)"""
    h = re.sub(r'^\s*(\[[^\]]*\]\s*)+', '', h).strip()   # leading attributes only (keep T[] array types)
    m = re.match(r'^(?P<mods>(?:(?:public|private|protected|internal|static|virtual|override|sealed|abstract|new|unsafe|extern|readonly|implicit|explicit)\s+)*)(?P<rest>.*)$', h)
    rest = m.group('rest'); mods = m.group('mods')
    if '(' not in rest: return None
    before, params = rest.split('(', 1)
    params = params.rsplit(')', 1)[0]
    before = before.strip()
    outs = []
    for p in split_params(params):
        pm = re.match(r'^(?:\[[^\]]*\]\s*)?out\s+(.+?)\s+(\w+)$', p)
        if pm: outs.append((pm.group(1), pm.group(2)))
    if before.startswith('operator ') or ' operator ' in ' ' + before:
        if before.startswith('operator '):   # implicit/explicit conversion: "operator T"
            return dict(kind='method', name='op_Conversion', rettype=before[len('operator '):].strip(), outs=outs)
        rt, op = before.split(' operator ', 1)
        return dict(kind='method', name='op_' + op.strip(), rettype=rt.strip(), outs=outs)
    toks = before.rsplit(None, 1)
    if len(toks) == 1:   # constructor
        return dict(kind='ctor', name=toks[0], rettype='void', outs=outs, static='static' in mods)
    rt, name = toks
    name = re.sub(r'<.*>$', '', name)
    return dict(kind='method', name=name, rettype=rt.strip(), outs=outs)


def body_for(info, member, is_struct_ctor=False):
    lines = []
    if is_struct_ctor: lines.append('this = default;')
    lines.append('RecoveryPending.Hit("%s");' % member)
    for t, n in info.get('outs', []): lines.append('%s = default(%s);' % (n, t))
    rt = info.get('rettype', 'void')
    if rt in ('IEnumerator', 'System.Collections.IEnumerator') or rt.startswith('IEnumerable'):
        lines.append('yield break;')
    elif rt != 'void':
        lines.append('return default(%s);' % rt)
    return lines


def transform(text, fname):
    L = text.split('\n')
    out = []
    stack = []   # (kind, name, header)
    i = 0; changed = 0
    while i < len(L):
        line = L[i]; s = line.strip()
        if s == '{':
            # header = previous non-empty, non-attribute line
            j = len(out) - 1
            while j >= 0 and (not out[j].strip() or out[j].strip().startswith('[')): j -= 1
            header = out[j].strip() if j >= 0 else ''
            # find matching close and check whether this is a leaf stub body
            depth = 1; k = i + 1; leaf = True; stub = True
            while k < len(L):
                t = L[k].strip()
                if t == '{' or t.endswith('{'): depth += 1; leaf = False
                if t == '}' or t.startswith('}'):
                    depth -= 1
                    if depth == 0: break
                if depth == 1 and not STUB_LINE.match(L[k]): stub = False
                k += 1
            if leaf and stub and not KEYWORDS_CONTAINER.search(header) and 'RECUPERADO-AOT' not in header:
                indent = line[:len(line) - len(line.lstrip())] + '\t'
                cls = '.'.join(n for kd, n, h in stack if kd == 'type')
                if header in ('get', 'set', 'add', 'remove'):
                    prop = next((h for kd, n, h in reversed(stack) if kd == 'prop'), '')
                    pinfo = analyse_prop(prop)
                    info = dict(rettype=pinfo[0] if header == 'get' else 'void', outs=[])
                    member = '%s.%s_%s' % (cls, header, pinfo[1])
                else:
                    info = analyse_header(header)
                    if info is None:
                        out.append(line); stack.append(('block', '', header)); i += 1; continue
                    member = '%s.%s' % (cls, '.ctor' if info['kind'] == 'ctor' else info['name'])
                is_struct = bool(stack) and stack[-1][0] == 'type' and re.search(r'\bstruct\b', stack[-1][2]) is not None and info.get('kind') == 'ctor' and not info.get('static')
                out.append(line)
                for b in body_for(info, member, is_struct): out.append(indent + b)
                out.append(L[k])
                i = k + 1; changed += 1
                continue
            # container or property block
            kind = 'block'; name = ''
            m = re.search(r'\b(class|struct|interface|enum)\s+(\w+)', header)
            if m: kind = 'type'; name = m.group(2)
            elif '(' not in header and not re.search(r'\b(namespace)\b', header) and header not in ('get', 'set', 'add', 'remove'):
                kind = 'prop'
            stack.append((kind, name, header))
            out.append(line); i += 1; continue
        if s == '}' or s.startswith('}'):
            if stack: stack.pop()
        out.append(line); i += 1
    return '\n'.join(out), changed


def analyse_prop(h):
    h = re.sub(r'^\s*(\[[^\]]*\]\s*)+', '', h).strip()
    h = re.sub(r'^((public|private|protected|internal|static|virtual|override|sealed|abstract|new|event)\s+)*', '', h)
    if ' this[' in ' ' + h:
        rt = h.split(' this[')[0].strip(); return rt, 'Item'
    toks = h.rsplit(None, 1)
    return (toks[0], toks[1]) if len(toks) == 2 else ('object', h)


PENDING = '''// Stage 0 recovery infrastructure (RECONSTRUIDO: tooling, not game logic).
// Every original method whose body has not been translated from the ARM AOT code yet calls Hit().
// The first call per member is logged, so running the game tells which method to recover next.
using System.Collections.Generic;
using UnityEngine;

public static class RecoveryPending
{
    static readonly HashSet<string> s_Seen = new HashSet<string>();
    public static bool LogEnabled = true;

    public static IEnumerable<string> Seen { get { return s_Seen; } }

    public static void Hit(string member)
    {
        if (!s_Seen.Add(member)) return;
        if (LogEnabled) Debug.LogWarning("[RecoveryPending] " + member);
    }
}
'''


def main():
    removed = []; total = 0; files = 0
    for d in SCRIPT_DIRS:
        for f in sorted(glob.glob(os.path.join(PROJ, d, '*.cs'))):
            base = os.path.splitext(os.path.basename(f))[0]
            if is_service(base):
                os.remove(f)
                if os.path.exists(f + '.meta'): os.remove(f + '.meta')
                removed.append(os.path.relpath(f, PROJ).replace('\\', '/')); continue
            text = open(f, encoding='utf-8-sig').read()
            if 'RecoveryPending.Hit' in text and 'Error: Method body' not in text:
                continue   # already transformed
            new, n = transform(text, base)
            open(f, 'w', encoding='utf8', newline='\n').write(new)
            total += n; files += 1
    rt = os.path.join(PROJ, 'Assets', 'Plugins', '_RecoveryRuntime')   # firstpass: visible to every game assembly
    os.makedirs(rt, exist_ok=True)
    open(os.path.join(rt, 'RecoveryPending.cs'), 'w', encoding='utf8', newline='\n').write(PENDING)
    json.dump(removed, open(os.path.join(HERE, '..', 'output', 'removed_service_scripts.json'), 'w'), indent=1)
    print('files transformed', files, 'bodies replaced', total, 'service files removed', len(removed))
    left = sum(open(f, encoding='utf8').read().count('Error: Method body') for d in SCRIPT_DIRS for f in glob.glob(os.path.join(PROJ, d, '*.cs')))
    print('remaining error markers', left)


if __name__ == '__main__':
    main()
