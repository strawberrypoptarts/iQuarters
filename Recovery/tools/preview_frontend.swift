import Foundation
import SceneKit
import AppKit
import Metal
let base=URL(fileURLWithPath:CommandLine.arguments[1])
func json(_ name:String)throws->Any {try JSONSerialization.jsonObject(with:Data(contentsOf:base.appendingPathComponent(name)))}
let data=try json("frontend.json") as! [String:Any]
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
 if let key=n["mesh"] as? String,(n["rendererEnabled"] as? Bool ?? true),let g=try? mesh(key){node.geometry=g.copy() as? SCNGeometry;node.geometry?.materials=(n["materials"] as? [String] ?? []).compactMap{materials[$0]}}
 nodes[n["id"] as! Int]=node
}
var owners=[Int:Int]();var parents=[Int:Int]()
for t in data["transforms"] as! [[String:Any]] {
 let owner=(t["owner"] as! [Int])[1];let node=nodes[owner]!;node.position=vec(t["position"] as! [Double]);node.scale=vec(t["scale"] as! [Double]);let q=t["rotation"] as! [Double];node.orientation=SCNQuaternion(q[0],q[1],q[2],q[3]);owners[t["id"] as! Int]=owner;parents[owner]=(t["parent"] as! [Int])[1]
}
let world=SCNNode();world.scale=SCNVector3(-1,1,1);scene.rootNode.addChildNode(world)
for (id,node) in nodes {if let p=parents[id],let owner=owners[p]{nodes[owner]!.addChildNode(node)}else{world.addChildNode(node);node.isHidden=true}}
func reveal(_ node:SCNNode){var n:SCNNode?=node;while let v=n{v.isHidden=false;n=v.parent}}
let menu=nodes.values.first{$0.name=="ui_main_menu_00"}!
func sample(_ id:Int){
let clip=try! json("animations/sharedassets0.assets-\(id).json") as! [String:Any]
for c in clip["curves"] as! [[String:Any]] {
 var node:SCNNode?=menu
 for part in (c["path"] as! String).split(separator:"/"){node=node?.childNodes.first{$0.name==String(part)}}
 guard let n=node,let k=(c["keys"] as! [[String:Any]]).last,let v=k["value"] as? [Double] else{continue}
 switch c["kind"] as! String {case "position":n.position=vec(v);case "scale":n.scale=vec(v);case "rotation":n.orientation=SCNQuaternion(v[0],v[1],v[2],v[3]);default:break}
}}
for id in CommandLine.arguments[3].split(separator:","){sample(Int(id)!)}
for name in ["ui_main_menu_00","backdrop","ui_about"]{if let n=nodes.values.first(where:{$0.name==name}){reveal(n)}}
for n in nodes.values where n.name=="dimplane" || n.name=="about_text" || n.name?.hasPrefix("high_score_bg_")==true {n.isHidden=true}
let camera=SCNNode();camera.camera=SCNCamera();camera.camera!.usesOrthographicProjection=true;camera.camera!.orthographicScale=100;camera.camera!.zNear=0.3;camera.camera!.zFar=1100;camera.position=SCNVector3(0,0,1000);scene.rootNode.addChildNode(camera)
let width=Double(CommandLine.arguments[4])!;let height=Double(CommandLine.arguments[5])!
camera.camera!.orthographicScale=max(100,66.666667*height/width)
nodes.values.first{$0.name=="backdrop"}!.scale=SCNVector3(33*max(1,(width/height)/(2.0/3)),33,33*camera.camera!.orthographicScale/100)
let renderer=SCNRenderer(device:MTLCreateSystemDefaultDevice(),options:nil);renderer.scene=scene;renderer.pointOfView=camera;renderer.autoenablesDefaultLighting=true
let image=renderer.snapshot(atTime:0,with:CGSize(width:width,height:height),antialiasingMode:.multisampling4X)
let rep=NSBitmapImageRep(data:image.tiffRepresentation!)!;try rep.representation(using:.png,properties:[:])!.write(to:URL(fileURLWithPath:CommandLine.arguments[2]))
