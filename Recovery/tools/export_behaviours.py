"""Decode scene script fields in supplied declaration order; reject mismatched sizes."""
from pathlib import Path
import json,struct,re
root=Path(__file__).resolve().parents[1]; scripts=root.parent/'Assets/Scripts'
scriptids={o['id']:o.get('candidateName') for o in json.loads((root/'catalog/sharedassets0.assets.json').read_text())['objects'] if o['classId']==115}
catalog=json.loads((root/'catalog/level0.json').read_text());data=(root/'extracted/Payload/iQuarters.app/Data/level0').read_bytes()
results=[];failures=[]
for obj in catalog['objects']:
 if obj['classId']!=114:continue
 p=obj['offset'];end=p+obj['size']
 def read(fmt):
  global p
  n=struct.calcsize('<'+fmt)
  if p+n>end:raise ValueError('Object overflow')
  v=struct.unpack_from('<'+fmt,data,p);p+=n
  return v[0] if len(v)==1 else list(v)
 def align():
  global p
  p=(p+3)&~3
 def string():
  global p
  n=read('i')
  if n<0 or p+n>end:raise ValueError('Bad string')
  v=data[p:p+n].decode();p+=n;align();return v
 def field(t):
  if t.endswith('[]'):
   n=read('i')
   if not 0<=n<10000:raise ValueError('Bad array length')
   return [field(t[:-2]) for _ in range(n)]
  if t=='int':return read('i')
  if t=='float':return read('f')
  if t=='bool':v=bool(read('B'));align();return v
  if t=='string':return string()
  if t in ('Vector2','Vector3','Quaternion','Color'):return read('f'*{'Vector2':2,'Vector3':3,'Quaternion':4,'Color':4}[t])
  if t in ('GameObject','AudioClip','Collider','ParticleEmitter','Transform','Rigidbody','Material','Texture','Renderer','AnimationClip','GUIText','GUITexture','Camera','Light','Font','GUISkin','MeshFilter'):return read('ii')
  if t=='ArrayList':return None
  raise ValueError('Unknown type '+t)
 owner=read('ii'); enabled=read('B');align();script=read('ii');name=string();classname=scriptids.get(script[1]);path=scripts/(str(classname)+'.cs')
 try:
  if script[0]!=3 or not path.exists():raise ValueError('Script reference unresolved '+str(script))
  source=path.read_text();fields=re.findall(r'^\tpublic (?!static)([\w\[\]]+) (\w+)(?:\s*=.*)?;',source,re.M)
  values={n:field(t) for t,n in fields if t!='ArrayList'}
  if p!=end:raise ValueError('Unconsumed bytes '+str(end-p))
  results.append({'id':obj['id'],'owner':owner,'script':classname,'fields':values})
 except (ValueError,struct.error) as e:failures.append({'id':obj['id'],'script':classname,'reason':str(e)})
(root/'catalog/behaviours.json').write_text(json.dumps({'decoded':results,'unresolved':failures},indent=2))
print('Decoded',len(results),'behaviours;',len(failures),'unresolved')
print(failures)
