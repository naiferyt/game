# Minimal ECMA-335 metadata reader: TypeDef/MethodDef/Field names + method body inspection
import struct, sys, collections, os
class PE:
    def __init__(s, path):
        s.d = open(path,'rb').read(); d=s.d
        pe = struct.unpack_from('<I', d, 0x3c)[0]
        nsec = struct.unpack_from('<H', d, pe+6)[0]; opt = struct.unpack_from('<H', d, pe+20)[0]
        optoff = pe+24; magic = struct.unpack_from('<H', d, optoff)[0]
        ddoff = optoff + (96 if magic==0x10b else 112)
        s.secs=[]
        so = optoff+opt
        for i in range(nsec):
            name,vs,va,rs,ra = struct.unpack_from('<8sIIII', d, so+i*40)
            s.secs.append((va,vs,ra,rs))
        cli_rva = struct.unpack_from('<I', d, ddoff+14*8)[0]
        c = s.off(cli_rva)
        mrva, msz = struct.unpack_from('<II', d, c+8)
        m = s.off(mrva); s.m=m
        vlen = struct.unpack_from('<I', d, m+12)[0]
        p = m+16+vlen; nstreams = struct.unpack_from('<H', d, p+2)[0]; p+=4
        s.streams={}
        for i in range(nstreams):
            o,sz = struct.unpack_from('<II', d, p); p+=8
            e = d.index(b'\0', p); name=d[p:e].decode(); p = (e+4)&~3
            s.streams[name]=(m+o,sz)
        s.parse_tables()
    def off(s, rva):
        for va,vs,ra,rs in s.secs:
            if va<=rva<va+max(vs,rs): return rva-va+ra
        raise Exception('rva')
    def string(s, i):
        o = s.streams['#Strings'][0]+i; e=s.d.index(b'\0',o); return s.d[o:e].decode('utf8','replace')
    def parse_tables(s):
        d=s.d; o=s.streams['#~'][0]
        hs = d[o+6]; valid = struct.unpack_from('<Q', d, o+8)[0]
        p=o+24; rows={}
        for t in range(64):
            if valid>>t&1: rows[t]=struct.unpack_from('<I',d,p)[0]; p+=4
        s.rows=rows
        si = 4 if hs&1 else 2; gi = 4 if hs&2 else 2; bi = 4 if hs&4 else 2
        R=lambda t: rows.get(t,0)
        idx=lambda t: 4 if R(t)>0xffff else 2
        def cidx(tabs, bits): return 4 if max(R(t) for t in tabs) >= (1<<(16-bits)) else 2
        TypeDefOrRef=cidx([2,1,0x1b],2); ResScope=cidx([0,0x1a,0x23,1],2)
        MemberRefParent=cidx([2,1,0x1a,6,0x1b],3)
        HasConstant=cidx([4,8,0x17],2); HasCustomAttr=cidx(list(range(0x2b)),5)
        sizes={0:2+si+gi*3, 1:ResScope+si*2, 2:4+si*2+TypeDefOrRef+idx(4)+idx(6), 3:idx(4), 4:2+si+bi, 5:idx(6), 6:4+2+2+si+bi+idx(8)}
        s.tab={}; q=p
        for t in range(7):
            s.tab[t]=(q,sizes[t]); q+=sizes[t]*R(t)
        s.si,s.bi=si,bi; s.idx=idx; s.TDR=TypeDefOrRef
        # read typedefs
        s.types=[]
        base,sz=s.tab[2]
        for i in range(R(2)):
            r=base+i*sz; flags=struct.unpack_from('<I',d,r)[0]; r+=4
            nm=s.rd(r,si); r+=si; ns=s.rd(r,si); r+=si; r+=TypeDefOrRef
            fl=s.rd(r,idx(4)); r+=idx(4); ml=s.rd(r,idx(6))
            s.types.append([s.string(ns),s.string(nm),fl,ml])
        s.methods=[]
        base,sz=s.tab[6]
        for i in range(R(6)):
            r=base+i*sz; rva,impl,flags=struct.unpack_from('<IHH',d,r); r+=8
            nm=s.rd(r,si)
            s.methods.append((rva,impl,flags,s.string(nm)))
        # owner
        s.owner=[None]*R(6)
        for ti,t in enumerate(s.types):
            end = s.types[ti+1][3] if ti+1<len(s.types) else R(6)+1
            for mi in range(t[3]-1, end-1): s.owner[mi]=ti
    def rd(s,o,n): return struct.unpack_from('<I' if n==4 else '<H', s.d, o)[0]
    def body(s, rva):
        o=s.off(rva); b=s.d[o]
        if b&3==2: return s.d[o+1:o+1+(b>>2)]
        cs=struct.unpack_from('<I',s.d,o+4)[0]; hsz=(struct.unpack_from('<H',s.d,o)[0]>>12)*4
        return s.d[o+hsz:o+hsz+cs]
if __name__=='__main__':
    D=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\Data\Managed"
    for a in ['Assembly-CSharp.dll','Assembly-CSharp-firstpass.dll','Assembly-UnityScript.dll','UnityEngine.dll']:
        pe=PE(os.path.join(D,a))
        cnt=collections.Counter()
        for rva,impl,flags,nm in pe.methods:
            if rva==0: cnt['no_body(abstract/extern/runtime)']+=1; continue
            b=pe.body(rva)
            if b in (b'\x2a',): cnt['only_ret']+=1
            elif len(b)<=2: cnt['tiny:'+b.hex()]+=1
            else: cnt['REAL_IL(len>2)']+=1
        print(a, 'types',len(pe.types),'methods',len(pe.methods), dict(cnt))
