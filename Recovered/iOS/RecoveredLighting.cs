using SceneKit;
using System.Text.Json;
using System.Globalization;
namespace IQuarters.iOS;
public sealed partial class LegacyScene
{
    JsonElement lighting;
    static UIColor Color(JsonElement e)=>UIColor.FromRGBA(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle(),e[3].GetSingle());
    void ConfigureMaterial(SCNMaterial material,string key,JsonElement data)
    {
        if(!lighting.GetProperty("materials").TryGetProperty(key,out var shader))return;
        if(data.GetProperty("name").GetString()=="shadow_00"){
            material.LightingModelName=SCNLightingModel.Constant;material.WritesToDepthBuffer=false;material.TransparencyMode=SCNTransparencyMode.AOne;return;
        }
        if(shader.GetProperty("name").GetString()=="Particle Add"){
            var glowTint=data.GetProperty("colors").GetProperty("_TintColor");
            material.LightingModelName=SCNLightingModel.Constant;material.BlendMode=SCNBlendMode.Add;
            material.WritesToDepthBuffer=false;material.TransparencyMode=SCNTransparencyMode.AOne;
            string C(float v)=>v.ToString("R",CultureInfo.InvariantCulture);
            material.ShaderModifiers=new SCNShaderModifiers {
                EntryPointGeometry="#pragma varyings\nfloat recoveredGlowAlpha;\n#pragma body\nout.recoveredGlowAlpha = _geometry.color.a;\n_geometry.color = float4(1.0);",
                EntryPointSurface=$"_surface.diffuse *= float4({C(glowTint[0].GetSingle()*2)}, {C(glowTint[1].GetSingle()*2)}, {C(glowTint[2].GetSingle()*2)}, {C(glowTint[3].GetSingle()*2)} * in.recoveredGlowAlpha);"
            };return;
        }
        if(data.GetProperty("name").GetString()=="flash_00"){
            material.LightingModelName=SCNLightingModel.Constant;material.BlendMode=SCNBlendMode.Add;
            material.WritesToDepthBuffer=false;material.TransparencyMode=SCNTransparencyMode.AOne;return;
        }
        bool vertexLit=shader.GetProperty("vertexLit").GetBoolean();
        material.LightingModelName=vertexLit?SCNLightingModel.Phong:SCNLightingModel.Lambert;
        material.LitPerPixel=!vertexLit;
        var colors=data.GetProperty("colors");

        if(colors.TryGetProperty("_Emission",out var emission)&&emission[0].GetSingle()>=1&&emission[1].GetSingle()>=1&&emission[2].GetSingle()>=1){
            // The room photographs are fully self-lit in the IPA. Preserve their texture;
            // a flat white SceneKit emission color would erase it.
            material.LightingModelName=SCNLightingModel.Constant;return;
        }
        string F(float x)=>x.ToString("R",CultureInfo.InvariantCulture);
        string surface="";
        if(colors.TryGetProperty("_Emission",out var e))surface+=$"_surface.emission.rgb = _surface.diffuse.rgb * float3({F(e[0].GetSingle())}, {F(e[1].GetSingle())}, {F(e[2].GetSingle())});\n";
        if(data.GetProperty("textures").TryGetProperty("_MainTex",out _)&&colors.TryGetProperty("_Color",out var tint))surface+=$"_surface.diffuse *= float4({F(tint[0].GetSingle())}, {F(tint[1].GetSingle())}, {F(tint[2].GetSingle())}, {F(tint[3].GetSingle())});";
        bool glass=data.GetProperty("name").GetString()=="shotglass_00";
        if(surface!="")material.ShaderModifiers=new SCNShaderModifiers{EntryPointSurface=surface,EntryPointFragment=glass?"_output.color.rgb *= 2.0;":null};
        if(glass){material.WritesToDepthBuffer=false;material.TransparencyMode=SCNTransparencyMode.AOne;}
        if(vertexLit&&colors.TryGetProperty("_SpecColor",out var specular))material.Specular.Contents=Color(specular);
        if(data.GetProperty("floats").TryGetProperty("_Shininess",out var shine))material.Shininess=shine.GetSingle()*128;
        // SceneKit uses a different lighting/color pipeline. Do not blindly multiply
        // its already-composited output by the legacy fixed-function DOUBLE flag.
    }
    public void ShowGlassShadows(int round)
    {
        foreach(var n in Nodes.Values)if(n.Name?.StartsWith("glassShadow")==true)n.Hidden=true;
        foreach(var item in lighting.GetProperty("roundShadows")[round].EnumerateArray()){
            var glass=Nodes[item.GetProperty("glass").GetInt32()];var shadow=Nodes[item.GetProperty("shadow").GetInt32()];
            shadow.Hidden=false;shadow.Opacity=1;var p=glass.Position;shadow.Position=new(p.X,shadow.Position.Y,p.Z);
            float scale=item.GetProperty("scale").GetSingle();shadow.Scale=new(scale,shadow.Scale.Y,scale);
        }
    }
    public void RestoreLighting()
    {
        var ambient=new SCNNode {Name="Recovered ambient",Light=new SCNLight {LightType=SCNLightType.Ambient,Color=Color(lighting.GetProperty("ambient")),Intensity=1000}};Scene.RootNode.AddChildNode(ambient);
        foreach(var source in lighting.GetProperty("lights").EnumerateArray()){
            int owner=source.GetProperty("owner").GetInt32();var record=Records[owner];uint mask=source.GetProperty("mask").GetUInt32();
            if(!source.GetProperty("enabled").GetBoolean()||!record.GetProperty("active").GetBoolean()||(mask&0xf00)==0)continue;
            var node=Nodes[owner];node.Hidden=false;
            // Attach a child rotated 180 degrees: Unity lights face +Z, SceneKit -Z.
            var lamp=new SCNNode {EulerAngles=new(0,MathF.PI,0),Light=new SCNLight {
                LightType=source.GetProperty("type").GetInt32() switch{0=>SCNLightType.Spot,1=>SCNLightType.Directional,_=>SCNLightType.Omni},
                Color=Color(source.GetProperty("color")),Intensity=source.GetProperty("intensity").GetSingle()*1000,
                CategoryBitMask=(nuint)mask,CastsShadow=false,
                AttenuationStartDistance=0,AttenuationEndDistance=source.GetProperty("range").GetSingle(),AttenuationFalloffExponent=2,
                SpotInnerAngle=0,SpotOuterAngle=source.GetProperty("spotAngle").GetSingle()
            }};node.AddChildNode(lamp);
        }
    }
}
