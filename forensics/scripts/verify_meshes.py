# Verifies every Mesh .asset of a Unity project: no compressed meshes left, vertex/index buffers consistent
# with the submesh table, vertices inside the serialized AABB. Prints a summary; exit code 1 on problems.
# Usage: python verify_meshes.py [project_root]      (default: recovery/DSSRacer_U6)
import glob, re, os, sys, struct
HERE = os.path.dirname(os.path.abspath(__file__))
PROJ = sys.argv[1] if len(sys.argv) > 1 else os.path.join(HERE, '..', '..', 'recovery', 'DSSRacer_U6')
EMPTY_OK = {'Down_Ramp.asset', 'Half_Circle.asset', 'Hiway_Curve.asset'}   # empty in the original build too
AABB_RE = re.compile(r'm_LocalAABB:\n\s+m_Center: \{x: ([^,]+), y: ([^,]+), z: ([^}]+)\}\n\s+m_Extent: \{x: ([^,]+), y: ([^,]+), z: ([^}]+)\}')
SUB_RE = re.compile(r'firstByte: (\d+)\n\s+indexCount: (\d+)\n\s+topology: \d+\n\s+firstVertex: (\d+)\n\s+vertexCount: (\d+)')
bad = []; n = 0; aabb_checked = 0
for f in sorted(glob.glob(os.path.join(PROJ, 'Assets', '**', '*.asset'), recursive=True)):
    t = open(f, encoding='utf8').read()
    if '--- !u!43 ' not in t: continue
    n += 1; name = os.path.relpath(f, PROJ)
    if re.search(r'm_MeshCompression: [12]', t): bad.append((name, 'still compressed')); continue
    vc = int(re.search(r'    m_VertexCount: (\d+)', t).group(1))
    ib = re.search(r'  m_IndexBuffer: ?([0-9a-f]*)', t).group(1)
    subs = [tuple(int(x) for x in s) for s in SUB_RE.findall(t)]
    nidx = sum(s[1] for s in subs); nv = max((s[2] + s[3] for s in subs), default=0)
    if vc == 0:
        if os.path.basename(f) not in EMPTY_OK and nidx: bad.append((name, 'empty vertex data'))
        continue
    stride = int(re.search(r'stride: (\d+)', t).group(1))
    data = re.search(r'_typelessdata: ([0-9a-f]*)', t).group(1)
    if len(data) // 2 != stride * vc: bad.append((name, 'data size %d != %d*%d' % (len(data) // 2, stride, vc)))
    if len(ib) // 4 != nidx: bad.append((name, 'indices %d != %d' % (len(ib) // 4, nidx)))
    if vc < nv: bad.append((name, 'vertexcount %d < submesh %d' % (vc, nv)))
    c = AABB_RE.search(t)
    if c and data:
        cx, cy, cz, ex, ey, ez = [float(x) for x in c.groups()]
        tol = 1e-3 + 2e-3 * max(ex, ey, ez); raw = bytes.fromhex(data); out = 0
        for k in range(vc):
            x, y, z = struct.unpack_from('<3f', raw, k * stride)
            if abs(x - cx) > ex + tol or abs(y - cy) > ey + tol or abs(z - cz) > ez + tol: out += 1
        if out: bad.append((name, '%d/%d vertices outside AABB' % (out, vc)))
        aabb_checked += 1
    if ib:
        mx = max(struct.unpack('<%dH' % (len(ib) // 4), bytes.fromhex(ib)))
        if mx >= vc: bad.append((name, 'index %d >= %d' % (mx, vc)))
print('meshes checked:', n, ' AABB-checked:', aabb_checked, ' problems:', len(bad))
for b in bad[:int(os.environ.get('VM_N', '40'))]: print('  ', b)
sys.exit(1 if bad else 0)
