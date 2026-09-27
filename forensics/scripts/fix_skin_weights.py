# Stage 4 (validation, 2026-09-27) — repair the 4th bone weight of the skinned meshes decoded from Unity 4
# compressed meshes. Unity stores up to 3 weights (5 bits, /31) per vertex and the 4th is implied: (31 - sum) / 31.
# The UnityPy decoder used by repair_meshes.py (Stage 0.2a) wrote 1 - sum_of_raw_values instead (e.g. 1 - 28 = -27),
# so every vertex with 4 influences had a weight of about -27 on its 4th bone. Unity's "1 bone" skinning (the editor's
# default quality level) ignores it; the Windows player (quality "Fantastic", 4 bones) threw those vertices far away:
# Randy became a huge red/black blob, Perry and Kick grew spikes. weight[3] = 1 - (w0 + w1 + w2) restores the original.
import os, re, glob
HERE = os.path.dirname(os.path.abspath(__file__))
ASSETS = os.path.join(HERE, '..', '..', 'recovery', 'DSSRacer_U6', 'Assets')
PAT = re.compile(r"(  - weight\[0\]: ([-\deE.+]+)\n    weight\[1\]: ([-\deE.+]+)\n    weight\[2\]: ([-\deE.+]+)\n    weight\[3\]: )(-[\deE.+]+)\n")


def fmt(v):
    s = repr(float(v))
    return s[:-2] if s.endswith('.0') else s


total = 0
for f in glob.glob(os.path.join(ASSETS, '**', '*.asset'), recursive=True):
    t = open(f, encoding='utf-8', errors='ignore').read()
    if '  m_Skin:' not in t or 'weight[3]: -' not in t:
        continue
    n = [0]

    def fix(m):
        n[0] += 1
        return m.group(1) + fmt(max(0.0, 1.0 - float(m.group(2)) - float(m.group(3)) - float(m.group(4)))) + '\n'
    t2 = PAT.sub(fix, t)
    if n[0]:
        open(f, 'w', encoding='utf-8', newline='\n').write(t2)
        total += n[0]
        print('%4d vertices  %s' % (n[0], os.path.relpath(f, ASSETS)))
print('fixed', total)
