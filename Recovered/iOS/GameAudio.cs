using AVFoundation;
namespace IQuarters.iOS;

// Decode once when the game opens. Impacts only schedule an existing PCM buffer.
sealed class GameAudio : IDisposable
{
    readonly AVAudioEngine engine=new();
    readonly AVAudioPlayerNode[] players=[new(),new(),new(),new()];
    readonly Dictionary<string,AVAudioPcmBuffer> clips=new();
    bool ready;
    public GameAudio()
    {
        foreach(var player in players)engine.AttachNode(player);
        AVAudioFormat? format=null;
        foreach(var path in Directory.EnumerateFiles(LegacyScene.Resource("audio"),"*.wav")){
            using var file=new AVAudioFile(NSUrl.FromFilename(path),out var error);
            if(error!=null)continue;
            var buffer=new AVAudioPcmBuffer(file.ProcessingFormat,(uint)file.Length);
            if(!file.ReadIntoBuffer(buffer,out error)){buffer.Dispose();continue;}
            format??=file.ProcessingFormat;clips[Path.GetFileName(path)]=buffer;
        }
        if(format is null)return;
        foreach(var player in players)if(OperatingSystem.IsIOSVersionAtLeast(27))engine.Connect(player,engine.MainMixerNode,format,out _);else engine.Connect(player,engine.MainMixerNode,format);
        engine.Prepare();Resume();
    }
    public void Resume(){if(engine.Running)return;ready=engine.StartAndReturnError(out _);if(ready){foreach(var player in players)if(OperatingSystem.IsIOSVersionAtLeast(27))ready=player.Play(out _);else player.Play();}}
    public void Pause(){foreach(var player in players)player.Pause();engine.Pause();ready=false;}
    public void Play(string name,int channel=0,float volume=1)
    {
        // Never restart hardware, load files or decode audio in the impact callback.
        if(!ready||!clips.TryGetValue(name,out var buffer))return;
        var player=players[channel];player.Volume=volume;player.ScheduleBuffer(buffer,null,AVAudioPlayerNodeBufferOptions.Interrupts,(Action?)null);
    }
    public void Stop(int channel){players[channel].Stop();if(ready){if(OperatingSystem.IsIOSVersionAtLeast(27))players[channel].Play(out _);else players[channel].Play();}}
    public void Dispose(){foreach(var player in players)player.Stop();engine.Stop();foreach(var clip in clips.Values)clip.Dispose();foreach(var player in players)player.Dispose();engine.Dispose();}
}
