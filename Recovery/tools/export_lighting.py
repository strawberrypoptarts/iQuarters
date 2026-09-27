"""Read this IPA's version-6 RenderSettings, Light and shader references.
Keeps the existing scene/animation export intact; emits a separate lighting file.
"""
from pathlib import Path
import json,struct,re
root=Path(__file__).resolve().parents[1];folder=root/'extracted/Payload/iQuarters.app/Data'
scene=json.loads((root/'converted/scene.json').read_text());cat=json.loads((root/'catalog/level0.json').read_text());data=(folder/'level0').read_bytes();lights=[]
for obj in cat['objects']:
 p=obj['offset']
 if obj['classId']==104:
  assert obj['size']==72
  ambient=list(struct.unpack_from('<ffff',data,p+24))
 if obj['classId']==108:
  assert obj['size']==100
  lights.append(dict(owner=struct.unpack_from('<i',data,p+4)[0],enabled=bool(data[p+8]),type=struct.unpack_from('<i',data,p+12)[0],color=list(struct.unpack_from('<ffff',data,p+16)),intensity=struct.unpack_from('<f',data,p+36)[0],range=struct.unpack_from('<f',data,p+40)[0],spotAngle=struct.unpack_from('<f',data,p+44)[0],mask=struct.unpack_from('<I',data,p+96)[0]))
shaders={};materials={}
for ar in ['sharedassets0.assets','sharedassets1.assets','unity default resources']:
 c=json.loads((root/'catalog'/(ar+'.json')).read_text());d=(folder/ar).read_bytes()
 for o in c['objects']:
  p=o['offset'];n=struct.unpack_from('<i',d,p)[0] if o['classId'] in [21,48] else 0
  if o['classId']==48:
   name=d[p+4:p+4+n].decode();pos=(p+4+n+3)&~3;length=struct.unpack_from('<i',d,pos)[0];text=d[pos+4:pos+4+length].decode(errors='replace');shaders[ar+'-'+str(o['id'])]={'name':name,'source':text}
  if o['classId']==21:
   pos=(p+4+n+3)&~3;file,ident=struct.unpack_from('<ii',d,pos);source=ar if file==0 else c['externals'][file-1]['path'].split('/')[-1];materials[ar+'-'+str(o['id'])]=source+'-'+str(ident)
result={'ambient':ambient,'lights':lights,'materials':{key:{'name':shaders.get(ref,{}).get('name',ref),'doubleLighting':'primary double' in shaders.get(ref,{}).get('source','').lower(),'vertexLit':'vertexlit' in shaders.get(ref,{}).get('name','').lower()} for key,ref in materials.items()}}
source=(root.parent/'Assets/Scripts/QuarterTrigger.cs').read_text().split('public void SetGlasses()')[1]
result['roundShadows']=[]
for i in range(13):
 case=re.search(r'case '+str(i)+r':(.*?)(?:break;)',source,re.S).group(1)
 result['roundShadows'].append([{'glass':scene['quarterFields'][name][1],'shadow':scene['quarterFields']['glassShadow'+('' if index=='1' else index)][1],'scale':.15+float(scale)} for name,index,scale in re.findall(r'SetGlassShadow\((\w+), (\d+), ([.\d]+)f\)',case)])
(root/'converted/lighting.json').write_text(json.dumps(result,indent=2))
print('Exported',len(lights),'lights, ambient',ambient)
from collections import Counter
print(Counter(result['materials'][key]['name'] for n in scene['nodes'] if n['layer'] in [8,9,10,11] for key in n.get('materials',[])))
