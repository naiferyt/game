import struct, re, pickle
P=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\DSSRacing"
d=open(P,'rb').read()
segs,sects,syms,base=pickle.load(open('macho.pkl','rb'))
def f2v(o):
    for sg,sn,a,sz,off in sects:
        if off and off<=o<off+sz: return a+(o-off)
    # fall back to segment mapping
    for sn,va,vs,fo,fs in segs:
        if fs and fo<=o<fo+fs: return va+(o-fo)
def v2f(v):
    for sn,va,vs,fo,fs in segs:
        if fs and va<=v<va+fs: return fo+(v-va)
def cstr(v):
    o=v2f(v); e=d.index(b'\0',o); return d[o:e].decode('latin1')
modules={}
for m in re.finditer(b'mono_aot_assembly_name\0', d):
    sv=f2v(m.start())
    for p in re.finditer(re.escape(struct.pack('<I',sv)), d):
        o=p.start()
        # walk back to table start: entries are (nameptr,valptr) pairs; go back while nameptr points to a string
        s=o
        while True:
            np_=struct.unpack_from('<I',d,s-8)[0]
            f=v2f(np_) if np_ else None
            if f is None or not (0x20<=d[f]<0x7f): break
            s-=8
        tab={}
        q=s
        while True:
            np_,vp=struct.unpack_from('<II',d,q)
            if np_==0: break
            try: tab[cstr(np_)]=vp
            except Exception: break
            q+=8
        name=cstr(tab['mono_aot_assembly_name'])
        modules[name]=dict(table_file_off=s, globals=tab)
        print('MODULE',name,'globals_at_vm',hex(f2v(s)),'n',len(tab))
pickle.dump(modules,open('aotmods.pkl','wb'))
for k,v in modules.items():
    if 'CSharp' in k:
        for n,a in v['globals'].items(): print('   %-28s %08x'%(n,a))
