import struct, os, glob, sys
D = r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\Data"
files = ["mainData"] + [f"level{i}" for i in range(16)] + ["resources.assets"] + [f"sharedassets{i}.assets" for i in range(17)] + ["unity default resources", r"Resources\unity_builtin_extra"]
for f in files:
    p = os.path.join(D, f)
    b = open(p,'rb').read(64)
    msize, fsize, ver, doff = struct.unpack('>IIII', b[:16])
    end = b[16]
    s = b[20:].split(b'\0')[0].decode('latin1')
    print(f"{f:28s} fmt={ver} unity={s} filesize_hdr={fsize} actual={os.path.getsize(p)} {'OK' if fsize==os.path.getsize(p) else 'SIZE MISMATCH'}")
