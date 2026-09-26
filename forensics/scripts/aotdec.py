import struct, pickle, collections, os
from climeta import PE
P=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\DSSRacing"
MD=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\Data\Managed"
d=open(P,'rb').read()
segs,sects,syms,base=pickle.load(open('macho.pkl','rb'))
mods=pickle.load(open('aotmods.pkl','rb'))
def v2f(v):
    for sn,va,vs,fo,fs in segs:
        if fs and va<=v<va+fs: return fo+(v-va)
def u32(v): return struct.unpack_from('<I',d,v2f(v))[0]
def cstr_f(o):
    e=d.index(b'\0',o); return d[o:e].decode('latin1'), e+1
def dv(o):
    b=d[o]
    if b&0x80==0: return b,o+1
    if b&0x40==0: return ((b&0x3f)<<8)|d[o+1],o+2
    if b!=0xff: return ((b&0x1f)<<24)|(d[o+1]<<16)|(d[o+2]<<8)|d[o+3],o+4
    return (d[o+1]<<24)|(d[o+2]<<16)|(d[o+3]<<8)|d[o+4],o+5
PEs={}
def pe(name):
    if name not in PEs:
        p=os.path.join(MD,name+'.dll'); PEs[name]=PE(p) if os.path.exists(p) else None
    return PEs[name]
def image_table(asm):
    g=mods[asm]['globals']; o=v2f(g['mono_image_table'])
    n=struct.unpack_from('<I',d,o)[0]; o+=4; names=[]
    for i in range(n):
        nm,o=cstr_f(o); guid,o=cstr_f(o); cul,o=cstr_f(o); pkt,o=cstr_f(o)
        o=(o+7)&~7; o+=4*5
        names.append(nm)
    return names
def mname(img,tok):
    p=pe(img)
    if p is None: return f'{img}:0x{tok:x}'
    idx=(tok&0xffffff)-1
    if (tok>>24)==6 and idx<len(p.methods):
        t=p.types[p.owner[idx]]
        return f"{img}::{t[0]+'.' if t[0] else ''}{t[1]}::{p.methods[idx][3]}"
    return f'{img}:tok0x{tok:x}'
if __name__=='__main__':
    asm='Assembly-CSharp'
    imgs=image_table(asm); print('image table:',imgs)
    g=mods[asm]['globals']; gi=v2f(g['got_info'])
    plt0,plt1=g['plt'],g['plt_end']
    types=collections.Counter()
    for k,i in enumerate(range(plt0,plt1,16)):
        info=u32(i+12)
        o=gi+info
        t,o2=dv(o)
        types[t]+=1
        if k<40 and k>0:
            v,o3=dv(o2)
            img=v>>24
            desc=''
            if img<len(imgs): desc=mname(imgs[img], 0x06000000|(v&0xffffff))
            print(k,'type',t,'val',hex(v),desc)
    print(types)
