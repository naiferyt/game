import sys, re, collections
from scene import summarize, parse, guid2script
p=sys.argv[1]; targets=sys.argv[2].split(',')
out,go,comps=summarize(p,0)
seen=collections.Counter()
for g,cl in comps.items():
    for name,fid,body in cl:
        if name in targets and seen[name]<int(sys.argv[3] if len(sys.argv)>3 else 1):
            seen[name]+=1
            b=body.split('m_EditorClassIdentifier:')[-1]
            print(f"=== {name} on '{go.get(g)}'"); print(b[:1800])
