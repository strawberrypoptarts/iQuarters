"""Run the shared presentation state machine against actual assets without a GPU.
Requires the sibling iQuarters-web checkout for its existing platform adapter.
The host replaces only browser I/O; all menu/game code and animation sampling run.
"""
from pathlib import Path
import tempfile,subprocess,os
root=Path(__file__).resolve().parents[2];web=root.parent/'iQuarters-web/Recovered';temp=Path(tempfile.mkdtemp(prefix='iquarters-presentation-'))
platform=(web/'Web/PlatformAdapter.cs').read_text().replace('public string ResourcePath=>"/";',f'public string ResourcePath=>@"{temp}";')
(temp/'PlatformAdapter.cs').write_text(platform)
os.symlink(root/'Recovery/converted',temp/'RecoveredAssets',target_is_directory=True)
(temp/'Host.cs').write_text('''namespace IQuarters.Web;
public static class WebBridge {
 static readonly Dictionary<string,string> prefs=[];
 public static string Hit(int root,int camera,double x,double y)=>"";
 public static double[] Project(int camera,double x,double y,double z)=>[0,0,0];
 public static void PlayAudio(string file,int channel,double volume){} public static void StopAudio(int channel){} public static void AudioPause(){} public static void AudioResume(){}
 public static string? Load(string key)=>prefs.GetValueOrDefault(key);public static void Save(string key,string value)=>prefs[key]=value;public static void Remove(string key)=>prefs.Remove(key);
 public static string Prompt(string message,string value)=>value;public static void Alert(string message)=>throw new Exception(message);
 public static void ReleaseScenes(params SceneKit.SCNScene?[] scenes){}
}''')
(temp/'Test.csproj').write_text(f'''<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework><ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable><DefineConstants>BROWSER</DefineConstants><NoWarn>CS8981</NoWarn></PropertyGroup><ItemGroup><ProjectReference Include="{root}/Recovered/Core/IQuarters.Core.csproj"/><Compile Include="{web}/Presentation/*.cs"/><Compile Include="{web}/Web/SceneAdapter.cs"/><Compile Include="{root}/Recovered/PresentationTests/Program.cs"/></ItemGroup></Project>''')
env=os.environ|{'DOTNET_CLI_HOME':str(root/'.dotnet-home')}
subprocess.run([str(root/'.dotnet/dotnet'),'run','--project',str(temp/'Test.csproj'),'-p:UseSharedCompilation=false'],env=env,check=True)
