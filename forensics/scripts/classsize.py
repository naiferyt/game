import pickle, os, collections, csv
from climeta import PE
MD=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\Data\Managed"
mm=pickle.load(open('methodmap.pkl','rb'))
rows=[]
for asm in ['Assembly-CSharp','Assembly-CSharp-firstpass','Assembly-UnityScript']:
    pe=PE(os.path.join(MD,asm+'.dll')); m=mm[asm]
    starts=sorted(set(a for a,o in zip(m['addrs'],m['offs']) if o!=-1))+[m['methods_end']]
    nxt={starts[i]:starts[i+1] for i in range(len(starts)-1)}
    for i,(rva,impl,flags,name) in enumerate(pe.methods):
        o=m['offs'][i]
        if o==-1: continue
        a=m['addrs'][i]; sz=nxt[a]-a
        t=pe.types[pe.owner[i]]
        rows.append((asm,t[0],t[1],name,0x06000001+i,hex(a),sz))
with open('native_method_map.csv','w',newline='',encoding='utf8') as f:
    w=csv.writer(f); w.writerow(['assembly','namespace','type','method','token','arm_addr','arm_bytes']); w.writerows(rows)
agg=collections.defaultdict(lambda:[0,0])
for r in rows:
    if r[0]!='Assembly-CSharp': continue
    k=r[2].split('/')[0]
    agg[k][0]+=r[6]; agg[k][1]+=1
tot=sum(v[0] for v in agg.values())
print('Assembly-CSharp total native bytes',tot,'methods',sum(v[1] for v in agg.values()))
for k,v in sorted(agg.items(),key=lambda x:-x[1][0])[:70]: print(f'{v[0]:8d} B {v[1]:4d} m  {k}')
