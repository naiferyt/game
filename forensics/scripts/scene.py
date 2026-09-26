import re, os, sys, glob, collections, json
ROOT=r"C:\Users\STEEP\Documents\game work\phase2_extraction\AssetRipperUnityProject\ExportedProject\Assets"
guid2script={}
for m in glob.glob(os.path.join(ROOT,'Scripts','**','*.cs.meta'),recursive=True)+glob.glob(os.path.join(ROOT,'Plugins','**','*.cs.meta'),recursive=True):
    g=re.search(r'guid: (\w+)',open(m,encoding='utf8').read()).group(1)
    guid2script[g]=os.path.basename(m)[:-8]
CLS={1:'GameObject',4:'Transform',114:'MonoBehaviour',20:'Camera',23:'MeshRenderer',33:'MeshFilter',54:'Rigidbody',64:'MeshCollider',65:'BoxCollider',135:'SphereCollider',136:'CapsuleCollider',82:'AudioSource',81:'AudioListener',111:'Animation',95:'Animator',108:'Light',146:'WheelCollider',137:'SkinnedMeshRenderer',96:'TrailRenderer',198:'ParticleSystem',199:'ParticleSystemRenderer',15:'ParticleEmitter?',87:'MeshParticleEmitter',88:'ParticleAnimator',26:'ParticleRenderer',120:'LineRenderer',124:'Behaviour?',92:'GUILayer',124:'Halo',102:'TextMesh',143:'CharacterController',104:'RenderSettings',157:'LightmapSettings',196:'NavMeshSettings',127:'LevelGameManager?',1001:'Prefab',212:'SpriteRenderer',60:'?',21:'Material'}
def parse(path):
    txt=open(path,encoding='utf8',errors='replace').read()
    docs=re.split(r'^--- !u!(\d+) &(-?\d+)(?: stripped)?\s*$',txt,flags=re.M)
    objs={}
    for i in range(1,len(docs),3):
        cid=int(docs[i]); fid=docs[i+1]; body=docs[i+2]
        objs[fid]=(cid,body)
    return objs
def summarize(path, maxdepth=3, show_fields=False):
    objs=parse(path)
    go={}; tr={}; comps=collections.defaultdict(list)
    for fid,(cid,body) in objs.items():
        if cid==1:
            n=re.search(r'm_Name: ?(.*)',body); go[fid]=n.group(1).strip() if n else '?'
            act=re.search(r'm_IsActive: (\d)',body)
        else:
            g=re.search(r'm_GameObject: \{fileID: (-?\d+)\}',body)
            if g:
                name=CLS.get(cid,str(cid))
                if cid==114:
                    s=re.search(r'm_Script: \{fileID: -?\d+, guid: (\w+)',body)
                    name=guid2script.get(s.group(1),'?'+s.group(1)[:8]) if s else 'MB?'
                comps[g.group(1)].append((name,fid,body))
                if cid==4:
                    f=re.search(r'm_Father: \{fileID: (-?\d+)\}',body)
                    tr[g.group(1)]=(fid, f.group(1) if f else '0')
    t2go={v[0]:k for k,v in tr.items()}
    children=collections.defaultdict(list); roots=[]
    for g,(tf,fa) in tr.items():
        if fa=='0': roots.append(g)
        else: children[t2go.get(fa,'?')].append(g)
    out=[]
    def rec(g,dep):
        cs=[c[0] for c in comps[g] if c[0] not in ('Transform',)]
        out.append('  '*dep+f"{go.get(g,'?')}  [{', '.join(cs)}]")
        if dep<maxdepth:
            kids=children.get(g,[])
            # collapse many similarly named kids
            names=collections.Counter(re.sub(r'\d+','#',go.get(k,'?')) for k in kids)
            shown=collections.Counter()
            for k in sorted(kids,key=lambda k:go.get(k,'')):
                key=re.sub(r'\d+','#',go.get(k,'?'))
                if names[key]>4:
                    shown[key]+=1
                    if shown[key]==1: out.append('  '*(dep+1)+f"{key} x{names[key]}  [{', '.join(c[0] for c in comps[k] if c[0]!='Transform')}]")
                    continue
                rec(k,dep+1)
        elif children.get(g): out.append('  '*(dep+1)+f"... {len(children[g])} children")
    for r in sorted(roots,key=lambda k:go.get(k,'')): rec(r,0)
    return out, go, comps
if __name__=='__main__':
    p=sys.argv[1]; dep=int(sys.argv[2]) if len(sys.argv)>2 else 2
    out,go,comps=summarize(p,dep)
    print('\n'.join(out))
