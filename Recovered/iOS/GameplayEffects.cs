using SceneKit;
using IQuarters.Core;
namespace IQuarters.iOS;

public sealed partial class GameViewController
{
    // Timings and clip ranges recovered from QuarterTrigger, Streak,
    // GlassScaleController, RoundComplete and CoinHolderController.
    readonly List<(float At,Action Run)> effects=[];
    float effectClock,glassPulseTime;
    SCNNode? pulsingGlass;
    SCNVector3 glassScale;
    static readonly int[] effectDigitTextures=[57,13,38,79,50,35,40,36,58,25];
    void After(float seconds,Action run)=>effects.Add((effectClock+seconds,run));
    void TickEffects(float dt)
    {
        effectClock+=dt;
        if(round==11&&!game.Nodes[957].Hidden){var p=game.Nodes[957].Position;var glass=game.Nodes[990].Position;game.Nodes[957].Position=new(glass.X,p.Y,glass.Z);}
        if(!ui.Nodes[677].Hidden)ui.Nodes[674].Opacity=Math.Clamp(ui.Nodes[668].Scale.X-1,0,1);
        if(pulsingGlass!=null){
            glassPulseTime+=dt;game.Sample(1983,"Take 001",Math.Min(.7f,glassPulseTime*1.05f));
            float factor=(game.Nodes[1983].Scale.X-1)*.75f+1;
            pulsingGlass.Scale=new(glassScale.X*factor,glassScale.Y*factor,glassScale.Z);
            if(glassPulseTime>=2f/3){pulsingGlass.Scale=glassScale;pulsingGlass=null;}
        }
        for(int i=0;i<effects.Count;){if(effects[i].At>effectClock){i++;continue;}var action=effects[i].Run;effects.RemoveAt(i);action();}
    }
    void EffectSound(int asset,int channel=1,float volume=1,bool shared0=false)
    {if(!GameStorage.Muted)audio?.Play($"sharedassets{(shared0?0:1)}.assets-{asset}.wav",channel,volume);}
    void SlideBannerIn(){ui.Show("ex_round_mon");var number=ui.Find("ex_round_mon")!.ChildNodes.FirstOrDefault(n=>n.Name==(round==12?"secret":$"{round+1:00}"));if(number!=null){var e=number.EulerAngles;e.Y=0;number.EulerAngles=e;}ui.PlayRange(ui.Id("ex_round_mon"),"Take 001",0,.4f);}
    void SlideBannerOut()=>ui.PlayRange(ui.Id("ex_round_mon"),"Take 001",50f/30,55f/30,()=>ui.Find("ex_round_mon")!.Hidden=true);
    static SCNNode? GlassRenderer(SCNNode root)
    {
        if(root.Geometry!=null&&root.Opacity>.01f)return root;
        foreach(var child in root.ChildNodes){var found=GlassRenderer(child);if(found!=null)return found;}return null;
    }
    void PlayExciter(int id,string? clip=null,Action? done=null)
    {
        var root=ui.Nodes[id];LegacyScene.Activate(root);
        for(var p=root.ParentNode;p!=null;p=p.ParentNode)p.Hidden=false;
        void Complete(){root.Hidden=true;done?.Invoke();}
        if(clip==null)ui.PlayDefault(id,Complete);else ui.Play(id,clip,Complete);
    }
    void EffectDigit(int id,int digit,bool visible=true){ui.Nodes[id].Opacity=visible?1:0;if(visible)Texture(ui.Nodes[id],effectDigitTextures[Math.Clamp(digit,0,9)]);}
    void CelebrateShot(ShotSimulation result)
    {
        state="effects";int multiplier=result.Multiplier;
        session.AddScore(multiplier*25);
        if(multiplier==0){if(result.Position.Y< -10)EffectSound(593,0);After(.3f,()=>CommitShot(0));return;}
        session.IncrementCurrentStreak();session.UpdateCurRicochet(result.Ricochets);Hud();
        if(PresentationRules.RoundStinger(session.IsPractice,session.curMadeShotsThisRound,multiplier))EffectSound(596);if(session.IsPractice)EffectSound(130,3,1,true);
        if(game.Nodes.TryGetValue(result.ScoringOwner,out var body)&&game.Records[result.ScoringOwner].GetProperty("tag").GetInt32()!=20002){
            pulsingGlass=GlassRenderer(body);if(pulsingGlass!=null){glassScale=pulsingGlass.Scale;glassPulseTime=0;}
        }
        var glow=game.Nodes[957];LegacyScene.Activate(glow);var at=coin.Position;at.Y-=.12f;glow.Position=at;
        game.Play(957,"Take 001",()=>glow.Hidden=true,speed:2);
        int streak=session.GetCurrentTotalStreak();
        if(streak>1){PlayExciter(1319);EffectDigit(1310,streak%10,streak>=10);EffectDigit(1313,streak/10%10,streak>=10);EffectDigit(1307,streak%10,streak<10);}
        if(multiplier>1){PlayExciter(677);Texture(ui.Nodes[674],multiplier switch{2=>49,3=>82,4=>74,_=>2});ui.Nodes[674].Opacity=1;ui.Nodes[668].Opacity=0;}
        EffectSound(597,2,session.curMadeShotsThisRound>=2?1:.5f);
        int slot=Math.Min(3,session.curMadeShotsThisRound+1),flies=Math.Min(9,multiplier);
        for(int i=0;i<flies;i++)After(.75f+i*.2f,()=>FlyCoin(slot));
        float finish=.75f+(flies-1)*.2f+.5f;
        After(finish,()=>{
            if(result.Ricochets==0){CommitShot(multiplier);return;}
            BeginAutomaticReplay(()=>{
                int scoreOwner=ui.Id("ui_richochet_score");LegacyScene.Activate(ui.Nodes[scoreOwner]);ui.PlayRange(scoreOwner,"Take 001",0,45f/30,()=>ui.Nodes[scoreOwner].Hidden=true);
                var root=ui.Find("ui_richochet_score")!;
                var marker=root.FindChildNode("center_marker",true);if(marker!=null)marker.Hidden=true;
                var ones=root.FindChildNode("rs_01",true);var tens=root.FindChildNode("rs_02",true);
                if(ones!=null)Texture(ones,effectDigitTextures[result.Ricochets%10]);if(tens!=null)Texture(tens,effectDigitTextures[0]);
                EffectSound(130,3,1,true);
                After(45f/30,()=>{
                    session.AddScore(result.Ricochets*10);Hud();
                    foreach(var n in ui.Nodes[1019].ChildNodes)if(n.Name?.StartsWith("ui_richochet_coin")==true)n.Hidden=true;
                    ui.PlayRange(ui.Id("ui_richochet_holder"),"Take 001",15f/30,20f/30,()=>{ui.Nodes[1019].Hidden=true;CommitShot(multiplier);});
                });
            });
        });
    }
    Action? afterAutomaticReplay;int replayContacts;
    void BeginAutomaticReplay(Action done)
    {
        beforeReplay=Capture();returnRound=round;replayFrame=0;replayTime=0;replayContacts=0;
        afterAutomaticReplay=done;UseReplayCamera();state="replay";
        ui.Show("RicochetParent");foreach(var n in ui.Nodes[1019].ChildNodes)if(n.Name?.StartsWith("ui_richochet_coin")==true)n.Hidden=true;
        var holder=ui.Find("ui_richochet_holder")!;ui.PlayRange(ui.Id(holder.Name!),"Take 001",0,8f/30);
    }
    void ReplayContactEffect(int ricochets)
    {
        // Use the same filtered collision chain as scoring, not raw solver contacts.
        int count=Math.Clamp(ricochets,0,9);
        if(count<=replayContacts)return;
        while(replayContacts<count){var n=ui.Find($"ui_richochet_coin0{replayContacts}");if(n!=null){LegacyScene.Activate(n);ui.PlayDefault(ui.Id(n.Name!));}replayContacts++;}
        EffectSound(598,3);
    }

