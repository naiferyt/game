# Stage 0.3 — inventory + strip of Unity 4 components that Unity 6 cannot load, BEFORE the first import.
#  * Legacy particles (EllipsoidParticleEmitter 15, ParticleAnimator 12, ParticleRenderer 26): all fields saved to
#    Assets/_Recovery/Data/legacy_particles.json (the editor converter rebuilds them as ParticleSystem).
#  * Lightmap data per scene (LightmapSettings lightmap list + per-renderer index/scale-offset) saved to
#    Assets/_Recovery/Data/lightmaps.json (LegacyLightmapRestorer applies it at runtime).
#  * GUILayer (92) and HaloManager (127) are removed (no Unity 6 equivalent needed).
# The component documents are removed from the YAML and from each GameObject's m_Component list.
import os, re, glob, json, collections
HERE = os.path.dirname(os.path.abspath(__file__))
PROJ = os.path.join(HERE, '..', '..', 'recovery', 'DSSRacer_U6')
DOC_RE = re.compile(r'^--- !u!(\d+) &(-?\d+)( stripped)?\s*$', re.M)
STRIP = {15: 'EllipsoidParticleEmitter', 12: 'ParticleAnimator', 26: 'ParticleRenderer', 92: 'GUILayer', 127: 'HaloManager'}
LEGACY_PARTICLES = {15, 12, 26}


def num(s):
    s = s.strip()
    try:
        if re.fullmatch(r'-?\d+', s): return int(s)
        return float(s)
    except ValueError:
        return s


def parse_value(v):
    v = v.strip()
    m = re.fullmatch(r'\{(.*)\}', v)
    if m:
        d = {}
        for part in re.findall(r'(\w+): ([^,]+)', m.group(1)): d[part[0]] = num(part[1])
        return d
    return num(v)


def parse_body(body):
    """flat parse of a component document (2-space indented keys, nested blocks one level, lists of {..})"""
    out = {}; cur = None
    for line in body.split('\n')[2:]:
        if not line.strip(): continue
        m = re.match(r'^  ([^ :][^:]*): ?(.*)$', line)
        if m:
            k, v = m.group(1), m.group(2)
            if v == '': out[k] = {}; cur = k
            else: out[k] = parse_value(v); cur = None
            continue
        m = re.match(r'^  - (.*)$', line)
        if m and cur is not None:
            if not isinstance(out[cur], list): out[cur] = []
            out[cur].append(parse_value(m.group(1))); continue
        m = re.match(r'^    ([^:]+): ?(.*)$', line)
        if m and cur is not None and isinstance(out[cur], dict):
            out[cur][m.group(1)] = parse_value(m.group(2))
    return out


def main():
    particles = []; lightmaps = {}; stats = collections.Counter()
    files = sorted(glob.glob(os.path.join(PROJ, 'Assets', '**', '*.unity'), recursive=True) +
                   glob.glob(os.path.join(PROJ, 'Assets', '**', '*.prefab'), recursive=True))
    for f in files:
        text = open(f, encoding='utf8').read()
        rel = os.path.relpath(f, os.path.join(PROJ)).replace('\\', '/')
        ms = list(DOC_RE.finditer(text))
        docs = []
        for i, m in enumerate(ms):
            end = ms[i + 1].start() if i + 1 < len(ms) else len(text)
            docs.append((int(m.group(1)), m.group(2), m.start(), end))
        # lightmaps (scenes only)
        if f.endswith('.unity'):
            lm = {'lightmaps': [], 'renderers': []}
            for cid, fid, a, b in docs:
                body = text[a:b]
                if cid == 157:
                    lm['lightmapsMode'] = num(re.search(r'm_LightmapsMode: (\d+)', body).group(1))
                    lm['lightmaps'] = re.findall(r'm_Lightmap: \{fileID: -?\d+(?:, guid: (\w+))?', body)
                elif cid in (23, 137, 26):
                    li = re.search(r'm_LightmapIndex: (\d+)', body)
                    if li and int(li.group(1)) != 255:
                        lt = parse_value(re.search(r'm_LightmapTilingOffset: (\{[^}]*\})', body).group(1))
                        lm['renderers'].append({'fileID': int(fid), 'index': int(li.group(1)), 'scaleOffset': [lt['x'], lt['y'], lt['z'], lt['w']]})
            if lm['renderers']:
                lightmaps[rel] = lm; stats['lightmapped_renderers'] += len(lm['renderers'])
        # legacy particles grouped by GameObject
        by_go = collections.defaultdict(dict)
        remove = set()
        for cid, fid, a, b in docs:
            if cid not in STRIP: continue
            body = text[a:b]
            remove.add(fid); stats['removed_' + STRIP[cid]] += 1
            if cid in LEGACY_PARTICLES:
                go = re.search(r'm_GameObject: \{fileID: (-?\d+)\}', body).group(1)
                by_go[go][STRIP[cid]] = dict(parse_body(body), fileID=int(fid))
        for go, comps in by_go.items():
            particles.append(dict(file=rel, gameObjectFileID=int(go), **comps))
        if not remove: continue
        # strip documents + component references
        pieces = []; last = 0
        for cid, fid, a, b in docs:
            if fid in remove:
                pieces.append(text[last:a]); last = b
        pieces.append(text[last:])
        text = ''.join(pieces)
        text = re.sub(r'^  - \d+: \{fileID: (-?\d+)\}\n', lambda m: '' if m.group(1) in remove else m.group(0), text, flags=re.M)
        open(f, 'w', encoding='utf8', newline='\n').write(text)
        stats['files_modified'] += 1
    outdir = os.path.join(PROJ, 'Assets', '_Recovery', 'Data')
    os.makedirs(outdir, exist_ok=True)
    json.dump(particles, open(os.path.join(outdir, 'legacy_particles.json'), 'w'), indent=1)
    json.dump(lightmaps, open(os.path.join(outdir, 'lightmaps.json'), 'w'), indent=1)
    print(dict(stats)); print('particle systems:', len(particles), ' scenes with lightmaps:', len(lightmaps))


if __name__ == '__main__':
    main()
