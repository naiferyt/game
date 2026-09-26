import re, os, glob, sys
from scene import summarize
A=r"C:\Users\STEEP\Documents\game work\phase2_extraction\AssetRipperUnityProject\ExportedProject\Assets"
g2p={}
for m in glob.glob(os.path.join(A,'Mesh','*.asset.meta')):
    g=re.search(r'guid: (\w+)',open(m,encoding='utf8').read()).group(1); g2p[g]=m[:-5]
f=os.path.join(A,'Scenes','Tracks','Phineas Track 1.unity')
out,go,comps=summarize(f,0)
seen=0
for g,cl in comps.items():
    for name,fid,body in cl:
        if name=='MeshCollider':
            mg=re.search(r'm_Mesh: \{fileID: -?\d+, guid: (\w+)',body)
            if not mg: continue
            p=g2p.get(mg.group(1))
            if not p: print(go.get(g),'-> mesh guid not in Mesh/'); continue
            t=open(p,encoding='utf8').read()
            vc=re.search(r'm_VertexCount: (\d+)',t); ib=re.search(r'm_IndexBuffer: (\w*)',t); rd=re.search(r'm_IsReadable: (\d)',t)
            sm=len(re.findall(r'- serializedVersion: 2\n\s+firstByte',t)) or t.count('firstByte')
            conv=re.search(r'm_Convex: (\d)',body)
            if seen<12 or 'Track' in (go.get(g) or ''):
                print(f"{go.get(g)[:30]:30s} mesh={os.path.basename(p)[:35]:35s} verts={vc.group(1) if vc else '?'} idxbytes={len(ib.group(1))//2 if ib else '?'} submeshes={sm} readable={rd.group(1) if rd else '?'} convex={conv.group(1) if conv else '?'}")
            seen+=1
print('total mesh colliders with mesh', seen)
