import Foundation
import SceneKit
import AppKit
import Metal
let base=URL(fileURLWithPath:CommandLine.arguments[1])
func json(_ name:String)throws->Any {try JSONSerialization.jsonObject(with:Data(contentsOf:base.appendingPathComponent(name)))}
let data=try json("scene.json") as! [String:Any]
let scene=SCNScene();scene.background.contents=NSColor.black
let width=CommandLine.arguments.count>4 ? Double(CommandLine.arguments[4])! : 640
let height=CommandLine.arguments.count>5 ? Double(CommandLine.arguments[5])! : 960
let mode=CommandLine.arguments.count>6 ? CommandLine.arguments[6] : "game"

let improved=CommandLine.arguments[3]=="after"
let lighting=try json("lighting.json") as! [String:Any]
var nodes=[Int:SCNNode]();var materials=[String:SCNMaterial]();var meshes=[String:SCNGeometry]()
func vec(_ v:[Double])->SCNVector3 {SCNVector3(v[0],v[1],v[2])}
for (key,m) in data["materials"] as! [String:[String:Any]] {
 let mat=SCNMaterial();mat.isDoubleSided=true;mat.lightingModel = .blinn
 if let c=(m["colors"] as! [String:[Double]])["_Color"] {mat.diffuse.contents=NSColor(red:c[0],green:c[1],blue:c[2],alpha:c[3])}
 if let t=(m["textures"] as! [String:[String:Any]])["_MainTex"],let img=NSImage(contentsOf:base.appendingPathComponent("textures/\(t["asset"] as! String).png")){mat.diffuse.contents=img}
 if improved,let shader=(lighting["materials"] as! [String:[String:Any]])[key]{
  let vertex=shader["vertexLit"] as! Bool;mat.lightingModel=vertex ? .phong : .lambert;mat.isLitPerPixel = !vertex
  let colors=m["colors"] as! [String:[Double]]
  func color(_ a:[Double])->NSColor{NSColor(red:a[0],green:a[1],blue:a[2],alpha:a[3])}
  var surface=""
  if let e=colors["_Emission"]{surface+="_surface.emission.rgb = _surface.diffuse.rgb * float3(\(e[0]), \(e[1]), \(e[2]));\n"}
  if let tint=colors["_Color"],(m["textures"] as! [String:Any])["_MainTex"] != nil{surface+="_surface.diffuse *= float4(\(tint[0]), \(tint[1]), \(tint[2]), \(tint[3]));"}
  if !surface.isEmpty{mat.shaderModifiers=[.surface:surface]}
  if m["name"] as? String == "shotglass_00"{mat.shaderModifiers?[.fragment]="_output.color.rgb *= 2.0;";mat.writesToDepthBuffer=false;mat.transparencyMode = .aOne}
  let selfLit=(colors["_Emission"] ?? [0,0,0]).prefix(3).allSatisfy{$0>=1}
  if vertex,let c=colors["_SpecColor"]{mat.specular.contents=color(c)}
  if let shine=(m["floats"] as! [String:Double])["_Shininess"]{mat.shininess=CGFloat(shine*128)}
  if selfLit{mat.lightingModel = .constant;mat.specular.contents=NSColor.black;mat.shaderModifiers=nil}
 }
 if improved,m["name"] as? String == "shadow_00"{mat.lightingModel = .constant;mat.writesToDepthBuffer=false;mat.transparencyMode = .aOne;mat.shaderModifiers=nil}
 if improved,(lighting["materials"] as! [String:[String:Any]])[key]?["name"] as? String == "Particle Add"{
  mat.lightingModel = .constant;mat.blendMode = .add;mat.writesToDepthBuffer=false;mat.transparencyMode = .aOne
  mat.shaderModifiers=[.geometry:"#pragma varyings\nfloat recoveredGlowAlpha;\n#pragma body\nout.recoveredGlowAlpha = _geometry.color.a;\n_geometry.color = float4(1.0);",.surface:"_surface.diffuse *= float4(2.0, 2.0, 1.34677422, 0.4 * in.recoveredGlowAlpha);"]
 }
 materials[key]=mat
}
func mesh(_ key:String)throws->SCNGeometry {
 if let g=meshes[key]{return g}
 let m=try json("meshes/\(key).json") as! [String:Any];let vertices=m["vertices"] as! [[Double]]
 var sources=[SCNGeometrySource(vertices:vertices.map(vec))]
 let normals=m["normals"] as! [[Double]];if normals.count==vertices.count{sources.append(SCNGeometrySource(normals:normals.map(vec)))}
 let uv=m["uv"] as! [[Double]];if uv.count==vertices.count{sources.append(SCNGeometrySource(textureCoordinates:uv.map{CGPoint(x:$0[0],y:1-$0[1])}))}
 if key == "sharedassets1.assets-426" || key == "sharedassets1.assets-427"{
  let rgba:[Float]=(m["colors"] as! [[Int]]).flatMap{c -> [Float] in [1,1,1,c[1]>0 ? 0 : 1]};let bytes=rgba.withUnsafeBytes{Data($0)}
  sources.append(SCNGeometrySource(data:bytes,semantic:.color,vectorCount:vertices.count,usesFloatComponents:true,componentsPerVector:4,bytesPerComponent:4,dataOffset:0,dataStride:16))
 }
 let elements=(m["submeshes"] as! [[[Int]]]).map {SCNGeometryElement(indices:$0.flatMap{$0}.map{Int32($0)},primitiveType:.triangles)}
 let g=SCNGeometry(sources:sources,elements:elements);meshes[key]=g;return g
}
for n in data["nodes"] as! [[String:Any]] {
 let node=SCNNode();if improved{node.categoryBitMask=1 << (n["layer"] as! Int)};node.name=n["name"] as? String;node.isHidden = !(n["active"] as! Bool)
 if let key=n["mesh"] as? String,let g=try? mesh(key){node.geometry=g.copy() as? SCNGeometry;node.geometry?.materials=(n["materials"] as? [String] ?? []).compactMap{materials[$0]}}
 if n["rendererEnabled"] as? Bool == false{node.opacity=0};nodes[n["id"] as! Int]=node
}
var owners=[Int:Int]();var parents=[Int:Int]()
for t in data["transforms"] as! [[String:Any]] {
 let owner=(t["owner"] as! [Int])[1];let node=nodes[owner]!;node.position=vec(t["position"] as! [Double]);node.scale=vec(t["scale"] as! [Double]);let q=t["rotation"] as! [Double];node.orientation=SCNQuaternion(q[0],q[1],q[2],q[3]);owners[t["id"] as! Int]=owner;parents[owner]=(t["parent"] as! [Int])[1]
}

