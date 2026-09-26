import struct, re, pickle
P=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\DSSRacing"
d=open(P,'rb').read()
segs,sects,syms,base=pickle.load(open('macho.pkl','rb'))
def f2v(o):
    for sg,sn,a,sz,off in sects:
        if off and off<=o<off+sz: return a+(o-off)
def v2f(v):
    for sg,sn,a,sz,off in sects:
        if off and a<=v<a+sz: return off+(v-a)
for kw in [b'method_offsets',b'method_addresses',b'mono_aot_version',b'mono_aot_full_aot',b'class_name_table',b'mono_assembly_guid',b'mono_aot_opt_flags',b'mono_aot_file_info',b'mono_aot_assembly_name',b'methods_end',b'plt_end',b'got_info']:
    hits=[m.start() for m in re.finditer(re.escape(kw)+b'\0', d)]
    print(kw.decode(), [(hex(h), hex(f2v(h) or 0)) for h in hits[:8]], len(hits))
