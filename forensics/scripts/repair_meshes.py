# Stage 0.2a — decompress Unity 4 compressed meshes (m_CompressedMesh) into plain vertex/index data.
# Source of truth: the ORIGINAL serialized files (decoded with UnityPy). AssetRipper's YAML is only used to
# locate/match each mesh (by its packed vertex bytes) and is rewritten in place in the recovery project copy.
# Keeps GUID/fileID (only the .asset content changes). Provenance: RECUPERADO (geometry is original).
import os, re, sys, glob, struct, json, warnings, math
warnings.filterwarnings('ignore')
import UnityPy
from UnityPy.helpers.MeshHelper import MeshHandler

DATA = r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\Data"
PROJ = r"C:\Users\STEEP\Documents\game work\recovery\DSSRacer_U6"


def pbv_bytes(v):
    d = v.m_Data
    return bytes(d) if not isinstance(d, (bytes, bytearray)) else bytes(d)


def build_index():
    idx = {}
    files = ['mainData'] + ['level%d' % i for i in range(16)] + ['resources.assets'] + ['sharedassets%d.assets' % i for i in range(17)]
    for f in files:
        env = UnityPy.load(os.path.join(DATA, f))
        for obj in env.objects:
            if obj.type.name != 'Mesh': continue
            m = obj.read()
            if not m.m_MeshCompression: continue
            cm = m.m_CompressedMesh
            key = (cm.m_Vertices.m_NumItems, pbv_bytes(cm.m_Vertices).hex())
            idx.setdefault(key, (f, obj.path_id, m))
    return idx


def fmt(x):
    if x == 0: return '0'
    r = repr(float(x))
    return r[:-2] if r.endswith('.0') else r


def vertex_block(h, colors):
    n = h.m_VertexCount
    chans = []   # (index, dim, fmt, data)
    chans.append((0, 3, 0, h.m_Vertices))
    if getattr(h, 'm_Normals', None): chans.append((1, 3, 0, h.m_Normals))
    if colors: chans.append((2, 1, 2, colors))
    if getattr(h, 'm_UV0', None): chans.append((3, 2, 0, h.m_UV0))
    if getattr(h, 'm_UV1', None): chans.append((4, 2, 0, h.m_UV1))
    if getattr(h, 'm_Tangents', None): chans.append((5, 4, 0, h.m_Tangents))
    offs = {}; stride = 0; mask = 0
    for ci, dim, f, data in chans:
        assert len(data) == n, (ci, len(data), n)
        offs[ci] = stride; stride += 4 if f == 2 else 4 * dim; mask |= 1 << ci
    buf = bytearray()
    for v in range(n):
        for ci, dim, f, data in chans:
            if f == 2:
                c = data[v]; buf += bytes(c)
            else:
                vals = list(data[v])[:dim]
                buf += struct.pack('<%df' % dim, *vals)
    lines = ['  m_VertexData:', '    m_CurrentChannels: %d' % mask, '    m_VertexCount: %d' % n, '    m_Channels:']
    dims = {ci: (dim, f) for ci, dim, f, _ in chans}
    for ci in range(6):
        if ci in dims:
            lines += ['    - stream: 0', '      offset: %d' % offs[ci], '      format: %d' % dims[ci][1], '      dimension: %d' % dims[ci][0]]
        else:
            lines += ['    - stream: 0', '      offset: 0', '      format: 0', '      dimension: 0']
    lines += ['    m_Streams:', '    - channelMask: %d' % mask, '      offset: 0', '      stride: %d' % stride, '      dividerOp: 0', '      frequency: 0']
    for _ in range(3):
        lines += ['    - channelMask: 0', '      offset: 0', '      stride: 0', '      dividerOp: 0', '      frequency: 0']
    lines += ['    m_DataSize: %d' % len(buf), '    _typelessdata: ' + buf.hex()]
    return '\n'.join(lines)


EMPTY_CM = """  m_CompressedMesh:
    m_Vertices:
      m_NumItems: 0
      m_Range: 0
      m_Start: 0
      m_Data:
      m_BitSize: 0
    m_UV:
      m_NumItems: 0
      m_Range: 0
      m_Start: 0
      m_Data:
      m_BitSize: 0
    m_BindPoses:
      m_NumItems: 0
      m_Range: 0
      m_Start: 0
      m_Data:
      m_BitSize: 0
    m_Normals:
      m_NumItems: 0
      m_Range: 0
      m_Start: 0
      m_Data:
      m_BitSize: 0
    m_Tangents:
      m_NumItems: 0
      m_Range: 0
      m_Start: 0
      m_Data:
      m_BitSize: 0
    m_Weights:
      m_NumItems: 0
      m_Data:
      m_BitSize: 0
    m_NormalSigns:
      m_NumItems: 0
      m_Data:
      m_BitSize: 0
    m_TangentSigns:
      m_NumItems: 0
      m_Data:
      m_BitSize: 0
    m_BoneIndices:
      m_NumItems: 0
      m_Data:
      m_BitSize: 0
    m_Triangles:
      m_NumItems: 0
      m_Data:
      m_BitSize: 0
    m_Colors:
      m_NumItems: 0
      m_Data:
      m_BitSize: 0
"""


