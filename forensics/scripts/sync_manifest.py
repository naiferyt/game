# Writes the file inventory section of SINCRONIZAR_A_LOCAL.md: every file added (A), modified (M), deleted (D)
# or renamed (R) in a commit range, grouped by commit and then by kind (Unity project / tooling / docs).
# Usage: python3 forensics/scripts/sync_manifest.py <base commit> [<head>] > section.md
import subprocess, sys

def git(*a):
    return subprocess.run(['git'] + list(a), capture_output=True, text=True, check=True).stdout

KINDS = [
    ('recovery/DSSRacer_U6/', 'Proyecto Unity (necesario para probar en Unity)'),
    ('forensics/', 'Herramientas de análisis (no las usa Unity)'),
    ('', 'Documentación y catálogo'),
]
STATUS = {'A': 'nuevo', 'M': 'modificado', 'D': 'borrado', 'R': 'renombrado'}


def kind(path):
    for prefix, name in KINDS:
        if path.startswith(prefix): return name


def changes(rev_range, single=False):
    args = ['diff-tree', '--no-commit-id', '--name-status', '-r', '-M', rev_range] if single else \
           ['diff', '--name-status', '-M', rev_range]
    out = []
    for line in git(*args).splitlines():
        parts = line.split('\t')
        st = parts[0][0]
        path = parts[-1]
        out.append((st, path, parts[1] if st == 'R' else None))
    return out


def table(rows):
    lines = ['| Estado | Archivo |', '|---|---|']
    for st, path, old in rows:
        extra = ' (antes `%s`)' % old if old else ''
        lines.append('| %s | `%s`%s |' % (STATUS.get(st, st), path, extra))
    return '\n'.join(lines)


def main():
    base = sys.argv[1]
    head = sys.argv[2] if len(sys.argv) > 2 else 'HEAD'
    total = changes('%s..%s' % (base, head))
    print('Rango: `%s..%s` (%d archivos).\n' % (git('rev-parse', '--short', base).strip(),
                                                 git('rev-parse', '--short', head).strip(), len(total)))
    for _, name in KINDS:
        rows = sorted(r for r in total if kind(r[1]) == name)
        if rows:
            print('#### %s — %d\n' % (name, len(rows)))
            print(table(rows) + '\n')
    print('#### Por commit\n')
    for c in git('rev-list', '--reverse', '%s..%s' % (base, head)).split():
        subject = git('log', '-1', '--format=%h %s', c).strip()
        rows = changes(c, single=True)
        print('- **%s** — %s' % (subject, ', '.join('`%s`' % p.split('/')[-1] for _, p, _ in rows)))


if __name__ == '__main__':
    main()
