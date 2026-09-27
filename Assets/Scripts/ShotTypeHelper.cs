using System;
using UnityEngine;

[Serializable]
public class ShotTypeHelper : MonoBehaviour
{
	public GameObject shotTypeHelperObject;

	public static bool triggerShotTypeHelper;

	private int stIdle = 100;

	private int stAnimating = 101;

	private int curState = 100;

	public bool isFlickShot()
	{
		return GameManagerScript.GetCurrentInputType() != GameManagerScript.inputTypeShake;
	}

	public void Update()
	{
		if (curState == stAnimating && !animation.isPlaying)
		{
			shotTypeHelperObject.SetActiveRecursively(false);
			curState = stIdle;
		}

		if (triggerShotTypeHelper)
		{
			curState = stAnimating;
			animation.Play(isFlickShot() ? "flick" : "shake");
			triggerShotTypeHelper = false;
		}
	}

	public void Main()
	{
	}
}
