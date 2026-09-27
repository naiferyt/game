# Fast compile check of the recovery project scripts with Roslyn against the installed Unity 6.6 assemblies
# (mirrors Unity's split: Assets/Plugins/** -> Assembly-CSharp-firstpass, rest -> Assembly-CSharp; Editor folders skipped).
# Usage: python compile_check.py            -> prints errors grouped, exit 1 on errors
import os, glob, subprocess, sys, re, collections, tempfile
HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.abspath(os.path.join(HERE, '..', '..'))
PROJ = os.path.join(ROOT, 'recovery', 'DSSRacer_U6', 'Assets')
UNITY = r"C:\Program Files\Unity\Hub\Editor\6000.6.3f1\Editor\Data"
CSC = os.path.join(ROOT, 'tools', 'Microsoft.Net.Compilers.Toolset_4.14.0', 'tasks', 'netcore', 'bincore', 'csc.dll')
OUT = os.path.join(tempfile.gettempdir(), 'dssr_compile'); os.makedirs(OUT, exist_ok=True)
# Cloud sessions (no Unity install): same compiler (Roslyn from NuGet Microsoft.Net.Compilers.Toolset, run with mono)
# against the closest Unity reference assemblies NuGet offers (UnityEngine.Modules 2021.3.33) plus netstandard 2.1.
# Set up by forensics/scripts/cloud_refs.sh. APIs added after Unity 2021.3 would show up as errors: the ones the
# project uses are listed in cloud_u6_only.txt and reported as ignored in the cloud only.
CLOUD = os.environ.get('DSSR_CLOUD_REFS', '/opt/dssr_ref')
IS_CLOUD = not os.path.isdir(UNITY) and os.path.isdir(CLOUD)


def refs():
    if IS_CLOUD:
        # netstandard 2.1 plus its facades (mscorlib, System.*): the NuGet Unity assemblies were built against mscorlib
        return sorted(glob.glob(os.path.join(CLOUD, 'nsref', 'ref', 'netstandard2.1', '*.dll'))) + \
            sorted(glob.glob(os.path.join(CLOUD, 'unity', 'lib', 'netstandard2.0', 'UnityEngine*.dll')))
    r = [os.path.join(UNITY, 'NetStandard', 'ref', '2.1.0', 'netstandard.dll')]
    r += glob.glob(os.path.join(UNITY, 'Managed', 'UnityEngine', 'UnityEngine.*Module.dll'))
    r.append(os.path.join(UNITY, 'Managed', 'UnityEngine', 'UnityEngine.dll'))
    return r


def sources(pred):
    out = []
    for f in glob.glob(os.path.join(PROJ, '**', '*.cs'), recursive=True):
        rel = os.path.relpath(f, PROJ).replace('\\', '/')
        if '/Editor/' in '/' + rel: continue
        if pred(rel): out.append(f)
    return sorted(out)


def build(name, srcs, extra):
    rsp = os.path.join(OUT, name + '.rsp')
    with open(rsp, 'w', encoding='utf8') as fh:
        fh.write('/target:library\n/nologo\n/langversion:9\n/unsafe+\n/nowarn:0618,0414,0169,0649,0162,0108,0114\n/define:UNITY_STANDALONE_WIN;UNITY_STANDALONE;UNITY_6000_0_OR_NEWER;UNITY_5_3_OR_NEWER\n')
        fh.write('/out:"%s"\n' % os.path.join(OUT, name + '.dll'))
        for r in refs() + extra: fh.write('/reference:"%s"\n' % r)
        for s in srcs: fh.write('"%s"\n' % s)
    csc = os.path.join(CLOUD, 'roslyn', 'tasks', 'netcore', 'bincore', 'csc.dll') if IS_CLOUD else CSC
    p = subprocess.run(['dotnet', csc, '@' + rsp], capture_output=True, text=True, encoding='utf8', errors='replace')
    errs = [l for l in p.stdout.splitlines() if ': error ' in l]
    if p.returncode != 0 and not errs:   # the compiler itself failed to run: never report that as "0 errors"
        errs = ['compiler failed (exit %d): %s' % (p.returncode, (p.stdout + p.stderr).strip()[:400])]
    if IS_CLOUD:
        pats = [l.strip() for l in open(os.path.join(HERE, 'cloud_u6_only.txt'), encoding='utf8') if l.strip() and not l.startswith('#')]
        kept = [e for e in errs if not any(re.search(pt, e) for pt in pats)]
        if len(kept) != len(errs): print('   (%s, cloud: %d Unity 6-only API errors ignored, see cloud_u6_only.txt)' % (name, len(errs) - len(kept)))
        errs = kept
    return errs


def main():
    fp = sources(lambda r: r.startswith('Plugins/'))
    e1 = build('Assembly-CSharp-firstpass', fp, [])
    cs = sources(lambda r: not r.startswith('Plugins/'))
    e2 = build('Assembly-CSharp', cs, [os.path.join(OUT, 'Assembly-CSharp-firstpass.dll')]) if not e1 else ['(skipped: firstpass failed)']
    for name, errs in (('firstpass', e1), ('Assembly-CSharp', e2)):
        print('== %s: %d errors' % (name, len(errs)))
        codes = collections.Counter(re.search(r'error (CS\d+)', e).group(1) for e in errs if 'error CS' in e)
        if codes: print('   ', dict(codes.most_common()))
        for e in errs[:int(os.environ.get('CC_N', '25'))]:
            print('  ', re.sub(r'^.*?Assets\\\\?', '', e.replace(PROJ + os.sep, ''))[:260])
    sys.exit(1 if (e1 or e2) else 0)


if __name__ == '__main__':
    main()
