using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class InGameHiScore : MonoBehaviour
{
	public GameObject newHighScoreObject;

	public GameObject InGameHSObject;

	public GameObject TrophyObject;

	public bool enableButtonView;

	public GUISkin dummySkin;

	public GUISkin fontSkin;

	public GUISkin fontSkin_iPad;

	public static bool triggerHiScores;

	public static bool cancelHiScores;

	private int hsStateIdle = 100;

	private int hsStateTrophy = 101;

	private int hsStateSlideIn = 102;

	private int hsStateWait = 103;

	private int hsStateSlideOut = 104;

	private int hsStateTurnOff = 105;

	private int hsStateCurrent = 100;

	public void Start()
	{
	}

	public void ScoresText()
	{
		GUI.skin = GameManagerScript.is_iPad() ? fontSkin_iPad : fontSkin;
		ArrayList scores = HiScoreScript.GetArray();
		for (int i = 0; i < scores.Count; i++)
		{
			Entry entry = (Entry)scores[i];
			Rect nameRect = new Rect(105f, 72f + i * 20f, 180f, 24f);
			Rect scoreRect = new Rect(285f, 72f + i * 20f, 90f, 24f);
			if (GameManagerScript.is_iPad())
			{
				nameRect = GameManagerScript.GetiPadRect(nameRect);
				scoreRect = GameManagerScript.GetiPadRect(scoreRect);
			}
			GUI.Label(nameRect, entry.name);
			GUI.Label(scoreRect, ((int)entry.score).ToString());
		}
	}

	public void OnGUI()
	{
		if (hsStateCurrent != hsStateWait) return;
		ScoresText();
		if (!enableButtonView) GUI.skin = dummySkin;
		Rect doneRect = new Rect(40f, 252f, 400f, 60f);
		if (GameManagerScript.is_iPad()) doneRect = GameManagerScript.GetiPadRect(doneRect);
		if (GUI.Button(doneRect, string.Empty))
		{
			AnnouncerScript.triggerClickSound = true;
			animation.Play("doneclick");
			animation.PlayQueued("barsout");
			hsStateCurrent = hsStateSlideOut;
		}
	}

	public void Update()
	{
		if (triggerHiScores)
		{
			triggerHiScores = false;
			if (HiScoreScript.guiIndex == 0)
			{
				TrophyObject.SetActiveRecursively(true);
				TrophyObject.animation.Play();
				newHighScoreObject.SetActiveRecursively(true);
				newHighScoreObject.animation.Play();
				hsStateCurrent = hsStateTrophy;
			}
			else
			{
				animation.Play("barsin");
				hsStateCurrent = hsStateSlideIn;
			}
		}
		if (hsStateCurrent == hsStateTrophy && !TrophyObject.animation.isPlaying && !newHighScoreObject.animation.isPlaying)
		{
			TrophyObject.SetActiveRecursively(false);
			newHighScoreObject.SetActiveRecursively(false);
			animation.Play("barsin");
			hsStateCurrent = hsStateSlideIn;
		}
		else if (hsStateCurrent == hsStateSlideIn && !animation.isPlaying)
		{
			hsStateCurrent = hsStateWait;
		}
		else if (hsStateCurrent == hsStateSlideOut && !animation.isPlaying)
		{
			cancelHiScores = true;
			hsStateCurrent = hsStateTurnOff;
		}
		else if (hsStateCurrent == hsStateTurnOff)
		{
			InGameHSObject.SetActiveRecursively(false);
			hsStateCurrent = hsStateIdle;
		}
	}

	public void Main()
	{
	}
}
