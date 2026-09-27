from pathlib import Path
import json,struct,re
root=Path(__file__).resolve().parents[1];folder=root/'extracted/Payload/iQuarters.app/Data'
materials={}
for archive in ('sharedassets0.assets','sharedassets1.assets'):
 data=(folder/archive).read_bytes();cat=json.loads((root/'catalog'/(archive+'.json')).read_text())
 for obj in cat['objects']:
  if obj['classId']!=21:continue
  p=obj['offset'];end=p+obj['size']
  def read(fmt):
   global p
   n=struct.calcsize('<'+fmt);v=struct.unpack_from('<'+fmt,data,p);p+=n
   if p>end:raise ValueError('Overflow')
   return v[0] if len(v)==1 else list(v)
  def string():
   global p
   n=read('i');v=data[p:p+n].decode();p=(p+n+3)&~3;return v
  name=string();shader=read('ii');textures={};floats={};colors={}
  for _ in range(read('i')):
   key=string();ref=read('ii');scale=read('ff');offset=read('ff')
   source=archive if ref[0]==0 else cat['externals'][ref[0]-1]['path'].split('/')[-1]
   textures[key]={'asset':source+'-'+str(ref[1]),'scale':scale,'offset':offset}
  for _ in range(read('i')):
   key=string();floats[key]=read('f')
  for _ in range(read('i')):
   key=string();colors[key]=read('ffff')
  if p!=end:raise ValueError('Material trailing bytes')
  materials[archive+'-'+str(obj['id'])]={'name':name,'textures':textures,'floats':floats,'colors':colors}
scene=json.loads((root/'catalog/level0.scene.json').read_text());cat=json.loads((root/'catalog/level0.json').read_text());data=(folder/'level0').read_bytes();objects={o['id']:o for o in cat['objects']}
def pointer(ref):
 source='level0' if ref[0]==0 else cat['externals'][ref[0]-1]['path'].split('/')[-1]
 return source+'-'+str(ref[1])
for node in scene['nodes']:
 for c in node['components']:
  o=objects[c['pathId']];p=o['offset']
  if c['classId']==33:node['mesh']=pointer(struct.unpack_from('<ii',data,p+8))
  if c['classId']==23:
   node['rendererEnabled']=bool(data[p+8]);n=struct.unpack_from('<i',data,p+12)[0]
   node['materials']=[pointer(struct.unpack_from('<ii',data,p+16+i*8)) for i in range(n)]
q=next(b for b in json.loads((root/'catalog/behaviours.json').read_text())['decoded'] if b['script']=='QuarterTrigger')
source=(root.parent/'Assets/Scripts/QuarterTrigger.cs').read_text().split('public void SetGlasses()')[1]
rounds=[]
for i in range(13):
 match=re.search(r'case '+str(i)+r':(.*?)(?:break;)',source,re.S)
 keys=re.findall(r'(Round\w+Glass\d+)\.SetActiveRecursively\(true\)',match.group(1))
 rounds.append([q['fields'][k][1] for k in keys])
scene.update(materials=materials,rounds=rounds,quarterFields=q['fields'],quarterObject=q['owner'][1])
out=root/'converted';(out/'scene.json').write_text(json.dumps(scene,separators=(',',':')))
print('Exported',len(materials),'materials and',len(rounds),'round object sets')
