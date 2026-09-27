using IQuarters.Core;
using System.Numerics;
using System.Text.Json;
using System.Diagnostics;
using System.Security.Cryptography;
var root=args[0];var body=CoinBody.Read(File.ReadAllText(Path.Combine(root,"physics.json")));
using var sceneDoc=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"scene.json")));
using var collisionDoc=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"collision.json")));
var scene=sceneDoc.RootElement;var tables=scene.GetProperty("nodes").EnumerateArray().Where(n=>n.GetProperty("name").GetString() is "TableTop" or "table_00").Select(n=>n.GetProperty("id").GetInt32());
var rounds=scene.GetProperty("rounds").EnumerateArray().Select(r=>{
 var ids=r.EnumerateArray().Select(x=>x.GetInt32()).Concat(tables).ToHashSet();return collisionDoc.RootElement.EnumerateArray().Where(c=>c.GetProperty("ancestors").EnumerateArray().Any(v=>ids.Contains(v.GetInt32()))).Select(c=>{
 var s=new CollisionShape{Owner=c.GetProperty("body").GetInt32(),ColliderId=c.GetProperty("collider").GetInt32(),Material=SurfaceMaterial.Read(c.GetProperty("material")),Multiplier=c.GetProperty("multiplier").GetInt32(),Triangles=c.GetProperty("triangles").EnumerateArray().Select(t=>t.EnumerateArray().Select(CoinBody.ReadVector).ToArray()).ToArray()};s.Prepare();return s;}).ToArray();}).ToArray();
void Run(Stream trace){using var writer=new BinaryWriter(trace,System.Text.Encoding.UTF8,true);foreach(var shapes in rounds)foreach(float aim in new[]{-1f,0,1f}){var shot=new ShotSimulation(new(0,2.4759626f,-4.3104444f),1,50,aim,shapes,body:body);for(int f=0;f<400&&!shot.Finished;f++){shot.Advance(1f/60);foreach(var v in new[]{shot.Position.X,shot.Position.Y,shot.Position.Z,shot.Velocity.X,shot.Velocity.Y,shot.Velocity.Z,shot.Orientation.X,shot.Orientation.Y,shot.Orientation.Z,shot.Orientation.W})writer.Write(v);writer.Write(shot.ContactCount);}writer.Write(shot.Multiplier);writer.Write(shot.Ricochets);}}
Run(Stream.Null);var results=new List<object>();for(int pass=0;pass<3;pass++){GC.Collect();long alloc=GC.GetAllocatedBytesForCurrentThread();var sw=Stopwatch.StartNew();using var trace=new MemoryStream();Run(trace);sw.Stop();alloc=GC.GetAllocatedBytesForCurrentThread()-alloc;results.Add(new{milliseconds=sw.Elapsed.TotalMilliseconds,allocatedBytes=alloc,traceSha256=Convert.ToHexString(SHA256.HashData(trace.ToArray())).ToLowerInvariant()});}
Console.WriteLine(JsonSerializer.Serialize(new{shotsPerPass=39,passes=results},new JsonSerializerOptions{WriteIndented=true}));
