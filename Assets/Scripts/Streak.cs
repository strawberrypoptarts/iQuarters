using System;
using UnityEngine;

[Serializable]
public class Streak : MonoBehaviour
{
	public GameObject streakExciterObject;

	public Renderer[] streakDigitsRendererArray;

	public Material[] streakDigitsMaterialArray;

	public Texture[] streakDigitsTextureArray;

	public static int maxDigits = 3;

	public static int stateIdle = 100;

	public static int stateTrigger = 101;

	public static int stateOnscreen = 102;

	public static int stateCurrent = 100;

	public static int streakCount;

	public static void Trigger(int count)
	{
		streakCount = count;
		stateCurrent = stateTrigger;
	}

	public void Update()
	{
		if (stateCurrent == stateTrigger)
		{
			int player = streakCount > 4 ? 4 : streakCount;
			string animationName = "player" + player;
			HandleTextures(streakCount);
			streakExciterObject.animation.Play();
			stateCurrent = stateOnscreen;
		}
		else if (stateCurrent == stateOnscreen && !streakExciterObject.animation.isPlaying)
		{
			DisableAllDigitRenders();
			streakExciterObject.SetActiveRecursively(false);
			stateCurrent = stateIdle;
		}
	}

	public void HandleTextures(int number)
	{
		if (number < 0 || number > 99)
		{
			Debug.Log("streak count is out of range!    " + number);
			return;
		}

		if (number < 10)
		{
			streakDigitsRendererArray[0].enabled = false;
			streakDigitsRendererArray[1].enabled = false;
			streakDigitsRendererArray[2].enabled = true;
			streakDigitsMaterialArray[2].mainTexture = streakDigitsTextureArray[number % 10];
		}
		else
		{
			streakDigitsRendererArray[0].enabled = true;
			streakDigitsRendererArray[1].enabled = true;
			streakDigitsRendererArray[2].enabled = false;
			streakDigitsMaterialArray[0].mainTexture = streakDigitsTextureArray[number % 10];
			streakDigitsMaterialArray[1].mainTexture = streakDigitsTextureArray[number / 10];
		}
	}

	public void DisableAllDigitRenders()
	{
		for (int index = 0; index < maxDigits; index++)
		{
			streakDigitsRendererArray[index].enabled = false;
		}
	}

	public void Main()
	{
	}
}
