using System;
using UnityEngine;

[Serializable]
public class AreYouSure : MonoBehaviour
{
	public static bool triggerAreYouSure;

	public static int stateWaitForAnswer;

	public static int stateAnswerYes = 2;

	public static int stateAnswerNo = 4;

	public static int returnState;

	public GameObject thisObject;

	public bool enableButtonView;

	public GUISkin dummySkin;

	public GUISkin fontSkin;

	private int popupStateIdle = 100;

	private int popupStateRunning = 101;

	private int popupStateWaitToEndYes = 102;

	private int popupStateWaitToEndNo = 103;

	private int curState;

	public static void TriggerAreYouSureMessage()
	{
		returnState = stateWaitForAnswer;
		triggerAreYouSure = true;
	}

	public void Start()
	{
	}

	public void CheckButtons()
	{
		GUI.skin = enableButtonView ? null : fontSkin;
		Rect yesRect = new Rect(43f, 345f, 105f, 55f);
		Rect noRect = new Rect(172f, 345f, 105f, 55f);
		if (GameManagerScript.is_iPad())
		{
			yesRect = GameManagerScript.GetiPadRect(yesRect, false);
			noRect = GameManagerScript.GetiPadRect(noRect, false);
		}
		if (GUI.Button(yesRect, string.Empty))
		{
			animation.Play("YesClick"); curState = popupStateWaitToEndYes;
		}
		if (GUI.Button(noRect, string.Empty))
		{
			animation.Play("NoClick"); curState = popupStateWaitToEndNo;
		}
	}

	public void OnGUI()
	{
		if (triggerAreYouSure)
		{
			curState = popupStateRunning; triggerAreYouSure = false;
		}
		if (curState == popupStateRunning) CheckButtons();
		else if (curState == popupStateWaitToEndYes && !animation.isPlaying)
		{
			thisObject.SetActiveRecursively(false); returnState = stateAnswerYes;
		}
		else if (curState == popupStateWaitToEndNo && !animation.isPlaying)
		{
			thisObject.SetActiveRecursively(false); returnState = stateAnswerNo;
		}
	}

	public void Main()
	{
	}
}
