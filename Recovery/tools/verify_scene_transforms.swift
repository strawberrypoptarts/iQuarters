import Foundation
import SceneKit
let root=URL(fileURLWithPath:CommandLine.arguments[1])
func json(_ p:String)throws->Any{try JSONSerialization.jsonObject(with:Data(contentsOf:root.appendingPathComponent(p)))}
let scene=try json("scene.json") as! [String:Any];let world=SCNNode();world.scale=SCNVector3(1,1,-1)
var nodes=[Int:SCNNode](),owners=[Int:Int]()
for t in scene["transforms"] as! [[String:Any]]{let id=(t["owner"] as! [Int])[1];let n=SCNNode();let p=t["position"] as! [Double],q=t["rotation"] as! [Double],s=t["scale"] as! [Double];n.position=SCNVector3(p[0],p[1],p[2]);n.orientation=SCNQuaternion(q[0],q[1],q[2],q[3]);n.scale=SCNVector3(s[0],s[1],s[2]);nodes[id]=n;owners[t["id"] as! Int]=id}
for t in scene["transforms"] as! [[String:Any]]{let id=(t["owner"] as! [Int])[1],parent=(t["parent"] as! [Int])[1];(parent==0 ? world : nodes[owners[parent]!]!).addChildNode(nodes[id]!)}
var maxError=0.0,points=0,shapes=0
for c in try json("collision.json") as! [[String:Any]]{let n=nodes[c["owner"] as! Int]!;let triangles=c["triangles"] as! [[[Double]]];let local=triangles.flatMap{$0}.map{n.convertPosition(SCNVector3($0[0],$0[1],$0[2]),from:world)}
 let original=n.position
 for displacement in [0.0,0.125]{n.position=SCNVector3(original.x+displacement,original.y,original.z);let m=n.convertTransform(SCNMatrix4Identity,to:world)
 for v in local{let a=n.convertPosition(v,to:world);let b=SCNVector3(v.x*m.m11+v.y*m.m21+v.z*m.m31+m.m41,v.x*m.m12+v.y*m.m22+v.z*m.m32+m.m42,v.x*m.m13+v.y*m.m23+v.z*m.m33+m.m43);maxError=max(maxError,abs(a.x-b.x),abs(a.y-b.y),abs(a.z-b.z));points+=1}}
 n.position=original;shapes+=1
}
precondition(maxError<0.0001)
print("{\"shapes\":\(shapes),\"pointsCompared\":\(points),\"maximumPositionDifference\":\(maxError),\"nativeCallsPerUpdateBeforeAllShapes\":\(points/2),\"nativeCallsPerUpdateAfterAllShapes\":\(shapes)}")
