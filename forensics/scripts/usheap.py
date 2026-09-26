import os
from climeta import PE
MD=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\Data\Managed"
for a in ['Assembly-CSharp','Assembly-CSharp-firstpass']:
    p=PE(os.path.join(MD,a+'.dll'))
    o,sz=p.streams['#US']; d=p.d
    strs=[]; i=o+1
    while i<o+sz:
        b=d[i]
        if b&0x80==0: L=b; i+=1
        elif b&0x40==0: L=((b&0x3f)<<8)|d[i+1]; i+=2
        else: L=((b&0x1f)<<24)|(d[i+1]<<16)|(d[i+2]<<8)|d[i+3]; i+=4
        if L==0: continue
        s=d[i:i+L-1].decode('utf-16le','replace'); i+=L
        strs.append(s)
    print(a,'#US bytes',sz,'strings',len(strs))
    open(a+'_userstrings.txt','w',encoding='utf8').write('\n'.join(strs))
