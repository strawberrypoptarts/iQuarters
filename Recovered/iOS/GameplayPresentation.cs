using SceneKit;
using CoreGraphics;
using IQuarters.Core;
using System.Numerics;
namespace IQuarters.iOS;

public sealed partial class GameViewController
{
    (int Id,SCNNode Node)[] replayNodes=[];
    void CacheReplayNodes()=>replayNodes=game.Nodes.Where(pair=>{
        if(pair.Value!=coin&&!game.AnimatedNodes.Contains(pair.Value))return false;
        for(SCNNode? n=pair.Value;n!=null;n=n.ParentNode)if(n.Hidden)return false;return true;
    }).Select(pair=>(pair.Key,pair.Value)).ToArray();
    NodePose[] Capture(){var poses=new NodePose[replayNodes.Length];for(int i=0;i<poses.Length;i++){var (id,n)=replayNodes[i];poses[i]=new(id,n.Position,n.Orientation,n.Scale);}return poses;}
    void Restore(NodePose[] poses){foreach(var pose in poses){var n=game.Nodes[pose.Id];n.Position=pose.Position;n.Orientation=pose.Orientation;n.Scale=pose.Scale;}}
    void React(int owner)
    {
        if(!GameStorage.Muted&&presentation.GetProperty("audioSources").TryGetProperty(owner.ToString(),out var source))audio?.Play(source.GetProperty("file").GetString()!,3,source.GetProperty("volume").GetSingle());
        var reaction=physics.GetProperty("reactions").GetProperty(owner.ToString());int hinge=reaction.GetProperty("hinge").GetInt32();
        game.PlayDefault(owner,()=>{if(hinge!=0&&game.Nodes.TryGetValue(hinge,out var n))n.Orientation=new(0,0,0,1);});
    }
    void UpdateCameraAndShadow(float dt)
    {
        // MainCameraScript.LateUpdate and its saved damping/yOffset values.
        if(usingReplayCamera)FollowReplayCamera(dt);
        else FollowMainCamera(dt);
        // ShadowQuarterScript.Update, including its table bounds and lazy Susan lift.
        var shadow=game.Nodes[1962];shadow.Hidden=false;shadow.Opacity=1;var p=coin.Position;float z=Math.Max(p.Z,-3.5f),y=p.Y<.1f?-10:.05f;
        if(round==11&&game.Find("lazy_susan_00") is {} susan&&MathF.Sqrt(MathF.Pow(susan.Position.X-p.X,2)+MathF.Pow(susan.Position.Z-z,2))<3)y+=.17f;
        shadow.Position=new(p.X,y,z);float size=p.Y<0?.1f:.1f+p.Y*.02f;if(Math.Abs(p.X)>4.2f||Math.Abs(z)>4)size=0;shadow.Scale=new(size,shadow.Scale.Y,size);
    }
    void FollowMainCamera(float dt,bool snap=false)
    {
        float target=(angle-50)/5;cameraT=snap?target:cameraT+(target-cameraT)*CameraFollow.Blend(.2f,dt);float t=Math.Clamp(cameraT,0,1);
        camera.Position=new(0,4.815438f+(-.007f+.014f*t),6.119505f-(-.05f+.1f*t));
        var p=coin.WorldPosition;var direction=new Vector3(p.X-camera.Position.X,Math.Max(p.Y-camera.Position.Y+1,-5),p.Z-camera.Position.Z);
        var old=camera.Orientation;var previous=new Quaternion(old.X,old.Y,old.Z,old.W);
        var q=snap?CameraFollow.LevelLook(direction,previous):CameraFollow.Follow(previous,direction,CameraFollow.Blend(3f/60,dt));
        camera.Orientation=new(q.X,q.Y,q.Z,q.W);
    }
    void CollisionSound(CollisionShape? shape)
    {
        if(shape==null||shape.Owner==0||!physics.GetProperty("bodies").TryGetProperty(shape.Owner.ToString(),out var body))return;
        int type=(int)body.GetProperty("mass").GetSingle();float time=shot?.Elapsed??0;
        if(type==lastSoundType&&time-lastSoundTime<=.01f)return;
        string field=type switch{2=>"glassMartiniSounds",3 or 5 or 6=>Random.Shared.Next(2)==0?"glassMediumSounds":"glassBigSounds",4=>"glassSmallSounds",7=>"glassTallSounds",8=>"lazySusanSounds",9=>"tableTopSounds",10=>"whiskeyBottleSounds",11=>"popBottleSounds",12=>"drinkingBirdSounds",13=>"checkBookSounds",14=>"bobbleHeadSounds",15=>"planeSounds",16=>"lighterSounds",17=>"phoneSounds",18=>"catapultSounds",19=>"pendulumSounds",_=>""};
        if(field=="")return;var fields=physics.GetProperty("quarterFields");var sounds=fields.GetProperty(field);if(sounds.GetArrayLength()==0)return;
        int played=soundCounts.GetValueOrDefault(type);int index=Math.Min(played,sounds.GetArrayLength()-1);
        if(shape.Owner==fields.GetProperty("RoundFourteenGlass02")[1].GetInt32())index%=2;
        var clip=sounds[index];Sound((clip[0].GetInt32()==3?"sharedassets0.assets-":"sharedassets1.assets-")+clip[1].GetInt32()+".wav");soundCounts[type]=played+1;lastSoundType=type;lastSoundTime=time;
    }
    void PromptNames(int index)
    {
        if(index>=session.playerData.Count){state="stats";Text(string.Join("\n\n",session.playerData.Cast<PlayerInfoClass>().Select(p=>$"{p.playerName}    {p.score}\nBEST STREAK {p.maxStreak}   COINS {p.shotsLeft}")),.3f,.4f);return;}
        var player=(PlayerInfoClass)session.playerData[index]!;
        if(player.nameEnteredFlag||!GameStorage.Scores.Any(s=>s.Id==player.recoveredScoreId)){PromptNames(index+1);return;}
        state="names";var prompt=UIAlertController.Create("New high score",$"Player {index+1}: {player.score}",UIAlertControllerStyle.Alert);
        prompt.AddTextField(t=>{t.Text=player.playerName;t.AutocorrectionType=UITextAutocorrectionType.No;t.AutocapitalizationType=UITextAutocapitalizationType.AllCharacters;});
        prompt.AddAction(UIAlertAction.Create("Done",UIAlertActionStyle.Default,_=>{var name=prompt.TextFields![0].Text?.Trim();if(!string.IsNullOrWhiteSpace(name))player.playerName=new string(name.Take(10).ToArray());player.nameEnteredFlag=true;GameStorage.RenameScore(player.recoveredScoreId,player.playerName);PromptNames(index+1);}));
        PresentViewController(prompt,true,null);
    }
}
