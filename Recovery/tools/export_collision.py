"""Convert observed box/mesh colliders to original-world triangle geometry.
Includes collider materials, rigid-body ownership, curved primitive surfaces,
and the active compound quarter collider.
"""
from pathlib import Path
import json,struct,math
root=Path(__file__).resolve().parents[1]
scene=json.loads((root/'converted/scene.json').read_text()); nodes={n['id']:n for n in scene['nodes']}; transforms={t['id']:t for t in scene['transforms']}; owners={t['owner'][1]:t for t in scene['transforms']}
cat=json.loads((root/'catalog/level0.json').read_text());data=(root/'extracted/Payload/iQuarters.app/Data/level0').read_bytes()
def add(a,b):return [a[i]+b[i] for i in range(3)]
def cross(a,b):return [a[1]*b[2]-a[2]*b[1],a[2]*b[0]-a[0]*b[2],a[0]*b[1]-a[1]*b[0]]
def world(owner,v):
 t=owners[owner];v=[v[i]*t['scale'][i] for i in range(3)];q=t['rotation'];u=q[:3];uv=cross(u,v);uuv=cross(u,uv);v=[v[i]+2*(q[3]*uv[i]+uuv[i])+t['position'][i] for i in range(3)]
 return world(transforms[t['parent'][1]]['owner'][1],v) if t['parent'][1] else v
faces=[[0,2,1],[0,3,2],[4,5,6],[4,6,7],[0,1,5],[0,5,4],[3,7,6],[3,6,2],[0,4,7],[0,7,3],[1,2,6],[1,6,5]]
def box(size,center):
 corners=[[-1,-1,-1],[1,-1,-1],[1,1,-1],[-1,1,-1],[-1,-1,1],[1,-1,1],[1,1,1],[-1,1,1]]
 return [[center[i]+v[i]*size[i]/2 for i in range(3)] for v in corners],faces
def curved(radius,height,axis,center):
 vertices=[];tris=[];rings=12;sides=24;half=max(0,height/2-radius)
 for r in range(rings+1):
  angle=-math.pi/2+math.pi*r/rings;along=radius*math.sin(angle)+(half if r>rings/2 else -half)
  for j in range(sides):
   p=[radius*math.cos(angle)*math.cos(j*2*math.pi/sides),along,radius*math.cos(angle)*math.sin(j*2*math.pi/sides)]
   if axis!=1:p[axis],p[1]=p[1],p[axis]
   vertices.append(add(p,center))
 for r in range(rings):
  for j in range(sides):
   a=r*sides+j;b=r*sides+(j+1)%sides;c=a+sides;d=b+sides;tris.extend([[a,b,c],[b,d,c]])
 return vertices,tris
materials={}
mc=json.loads((root/'catalog/sharedassets1.assets.json').read_text());mb=(root/'extracted/Payload/iQuarters.app/Data/sharedassets1.assets').read_bytes()
for o in mc['objects']:
 if o['classId']!=134:continue
 p=o['offset'];length=struct.unpack_from('<i',mb,p)[0];name=mb[p+4:p+4+length].decode();p=(p+4+length+3)&~3
 dynamic,static,bounce,frictionMode,bounceMode=struct.unpack_from('<fffii',mb,p)
 materials[str(o['id'])]={'name':name,'dynamicFriction':dynamic,'staticFriction':static,'bounce':bounce,'frictionCombine':frictionMode,'bounceCombine':bounceMode}
bodies={}
for o in cat['objects']:
 if o['classId']==54:
  p=o['offset'];owner=struct.unpack_from('<i',data,p+4)[0];mass,drag,angularDrag=struct.unpack_from('<fff',data,p+8)
  bodies[owner]={'mass':mass,'drag':drag,'angularDrag':angularDrag}
