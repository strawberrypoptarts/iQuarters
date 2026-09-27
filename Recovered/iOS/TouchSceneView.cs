using SceneKit;
using CoreGraphics;
namespace IQuarters.iOS;

// Preserve touch samples before a pan recognizer's movement threshold or
// release-velocity filtering can change the recovered flick calculation.
public sealed class TouchSceneView(CGRect frame) : SCNView(frame)
{
    public Action<CGPoint,double>? BeginContact;
    public Action<CGPoint,double>? MoveContact;
    public Action? EndContact;
    public Action? CancelContact;
    UITouch? contact;
    public override void TouchesBegan(NSSet touches, UIEvent? evt)
    {
        if(contact!=null)return;
        contact=touches.AnyObject as UITouch;
        if(contact!=null)BeginContact?.Invoke(contact.LocationInView(this),contact.Timestamp);
    }
    public override void TouchesMoved(NSSet touches, UIEvent? evt)
    {
        if(contact==null||!touches.Contains(contact))return;
        var samples=evt?.GetCoalescedTouches(contact);
        if(samples is {Length:>0})foreach(var sample in samples)MoveContact?.Invoke(sample.LocationInView(this),sample.Timestamp);
        else MoveContact?.Invoke(contact.LocationInView(this),contact.Timestamp);
    }
    public override void TouchesEnded(NSSet touches, UIEvent? evt)
    {
        if(contact!=null && touches.Contains(contact)){MoveContact?.Invoke(contact.LocationInView(this),contact.Timestamp);EndContact?.Invoke();contact=null;}
    }
    public override void TouchesCancelled(NSSet touches, UIEvent? evt)
    {
        CancelContact?.Invoke();contact=null;
    }
}
