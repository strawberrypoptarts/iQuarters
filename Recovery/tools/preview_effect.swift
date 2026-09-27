import Foundation
import SceneKit
import AppKit
import Metal
let base=URL(fileURLWithPath:CommandLine.arguments[1])
func json(_ name:String)throws->Any {try JSONSerialization.jsonObject(with:Data(contentsOf:base.appendingPathComponent(name)))}
let data=try json("scene.json") as! [String:Any]
let scene=SCNScene();scene.background.contents=NSColor.black
var nodes=[Int:SCNNode]();var materials=[String:SCNMaterial]();var meshes=[String:SCNGeometry]()
func vec(_ v:[Double])->SCNVector3 {SCNVector3(v[0],v[1],v[2])}
for (key,m) in data["materials"] as! [String:[String:Any]] {
 let mat=SCNMaterial();mat.isDoubleSided=true;mat.lightingModel = .constant
 if let c=(m["colors"] as! [String:[Double]])["_Color"] {mat.diffuse.contents=NSColor(red:c[0],green:c[1],blue:c[2],alpha:c[3])}
 if let t=(m["textures"] as! [String:[String:Any]])["_MainTex"],let img=NSImage(contentsOf:base.appendingPathComponent("textures/\(t["asset"] as! String).png")){mat.diffuse.contents=img}
 materials[key]=mat
}
func mesh(_ key:String)throws->SCNGeometry {
 if let g=meshes[key]{return g}
 let m=try json("meshes/\(key).json") as! [String:Any];let vertices=m["vertices"] as! [[Double]]
 var sources=[SCNGeometrySource(vertices:vertices.map(vec))]
 let normals=m["normals"] as! [[Double]];if normals.count==vertices.count{sources.append(SCNGeometrySource(normals:normals.map(vec)))}
 let uv=m["uv"] as! [[Double]];if uv.count==vertices.count{sources.append(SCNGeometrySource(textureCoordinates:uv.map{CGPoint(x:$0[0],y:1-$0[1])}))}
 let elements=(m["submeshes"] as! [[[Int]]]).map {SCNGeometryElement(indices:$0.flatMap{$0}.map{Int32($0)},primitiveType:.triangles)}
 let g=SCNGeometry(sources:sources,elements:elements);meshes[key]=g;return g
}
for n in data["nodes"] as! [[String:Any]] {
 let node=SCNNode();node.name=n["name"] as? String;node.isHidden = !(n["active"] as! Bool)
 if let key=n["mesh"] as? String,let g=try? mesh(key){node.geometry=g.copy() as? SCNGeometry;node.geometry?.materials=(n["materials"] as? [String] ?? []).compactMap{materials[$0]}}
 nodes[n["id"] as! Int]=node
}
var owners=[Int:Int]();var parents=[Int:Int]()
for t in data["transforms"] as! [[String:Any]] {
 let owner=(t["owner"] as! [Int])[1];let node=nodes[owner]!;node.position=vec(t["position"] as! [Double]);node.scale=vec(t["scale"] as! [Double]);let q=t["rotation"] as! [Double];node.orientation=SCNQuaternion(q[0],q[1],q[2],q[3]);owners[t["id"] as! Int]=owner;parents[owner]=(t["parent"] as! [Int])[1]
}
let world=SCNNode();world.scale=SCNVector3(-1,1,1);scene.rootNode.addChildNode(world)
for (id,node) in nodes {if let p=parents[id],let owner=owners[p]{nodes[owner]!.addChildNode(node)}else{world.addChildNode(node);node.isHidden=true}}
func reveal(_ node:SCNNode){var n:SCNNode?=node;while let v=n{v.isHidden=false;n=v.parent}}
func activate(_ n:SCNNode){n.isHidden=false;for c in n.childNodes{activate(c)}}
let owner=Int(CommandLine.arguments[3])!,clipId=Int(CommandLine.arguments[6])!,time=Double(CommandLine.arguments[7])!
let root=nodes[owner]!;activate(root);reveal(root)
let clip=try json("animations/sharedassets1.assets-\(clipId).json") as! [String:Any]
func values(_ k:[String:Any],_ name:String)->[Double]{if let v=k[name] as? [Double]{return v};return []}
for c in clip["curves"] as! [[String:Any]] {
 var node:SCNNode?=root
 for part in (c["path"] as! String).split(separator:"/"){node=node?.childNodes.first{$0.name==String(part)}}
 let keys=c["keys"] as! [[String:Any]];guard let n=node,!keys.isEmpty else{continue}
 var v=values(keys.last!,"value")
 if time <= keys[0]["time"] as! Double{v=values(keys[0],"value")}
 else if let i=keys.firstIndex(where:{($0["time"] as! Double)>time}),i>0 {
  let a=keys[i-1],b=keys[i],span=(b["time"] as! Double)-(a["time"] as! Double),t=(time-(a["time"] as! Double))/span
  let av=values(a,"value"),bv=values(b,"value"),sa=values(a,"outSlope"),sb=values(b,"inSlope")
  if av.count==sa.count && av.count==sb.count{v=av.indices.map{(2*t*t*t-3*t*t+1)*av[$0]+(t*t*t-2*t*t+t)*span*sa[$0]+(-2*t*t*t+3*t*t)*bv[$0]+(t*t*t-t*t)*span*sb[$0]}}
 }
 guard v.count>=3 else{continue}
 switch c["kind"] as! String {case "position":n.position=vec(v);case "scale":n.scale=vec(v);case "rotation":n.orientation=SCNQuaternion(v[0],v[1],v[2],v[3]);default:break}
}
if owner==236 {for n in root.childNodes{if Int(n.name ?? "") != nil{n.isHidden=n.name != "01"};if n.name?.hasPrefix("hs_")==true || n.name?.hasPrefix("new_high_")==true{n.isHidden=true}}}
if owner==1319 {for id in [1310,1313]{nodes[id]!.isHidden=true}}
let camera=SCNNode();camera.camera=SCNCamera();camera.camera!.usesOrthographicProjection=true;camera.camera!.orthographicScale=100;camera.camera!.zNear=0.3;camera.camera!.zFar=1100;camera.position=SCNVector3(0,0,1000);scene.rootNode.addChildNode(camera)
let width=Double(CommandLine.arguments[4])!;let height=Double(CommandLine.arguments[5])!
camera.camera!.orthographicScale=max(100,66.666667*height/width)

let renderer=SCNRenderer(device:MTLCreateSystemDefaultDevice(),options:nil);renderer.scene=scene;renderer.pointOfView=camera;renderer.autoenablesDefaultLighting=true
let image=renderer.snapshot(atTime:0,with:CGSize(width:width,height:height),antialiasingMode:.multisampling4X)
let rep=NSBitmapImageRep(data:image.tiffRepresentation!)!;try rep.representation(using:.png,properties:[:])!.write(to:URL(fileURLWithPath:CommandLine.arguments[2]))
