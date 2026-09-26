import struct, pickle, collections
P=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\DSSRacing"
d=open(P,'rb').read()
segs,sects,syms,base=pickle.load(open('macho.pkl','rb'))
mods=pickle.load(open('aotmods.pkl','rb')); mm=pickle.load(open('methodmap.pkl','rb'))
def v2f(v):
    for sn,va,vs,fo,fs in segs:
        if fs and va<=v<va+fs: return fo+(v-va)
g=mods['Assembly-CSharp']['globals']
s,e=g['methods'],g['methods_end']; plt0,plt1=g['plt'],g['plt_end']
starts=set(mm['Assembly-CSharp']['addrs'])
c=collections.Counter()
for a in range(s,e,4):
    w=struct.unpack_from('<I',d,v2f(a))[0]
    if (w>>24)&0xf==0xb and (w>>28)!=0xf:  # BL cond
        off=w&0xffffff
        if off&0x800000: off-=0x1000000
        t=a+8+off*4
        if plt0<=t<plt1: c['->PLT (this module)']+=1
        elif t in starts: c['->direct method start']+=1
        elif s<=t<e: c['->inside module code']+=1
        else: c['->elsewhere (runtime/other module)']+=1
print(c)
print('PLT size bytes',plt1-plt0,'entries if 16B:',(plt1-plt0)/16, 'if 20B', (plt1-plt0)/20)
o=v2f(plt0)
for i in range(0,0x60,4): print(hex(plt0+i), d[o+i:o+i+4][::-1].hex())
