"""Export observed v6 GameObject and Transform layouts to portable JSON."""
from pathlib import Path
import json,struct
root=Path(__file__).resolve().parents[1]
for name in ('mainData','level0'):
    catalog=json.loads((root/'catalog'/(name+'.json')).read_text())
    data=(root/'extracted/Payload/iQuarters.app/Data'/name).read_bytes()
    nodes=[]; transforms=[]
    for obj in catalog['objects']:
        start=obj['offset']; end=start+obj['size']; p=start
        def read(fmt):
            global p
            n=struct.calcsize('<'+fmt)
            if p+n>end: raise ValueError('Object overflow')
            values=struct.unpack_from('<'+fmt,data,p); p+=n
            return values[0] if len(values)==1 else list(values)
        if obj['classId']==1:
            count=read('i'); components=[]
            for _ in range(count):
                kind,fileid,pathid=read('iii'); components.append({'classId':kind,'fileId':fileid,'pathId':pathid})
            layer=read('i'); length=read('i'); title=data[p:p+length].decode('utf8'); p+=length
            p=(p+3)&~3
            tag=read('H'); active=read('B')
            if p!=end: raise ValueError('Unconsumed GameObject bytes')
            nodes.append({'id':obj['id'],'name':title,'layer':layer,'tag':tag,'active':bool(active),'components':components})
        elif obj['classId']==4:
            owner=read('ii'); rotation=read('ffff'); position=read('fff'); scale=read('fff')
            children=[read('ii') for _ in range(read('i'))]; parent=read('ii')
            if p!=end: raise ValueError('Unconsumed Transform bytes')
            transforms.append({'id':obj['id'],'owner':owner,'rotation':rotation,'position':position,'scale':scale,'children':children,'parent':parent})
    result={'source':name,'coordinateSystem':'Original Unity local coordinates; quaternion XYZW','nodes':nodes,'transforms':transforms}
    (root/'catalog'/(name+'.scene.json')).write_text(json.dumps(result,indent=2))
    print(name,len(nodes),'named objects,',len(transforms),'transforms; exact object boundaries verified')