def skin_block(h):
    if not getattr(h, 'm_BoneWeights', None): return '  m_Skin: []'
    out = ['  m_Skin:']
    for w, b in zip(h.m_BoneWeights, h.m_BoneIndices):
        w = list(w) + [0] * (4 - len(w)); b = list(b) + [0] * (4 - len(b))
        out.append('  - weight[0]: %s' % fmt(w[0]))
        for k in (1, 2, 3): out.append('    weight[%d]: %s' % (k, fmt(w[k])))
        for k in range(4): out.append('    boneIndex[%d]: %d' % (k, b[k]))
    return '\n'.join(out)


def colors_of(h):
    c = getattr(h, 'm_Colors', None)
    if not c: return None
    out = []
    for col in c:
        col = list(col)
        if all(isinstance(x, float) for x in col) and max(col) <= 1.0001:
            col = [int(round(max(0, min(1, x)) * 255)) for x in col]
        out.append([int(x) & 0xff for x in col[:4]])
    return out


def check(h, t, name):
    subs = [(int(a), int(b), int(c), int(d)) for a, b, c, d in re.findall(r'firstByte: (\d+)\n\s+indexCount: (\d+)\n\s+topology: \d+\n\s+firstVertex: (\d+)\n\s+vertexCount: (\d+)', t)]
    nidx = sum(s[1] for s in subs); nv = max(s[2] + s[3] for s in subs) if subs else 0
    problems = []
    if len(h.m_IndexBuffer) != nidx: problems.append('indices %d != submesh %d' % (len(h.m_IndexBuffer), nidx))
    if h.m_VertexCount != nv: problems.append('vertices %d != submesh %d' % (h.m_VertexCount, nv))
    c = re.search(r'm_LocalAABB:\n\s+m_Center: \{x: ([^,]+), y: ([^,]+), z: ([^}]+)\}\n\s+m_Extent: \{x: ([^,]+), y: ([^,]+), z: ([^}]+)\}', t)
    if c:
        cx, cy, cz, ex, ey, ez = [float(x) for x in c.groups()]
        tol = 1e-3 + 1e-3 * max(ex, ey, ez)
        bad = sum(1 for v in h.m_Vertices if abs(v[0] - cx) > ex + tol or abs(v[1] - cy) > ey + tol or abs(v[2] - cz) > ez + tol)
        if bad: problems.append('%d vertices outside AABB' % bad)
    if h.m_IndexBuffer and max(h.m_IndexBuffer) >= h.m_VertexCount: problems.append('index out of range')
    return problems


def main():
    print('indexing original compressed meshes...', flush=True)
    idx = build_index()
    print('  original compressed meshes:', len(idx))
    report = []
    for f in sorted(glob.glob(os.path.join(PROJ, 'Assets', '**', '*.asset'), recursive=True)):
        t = open(f, encoding='utf8').read()
        if '--- !u!43 ' not in t: continue
        m = re.search(r'm_MeshCompression: (\d)', t)
        if not m or m.group(1) == '0': continue
        v = re.search(r'm_CompressedMesh:\n\s+m_Vertices:\n\s+m_NumItems: (\d+)\n\s+m_Range: [^\n]*\n\s+m_Start: [^\n]*\n\s+m_Data: ?([0-9a-f]*)', t)
        key = (int(v.group(1)), v.group(2))
        rel = os.path.relpath(f, PROJ)
        if key[0] == 0:
            open(f, 'w', encoding='utf8', newline='\n').write(re.sub(r'm_MeshCompression: \d', 'm_MeshCompression: 0', t))
            report.append(dict(file=rel, status='EMPTY IN ORIGINAL')); continue
        if key not in idx:
            report.append(dict(file=rel, status='NOT FOUND IN ORIGINAL')); print('  NOT FOUND', rel); continue
        src, pid, mesh = idx[key]
        h = MeshHandler(mesh); h.process()
        probs = check(h, t, rel)
        if max(h.m_IndexBuffer or [0]) > 0xffff: probs.append('32-bit indices')
        cols = colors_of(h)
        t2 = re.sub(r'm_MeshCompression: \d', 'm_MeshCompression: 0', t)
        t2 = re.sub(r'  m_IndexBuffer:[^\n]*', '  m_IndexBuffer: ' + struct.pack('<%dH' % len(h.m_IndexBuffer), *h.m_IndexBuffer).hex(), t2)
        t2 = re.sub(r'  m_Skin: \[\]|  m_Skin:\n(?:  [ -][^\n]*\n)*?(?=  m_VertexData:)', lambda _: skin_block(h) + ('\n' if not _.group(0).endswith(']') else ''), t2, count=1)
        a = t2.index('  m_VertexData:'); b = t2.index('  m_CompressedMesh:')
        t2 = t2[:a] + vertex_block(h, cols) + '\n' + t2[b:]
        a = t2.index('  m_CompressedMesh:'); b = t2.index('  m_LocalAABB:')
        t2 = t2[:a] + EMPTY_CM + t2[b:]
        open(f, 'w', encoding='utf8', newline='\n').write(t2)
        report.append(dict(file=rel, status='OK' if not probs else 'CHECK', problems=probs, source='%s pathID %d' % (src, pid),
                           vertices=h.m_VertexCount, indices=len(h.m_IndexBuffer), skinned=bool(getattr(h, 'm_BoneWeights', None)), colors=bool(cols)))
    out = os.path.join(os.path.dirname(__file__), '..', 'output', 'mesh_decompression_report.json')
    json.dump(report, open(out, 'w'), indent=1)
    from collections import Counter
    print(Counter(r['status'] for r in report))
    for r in report:
        if r['status'] != 'OK': print(' ', r)


if __name__ == '__main__':
    main()
