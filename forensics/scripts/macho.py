import struct, os, re, sys
P=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\DSSRacing"
d=open(P,'rb').read()
magic=struct.unpack_from('<I',d,0)[0]
fat=False
if magic in (0xbebafeca,):
    n=struct.unpack_from('>I',d,4)[0]; print('FAT',n)
    for i in range(n):
        ct,cs,off,sz,al=struct.unpack_from('>IIIII',d,8+i*20); print(' arch',hex(ct),cs,off,sz)
    base=struct.unpack_from('>IIIII',d,8)[2]
else: base=0
mg,ct,cst,ft,ncmds,szcmds,flags=struct.unpack_from('<IiiIIII',d,base)
print('magic',hex(mg),'cpu',ct,'sub',cst,'ncmds',ncmds)
p=base+28
segs=[];sects=[];symtab=None
for i in range(ncmds):
    cmd,cs=struct.unpack_from('<II',d,p)
    if cmd==1:
        segname=d[p+8:p+24].rstrip(b'\0').decode(); vmaddr,vmsize,fo,fs,mp,ip,ns,fl=struct.unpack_from('<IIIIiiII',d,p+24)
        segs.append((segname,vmaddr,vmsize,fo,fs))
        q=p+56
        for j in range(ns):
            sn=d[q:q+16].rstrip(b'\0').decode(); sg=d[q+16:q+32].rstrip(b'\0').decode()
            addr,size,off=struct.unpack_from('<III',d,q+32)
            sects.append((sg,sn,addr,size,off)); q+=68
    elif cmd==2: symtab=struct.unpack_from('<IIII',d,p+8)
    p+=cs
for s in segs: print('SEG',s[0],hex(s[1]),hex(s[2]),'fileoff',hex(s[3]))
for s in sects: print('  SECT %-12s %-22s %08x size=%x off=%x'%s)
symoff,nsyms,stroff,strsize=symtab
syms=[]
for i in range(nsyms):
    nx,ty,se,de,val=struct.unpack_from('<IBBhI',d,base+symoff+i*12)
    e=d.index(b'\0',base+stroff+nx); nm=d[base+stroff+nx:e].decode('latin1')
    syms.append((val,ty,se,nm))
print('nsyms',nsyms)
import pickle; pickle.dump((segs,sects,syms,base),open('macho.pkl','wb'))
for v,t,s,n in sorted(syms):
    if re.search(r'aot|mono_|method|Assembly|UnityEngine|got|plt|class_name',n,re.I) and not n.startswith('_mono_') :
        print('%08x %02x %2d %s'%(v,t,s,n))
