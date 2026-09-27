# Stage 4.9 — restore the materials of the 91 converted legacy particle systems.
# extract_legacy.py (Stage 0.3) parsed the ParticleRenderer's "  - {fileID: 2100000, guid: ..., type: 2}" list line
# as a key named "- {fileID", so m_Materials stayed empty, prep_stage0.py wrote materialGuid "" and
# LegacyParticleConverter left every ParticleSystemRenderer without material (drawn magenta).
# This script:
#  1. repairs legacy_particles.json (m_Materials list rebuilt from the broken key),
#  2. fills materialGuid/materialFileID in legacy_particles_u6.json,
#  3. patches the ParticleSystemRenderer (class 199) of each system in its prefab/scene.
import os, re, json, glob
HERE = os.path.dirname(os.path.abspath(__file__))
PROJ = os.path.join(HERE, '..', '..', 'recovery', 'DSSRacer_U6')
DATA = os.path.join(PROJ, 'Assets', '_Recovery', 'Data')
BROKEN = '- {fileID'

guids = set()
for m in glob.glob(os.path.join(PROJ, 'Assets', '**', '*.mat.meta'), recursive=True):
    g = re.search(r'^guid: (\w+)', open(m, encoding='utf-8').read(), re.M)
    if g: guids.add(g.group(1))

src_path = os.path.join(DATA, 'legacy_particles.json')
src = json.load(open(src_path))
mats = []
for e in src:
    r = e['ParticleRenderer']
    mat = {}
    if BROKEN in r:
        m = re.match(r'(\d+), guid: (\w+), type: (\d+)\}', r.pop(BROKEN))
        mat = dict(fileID=int(m.group(1)), guid=m.group(2), type=int(m.group(3)))
        r['m_Materials'] = [mat]
    elif r.get('m_Materials'):
        mat = r['m_Materials'][0]
    mats.append(mat)
json.dump(src, open(src_path, 'w'), indent=1)

u6_path = os.path.join(DATA, 'legacy_particles_u6.json')
u6 = json.load(open(u6_path))
assert len(u6['systems']) == len(src)
patched = missing = notfound = 0
texts = {}
for s, e, mat in zip(u6['systems'], src, mats):
    assert s['file'] == e['file'] and s['goFileID'] == e['gameObjectFileID']
    if not mat.get('guid'): continue
    s['materialGuid'] = mat['guid']; s['materialFileID'] = mat['fileID']
    if mat['guid'] not in guids:
        missing += 1; print('material not in project', mat['guid'], s['file']); continue
    f = os.path.join(PROJ, s['file'])
    t = texts.get(f) or open(f, encoding='utf-8').read()
    ref = '{fileID: %d, guid: %s, type: 2}' % (mat['fileID'], mat['guid'])
    pat = re.compile(r'(--- !u!199 &-?\d+[^\n]*\nParticleSystemRenderer:\n(?:(?!--- )[^\n]*\n)*?  m_GameObject: \{fileID: %d\}\n(?:(?!--- )[^\n]*\n)*?  m_Materials:\n  - )\{fileID: 0\}' % s['goFileID'])
    t2, n = pat.subn(lambda m: m.group(1) + ref, t, count=1)
    if n: patched += 1; texts[f] = t2
    else: notfound += 1; print('renderer not found', s['goFileID'], s['file']); texts[f] = t
json.dump(u6, open(u6_path, 'w'), indent=1)
for f, t in texts.items():
    open(f, 'w', encoding='utf-8', newline='\n').write(t)
print('systems', len(src), 'patched', patched, 'material missing', missing, 'renderer not found', notfound)
