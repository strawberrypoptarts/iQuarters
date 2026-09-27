using Mono.Cecil;
using System.Text.Json;
var asm=AssemblyDefinition.ReadAssembly(args[0]);
if(args.Length==1){Console.WriteLine(JsonSerializer.Serialize(asm.MainModule.Types.SelectMany(t=>t.Methods).Select(m=>new {rid=m.MetadataToken.RID,type=m.DeclaringType.Name,name=m.Name,signature=m.FullName}),new JsonSerializerOptions{WriteIndented=true}));return;}
foreach(var t in asm.MainModule.Types.Where(t=>t.Name.Contains(args[1]))){
foreach(var f in t.Fields)Console.WriteLine($"FIELD {f.MetadataToken.RID} {f.FieldType} {f.Name} static={f.IsStatic}");
foreach(var m in t.Methods.Where(m=>args.Length<3||m.Name==args[2])){Console.WriteLine($"METHOD {m.MetadataToken.RID} {m.FullName}");if(m.HasBody)foreach(var i in m.Body.Instructions)Console.WriteLine(i);}}
