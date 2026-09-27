using System;
using UnityEngine;

[Serializable]
public class PracticeUI : MonoBehaviour
{
	public GameObject lockUIObject;

	public GameObject PracticeUIObject;

	public bool enableButtonView;

	public GUISkin dummySkin;

	public GUISkin fontSkin;

	public GUISkin fontSkin_iPad;

	private int practiceStateNone = 1000;

	private int practiceStateSlideIn = 1001;

	private int practiceStateWait = 1002;

	private int practiceStateSlideOut = 1003;

	private int practiceStateSwitchClicked = 1004;

	private int currentState = 1000;

	private bool lockDisplayedState;

	private int roundScore;

	public static bool triggerPracticeUI;

	public static bool triggerLevelSwitch;

	public static int curLevelSelected;

	public static bool selectLevelDone;

	public static bool triggerDelayedLockAnim;

	public static bool triggerDelayedLockIn;

	public static bool triggerDelayedLockOut;

	public static bool cancelPracticeScreen;

	private bool firstTimeFlag;

	public void Start()
	{
		firstTimeFlag = true;
	}

	public void Update()
	{
		if (currentState == practiceStateSlideIn && !animation.isPlaying)
		{
			currentState = practiceStateWait;
		}
		else if (currentState == practiceStateSlideOut && !animation.isPlaying)
		{
			if (cancelPracticeScreen)
			{
				QuarterTrigger.state = QuarterTrigger.stateGameOver;
			}
			PracticeUIObject.SetActiveRecursively(false);
			lockUIObject.SetActiveRecursively(false);
			currentState = practiceStateNone;
		}
		else if (currentState == practiceStateSwitchClicked && !animation.isPlaying &&
			!lockUIObject.animation.IsPlaying("lockin") && !lockUIObject.animation.IsPlaying("lockout"))
		{
			triggerLevelSwitch = true;
			currentState = practiceStateWait;
		}

		if (triggerPracticeUI)
		{
			roundScore = HiScoreRoundScript.GetScore(curLevelSelected);
			animation.Play("slidein");
			currentState = practiceStateSlideIn;
			triggerPracticeUI = false;
			lockDisplayedState = curLevelSelected >= HiScoreScript.lockedRoundStartIndex;
			cancelPracticeScreen = false;
			lockUIObject.SetActiveRecursively(true);
			ChecktoTriggerLockAnimation();
		}

		if (triggerDelayedLockAnim)
		{
			triggerDelayedLockAnim = false;
			GameObject lockObject = GameObject.Find("/ui_practice_lock/lock");
			if (triggerDelayedLockIn)
			{
				triggerDelayedLockIn = false;
				if (firstTimeFlag)
				{
					lockUIObject.animation.Play("lockin");
					firstTimeFlag = false;
				}
				else
				{
					lockObject.renderer.enabled = true;
				}
			}
			else if (triggerDelayedLockOut)
			{
				triggerDelayedLockOut = false;
				lockObject.renderer.enabled = false;
			}
		}
	}

	public void ChecktoTriggerLockAnimation()
	{
		bool shouldLock = curLevelSelected >= HiScoreScript.lockedRoundStartIndex;
		if (!lockDisplayedState && shouldLock)
		{
			triggerDelayedLockIn = true;
			lockDisplayedState = true;
		}
		else if (lockDisplayedState && !shouldLock)
		{
			triggerDelayedLockOut = true;
			lockDisplayedState = false;
		}
	}

	public bool IsGoButtonDisabled()
	{
		return curLevelSelected >= HiScoreScript.lockedRoundStartIndex;
	}

	public void OnGUI()
	{
		if (currentState == practiceStateWait || currentState == practiceStateSwitchClicked)
		{
			GUI.skin = GameManagerScript.is_iPad() ? fontSkin_iPad : fontSkin;
			Rect scoreRect = new Rect(40f, 72f, 400f, 40f);
			if (GameManagerScript.is_iPad()) scoreRect = GameManagerScript.GetiPadRect(scoreRect);
			GUI.Label(scoreRect, "Hi Score  " + roundScore);
		}
		if (currentState != practiceStateWait)
		{
			return;
		}

		GUI.skin = enableButtonView ? null : dummySkin;
		Rect goRect = new Rect(96f, 220f, 288f, 70f);
		Rect leftRect = new Rect(74f, 120f, 80f, 80f);
		Rect rightRect = new Rect(326f, 120f, 80f, 80f);
		Rect quitRect = new Rect(40f, 8f, 64f, 64f);
		if (GameManagerScript.is_iPad())
		{
			goRect = GameManagerScript.GetiPadRect(goRect);
			leftRect = GameManagerScript.GetiPadRect(leftRect);
			rightRect = GameManagerScript.GetiPadRect(rightRect);
			quitRect = GameManagerScript.GetiPadRect(quitRect);
		}
		if (!IsGoButtonDisabled() && GUI.Button(goRect, string.Empty))
		{
			selectLevelDone = true;
			AnnouncerScript.triggerClickSound = true;
			animation.Play("goclick");
			animation.PlayQueued("slideout");
			currentState = practiceStateSlideOut;
		}
		if (GUI.Button(leftRect, string.Empty))
		{
			curLevelSelected--;
			if (curLevelSelected < 0) curLevelSelected = GameManagerScript.numRounds - 1;
			currentState = practiceStateSwitchClicked;
			roundScore = HiScoreRoundScript.GetScore(curLevelSelected);
			AnnouncerScript.triggerClickSound = true;
			animation.Play("leftclick");
			ChecktoTriggerLockAnimation();
		}
		if (GUI.Button(rightRect, string.Empty))
		{
			curLevelSelected++;
			if (curLevelSelected >= GameManagerScript.numRounds) curLevelSelected = 0;
			currentState = practiceStateSwitchClicked;
			roundScore = HiScoreRoundScript.GetScore(curLevelSelected);
			AnnouncerScript.triggerClickSound = true;
			animation.Play("rightclick");
			ChecktoTriggerLockAnimation();
		}
		if (GUI.Button(quitRect, string.Empty))
		{
			lockUIObject.SetActiveRecursively(false);
			cancelPracticeScreen = true;
			AnnouncerScript.triggerClickSound = true;
			animation.Play("quitclick");
			animation.PlayQueued("slideout");
			currentState = practiceStateSlideOut;
		}
	}

	public void Main()
	{
	}
}
