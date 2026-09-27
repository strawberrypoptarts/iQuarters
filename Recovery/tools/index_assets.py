"""Index version-6 serialized archives without loading Unity or modifying inputs.
Format reference: https://github.com/Perfare/AssetStudio/blob/master/AssetStudio/SerializedFile.cs
"""
from pathlib import Path
import struct, json, collections

class Reader:
    def __init__(self, data, pos, endian): self.data,self.pos,self.endian=data,pos,endian
    def read(self, fmt):
        fmt=self.endian+fmt; n=struct.calcsize(fmt)
        if self.pos+n>len(self.data): raise ValueError('Truncated data')
        value=struct.unpack_from(fmt,self.data,self.pos); self.pos+=n
        return value[0] if len(value)==1 else value
    def string(self):
        end=self.data.index(b'\0',self.pos)
        value=self.data[self.pos:end].decode('utf-8',errors='replace'); self.pos=end+1
        return value
    def tree(self, depth=0):
        if depth>64: raise ValueError('Invalid tree depth')
        node={'type':self.string(),'name':self.string()}
        node.update(zip(('size','index','flags','version','meta'),self.read('iiiii')))
        count=self.read('i')
        if not 0<=count<10000: raise ValueError('Invalid child count')
        node['children']=[self.tree(depth+1) for _ in range(count)]
        return node

def index(path):
    data=path.read_bytes(); meta,size,version,offset=struct.unpack_from('>IIII',data)
    if version!=6 or size!=len(data): raise ValueError('Expected intact version-6 archive')
    start=size-meta; r=Reader(data,start+1,'<' if data[start]==0 else '>')
    count=r.read('i')
    if not 0<=count<10000: raise ValueError('Invalid type count')
    types={}
    for _ in range(count):
        key=r.read('i'); types[key]=r.tree()
    count=r.read('i'); objects=[]
    if not 0<=count<100000: raise ValueError('Invalid object count')
    for _ in range(count):
        ident,pos,length,tid,cid,destroyed=r.read('iIIiHH'); pos+=offset
        if pos<16 or pos+length>start: raise ValueError('Object outside data section')
        obj={'id':ident,'offset':pos,'size':length,'typeId':tid,'classId':cid}
        # Named asset classes start with a length-prefixed UTF-8 name in this build.
        if cid in (21,28,43,48,49,74,83,115,128):
            n=struct.unpack_from(r.endian+'i',data,pos)[0]
            if 0<n<512 and n+4<=length:
                raw=data[pos+4:pos+4+n]
                try:
                    name=raw.decode('utf-8')
                    if all(ord(c)>=32 for c in name): obj['candidateName']=name
                except UnicodeDecodeError: pass
        objects.append(obj)
    externals=[]
    for _ in range(r.read('i')):
        label=r.string(); guid=[r.read('B') for _ in range(16)]; kind=r.read('i'); external=r.string()
        externals.append({'label':label,'path':external,'kind':kind})
    return {'externals':externals,'file':path.name,'formatVersion':version,'types':types,'objects':objects,'classCounts':dict(collections.Counter(o['classId'] for o in objects))}

if __name__=='__main__':
    root=Path(__file__).resolve().parents[1]; out=root/'catalog'; out.mkdir(exist_ok=True)
    folder=root/'extracted/Payload/iQuarters.app/Data'
    for name in ('mainData','level0','sharedassets0.assets','sharedassets1.assets','unity default resources'):
        result=index(folder/name)
        (out/(name+'.json')).write_text(json.dumps(result,indent=2))
        print(name,len(result['objects']),result['classCounts'])