behaviours=json.loads((root/'catalog/behaviours.json').read_text())['decoded'];reactions={}
for b in behaviours:
 if b['script'] in ('LauncherScript','LighterScript','CellPhoneScript','NewtonsCradleScript'):
  f=b['fields'];reactions[b['owner'][1]]={'velocity':[f['xVel'],f['yVel'],f['zVel']],'normalThreshold':f.get('contactAngle',.707),'extraTime':f.get('shotTimeAdd',2.2 if b['script']=='CellPhoneScript' else 2),'hinge':f.get('hingeObject',[0,0])[1],'script':b['script']}
def quarterlocal(owner,v):
 t=owners[owner];v=[v[i]*t['scale'][i] for i in range(3)]
 if owner==scene['quarterObject']:return v
 q=t['rotation'];uv=cross(q[:3],v);uuv=cross(q[:3],uv);v=[v[i]+2*(q[3]*uv[i]+uuv[i])+t['position'][i] for i in range(3)]
 return quarterlocal(transforms[t['parent'][1]]['owner'][1],v)
result=[];coin=[]
for obj in cat['objects']:
 cid=obj['classId'];p=obj['offset']
 if cid not in (64,65,135,136):continue
 owner=struct.unpack_from('<i',data,p+4)[0];node=nodes[owner]
 ancestor=owner;chain=[owner]
 while owners[ancestor]['parent'][1]:ancestor=transforms[owners[ancestor]['parent'][1]]['owner'][1];chain.append(ancestor)
 if data[p+16]:continue
 if cid==64:
  fileid,ident=struct.unpack_from('<ii',data,p+20);archive='level0' if fileid==0 else cat['externals'][fileid-1]['path'].split('/')[-1];meshpath=root/'converted/meshes'/(archive+'-'+str(ident)+'.json')
  if not meshpath.exists():raise ValueError(str(meshpath))
  mesh=json.loads(meshpath.read_text());vertices=mesh['vertices'];tris=[f for g in mesh['submeshes'] for f in g]
 elif cid==65:vertices,tris=box(struct.unpack_from('<fff',data,p+20),struct.unpack_from('<fff',data,p+32))
 elif cid==135:
  radius=struct.unpack_from('<f',data,p+20)[0];vertices,tris=curved(radius,2*radius,1,struct.unpack_from('<fff',data,p+24))
 else:
  radius,height,axis=struct.unpack_from('<ffi',data,p+20);vertices,tris=curved(radius,height,axis,struct.unpack_from('<fff',data,p+32))
 if scene['quarterObject'] in chain:
  if all(nodes[a]['active'] for a in chain):coin.append({'owner':owner,'name':node['name'],'vertices':[quarterlocal(owner,v) for v in vertices],'triangles':tris})
  continue
 materialRef=struct.unpack_from('<ii',data,p+8)
 material=materials.get(str(materialRef[1])) if materialRef[0]==1 else None
 rigid=next((a for a in chain if a in bodies),0)
 reactionOwner=next((a for a in chain if a in reactions),0)
 verts=[world(owner,v) for v in vertices];name=node['name'];multiplier={'COL':1,'COL2':2,'COL3':3,'COL4':4}.get(name,0)
 result.append({'owner':owner,'collider':obj['id'],'body':rigid,'material':material,'reactionOwner':reactionOwner,'reaction':reactions.get(reactionOwner),'ancestors':chain,'name':name,'multiplier':multiplier,'triangles':[[verts[i] for i in t] for t in tris]})
(root/'converted/collision.json').write_text(json.dumps(result,separators=(',',':')))
print('Exported',len(result),'collision shapes,',sum(len(s['triangles']) for s in result),'triangles')

settings={'quarter':bodies[scene['quarterObject']],'initialOrientation':owners[scene['quarterObject']]['rotation'],'compound':coin,'materials':materials,'bodies':bodies,'quarterFields':scene['quarterFields'],'reactions':reactions}
(root/'converted/physics.json').write_text(json.dumps(settings,separators=(',',':')))
print('Recovered',len(coin),'active quarter shapes;',len(materials),'materials;',len(reactions),'scripted obstacle reactions')
