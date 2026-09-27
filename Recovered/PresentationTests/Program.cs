using System.Reflection;
using IQuarters.iOS;
using IQuarters.Core;
using IQuarters.Web;
using SceneKit;

int checks=0;
void Check(bool condition,string name){if(!condition)throw new Exception(name);Console.WriteLine("PASS "+name);checks++;}
object? Call(object target,string name,params object?[] args)=>target.GetType().GetMethod(name,BindingFlags.Instance|BindingFlags.NonPublic)!.Invoke(target,args);
T Field<T>(object target,string name)=>(T)target.GetType().GetField(name,BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(target)!;
void Set(object target,string name,object value)=>target.GetType().GetField(name,BindingFlags.Instance|BindingFlags.NonPublic)!.SetValue(target,value);
void Tick(GameViewController game,float seconds){for(int i=0;i<(int)Math.Ceiling(seconds*60);i++)Call(game,"Tick",1f/60);}
string State(GameViewController game)=>Field<string>(game,"state");
async Task<GameViewController> Game(GameSession session,bool practice=false){var game=new GameViewController(session,practice);await game.PrepareAsync();game.LoadViewIfNeeded();UIHost.Current=game;Tick(game,.6f);return game;}
string Labels(GameViewController game)=>string.Join("\n",game.View.Descendants().OfType<UILabel>().Select(l=>l.Text));
var session=new GameSession();var game=await Game(session);var ui=Field<LegacyScene>(game,"ui");
Check(State(game)=="play","Round introduction reaches a playable shot");
Tick(game,1);var hud=Field<ShotHudMotion>(game,"shotHud");Check(hud.Holder==1&&hud.Angle==1&&hud.SpinRadians<0,"HUD slides in and round number continuously rotates");
Call(game,"Pause");Tick(game,.8f);Call(game,"OpenRules");Tick(game,1);
Check(State(game)=="help"&&Labels(game).Contains("Two Modes: Classic and Practice"),"Pause help shows original rules page one");
Call(game,"AdvanceRules");Check(Labels(game).Contains("5 bonus points for every unused"),"Second rules page contains original scoring rules");
Call(game,"AdvanceRules");Tick(game,1);Check(State(game)=="pause"&&!ui.Nodes[1882].Hidden,"Rules exit returns through original pause animation");
Call(game,"LeavePause","doneclick",(Action)(()=>{Set(game,"state","play");Call(game,"ShowShotHud");}));Tick(game,1);Check(State(game)=="play"&&ui.Nodes[1882].Hidden,"Pause click and slide-out complete before play resumes");
Call(game,"Shoot",.9f,0f);Tick(game,.31f);Check(hud.Holder==0&&hud.Angle==0&&ui.Nodes[1051].Hidden&&ui.Nodes[1835].Hidden,"Throw hides score, angle, round and pause UI");
Tick(game,8);Check(State(game)=="play"||State(game)=="effects","Shot/effects sequence does not stall");
Call(game,"ContactFlash",new System.Numerics.Vector3(1,2,3));
var flashes=Field<List<(SCNNode Node,float Age)>>(game,"contactFlashes");
Check(flashes.Any(f=>!f.Node.Hidden&&f.Node.Position.X==1&&f.Node.Position.Y==2),"Contact flash appears at the impact point");
Tick(game,.2f);Check(flashes.All(f=>f.Node.Hidden),"Contact flash clears after its recovered 0.1-second life");
Call(game,"PositionPowerX");
Check(ui.Nodes[677].Position.X>0&&ui.Nodes[677].Position.Y>0,"Power multiplier follows the projected coin position");
Call(game,"ShowRound",11);Call(game,"UpdateCameraAndShadow",1f/60);
var glassShadow=Field<LegacyScene>(game,"game").Nodes[1609];
Check(!glassShadow.Hidden&&glassShadow.Opacity==1&&MathF.Abs(glassShadow.Scale.X-.17f)<.0001f&&MathF.Abs(glassShadow.Position.Y-Field<LegacyScene>(game,"game").Nodes[990].Position.Y-.23f)<.0001f,"Lazy Susan glass shadow follows the animated glass");
var world=Field<LegacyScene>(game,"game");world.Play(979,"Take 001",loop:true);
var beforeSusan=world.Nodes[979].Orientation;Call(game,"Pause");Tick(game,.5f);
Check(!world.Nodes[979].Orientation.Equals(beforeSusan),"World props continue their recovered animations under the pause menu");
// Use actual recovered animation curves while driving the late-game outcome directly.
foreach(int count in new[]{1,2,4}){
 var s=new GameSession(count);s.curRound=11;
 var g=await Game(s);bool quit=false;g.Quit=()=>quit=true;
 for(int player=0;player<count;player++){
  s.curMadeShotsThisRound=2;s.AddScore(75);s.SetNameEnteredFlag(player);
  Call(g,"CommitShot",1);Tick(g,12);
  Check(State(g)=="highScores",$"Player {player+1}/{count}: completion, stack bonus and high-score board finish in order");
  Check(Labels(g).Contains("275"),"Unused-coin bonus adds 40 x 5 to 75");
  Call(g,"CloseInGameScores");Tick(g,2);
 }
 Check(State(g)=="stats"&&Labels(g).Split('\n').Length==count*4,$"{count}-player statistics include score, streak, ricochet and remaining coins");
 Call(g,"CloseStats");Tick(g,1);Check(quit,"Stats Done completes original exit animation");g.ReleasePreparedResources();
}
var outSession=new GameSession();outSession.SetCurrentShotsLeft(1);var outGame=await Game(outSession);Call(outGame,"CommitShot",0);Tick(outGame,5);Check(State(outGame)=="stats","Zero-score last miss bypasses high-score entry and reaches statistics");
var secret=new GameSession{curRound=8,curMadeShotsThisRound=2,secretRoundUnlocked=true};var sg=await Game(secret);secret.AddScore(75);Call(sg,"CommitShot",1);Tick(sg,4);Check(secret.curRound==12&&State(sg)=="play","Secret-round intro uses its recovered effect and reaches the secret layout");
secret.curMadeShotsThisRound=2;secret.AddScore(75);Call(sg,"CommitShot",1);Tick(sg,4);Check(secret.curRound==9&&State(sg)=="play","Secret outro returns to round ten");
GameStorage.Unlocked=2;var ps=new GameSession(1,true);var pg=await Game(ps,true);Tick(pg,.3f);Check(State(pg)=="select"&&Labels(pg).Contains("Hi Score"),"Practice uses original score label");
Call(pg,"ShowRound",5);Call(pg,"PracticeLock");Tick(pg,.6f);Check(!Field<LegacyScene>(pg,"ui").Nodes[1254].Hidden,"Locked practice rounds show recovered lock art");
Call(pg,"ShowRound",0);Call(pg,"BeginRound");Tick(pg,1);ps.curMadeShotsThisRound=2;ps.AddScore(75);int previous=GameStorage.RoundScore(0);Call(pg,"CommitShot",1);Tick(pg,4);Check(State(pg)=="select"&&GameStorage.RoundScore(0)==previous,"Practice great-score effect returns to selection without changing Classic records");
Console.WriteLine($"Presentation verification: {checks} checks passed");