    void FlyCoin(int slot)
    {
        ui.Show("ui_ingame_3coin_root");var root=ui.Nodes[2102];root.Hidden=false;
        foreach(var n in root.ChildNodes)n.Opacity=n.Name==$"quarter_card_0{slot}"?1:0;
        float start=slot==1?0:slot==2?40f/30:80f/30;
        ui.PlayRange(2102,"Take 001",start,start+20f/30,()=>{root.Hidden=true;var holder=ui.Find("ui_ingame_3coin_hold")!;holder.ChildNodes.First(n=>n.Name==$"quarter_card_0{slot}").Opacity=1;});
    }
    void RoundCompleteEffect(int score,bool newHigh,Action done)
    {
        state="effects";PlayExciter(236,newHigh?"newroundhigh":$"rnd{round+1:00}",done);
        foreach(var n in ui.Nodes[236].ChildNodes){if(int.TryParse(n.Name,out _))n.Hidden=newHigh||n.Name!=$"{round+1:00}";else if(n.Name?.StartsWith("new_high_")==true)n.Hidden=!newHigh;else if(n.Name is "round_graphic" or "complete_graphic")n.Hidden=newHigh;}
        int[] ids=[325,328,331,284,367];foreach(int id in ids)ui.Nodes[id].Opacity=0;
        if(newHigh){int start=score<100?3:0,count=score<100?2:3;for(int i=0;i<count;i++)EffectDigit(ids[start+i],score/(int)Math.Pow(10,i)%10);}
    }
    void PracticeScoreEffect(int score,Action done)
    {
        state="effects";PlayExciter(1176,null,done);var root=ui.Nodes[1176];
        string[] names=["hs_03","hs_02","hs_01","hs_05","hs_04"];
        int start=score<100?3:0,count=score<100?2:3;
        for(int i=0;i<5;i++){var node=root.FindChildNode(names[i],true)!;bool show=i>=start&&i<start+count;node.Opacity=show?1:0;if(show)Texture(node,effectDigitTextures[score/(int)Math.Pow(10,i-start)%10]);}
    }
    void GameOverEffect(bool outOfCoins,Action done){state="effects";PlayExciter(282,outOfCoins?"outofshots":"gamecomplete",done);}
}
