# Minimal Unity 4 (format 9) serialized file reader: object table + raw object bytes (no type trees needed)
import struct, sys
class SFile:
    def __init__(s, path):
        d=s.d=open(path,'rb').read()
        s.msize,s.fsize,s.ver,s.doff=struct.unpack_from('>IIII',d,0)
        s.le = d[16]==0
        e='<' if s.le else '>'
        p=20
        z=d.index(b'\0',p); s.unity=d[p:z].decode(); p=z+1
        s.platform=struct.unpack_from(e+'i',d,p)[0]; p+=4
        nbase=struct.unpack_from(e+'i',d,p)[0]; p+=4
        if nbase!=0: raise Exception('type trees present (%d); not supported'%nbase)
        p+=4  # v9: extra int32 after (empty) type tree list
        n=struct.unpack_from(e+'i',d,p)[0]; p+=4
        s.objs=[]
        for i in range(n):
            pid,start,size,tid=struct.unpack_from(e+'iIIi',d,p); cid,dest=struct.unpack_from(e+'hh',d,p+16); p+=20
            s.objs.append(dict(pathID=pid,start=s.doff+start,size=size,typeID=tid,classID=cid))
    def raw(s,o): return s.d[o['start']:o['start']+o['size']]
if __name__=='__main__':
    sf=SFile(sys.argv[1]); print(sf.unity, 'platform', sf.platform, 'objects', len(sf.objs))
    import collections; print(collections.Counter(o['classID'] for o in sf.objs).most_common(40))
