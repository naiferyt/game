import struct, collections, os
from aotdec import *
asm='Assembly-CSharp'; imgs=image_table(asm); g=mods[asm]['globals']
gi=v2f(g['got_info']); go=v2f(g['got_info_offsets'])
n=(g['ex_info']-g['got_info_offsets'])//4
n=min(n,2608)
us=open(asm+'_userstrings.txt',encoding='utf8').read().split('\n')
pcs=PE(os.path.join(MD,asm+'.dll'))
# map #US offset -> string
usmap={}; o,sz=pcs.streams['#US']; dd=pcs.d; i=o+1
while i<o+sz:
    st=i-o; b=dd[i]
    if b&0x80==0: L=b; i+=1
    elif b&0x40==0: L=((b&0x3f)<<8)|dd[i+1]; i+=2
    else: L=((b&0x1f)<<24)|(dd[i+1]<<16)|(dd[i+2]<<8)|dd[i+3]; i+=4
    usmap[st]=dd[i:i+L-1].decode('utf-16le','replace') if L else ''; i+=L
c=collections.Counter(); ex=collections.defaultdict(list)
for k in range(n):
    off=struct.unpack_from('<I',d,go+4*k)[0]
    t,p=dv(gi+off); c[t]+=1
    if len(ex[t])<4:
        a,p2=dv(p); b,p3=dv(p2)
        desc=''
        if t==17: desc=repr(usmap.get(b & 0xffffff, usmap.get(a&0xffffff,'?')))
        ex[t].append((hex(a),hex(b),desc))
print('GOT entries',n, dict(sorted(c.items())))
for t,v in sorted(ex.items()): print(t,v)
