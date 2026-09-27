using CoreAnimation;
using SceneKit;
namespace IQuarters.iOS;

// Follow the display's actual cadence instead of a fixed 60 Hz timer.
sealed class DisplayFrameLoop : IDisposable
{
    readonly CADisplayLink link;
    readonly Action<float> update;
    double previousTarget;
    public DisplayFrameLoop(UIScreen screen,Action<float> update,params SCNView[] views)
    {
        this.update=update;
        int maximum=(int)Math.Clamp((long)screen.MaximumFramesPerSecond,1,120);
        foreach(var view in views){view.PreferredFramesPerSecond=maximum;view.Playing=true;view.RendersContinuously=true;}
        link=CADisplayLink.Create(Frame);
        link.PreferredFrameRateRange=CAFrameRateRange.Create(Math.Min(60,maximum),maximum,maximum);
        link.AddToRunLoop(NSRunLoop.Main,NSRunLoopMode.Common);
    }
    void Frame()
    {
        double next=link.TargetTimestamp;
        double seconds=previousTarget>0?next-previousTarget:next-link.Timestamp;previousTarget=next;
        if(double.IsFinite(seconds)&&seconds>0)update((float)Math.Min(seconds,.05));
    }
    public void Dispose(){link.Invalidate();link.Dispose();}
}
