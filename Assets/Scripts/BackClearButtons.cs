using System;
using UnityEngine;

[Serializable]
public class BackClearButtons : MonoBehaviour
{
	public static bool TriggerIn;

	public static bool TriggerBack;

	public static bool TriggerClear;

	private GameObject backClearButtonBack;

	private GameObject backClearButtonClear;

	private int stateIdle = 100;

	private int stateSlidingIn = 101;

	private int stateOnScreen = 102;

	private int stateBackClicked = 103;

	private int stateSlidingOut = 104;

	private int state;

	public void Start()
	{
		backClearButtonBack = GameObject.Find("/ui_back_clear/button_back_hs");
		backClearButtonClear = GameObject.Find("/ui_back_clear/button_clear_hs");
		Shader shader = Shader.Find("iPhone/Transparent/Vertex Color");
		backClearButtonBack.renderer.material.shader = shader;
		backClearButtonClear.renderer.material.shader = shader;
		if (animation.GetClipCount() == 1)
		{
			animation.AddClip(animation.clip, "SlideIn", 0, 16);
			animation.AddClip(animation.clip, "BackClick", 25, 29);
			animation.AddClip(animation.clip, "ClearClick", 40, 45);
			animation.AddClip(animation.clip, "SlideOut", 60, 65);
		}
		TriggerIn = TriggerBack = TriggerClear = false;
		state = stateIdle;
	}

	public void Update()
	{
		if (TriggerIn)
		{
			animation.Play("SlideIn"); TriggerIn = false; state = stateSlidingIn;
		}
		else if (TriggerBack)
		{
			animation.Play("BackClick"); TriggerBack = false; state = stateBackClicked;
		}
		else if (TriggerClear)
		{
			animation.Play("ClearClick"); TriggerClear = false;
		}
		else if (state == stateSlidingIn && !animation.IsPlaying("SlideIn")) state = stateOnScreen;
		else if (state == stateBackClicked && !animation.IsPlaying("BackClick"))
		{
			animation.Play("SlideOut"); state = stateSlidingOut;
		}
		else if (state == stateSlidingOut && !animation.IsPlaying("SlideOut")) state = stateIdle;
	}

	public void OnGUI()
	{
	}

	public void Main()
	{
	}
}
