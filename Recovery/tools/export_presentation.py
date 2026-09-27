"""Recover audio-source bindings from the original serialized scene."""
import json,struct
from pathlib import Path
root=Path(__file__).resolve().parents[1]
cat=json.loads((root/'catalog/level0.json').read_text())
data=(root/'extracted/Payload/iQuarters.app/Data/level0').read_bytes()
sources={}
for obj in cat['objects']:
 if obj['classId']!=82:continue
 p=obj['offset'];owner=struct.unpack_from('<i',data,p+4)[0]
 file,clip=struct.unpack_from('<ii',data,p+12)
 if clip:sources[str(owner)]={'file':f'sharedassets{0 if file==3 else 1}.assets-{clip}.wav','volume':struct.unpack_from('<f',data,p+24)[0]}
(root/'converted/presentation.json').write_text(json.dumps({'audioSources':sources},indent=2))
print('Exported',len(sources),'original audio source bindings')
scene=json.loads((root/'converted/scene.json').read_text())
behaviours=json.loads((root/'catalog/behaviours.json').read_text())['decoded']
cameras=[]
for obj in cat['objects']:
 if obj['classId']!=20:continue
 p=obj['offset'];owner=struct.unpack_from('<i',data,p+4)[0]
 camera=dict(owner=owner,near=struct.unpack_from('<f',data,p+48)[0],far=struct.unpack_from('<f',data,p+52)[0],fov=struct.unpack_from('<f',data,p+56)[0])
 for b in behaviours:
  if b['owner'][1]==owner and 'CameraScript' in b['script']:camera['follow']=b['fields']
 cameras.append(camera)
(root/'converted/presentation.json').write_text(json.dumps({'audioSources':sources,'cameras':cameras},indent=2))
