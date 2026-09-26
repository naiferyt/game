import struct, pickle
P=r"C:\Users\STEEP\Documents\game work\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\DSSRacing"
d=open(P,'rb').read()
segs,sects,syms,base=pickle.load(open('macho.pkl','rb'))
mods=pickle.load(open('aotmods.pkl','rb'))
def v2f(v):
    for sn,va,vs,fo,fs in segs:
        if fs and va<=v<va+fs: return fo+(v-va)
def cstr(v):
    o=v2f(v); e=d.index(b'\0',o); return d[o:e].decode('latin1')
def u32(v): return struct.unpack_from('<I',d,v2f(v))[0]
def i32(v): return struct.unpack_from('<i',d,v2f(v))[0]
g=mods['Assembly-CSharp']['globals']
print('runtime version:', cstr(g['mono_runtime_version']))
print('aot version:', u32(g['mono_aot_version']), 'opt flags', hex(u32(g['mono_aot_opt_flags'])), 'full_aot', u32(g['mono_aot_full_aot']))
print('guid', cstr(g['mono_assembly_guid']))
fi=g['mono_aot_file_info']
print('file_info words:', [u32(fi+4*i) for i in range(16)])
print('got_addr ->', hex(u32(g['mono_aot_got_addr'])))
ma=g['method_addresses']
print('method_addresses first 16:', [hex(u32(ma+4*i)) for i in range(16)])
mo=g['method_offsets']
print('method_offsets first 40:', [i32(mo+4*i) for i in range(40)])
print('methods sym', hex(g['methods']), 'methods_end', hex(g['methods_end']))
