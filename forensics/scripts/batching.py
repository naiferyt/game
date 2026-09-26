import re, os, glob, collections, sys
A=r"C:\Users\STEEP\Documents\game work\phase2_extraction\AssetRipperUnityProject\ExportedProject\Assets"
g2n={}
for m in glob.glob(os.path.join(A,'**','*.asset.meta'),recursive=True):
    g=re.search(r'guid: (\w+)',open(m,encoding='utf8').read())
    if g: g2n[g.group(1)]=os.path.relpath(m[:-5],A)
from scene import parse
for f in sorted(glob.glob(os.path.join(A,'Scenes','**','*.unity'),recursive=True)):
    objs=parse(f)
    mf=collections.Counter(); mc=collections.Counter(); subsets=0; mcnull=0
    for fid,(cid,body) in objs.items():
        if cid==33:
            g=re.search(r'm_Mesh: \{fileID: -?\d+(?:, guid: (\w+))?',body)
            name=g2n.get(g.group(1),'builtin/none') if g and g.group(1) else 'NONE'
            mf['combined' if 'Combined Mesh' in name else 'normal']+=1
        elif cid==64:
            g=re.search(r'm_Mesh: \{fileID: (-?\d+)(?:, guid: (\w+))?',body)
            if not g or g.group(1)=='0': mcnull+=1; continue
            name=g2n.get(g.group(2),'?') if g.group(2) else 'local'
            mc['combined' if 'Combined Mesh' in name else 'normal']+=1
        elif cid==23:
            s=re.search(r'm_SubsetIndices: (\w*)',body)
            if s and s.group(1): subsets+=1
    print(f"{os.path.basename(f)[:-6]:24s} MeshFilter: combined={mf['combined']:4d} normal={mf['normal']:4d} | renderers w/ subsets={subsets:4d} | MeshCollider: combined={mc['combined']} normal={mc['normal']} null={mcnull}")
