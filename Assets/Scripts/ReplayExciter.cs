using System;
using UnityEngine;

[Serializable]
public class ReplayExciter : MonoBehaviour
{
	public GameObject replayExciterObject;

	public GameObject scaleControllerObject;

	public Material pUpMaterial;

	public Color startColor;

	public GUISkin dummySkin;

	public static int stateIdle = 100;

	public static int stateTriggerIn = 101;

	public static int stateOnScreen = 102;

	public static int stateTriggerOut = 103;

	public static int state = 100;

	public static bool checkForReplaySkip;

	public static void TriggerOn(bool skipOnly)
	{
		checkForReplaySkip = false;
		GameObject.Find("/exciter_instant_replay/instant replay").active = false;
		if (state == stateIdle)
		{
			state = stateTriggerIn;
			if (skipOnly)
			{
				Debug.Log(" state " + QuarterTrigger.state);
				checkForReplaySkip = true;
			}
		}
	}

	public static void TriggerOff()
	{
		if (state == stateOnScreen)
		{
			state = stateTriggerOut;
		}
		checkForReplaySkip = false;
	}

	public void Update()
	{
		if (state == stateTriggerIn)
		{
			if (!checkForReplaySkip)
			{
				animation.Play();
			}
			state = stateOnScreen;
		}
		else if (state == stateOnScreen)
		{
			Color color = startColor;
			color.a = scaleControllerObject.transform.localScale.x - 1f;
			pUpMaterial.SetColor("_Color", color);
		}
		else if (state == stateTriggerOut)
		{
			replayExciterObject.SetActiveRecursively(false);
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
