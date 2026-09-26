# Stage 0.2b — undo Unity 4 static batching in the recovery project scenes.
# In the build, static renderers point at world-space "Combined Mesh (root: scene)" assets and draw only the
# submeshes listed in m_SubsetIndices. Unity 6 ignores that field, so each object drew the whole chunk again.
# For every such renderer we extract its submeshes, move the vertices back to the object's local space
# (inverse of its world matrix, computed from the scene transforms) and write a dedicated mesh asset.
# Geometry = original (re-partitioned only). Provenance: ADAPTADO-U6.
import os, re, sys, glob, struct, hashlib, json, math, collections
import numpy as np
HERE = os.path.dirname(os.path.abspath(__file__))
PROJ = os.path.join(HERE, '..', '..', 'recovery', 'DSSRacer_U6')
DOC_RE = re.compile(r'^--- !u!(\d+) &(-?\d+)( stripped)?\s*$', re.M)
V3 = r'\{x: ([^,]+), y: ([^,]+), z: ([^}]+)\}'
V4 = r'\{x: ([^,]+), y: ([^,]+), z: ([^,]+), w: ([^}]+)\}'


def docs(text):
    out = {}; ms = list(DOC_RE.finditer(text))
    for i, m in enumerate(ms):
        end = ms[i + 1].start() if i + 1 < len(ms) else len(text)
        out[m.group(2)] = (int(m.group(1)), m.start(), end)
    return out


def quat_mat(x, y, z, w):
    return np.array([[1 - 2 * (y * y + z * z), 2 * (x * y - z * w), 2 * (x * z + y * w)],
                     [2 * (x * y + z * w), 1 - 2 * (x * x + z * z), 2 * (y * z - x * w)],
                     [2 * (x * z - y * w), 2 * (y * z + x * w), 1 - 2 * (x * x + y * y)]])


