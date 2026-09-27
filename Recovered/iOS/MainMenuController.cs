using SceneKit;
using CoreGraphics;
using AVFoundation;
using IQuarters.Core;
namespace IQuarters.iOS;

public sealed class MainMenuController : UIViewController
{
    LegacyScene legacy=null!;SCNView display=null!;DisplayFrameLoop? frameLoop;AVAudioPlayer? audio;
    readonly UIView textLayer=new();
    UILabel? loadingLabel;
    string screen="busy";bool roundScores;
    int Main=>legacy.Id("ui_main_menu_00");
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();View!.BackgroundColor=UIColor.Black;
        legacy=new LegacyScene("frontend.json",true);legacy.HideRoots();
        var camera=new SCNNode {Position=new SCNVector3(0,0,1000),Camera=new SCNCamera {UsesOrthographicProjection=true,OrthographicScale=100,ZNear=.3,ZFar=1100}};legacy.Scene.RootNode.AddChildNode(camera);
        display=new SCNView(View.Bounds){Scene=legacy.Scene,PointOfView=camera,BackgroundColor=UIColor.Black,AutoresizingMask=UIViewAutoresizing.FlexibleDimensions};View.AddSubview(display);
        textLayer.Frame=View.Bounds;textLayer.AutoresizingMask=UIViewAutoresizing.FlexibleDimensions;textLayer.UserInteractionEnabled=false;View.AddSubview(textLayer);
        display.AddGestureRecognizer(new UITapGestureRecognizer(g=>Tap(g.LocationInView(display))));
        Home(true);
    }
    public override void ViewDidAppear(bool animated){base.ViewDidAppear(animated);frameLoop?.Dispose();frameLoop=new(View!.Window?.Screen??UIScreen.MainScreen,dt=>legacy.Tick(dt),display);}
    public override void ViewDidDisappear(bool animated){base.ViewDidDisappear(animated);frameLoop?.Dispose();frameLoop=null;}
    public override void ViewDidLayoutSubviews(){base.ViewDidLayoutSubviews();if(display==null||View!.Bounds.Width<=0||View.Bounds.Height<=0)return;double scale=Math.Max(100,66.666667*(double)View!.Bounds.Height/(double)View.Bounds.Width);display.ContentScaleFactor=View.Window?.Screen.NativeScale??UIScreen.MainScreen.NativeScale;display.PointOfView!.Camera!.OrthographicScale=scale;var backdrop=legacy.Find("backdrop");if(backdrop!=null){backdrop.Scale=new(33*(float)Math.Max(1,((double)View.Bounds.Width/(double)View.Bounds.Height)/(2d/3)),33,33*(float)(scale/100));}if(screen=="scores")ScoreText();if(loadingLabel!=null)LayoutLoading();}
    void Sound(string file){if(GameStorage.Muted)return;audio?.Stop();audio?.Dispose();audio=AVAudioPlayer.FromUrl(NSUrl.FromFilename(LegacyScene.Resource("audio/"+file)));audio?.Play();}
    void ClearText(){foreach(var child in textLayer.Subviews)child.RemoveFromSuperview();}
    void Text(string text,CGRect rect,double size=18)
    {
        var label=new UILabel(rect){Text=text,TextColor=UIColor.White,TextAlignment=UITextAlignment.Center,Lines=0,Font=UIFont.BoldSystemFontOfSize((nfloat)size)!,AdjustsFontSizeToFitWidth=true,MinimumScaleFactor=.6f};label.Layer.ShadowColor=UIColor.Black.CGColor;label.Layer.ShadowOpacity=1;label.Layer.ShadowOffset=new CGSize(1,2);textLayer.AddSubview(label);
    }
    void Home(bool intro=false)
    {
        screen="busy";ClearText();legacy.HideRoots();legacy.Show("backdrop");legacy.Show("ui_main_menu_00");legacy.Show("ui_about");
        foreach(var n in legacy.Nodes.Values)if(n.Name is "dimplane" or "about_text"||n.Name?.StartsWith("high_score_bg_")==true)n.Opacity=0;
        var about=legacy.Find("itme");if(about!=null)about.Opacity=1;
        legacy.Play(Main,"intro",()=>{screen="main";if(intro&&GameStorage.Load()!=null)ResumePrompt();});
        if(intro)Sound("sharedassets0.assets-130.wav");
    }
    void Sequence(string[] clips,Action complete)
    {
        screen="busy";void Next(int i){if(i==clips.Length){complete();return;}legacy.Play(Main,clips[i],()=>Next(i+1));}Next(0);
    }
    void ResumePrompt()
    {
        legacy.Show("ui_resume");foreach(var c in legacy.Find("ui_resume")!.ChildNodes)c.Opacity=1;screen="resume";
    }
    static bool Visible(SCNNode node){for(SCNNode? n=node;n!=null;n=n.ParentNode)if(n.Hidden||n.Opacity<.01)return false;return true;}
    public override bool PrefersStatusBarHidden()=>true;
    void Tap(CGPoint point)
    {
        if(screen=="busy")return;
        var hits=display.HitTest(point,new SCNHitTestOptions {IgnoreHiddenNodes=true});
        string name=hits.Where(h=>Visible(h.Node)).Select(h=>h.Node.Name??"").FirstOrDefault(n=>n.StartsWith("button_")||n is "itme" or "yes" or "no")??"";
        if(screen=="about"){Home();return;}
        if(name=="")return;Sound("sharedassets0.assets-131.wav");
        if(screen=="resume") {if(name=="yes"){var saved=GameStorage.Load();if(saved!=null)Start(saved,false);else Home();}else if(name=="no"){GameStorage.ClearSaved();Home();}return;}
        if(screen=="clear") {if(name=="yes")GameStorage.ClearScores();if(name is "yes" or "no"){legacy.Find("ui_are_you_sure")!.Hidden=true;screen="scores";ScoreText();}return;}
        if(screen=="main") {
            if(name=="button_playnow"){legacy.Find("ui_about")!.Hidden=true;Sequence(["playnowclick","playnowout","gtin"],()=>{screen="type";SetPracticeTexture();});}
            else if(name=="button_highscore"){legacy.Find("ui_about")!.Hidden=true;Sequence(["hiscoreclick","playnowout"],Scores);}
            else if(name=="itme"){Sequence(["playnowout"],About);}
        } else if(screen=="type") {
            if(name=="button_classic")Sequence(["gtclassicclick","gtout","npin"],()=>screen="players");
            else if(name=="button_practice"&&GameStorage.Unlocked>=2)Sequence(["gtpracticeclick","gtpracticeout"],()=>Start(new GameSession(1,true),true));
            else if(name is "button_button_left" or "button_right_bk")Sequence(["gtbackclick","gtout"],()=>Home());
        } else if(screen=="players") {
            if(name.StartsWith("button_player_")&&int.TryParse(name[^2..],out int count)) {
                string[] clips=["nponeplayer","nptwoplayer","npthreeplayer","npfourplayer"];
                Sequence([clips[count-1],"npout"],()=>Start(new GameSession(count),false));
            }else if(name is "button_button_left" or "button_right_bk")Sequence(["npbackclick","npout","gtin"],()=>screen="type");
        } else if(screen=="scores") {
            if(name=="button_back_hs")Home();
            else if(name=="button_clear_hs"){ClearText();legacy.Show("ui_are_you_sure");foreach(var n in legacy.Find("ui_are_you_sure")!.ChildNodes)n.Opacity=1;screen="clear";}
            else if(name is "button_roundhigh" or "button_highscore"){roundScores=name=="button_roundhigh";ShowScorePanel();}
        }
    }
    void SetPracticeTexture()
    {
        var n=legacy.Find("button_practice");if(n?.Geometry!=null)n.Geometry.FirstMaterial!.Diffuse.Contents=UIImage.FromFile(LegacyScene.Resource("textures/sharedassets0.assets-"+(GameStorage.Unlocked<2?16:13)+".png"));
    }
    void Scores()
    {
        screen="busy";roundScores=false;ClearText();legacy.HideRoots();legacy.Show("backdrop");
        foreach(var name in new[]{"ui_back_clear","ui_button_high_round","ui_quarter_logo_score"}){legacy.Show(name);foreach(var n in legacy.Find(name)!.ChildNodes)n.Opacity=1;legacy.PlayRange(legacy.Id(name),"Take 001",0,16f/30);}
        ShowScorePanel();
    }
    void ShowScorePanel()
    {
        screen="busy";ClearText();legacy.Find("ui_high_high")!.Hidden=roundScores;legacy.Find("ui_round_high")!.Hidden=!roundScores;
        string name=roundScores?"ui_round_high":"ui_high_high";legacy.Show(name);foreach(var n in legacy.Find(name)!.ChildNodes)n.Opacity=1;
        legacy.PlayRange(legacy.Id(name),"Take 001",0,(roundScores?30f:22f)/30,()=>{screen="scores";ScoreText();});
    }
    void ScoreText()
    {
        ClearText();var rows=GameStorage.Scores;var root=legacy.Find(roundScores?"ui_round_high":"ui_high_high")!;
        foreach(var node in root.ChildNodes.Where(n=>n.Name?.StartsWith("high_score_bg_")==true)) {
            if(!int.TryParse(node.Name![^2..],out int index))continue;
            var p=display.ProjectPoint(node.WorldPosition);string text=roundScores?$"ROUND {index+1}        {GameStorage.RoundScore(index)}":index<rows.Count?$"{rows[index].Name}        {rows[index].Score}":"EMPTY        0";
            Text(text,new CGRect(View!.Bounds.Width*.17,p.Y-12,View.Bounds.Width*.66,24),Math.Min(20,(double)View.Bounds.Width/23));
        }
    }
    void About()
    {
        screen="about";ClearText();legacy.HideRoots();legacy.Show("backdrop");Text("iQuarters\n\nCopyright 2010 iT’s Games\n\nV 1.1.0    06/21/2010",new CGRect(25,View!.Bounds.Height*.25,View.Bounds.Width-50,View.Bounds.Height*.45),20);Text("Tap to return",new CGRect(20,View.Bounds.Height-80,View.Bounds.Width-40,40),14);
    }
    void LayoutLoading()
    {
        if(loadingLabel==null)return;
        var safe=View!.SafeAreaInsets;double scale=Math.Min(2,(double)View.Bounds.Width/320);
        loadingLabel.Frame=new CGRect((double)safe.Left+6*scale,(double)View.Bounds.Height-(double)safe.Bottom-32*scale,Math.Min(240,(double)View.Bounds.Width-12*scale),32*scale);
        loadingLabel.Font=UIFont.SystemFontOfSize((nfloat)(16*scale))!;
    }
    async void Start(GameSession session,bool selectRound)
    {
        screen="busy";audio?.Stop();ClearText();legacy.HideRoots();legacy.Show("backdrop");
        loadingLabel=new UILabel {Text="Loading...",TextColor=UIColor.White,TextAlignment=UITextAlignment.Left};
        textLayer.AddSubview(loadingLabel);LayoutLoading();
        var game=new GameViewController(session,selectRound){ModalPresentationStyle=UIModalPresentationStyle.FullScreen};
        try {
            await game.PrepareAsync();
            // Build views on the main thread and prepare GPU resources while Loading remains visible.
            game.LoadViewIfNeeded();
            await game.PrepareRenderingAsync();
            game.Quit=()=>DismissViewController(false,()=>Home());
            PresentViewController(game,false,()=>{ClearText();loadingLabel=null;});
        }catch(Exception error){
            game.ReleasePreparedResources();Console.Error.WriteLine(error);
            ClearText();loadingLabel=null;Home();
            var alert=UIAlertController.Create("Couldn’t load game",error.Message,UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK",UIAlertActionStyle.Default,null));PresentViewController(alert,true,null);
        }
    }
}
