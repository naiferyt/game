# Small C# source editing helpers for the recovery project (member removal with brace matching).
import re


def remove_members(text, names, fields=()):
    """Remove methods (all overloads) named in `names` and field declarations named in `fields`.
    Returns (new_text, removed_signatures)."""
    L = text.split('\n'); out = []; removed = []; i = 0
    while i < len(L):
        s = L[i].strip()
        m = re.match(r'^(?:\[[^\]]*\]\s*)*(?:(?:public|private|protected|internal|static|virtual|override|abstract|sealed|new)\s+)+[\w<>\[\],. ]+?\s+(\w+)\s*\(', s)
        if m and m.group(1) in names and not s.endswith(';'):
            # drop preceding attribute lines
            while out and out[-1].strip().startswith('['): out.pop()
            removed.append(s)
            j = i + 1
            while L[j].strip() != '{': j += 1
            depth = 0; k = j
            while True:
                t = L[k].strip()
                if t == '{' or t.endswith('{'): depth += t.count('{')
                if t.startswith('}') or t == '}': depth -= 1
                if depth == 0 and k > j: break
                k += 1
            i = k + 1
            if i < len(L) and not L[i].strip(): i += 1
            continue
        fm = re.match(r'^(?:\[[^\]]*\]\s*)*(?:(?:public|private|protected|internal|static|readonly)\s+)+[\w<>\[\],. ]+?\s+(\w+)\s*(=[^;]*)?;$', s)
        if fm and fm.group(1) in fields:
            while out and out[-1].strip().startswith('['): out.pop()
            removed.append(s); i += 1
            if i < len(L) and not L[i].strip(): i += 1
            continue
        out.append(L[i]); i += 1
    return '\n'.join(out), removed


def add_class_note(text, class_name, lines):
    m = re.search(r'^(\s*)(public |internal )?(\w+ )*class ' + re.escape(class_name) + r'\b[^\n]*\n\1\{\n', text, re.M)
    if not m: raise ValueError('class not found ' + class_name)
    ind = m.group(1) + '\t'
    note = ''.join(ind + '// ' + l + '\n' for l in lines)
    return text[:m.end()] + note + '\n' + text[m.end():]
