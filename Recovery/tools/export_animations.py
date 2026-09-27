"""Decode this game's 2.x uncompressed keyframe clips. Source bytes are untouched."""
from pathlib import Path
import json,struct,math
root=Path(__file__).resolve().parents[1];out=root/'converted/animations';out.mkdir(exist_ok=True);manifest=[]
for archive in ('sharedassets0.assets','sharedassets1.assets'):
 data=(root/'extracted/Payload/iQuarters.app/Data'/archive).read_bytes()
 for obj in json.loads((root/'catalog'/(archive+'.json')).read_text())['objects']:
  if obj['classId']!=74:continue
  p=obj['offset'];end=p+obj['size']
  def read(fmt):
   global p
   size=struct.calcsize('<'+fmt)
   if p+size>end:raise ValueError('Truncated clip')
   v=struct.unpack_from('<'+fmt,data,p);p+=size
   return v[0] if len(v)==1 else list(v)
  def count():
   n=read('i')
   if not 0<=n<10000:raise ValueError('Invalid count '+str(n)+' at '+str(p))
   return n
  def string():
   global p
   n=count();v=data[p:p+n].decode();p=(p+n+3)&~3;return v
  def curve(dim):
   keys=[]
   for _ in range(count()):
    time=read('f');v=read('f'*dim);ins=read('f'*dim);outs=read('f'*dim)
    keys.append({'time':time,'value':v,'inSlope':ins,'outSlope':outs})
   pre,post=read('ii');return {'keys':keys,'pre':pre,'post':post}
  try:
   name=string();curves=[]
   for kind,dim in [('rotation',4),('position',3),('scale',3),('float',1)]:
    for _ in range(count()):
     c=curve(dim);c['kind']=kind
     if kind=='float':c['attribute']=string()
     c['path']=string()
     if kind=='float':c['classId']=read('i');c['script']=read('ii')
     curves.append(c)
   rate=read('f');wrap=read('i');events=[]
   for _ in range(count() if p<end else 0):events.append({'time':read('f'),'function':string(),'text':string(),'object':read('ii'),'float':read('f'),'options':read('i')})
   if p!=end:raise ValueError('Unparsed '+str(end-p)+' bytes')
   duration=max((k['time'] for c in curves for k in c['keys']),default=0)
   result={'name':name,'duration':duration,'sampleRate':rate,'wrap':wrap,'curves':curves,'events':events}
   # Infinite tangent slopes encode stepped keys. JSON represents them as null.
   def clean(v):
    if isinstance(v,float):return v if math.isfinite(v) else None
    if isinstance(v,list):return [clean(i) for i in v]
    if isinstance(v,dict):return {k:clean(i) for k,i in v.items()}
    return v
   key=archive+'-'+str(obj['id']);(out/(key+'.json')).write_text(json.dumps(clean(result),separators=(',',':')))
   manifest.append({'key':key,'name':name,'duration':duration,'curves':len(curves)})
  except Exception as e:raise ValueError(archive+' '+str(obj)+' '+str(e)) from e
(out/'manifest.json').write_text(json.dumps(manifest,indent=2));print('Decoded',len(manifest),'clips; exact object boundaries verified')
