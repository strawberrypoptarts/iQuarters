using System;
using UnityEngine;

[Serializable]
public class StatsScreen : MonoBehaviour
{
	public GameObject StatsScreenObject;

	public bool enableButtonView;

	public GUISkin dummySkin;

	public GUISkin fontSkin;

	public GUISkin fontSkin_iPad;

	public static bool triggerStatscreen;

	public static bool cancelStatscreen;

	private int ssStateIdle = 100;

	private int ssStateSlideIn = 101;

	private int ssStateWait = 102;

	private int ssStateSlideOut = 103;

	private int ssStateCurrent = 100;

	private bool displayLoadingFlag;

	private float slidingOutTimer;

	public void Start()
	{
		cancelStatscreen = false;
	}

	public void StatsText()
	{
		GUI.skin = GameManagerScript.is_iPad() ? fontSkin_iPad : fontSkin;
		TextAnchor oldAlignment = GUI.skin.label.alignment;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		float spacing = GameManagerScript.is_iPad() ? 57f : 64f;
		float startX = GameManagerScript.totPlayers == 2 ? 100f : 132f - spacing * (GameManagerScript.totPlayers - 1) / 2f;
		for (int i = 0; i < GameManagerScript.totPlayers; i++)
		{
			float x = startX + i * spacing;
			string[] values = {
				GameManagerScript.GetPlayerScore(i).ToString(),
				GameManagerScript.GetPlayerMaxStreak(i).ToString(),
				GameManagerScript.GetPlayerMaxRicochet(i).ToString(),
				GameManagerScript.GetPlayerShotsLeft(i).ToString()
			};
			for (int row = 0; row < values.Length; row++)
			{
				Rect rect = new Rect(x, 115f + row * 34f, 60f, 30f);
				if (GameManagerScript.is_iPad()) rect = GameManagerScript.GetiPadRect(rect);
				GUI.Label(rect, values[row]);
			}
		}
		GUI.skin.label.alignment = oldAlignment;
	}

	public void OnGUI()
	{
		if (displayLoadingFlag)
		{
			GUI.skin = fontSkin;
			Rect loadingRect = new Rect(32f, Screen.height - 32f, 300f, 24f);
			if (GameManagerScript.is_iPad()) loadingRect = GameManagerScript.GetiPadRect(loadingRect);
			GUI.Label(loadingRect, "Loading...");
		}
		if (ssStateCurrent != ssStateWait) return;
		StatsText();
		GUI.skin = enableButtonView ? null : dummySkin;
		Rect doneRect = new Rect(40f, 252f, 400f, 60f);
		if (GameManagerScript.is_iPad()) doneRect = GameManagerScript.GetiPadRect(doneRect);
		if (GUI.Button(doneRect, string.Empty))
		{
			string suffix = GameManagerScript.totPlayers > 0 && GameManagerScript.totPlayers < 5 ? GameManagerScript.totPlayers.ToString() : "1";
			animation.Play("done_click_" + suffix);
			animation.PlayQueued("ui_out_" + suffix);
			slidingOutTimer = Time.time + 0.25f;
			AnnouncerScript.triggerClickSound = true;
			ssStateCurrent = ssStateSlideOut;
		}
	}

	public void DisplayFingers(bool flag)
	{
		string[] names = { "stats_score_", "stats_streak_", "stats_richochet_", "stats_coins_left_" };
		for (int i = 0; i < names.Length; i++)
		{
			for (char player = 'a'; player <= 'd'; player++)
			{
				GameObject gameObject = GameObject.Find("/ui_stats/" + names[i] + player);
				if (gameObject) gameObject.renderer.enabled = flag;
			}
		}
	}

	public void Update()
	{
		if (triggerStatscreen)
		{
			string suffix = GameManagerScript.totPlayers > 0 && GameManagerScript.totPlayers < 5 ? GameManagerScript.totPlayers.ToString() : "1";
			DisplayFingers(true);
			animation.Play("ui_in_" + suffix);
			triggerStatscreen = false;
			ssStateCurrent = ssStateSlideIn;
		}
		if (ssStateCurrent == ssStateSlideIn && !animation.isPlaying)
		{
			ssStateCurrent = ssStateWait;
		}
		else if (ssStateCurrent == ssStateSlideOut)
		{
			if (Time.time > slidingOutTimer) DisplayFingers(false);
			if (!animation.isPlaying)
			{
				displayLoadingFlag = true;
				cancelStatscreen = true;
				ssStateCurrent = ssStateIdle;
			}
		}
	}

	public void Main()
	{
	}
}
