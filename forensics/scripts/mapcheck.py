import struct, pickle, os
from climeta import PE
P=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\DSSRacing"
D=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\Data\Managed"
d=open(P,'rb').read()
segs,sects,syms,base=pickle.load(open('macho.pkl','rb'))
mods=pickle.load(open('aotmods.pkl','rb'))
def v2f(v):
    for sn,va,vs,fo,fs in segs:
        if fs and va<=v<va+fs: return fo+(v-va)
out={}
for asm in ['Assembly-CSharp','Assembly-CSharp-firstpass','Assembly-UnityScript']:
    g=mods[asm]['globals']; pe=PE(os.path.join(D,asm+'.dll'))
    fi=g['mono_aot_file_info']; nm=struct.unpack_from('<I',d,v2f(fi)+12)[0]
    mo=v2f(g['method_offsets']); ma=v2f(g['method_addresses'])
    offs=[struct.unpack_from('<i',d,mo+4*i)[0] for i in range(nm)]
    addrs=[struct.unpack_from('<I',d,ma+4*i)[0] for i in range(nm)]
    nmd=len(pe.methods)
    ok=mism=0; abs_ok=abs_bad=0; notcomp=0
    for i in range(nmd):
        rva,impl,flags,name=pe.methods[i]
        if offs[i]==-1 or offs[i]==0xffffffff: 
            notcomp+=1
            if rva==0: abs_ok+=1
            continue
        if rva==0: abs_bad+=1
        if addrs[i]==g['methods']+offs[i]: ok+=1
        else: mism+=1
    # sizes: sort compiled starts
    starts=sorted(set(a for a,o in zip(addrs,offs) if o!=-1))
    print(f"{asm}: aot nmethods={nm} methoddefs={nmd} compiled_defs={nmd-notcomp} not_compiled={notcomp} (abstract&notcompiled={abs_ok}, abstract_but_compiled={abs_bad}) addr==methods+off:{ok} mismatch:{mism}")
    out[asm]=dict(offs=offs,addrs=addrs,methods_start=g['methods'],methods_end=g['methods_end'])
pickle.dump(out,open('methodmap.pkl','wb'))
