using System;
using UnityEngine;

[Serializable]
public class GameHighScreen : MonoBehaviour
{
	public static bool TriggerIn;

	public static bool TriggerOut;

	public static bool IsScreenSliding;

	private int stateIdle = 100;

	private int stateSlidingIn = 101;

	private int stateOnScreen = 102;

	private int stateSlidingOut = 103;

	private int state;

	public void Start()
	{
		if (animation.GetClipCount() == 1)
		{
			animation.AddClip(animation.clip, "SlideIn", 0, 22);
			animation.AddClip(animation.clip, "SlideOut", 50, 66);
		}
		Shader shader = Shader.Find("iPhone/Transparent/Vertex Color");
		for (int index = 0; index < HiScoreScript.maxEntryCount; index++)
			GameObject.Find("/ui_high_high/high_score_bg_0" + index).renderer.material.shader = shader;
		TriggerIn = TriggerOut = IsScreenSliding = false;
		state = stateIdle;
	}

	public void DisplayOddFinger(bool flag)
	{
		GameObject.Find("/ui_high_high/high_score_bg_08").renderer.enabled = flag;
	}

	public void Update()
	{
		if (TriggerIn)
		{
			DisplayOddFinger(true);
			animation.Play("SlideIn");
			TriggerIn = false;
			IsScreenSliding = true;
			state = stateSlidingIn;
		}
		else if (TriggerOut)
		{
			animation.Play("SlideOut");
			TriggerOut = false;
			IsScreenSliding = true;
			state = stateSlidingOut;
		}
		else if (state == stateSlidingIn && !animation.IsPlaying("SlideIn"))
		{
			IsScreenSliding = false;
			state = stateOnScreen;
		}
		else if (state == stateSlidingOut && !animation.IsPlaying("SlideOut"))
		{
			DisplayOddFinger(false);
			IsScreenSliding = false;
			state = stateIdle;
		}
	}

	public void OnGUI()
	{
	}

	public void Main()
	{
	}
}
