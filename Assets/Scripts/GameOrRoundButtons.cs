using System;
using UnityEngine;

[Serializable]
public class GameOrRoundButtons : MonoBehaviour
{
	public Texture gameButtonTextureOff;

	public Texture gameButtonTextureOn;

	public Texture roundButtonTextureOff;

	public Texture roundButtonTextureOn;

	public static bool TriggerIn;

	public static bool TriggerOut;

	public static bool TriggerButtonGame;

	public static bool TriggerButtonRound;

	public static bool gameButtonSelected = true;

	private GameObject roundOrGameButtonsGame;

	private GameObject roundOrGameButtonsRound;

	private int stateIdle = 100;

	private int stateSlidingIn = 101;

	private int stateOnScreen = 102;

	private int stateGameInRoundOut = 103;

	private int stateGameOutRoundIn = 104;

	private int stateSlidingOut = 105;

	private int state;

	public void Start()
	{
		roundOrGameButtonsGame = GameObject.Find("/ui_button_high_round/button_highscore");
		roundOrGameButtonsRound = GameObject.Find("/ui_button_high_round/button_roundhigh");
		Shader shader = Shader.Find("iPhone/Transparent/Vertex Color");
		roundOrGameButtonsGame.renderer.material.shader = shader;
		roundOrGameButtonsRound.renderer.material.shader = shader;
		if (animation.GetClipCount() == 1)
		{
			animation.AddClip(animation.clip, "SlideIn", 0, 16);
			animation.AddClip(animation.clip, "GameClick", 30, 34);
			animation.AddClip(animation.clip, "RoundClick", 45, 49);
			animation.AddClip(animation.clip, "SlideOut", 70, 83);
		}
		TriggerIn = TriggerOut = TriggerButtonGame = TriggerButtonRound = false;
		gameButtonSelected = true;
		state = stateIdle;
	}

	public void Update()
	{
		if (TriggerIn)
		{
			animation.Play("SlideIn"); TriggerIn = false; gameButtonSelected = true;
			HandleButtonTextures(); state = stateSlidingIn;
		}
		else if (TriggerOut)
		{
			animation.Play("SlideOut"); TriggerOut = false; state = stateSlidingOut;
		}
		else if (TriggerButtonGame)
		{
			bool wasSelected = gameButtonSelected;
			gameButtonSelected = true; HandleButtonTextures();
			if (!wasSelected) state = stateGameInRoundOut;
			TriggerButtonGame = false;
		}
		else if (TriggerButtonRound)
		{
			bool wasSelected = gameButtonSelected;
			gameButtonSelected = false; HandleButtonTextures();
			if (wasSelected) state = stateGameOutRoundIn;
			TriggerButtonRound = false;
		}
		else if (state == stateSlidingIn && !animation.IsPlaying("SlideIn")) state = stateOnScreen;
		else if ((state == stateGameInRoundOut || state == stateGameOutRoundIn) && !RoundHighScreen.IsScreenSliding)
			state = stateOnScreen;
		else if (state == stateSlidingOut && !animation.IsPlaying("SlideOut")) state = stateIdle;
	}

	public void OnGUI()
	{
	}

	public void HandleButtonTextures()
	{
		if (gameButtonSelected)
		{
			roundOrGameButtonsGame.renderer.material.mainTexture = gameButtonTextureOn;
			roundOrGameButtonsRound.renderer.material.mainTexture = roundButtonTextureOff;
		}
		else
		{
			roundOrGameButtonsGame.renderer.material.mainTexture = gameButtonTextureOff;
			roundOrGameButtonsRound.renderer.material.mainTexture = roundButtonTextureOn;
		}
	}

	public void Main()
	{
	}
}
