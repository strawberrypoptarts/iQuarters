from pathlib import Path
import json,struct
root=Path(__file__).resolve().parents[1]
materials=json.loads((root/'converted/scene.json').read_text())['materials']
for name,output in [('mainData','frontend.json'),('level0','scene.json')]:
 scene=json.loads((root/'catalog'/(name+'.scene.json')).read_text()) if name=='mainData' else json.loads((root/'converted/scene.json').read_text())
 cat=json.loads((root/'catalog'/(name+'.json')).read_text());data=(root/'extracted/Payload/iQuarters.app/Data'/name).read_bytes();objects={o['id']:o for o in cat['objects']}
 def pointer(at):
  fileid,ident=struct.unpack_from('<ii',data,at)
  if ident==0:return None
  archive=name if fileid==0 else cat['externals'][fileid-1]['path'].split('/')[-1]
  return archive+'-'+str(ident)
 for node in scene['nodes']:
  for c in node['components']:
   o=objects[c['pathId']];p=o['offset'];cid=c['classId']
   if cid==33:node['mesh']=pointer(p+8)
   if cid==23:
    node['rendererEnabled']=bool(data[p+8]);n=struct.unpack_from('<i',data,p+12)[0];node['materials']=[pointer(p+16+i*8) for i in range(n)]
   if cid==111:
    n=struct.unpack_from('<i',data,p+20)[0];node['animation']={'default':pointer(p+12),'clips':[pointer(p+24+i*8) for i in range(n)],'wrap':struct.unpack_from('<i',data,p+24+n*8)[0],'autoPlay':bool(data[p+28+n*8])}
   if cid==20:
    node['camera']={'near':struct.unpack_from('<f',data,p+48)[0],'far':struct.unpack_from('<f',data,p+52)[0],'fov':struct.unpack_from('<f',data,p+56)[0],'orthographic':bool(data[p+60]),'size':struct.unpack_from('<f',data,p+64)[0]}
 scene['materials']=materials
 (root/'converted'/output).write_text(json.dumps(scene,separators=(',',':')))
 print(output,'exported with original camera and animation bindings')
