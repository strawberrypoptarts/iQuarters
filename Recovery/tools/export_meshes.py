"""Export legacy uncompressed static mesh geometry as JSON and OBJ.
Format reference: Perfare/AssetStudio Classes/Mesh.cs (legacy 2.5 layouts).
Does not claim animation, skinning or material conversion.
"""
from pathlib import Path
import json,struct,math
root=Path(__file__).resolve().parents[1]; out=root/'converted/meshes';out.mkdir(parents=True,exist_ok=True)
count=0
for archive in ('sharedassets0.assets','sharedassets1.assets','unity default resources'):
    catalog=json.loads((root/'catalog'/(archive+'.json')).read_text());data=(root/'extracted/Payload/iQuarters.app/Data'/archive).read_bytes()
    for obj in catalog['objects']:
        if obj['classId']!=43: continue
        p=obj['offset']; end=p+obj['size']
        def read(fmt):
            global p
            n=struct.calcsize('<'+fmt)
            if p+n>end: raise ValueError('Mesh overflow')
            v=struct.unpack_from('<'+fmt,data,p);p+=n
            return v[0] if len(v)==1 else list(v)
        def array(dim):
            n=read('i')
            if not 0<=n<1000000: raise ValueError('Invalid array length')
            return [read('f'*dim) for _ in range(n)]
        n=read('i');name=data[p:p+n].decode();p=(p+n+3)&~3
        short=read('i')>0;size=read('i');indices=[read('H' if short else 'I') for _ in range(size//(2 if short else 4))];p=(p+3)&~3
        sub=[read('IIiI') for _ in range(read('i'))]
        vertices=array(3)
        skin=read('i');p+=skin*32
        binds=read('i');p+=binds*64
        uv=array(2);uv2=array(2)
        tangent=array(7); normals=[v[:3] for v in tangent]
        # Legacy Mesh stores AABB then Color32[] after tangent-space data.
        trailer=p
        p+=24
        color_count=read('i'); colors=[read('BBBB') for _ in range(color_count)]
        assert color_count in (0,len(vertices))
        p=trailer
        groups=[]
        for first,n,topology,declared in sub:
            idx=indices[first//(2 if short else 4):first//(2 if short else 4)+n]; triangles=[]
            if topology==0: triangles=[idx[i:i+3] for i in range(0,n,3)]
            else:
                for i in range(n-2):
                    a,b,c=idx[i:i+3]
                    if len({a,b,c})==3: triangles.append([b,a,c] if i%2 else [a,b,c])
            if any(len(t)!=3 or min(t)<0 or max(t)>=len(vertices) for t in triangles): raise ValueError('Invalid vertex index')
            groups.append(triangles)
        if not all(math.isfinite(v) for row in vertices for v in row): raise ValueError('Invalid coordinates')
        stem=archive+'-'+str(obj['id'])
        result={'name':name,'source':archive,'pathId':obj['id'],'vertices':vertices,'normals':normals,'uv':uv,'colors':colors,'submeshes':groups,'unparsedTailBytes':end-p}
        (out/(stem+'.json')).write_text(json.dumps(result,separators=(',',':')))
        lines=['# '+name]+['v '+' '.join(map(str,v)) for v in vertices]
        for i,g in enumerate(groups):
            lines.append('g submesh_'+str(i));lines.extend('f '+' '.join(str(x+1) for x in t) for t in g)
        (out/(stem+'.obj')).write_text('\n'.join(lines)+'\n');count+=1
print('Exported',count,'meshes; finite positions and all triangle indices validated')