let world=SCNNode();world.scale=SCNVector3(1,1,-1);scene.rootNode.addChildNode(world)
for (id,node) in nodes {if let p=parents[id],let owner=owners[p]{nodes[owner]!.addChildNode(node)}else{world.addChildNode(node);node.isHidden=true}}
for record in data["nodes"] as! [[String:Any]] {let n=nodes[record["id"] as! Int]!;if record["rendererEnabled"] as? Bool == false && !n.childNodes.isEmpty{n.geometry=nil;n.opacity=1}}
func activate(_ n:SCNNode){n.isHidden=false;for child in n.childNodes{activate(child)}}
for name in ["table_00","scene_bar_00","a_quarter5"]{nodes.values.first{$0.name==name}?.isHidden=false}
for id in (data["rounds"] as! [[Int]])[0]{activate(nodes[id]!);var n:SCNNode?=nodes[id];while let v=n{v.isHidden=false;n=v.parent}}
if improved{
 for shadow in (lighting["roundShadows"] as! [[[String:Any]]])[0]{let n=nodes[shadow["shadow"] as! Int]!,g=nodes[shadow["glass"] as! Int]!;activate(n);n.opacity=1;n.position=SCNVector3(g.position.x,n.position.y,g.position.z);let size=shadow["scale"] as! Double;n.scale=SCNVector3(size,n.scale.y,size)}
 let a=lighting["ambient"] as! [Double];let ambient=SCNNode();ambient.light=SCNLight();ambient.light!.type = .ambient;ambient.light!.color=NSColor(red:a[0],green:a[1],blue:a[2],alpha:1);ambient.light!.intensity=1000;scene.rootNode.addChildNode(ambient)
 for source in lighting["lights"] as! [[String:Any]]{
  let owner=source["owner"] as! Int,mask=source["mask"] as! Int
  let record=(data["nodes"] as! [[String:Any]]).first{$0["id"] as! Int==owner}!
  if !(source["enabled"] as! Bool) || !(record["active"] as! Bool) || mask & 0xf00 == 0 {continue}
  let node=nodes[owner]!;node.isHidden=false;let lamp=SCNNode();lamp.eulerAngles=SCNVector3(0,Double.pi,0);let l=SCNLight();lamp.light=l;l.type=(source["type"] as! Int)==0 ? .spot : .omni
  l.intensity=CGFloat((source["intensity"] as! Double)*1000);l.categoryBitMask=mask;l.attenuationStartDistance=0;l.attenuationEndDistance=CGFloat(source["range"] as! Double);l.attenuationFalloffExponent=2;l.spotInnerAngle=0;l.spotOuterAngle=CGFloat(source["spotAngle"] as! Double);node.addChildNode(lamp)
 }
}
let camera=SCNNode();camera.camera=SCNCamera();camera.camera!.fieldOfView=CGFloat(2*atan(tan(55*Double.pi/360)*max(1,(2.0/3)*height/width))*180/Double.pi);camera.camera!.zNear=0.05;camera.camera!.zFar=300;camera.position=SCNVector3(0,4.815438,6.119505);camera.eulerAngles=SCNVector3(-0.5585,0,0);scene.rootNode.addChildNode(camera)
func sample(_ root:SCNNode,_ clipId:Int,_ time:Double){
 let clip=try! json("animations/sharedassets1.assets-\(clipId).json") as! [String:Any]
 func vals(_ k:[String:Any],_ key:String)->[Double]{k[key] as? [Double] ?? []}
 for c in clip["curves"] as! [[String:Any]]{
  var n:SCNNode?=root;for part in (c["path"] as! String).split(separator:"/"){n=n?.childNode(withName:String(part),recursively:false)}
  let keys=c["keys"] as! [[String:Any]];guard let node=n,!keys.isEmpty else{continue}
  var v=vals(keys.last!,"value")
  if time<=keys[0]["time"] as! Double{v=vals(keys[0],"value")}
  else if let i=keys.firstIndex(where:{($0["time"] as! Double)>time}),i>0{
   let ka=keys[i-1],kb=keys[i],span=(kb["time"] as! Double)-(ka["time"] as! Double),t=(time-(ka["time"] as! Double))/span
   let av=vals(ka,"value"),bv=vals(kb,"value"),sa=vals(ka,"outSlope"),sb=vals(kb,"inSlope")
   if av.count==sa.count && av.count==sb.count{v=av.indices.map{(2*t*t*t-3*t*t+1)*av[$0]+(t*t*t-2*t*t+t)*span*sa[$0]+(-2*t*t*t+3*t*t)*bv[$0]+(t*t*t-t*t)*span*sb[$0]}}
  }
  guard v.count>=3 else{continue};switch c["kind"] as! String{case "position":node.position=vec(v);case "scale":node.scale=vec(v);case "rotation":node.orientation=SCNQuaternion(v[0],v[1],v[2],v[3]);default:break}
 }
}
if mode == "glow"{
 let coin=nodes[965]!;coin.position=SCNVector3(0,0.3,0);activate(nodes[957]!);nodes[957]!.position=SCNVector3(0,0.18,0);sample(nodes[957]!,506,0.4)
}
if mode == "replay"{camera.position=nodes[2385]!.worldPosition;let q=nodes[2385]!.orientation;camera.orientation=SCNQuaternion(-q.x,-q.y,q.z,q.w);camera.look(at:SCNVector3(0,0.5,0))}
let renderer=SCNRenderer(device:MTLCreateSystemDefaultDevice(),options:nil);renderer.scene=scene;renderer.pointOfView=camera;renderer.autoenablesDefaultLighting = !improved
let image=renderer.snapshot(atTime:0,with:CGSize(width:width,height:height),antialiasingMode:.multisampling4X)
var finalImage=image
if mode == "dim" || mode == "hud"{
 let ui=SCNScene();ui.background.contents=NSColor.clear;let uiWorld=SCNNode();uiWorld.scale=SCNVector3(-1,1,1);ui.rootNode.addChildNode(uiWorld)
 let root=nodes[236]!.clone();uiWorld.addChildNode(root);activate(root)
 func style(_ n:SCNNode){if let g=n.geometry{n.geometry=g.copy() as? SCNGeometry;n.geometry!.materials=g.materials.map{m in let copy=m.copy() as! SCNMaterial;copy.lightingModel = .constant;copy.shaderModifiers=nil;if n.name=="dimplane"{copy.diffuse.contents=NSColor(white:0.117647,alpha:0.5);copy.transparencyMode = .aOne;copy.writesToDepthBuffer=false};return copy}};for c in n.childNodes{style(c)}}
 style(root);sample(root,575,0.8);for n in root.childNodes{if Int(n.name ?? "") != nil{n.isHidden=n.name != "01"};if n.name?.hasPrefix("hs_")==true || n.name?.hasPrefix("new_high_")==true{n.isHidden=true}}
 if mode == "hud"{
  root.isHidden=true
  let half=max(100,66.666667*height/width),halfWidth=half*width/height,unit=2*half/height
  let safeTop=height/width>2 ? 47.0 : 0.0,safeBottom=height/width>2 ? 34.0 : 0.0
  let top=half-100-safeTop*unit,bottom = -half+100+safeBottom*unit
  for name in ["UI_pause","ui_ingame_3coin_hold","ui_ingame_angle_root","ex_round_mon"]{
   let original=nodes.values.first{$0.name==name}!,n=original.clone(),wrapper=SCNNode();uiWorld.addChildNode(wrapper);wrapper.addChildNode(n);activate(n);style(n)
   let left=name=="ui_ingame_3coin_hold";wrapper.position=SCNVector3(left ? halfWidth-66.666667 : -halfWidth+66.666667,name=="UI_pause" ? bottom : top,0)
   if name=="ui_ingame_3coin_hold"{n.position=SCNVector3(0,0,0);for c in n.childNodes{if c.name?.hasPrefix("quarter_card_")==true{c.opacity=0}}}
   if name=="UI_pause"{n.childNode(withName:nodes[1829]!.name!,recursively:true)?.opacity=0;let id=Int((data["nodes"] as! [[String:Any]]).first{$0["name"] as? String==name}!["id"] as! Int);let rec=(data["nodes"] as! [[String:Any]]).first{$0["id"] as! Int==id}!;let key=(rec["animation"] as! [String:Any])["default"] as! String;sample(n,Int(key.split(separator:"-").last!)!,1)}
   if name=="ui_ingame_angle_root"{n.position=SCNVector3(33.5,0,0);if let angle=n.childNode(withName:"UI_ingame_angle",recursively:true){let rec=(data["nodes"] as! [[String:Any]]).first{$0["name"] as? String=="UI_ingame_angle"}!;let key=(rec["animation"] as! [String:Any])["clips"] as! [String];let k=key.first{(try! json("animations/\($0).json") as! [String:Any])["name"] as? String=="hold"}!;sample(angle,Int(k.split(separator:"-").last!)!,0);for c in angle.childNodes{if c.name?.hasPrefix("button_done")==true{c.opacity=0}}}}
   if name=="ex_round_mon"{let rec=(data["nodes"] as! [[String:Any]]).first{$0["name"] as? String==name}!;let key=(rec["animation"] as! [String:Any])["default"] as! String;sample(n,Int(key.split(separator:"-").last!)!,0.4);for c in n.childNodes{if Int(c.name ?? "") != nil || c.name=="secret" || c.name=="round_move_marker"{c.isHidden=c.name != "01"}};if let marker=n.childNode(withName:"round_move_marker",recursively:false){n.childNode(withName:"01",recursively:false)?.position=marker.position;if let graphic=n.childNode(withName:"round_graphic",recursively:false){graphic.position.x=marker.position.x}}}
  }
 }
 let cam=SCNNode();cam.camera=SCNCamera();cam.camera!.usesOrthographicProjection=true;cam.camera!.orthographicScale=max(100,66.666667*height/width);cam.camera!.zNear=0.3;cam.camera!.zFar=1100;cam.position=SCNVector3(0,0,1000);ui.rootNode.addChildNode(cam)
 let r=SCNRenderer(device:MTLCreateSystemDefaultDevice(),options:nil);r.scene=ui;r.pointOfView=cam
 let over=r.snapshot(atTime:0,with:CGSize(width:width,height:height),antialiasingMode:.multisampling4X)
 finalImage=NSImage(size:CGSize(width:width,height:height));finalImage.lockFocus();image.draw(in:CGRect(x:0,y:0,width:width,height:height));over.draw(in:CGRect(x:0,y:0,width:width,height:height));finalImage.unlockFocus()
}
let bitmap=NSBitmapImageRep(data:finalImage.tiffRepresentation!)!;try bitmap.representation(using:.png,properties:[:])!.write(to:URL(fileURLWithPath:CommandLine.arguments[2]))
print("Rendered",CommandLine.arguments[2])
