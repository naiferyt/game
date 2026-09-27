# lightprobes_export: Unity 4 baked light probes (LightProbes.asset exported from the original build) ->
# compact binary per scene for the runtime sampler (Assets/_Recovery/Runtime/LegacyLightProbes.cs).
# Stage 4.0. Data is RECUPERADO (positions, SH coefficients and tetrahedralization baked by the original team).
#
# Binary layout (little endian):
#   "LP4\0", int probeCount, int tetCount
#   probeCount x (float x, y, z)
#   probeCount x 27 floats  (Unity 4 order: coefficient k, channel c -> sh[3k + c])
#   tetCount x (int idx[4], int neighbors[4], float matrix[12] row-major 3x4)
# Inner tetrahedra (idx[3] >= 0): barycentric (b0,b1,b2) = M * (p - pos[idx[3]]), b3 = 1 - b0 - b1 - b2.
# Outer cells (idx[3] == -1) are hull faces; the sampler projects onto the face triangle.
import os, re, struct, sys

ROOT = os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", "..", "recovery", "DSSRacer_U6", "Assets")
OUT = os.path.join(ROOT, "_Recovery", "Resources", "LegacyLightProbes")

# scene name -> probe asset (AssetRipper put the Kick Butt Track 1 probes at Assets/LightProbes: its probes sit
# on that track, 9.5 units from the starting grid). Tutorial Track had none.
SOURCES = {
    "Kick Butt Track 1": "LightProbes/LightProbes.asset",
    "Tutorial Track": "LightProbes/LightProbes.asset",  # same arena as Kick Butt 1 (shared asset in the original build)
    "Kick Butt Track 2": "Scenes/Tracks/Kick Butt Track 2/LightProbes.asset",
    "Kick Butt Track 3": "Scenes/Tracks/Kick Butt Track 3/LightProbes.asset",
    "Phineas Track 1": "Scenes/Tracks/Phineas Track 1/LightProbes.asset",
    "Phineas Track 2": "Scenes/Tracks/Phineas Track 2/LightProbes.asset",
    "Phineas Track 3": "Scenes/Tracks/Phineas Track 3/LightProbes.asset",
    "Fish Hooks Track 1": "Scenes/Tracks/Fish Hooks Track 1/LightProbes.asset",
    "Fish Hooks Track 2": "Scenes/Tracks/Fish Hooks Track 2/LightProbes.asset",
    "Fish Hooks Track 3": "Scenes/Tracks/Fish Hooks Track 3/LightProbes.asset",
    "FrontEndTest": "Scenes/Front End/FrontEndTest/LightProbes.asset",
    "Pranksgiving Test": "Scenes/Test Scenes/Pranksgiving Test/LightProbes.asset",
}

VEC = re.compile(r"\{x: ([^,]+), y: ([^,]+), z: ([^}]+)\}")
KV = re.compile(r"^\s*-?\s*([A-Za-z_][A-Za-z_0-9]*(?:\[\d+\])?): (\S+)")


def parse(path):
    lines = open(path, encoding="utf-8").read().splitlines()
    section = None
    pos, coeffs, tets = [], [], []
    cur = None
    for line in lines:
        s = line.strip()
        if line.startswith("  ") and not line.startswith("   ") and s.endswith(":") and not s.startswith("-"):
            section = s[:-1]
            continue
        if section == "bakedPositions":
            m = VEC.search(s)
            if m:
                pos.append(tuple(float(v) for v in m.groups()))
        elif section == "bakedCoefficients":
            m = KV.match(line)
            if m and m.group(1).startswith("sh["):
                if s.startswith("- "):
                    coeffs.append([])
                coeffs[-1].append(float(m.group(2)))
        elif section == "tetrahedra":
            m = KV.match(line)
            if not m:
                continue
            k, v = m.group(1), m.group(2)
            if s.startswith("- "):
                cur = {"idx": [], "nb": [], "m": []}
                tets.append(cur)
            if k.startswith("indices["):
                cur["idx"].append(int(v))
            elif k.startswith("neighbors["):
                cur["nb"].append(int(v))
            elif re.fullmatch(r"e[0-2][0-3]", k):
                cur["m"].append(float(v))
    for c in coeffs:
        assert len(c) == 27, len(c)
    for t in tets:
        assert len(t["idx"]) == 4 and len(t["nb"]) == 4 and len(t["m"]) == 12, t
    assert len(pos) == len(coeffs), (len(pos), len(coeffs))
    return pos, coeffs, tets


def main():
    os.makedirs(OUT, exist_ok=True)
    for scene, rel in SOURCES.items():
        pos, coeffs, tets = parse(os.path.join(ROOT, rel))
        data = bytearray(b"LP4\0")
        data += struct.pack("<ii", len(pos), len(tets))
        for p in pos:
            data += struct.pack("<3f", *p)
        for c in coeffs:
            data += struct.pack("<27f", *c)
        for t in tets:
            data += struct.pack("<4i", *t["idx"]) + struct.pack("<4i", *t["nb"]) + struct.pack("<12f", *t["m"])
        out = os.path.join(OUT, scene + ".bytes")
        open(out, "wb").write(bytes(data))
        print("%-20s probes %4d  tetrahedra %5d  (%d outer)" % (scene, len(pos), len(tets), sum(1 for t in tets if t["idx"][3] < 0)))


if __name__ == "__main__":
    main()