class Mesh:
    def __init__(self, path):
        t = open(path, encoding='utf8').read(); self.text = t
        self.vc = int(re.search(r'    m_VertexCount: (\d+)', t).group(1))
        ch = re.findall(r'    - stream: (\d+)\n      offset: (\d+)\n      format: (\d+)\n      dimension: (\d+)', t)
        self.channels = [tuple(int(x) for x in c) for c in ch[:6]]
        self.stride = int(re.search(r'stride: (\d+)', t).group(1))
        self.data = bytes.fromhex(re.search(r'_typelessdata: ([0-9a-f]*)', t).group(1))
        ib = re.search(r'  m_IndexBuffer: ?([0-9a-f]*)', t).group(1)
        self.idx = list(struct.unpack('<%dH' % (len(ib) // 4), bytes.fromhex(ib)))
        self.subs = [tuple(int(x) for x in s) for s in re.findall(r'firstByte: (\d+)\n\s+indexCount: (\d+)\n\s+topology: (\d+)\n\s+firstVertex: (\d+)\n\s+vertexCount: (\d+)', t)]

    def attr(self, ci):
        stream, off, fmt, dim = self.channels[ci]
        if dim == 0: return None
        out = []
        for v in range(self.vc):
            o = v * self.stride + off
            out.append(tuple(self.data[o:o + 4]) if fmt == 2 else struct.unpack_from('<%df' % dim, self.data, o))
        return out


def fnum(x):
    x = float(x)
    if x == 0: return '0'
    r = '%.9g' % x
    return r


def write_mesh(path, name, attrs, sub_indices, fmt_channels):
    """attrs: dict ci -> list; sub_indices: list of index lists (one per submesh)"""
    n = len(attrs[0])
    chans = [ci for ci in range(6) if ci in attrs]
    offs = {}; stride = 0; mask = 0
    for ci in chans:
        dim = fmt_channels[ci][3]; f = fmt_channels[ci][2]
        offs[ci] = stride; stride += 4 if f == 2 else 4 * dim; mask |= 1 << ci
    buf = bytearray()
    for v in range(n):
        for ci in chans:
            dim = fmt_channels[ci][3]; f = fmt_channels[ci][2]
            buf += bytes(attrs[ci][v]) if f == 2 else struct.pack('<%df' % dim, *attrs[ci][v][:dim])
    idx = []; subs = []
    pos = np.array(attrs[0], dtype=np.float64)
    for si in sub_indices:
        first = len(idx) * 2; idx += si
        used = sorted(set(si)); p = pos[used] if used else np.zeros((1, 3))
        mn, mx = p.min(0), p.max(0)
        subs.append((first, len(si), min(used) if used else 0, (max(used) - min(used) + 1) if used else 0, (mn + mx) / 2, (mx - mn) / 2))
    mn, mx = pos.min(0), pos.max(0); c = (mn + mx) / 2; e = (mx - mn) / 2
    L = ['%YAML 1.1', '%TAG !u! tag:unity3d.com,2011:', '--- !u!43 &4300000', 'Mesh:', '  serializedVersion: 8',
         '  m_ObjectHideFlags: 0', '  m_PrefabParentObject: {fileID: 0}', '  m_PrefabInternal: {fileID: 0}', '  m_Name: %s' % name, '  m_SubMeshes:']
    for first, cnt, fv, vcount, sc, se in subs:
        L += ['  - serializedVersion: 2', '    firstByte: %d' % first, '    indexCount: %d' % cnt, '    topology: 0',
              '    firstVertex: %d' % fv, '    vertexCount: %d' % vcount, '    localAABB:',
              '      m_Center: {x: %s, y: %s, z: %s}' % tuple(fnum(x) for x in sc), '      m_Extent: {x: %s, y: %s, z: %s}' % tuple(fnum(x) for x in se)]
    L += ['  m_Shapes:', '    vertices: []', '    shapes: []', '    channels: []', '    fullWeights: []', '  m_BindPose: []', '  m_BoneNameHashes:',
          '  m_RootBoneNameHash: 0', '  m_MeshCompression: 0', '  m_StreamCompression: 0', '  m_IsReadable: 1', '  m_KeepVertices: 1', '  m_KeepIndices: 1',
          '  m_IndexBuffer: ' + struct.pack('<%dH' % len(idx), *idx).hex(), '  m_Skin: []', '  m_VertexData:', '    m_CurrentChannels: %d' % mask,
          '    m_VertexCount: %d' % n, '    m_Channels:']
    for ci in range(6):
        if ci in offs: L += ['    - stream: 0', '      offset: %d' % offs[ci], '      format: %d' % fmt_channels[ci][2], '      dimension: %d' % fmt_channels[ci][3]]
        else: L += ['    - stream: 0', '      offset: 0', '      format: 0', '      dimension: 0']
    L += ['    m_Streams:', '    - channelMask: %d' % mask, '      offset: 0', '      stride: %d' % stride, '      dividerOp: 0', '      frequency: 0']
    for _ in range(3): L += ['    - channelMask: 0', '      offset: 0', '      stride: 0', '      dividerOp: 0', '      frequency: 0']
    L += ['    m_DataSize: %d' % len(buf), '    _typelessdata: ' + buf.hex()]
    from repair_meshes import EMPTY_CM
    L += [EMPTY_CM.rstrip('\n'), '  m_LocalAABB:', '    m_Center: {x: %s, y: %s, z: %s}' % tuple(fnum(x) for x in c),
          '    m_Extent: {x: %s, y: %s, z: %s}' % tuple(fnum(x) for x in e), '  m_MeshUsageFlags: 0', '  m_MeshOptimized: 1', '']
    open(path, 'w', encoding='utf8', newline='\n').write('\n'.join(L))


def guid_for(key): return hashlib.md5(('dssr-sep:' + key).encode()).hexdigest()


def process_scene(scene_path, guid2mesh, report):
    text = open(scene_path, encoding='utf8').read()
    D = docs(text)
    body = lambda fid: text[D[fid][1]:D[fid][2]]
    go_tr = {}; tr = {}; mf = {}; mr = {}; mc = {}; names = {}
    for fid, (cid, a, b) in D.items():
        t = text[a:b]
        g = re.search(r'm_GameObject: \{fileID: (-?\d+)\}', t)
        if cid == 1:
            n = re.search(r'm_Name: ?(.*)', t); names[fid] = n.group(1).strip() if n else ''
        elif cid == 4:
            r = [float(x) for x in re.search(r'm_LocalRotation: ' + V4, t).groups()]
            p = [float(x) for x in re.search(r'm_LocalPosition: ' + V3, t).groups()]
            s = [float(x) for x in re.search(r'm_LocalScale: ' + V3, t).groups()]
            fa = re.search(r'm_Father: \{fileID: (-?\d+)\}', t).group(1)
            tr[fid] = (r, p, s, fa); go_tr[g.group(1)] = fid
        elif cid == 33:
            m = re.search(r'm_Mesh: \{fileID: (-?\d+)(?:, guid: (\w+))?', t); mf[g.group(1)] = (fid, m.group(2))
        elif cid == 23:
            s = re.search(r'm_SubsetIndices: ?([0-9a-f]*)', t)
            lt = re.search(r'm_LightmapTilingOffset: ' + V4, t)
            li = re.search(r'm_LightmapIndex: (\d+)', t)
            mr[g.group(1)] = (fid, s.group(1) if s else '', [float(x) for x in lt.groups()] if lt else None, int(li.group(1)) if li else 255)
        elif cid == 64:
            m = re.search(r'm_Mesh: \{fileID: (-?\d+)(?:, guid: (\w+))?', t)
            if m and m.group(2): mc[g.group(1)] = m.group(2)
    wm = {}
    def world(tf):
        if tf in wm: return wm[tf]
        r, p, s, fa = tr[tf]
        M = np.eye(4); M[:3, :3] = quat_mat(*r) @ np.diag(s); M[:3, 3] = p
        if fa != '0' and fa in tr: M = world(fa) @ M
        wm[tf] = M; return M
    scene_name = os.path.splitext(os.path.basename(scene_path))[0]
    outdir = os.path.join(PROJ, 'Assets', 'Mesh', '_StaticBatchSeparated', scene_name)
    edits = []
    combined_cache = {}
    for go, (rfid, subset_hex, lt, li) in mr.items():
        if not subset_hex: continue
        if go not in mf or not mf[go][1]: continue
        mfid, mguid = mf[go]
        mpath = guid2mesh.get(mguid)
        if not mpath or 'Combined Mesh' not in mpath:
            report['skipped_not_combined'] += 1; continue
        subsets = list(struct.unpack('<%dI' % (len(subset_hex) // 8), bytes.fromhex(subset_hex)))
        if mpath not in combined_cache: combined_cache[mpath] = Mesh(mpath)
        cm = combined_cache[mpath]
        M = world(go_tr[go]); Minv = np.linalg.inv(M); A = M[:3, :3]; det = np.linalg.det(A)
        # gather
        remap = {}; order = []; sub_lists = []
        for s in subsets:
            first, cnt, top, fv, vcnt = cm.subs[s]
            tri = cm.idx[first // 2: first // 2 + cnt]
            loc = []
            for i in tri:
                if i not in remap: remap[i] = len(order); order.append(i)
                loc.append(remap[i])
            if det < 0:   # Unity's static batching flips winding for mirrored objects -> flip back
                loc = [loc[k + d] for k in range(0, len(loc), 3) for d in (0, 2, 1)]
            sub_lists.append(loc)
        attrs = {}
        pos_w = np.array([cm.attr_cache(0)[i] for i in order]) if hasattr(cm, 'attr_cache') else None
        if not hasattr(cm, '_attrs'): cm._attrs = {ci: cm.attr(ci) for ci in range(6)}
        P = np.array([cm._attrs[0][i] for i in order], dtype=np.float64)
        Pl = (Minv @ np.c_[P, np.ones(len(P))].T).T[:, :3]
        attrs[0] = [tuple(p) for p in Pl]
        if cm._attrs[1]:
            N = np.array([cm._attrs[1][i] for i in order]); Nl = (A.T @ N.T).T
            Nl /= np.maximum(np.linalg.norm(Nl, axis=1, keepdims=True), 1e-12); attrs[1] = [tuple(x) for x in Nl]
        if cm._attrs[2]: attrs[2] = [cm._attrs[2][i] for i in order]
        if cm._attrs[3]: attrs[3] = [cm._attrs[3][i] for i in order]
        uv_mode = 'none'
        if cm._attrs[4]:
            uv1 = np.array([cm._attrs[4][i] for i in order])
            if lt and li != 255:
                sx, sy, ox, oy = lt
                inside = np.mean((uv1[:, 0] >= ox - 1e-3) & (uv1[:, 0] <= ox + sx + 1e-3) & (uv1[:, 1] >= oy - 1e-3) & (uv1[:, 1] <= oy + sy + 1e-3))
                raw01 = np.mean((uv1 >= -1e-3).all(1) & (uv1 <= 1 + 1e-3).all(1))
                if inside > 0.99 and not (sx > 0.99 and sy > 0.99):
                    uv1 = (uv1 - [ox, oy]) / [sx, sy]; uv_mode = 'baked-scale-offset-inverted'
                else: uv_mode = 'raw'
            attrs[4] = [tuple(x) for x in uv1]
            report['uv1_' + uv_mode] += 1
        if cm._attrs[5]:
            T = np.array([cm._attrs[5][i] for i in order]); Tl = (np.linalg.inv(A) @ T[:, :3].T).T
            Tl /= np.maximum(np.linalg.norm(Tl, axis=1, keepdims=True), 1e-12)
            attrs[5] = [tuple(Tl[k]) + (T[k, 3],) for k in range(len(T))]
        safe = re.sub(r'[^A-Za-z0-9_.-]+', '_', names.get(go, 'obj'))[:40]
        fname = '%s_%s.asset' % (safe, go)
        os.makedirs(outdir, exist_ok=True)
        mpath_new = os.path.join(outdir, fname)
        write_mesh(mpath_new, names.get(go, 'obj'), attrs, sub_lists, cm.channels)
        g = guid_for(scene_name + ':' + go)
        open(mpath_new + '.meta', 'w', encoding='utf8', newline='\n').write(
            'fileFormatVersion: 2\nguid: %s\nNativeFormatImporter:\n  externalObjects: {}\n  mainObjectFileID: 4300000\n  userData: \n  assetBundleName: \n  assetBundleVariant: \n' % g)
        edits.append((mfid, 'mesh', g)); edits.append((rfid, 'subset', None))
        report['separated'] += 1
        if det < 0: report['mirrored'] += 1
        # oracle: same GameObject has a MeshCollider with an (original, non-batched) mesh
        if go in mc and mc[go] in guid2mesh and 'Combined' not in guid2mesh[mc[go]]:
            try:
                om = Mesh(guid2mesh[mc[go]])
                if om.vc:
                    op = np.array(om.attr(0)); sp = np.array(attrs[0])
                    # compare bounding boxes (collider mesh may differ in topology but should overlap closely)
                    d = np.abs(op.min(0) - sp.min(0)).max() + np.abs(op.max(0) - sp.max(0)).max()
                    ext = max(np.abs(op).max(), 1.0)
                    report['oracle_checked'] += 1
                    if d / ext < 0.01: report['oracle_match'] += 1
                    else: report['oracle_mismatch'].append((scene_name, names.get(go), round(float(d), 3)))
            except Exception as e:
                report['oracle_error'] += 1
    # apply edits (bottom-up so offsets stay valid)
    for fid, kind, g in sorted(edits, key=lambda e: D[e[0]][1], reverse=True):
        a, b = D[fid][1], D[fid][2]; seg = text[a:b]
        if kind == 'mesh':
            seg = re.sub(r'm_Mesh: \{fileID: -?\d+, guid: \w+, type: \d\}', 'm_Mesh: {fileID: 4300000, guid: %s, type: 2}' % g, seg, count=1)
        else:
            seg = re.sub(r'm_SubsetIndices: ?[0-9a-f]*', 'm_SubsetIndices: ', seg, count=1)
        text = text[:a] + seg + text[b:]
    if edits: open(scene_path, 'w', encoding='utf8', newline='\n').write(text)


def main():
    guid2mesh = {}
    for m in glob.glob(os.path.join(PROJ, 'Assets', '**', '*.asset.meta'), recursive=True):
        g = re.search(r'guid: (\w+)', open(m, encoding='utf8').read())
        if g: guid2mesh[g.group(1)] = m[:-5]
    total = collections.Counter(); mism = []
    for sc in sorted(glob.glob(os.path.join(PROJ, 'Assets', 'Scenes', '**', '*.unity'), recursive=True)):
        rep = collections.Counter(); rep['oracle_mismatch'] = []
        process_scene(sc, guid2mesh, rep)
        mism += rep.pop('oracle_mismatch')
        if rep['separated']: print('%-28s %s' % (os.path.basename(sc), dict(rep)), flush=True)
        total.update(rep)
    print('TOTAL', dict(total)); print('oracle mismatches:', len(mism))
    for x in mism[:20]: print('  ', x)
    json.dump(dict(total=dict(total), oracle_mismatches=mism), open(os.path.join(HERE, '..', 'output', 'static_batching_separation.json'), 'w'), indent=1)


if __name__ == '__main__':
    sys.path.insert(0, HERE)
    main()
