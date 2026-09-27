"""Expose the Android reference's recovered GlassFlash billboard to both renderers.
Legacy emitter data is decoded from the IPA, not an invented score particle.
Run after export_render_scene.py.
"""
from pathlib import Path
import json,struct
root=Path(__file__).resolve().parents[1];out=root/'converted'
catalog=json.loads((root/'catalog/level0.json').read_text());raw=(root/'extracted/Payload/iQuarters.app/Data/level0').read_bytes()
objects={o['id']:o for o in catalog['objects']}
def read(id):
 o=objects[id];return raw[o['offset']:o['offset']+o['size']]
e=read(920);a=read(919)
scene=json.loads((out/'scene.json').read_text());flash=next(n for n in scene['nodes'] if n['id']==917)
flash.update(mesh='glassflash-billboard',materials=['sharedassets1.assets-737'],rendererEnabled=False)
scene['contactFlash']={'size':struct.unpack_from('<f',e,12)[0],'life':struct.unpack_from('<f',e,20)[0],'grow':struct.unpack_from('<f',a,56)[0],'alpha':[a[15+i*4]/255 for i in range(5)]}
(out/'scene.json').write_text(json.dumps(scene,separators=(',',':')))
mesh={'vertices':[[-.5,-.5,0],[.5,-.5,0],[.5,.5,0],[-.5,.5,0]],'normals':[[0,0,1]]*4,'uv':[[0,0],[1,0],[1,1],[0,1]],'colors':[[255]*4]*4,'submeshes':[[[0,1,2],[0,2,3]]]}
(out/'meshes/glassflash-billboard.json').write_text(json.dumps(mesh,separators=(',',':')))
print('Recovered contact flash:',scene['contactFlash'])
