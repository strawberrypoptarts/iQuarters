using System;
using UnityEngine;

[Serializable]
public class RoundComplete : MonoBehaviour
{
	public GameObject RoundCompleteObject;

	public static int displayScore = 50;

	public Renderer[] digitsRendererArray;

	public Material[] digitsMaterialArray;

	public Texture[] digitsTextureArray;

	public static bool triggerExciterRoundFinished;

	public static bool triggerExciterNewRoundHigh;

	public static int roundToDisplay;

	private int rfStateIsRunning = 10000;

	private int rfStateIdle = 10001;

	private int rfStateEnding = 10002;

	private int rfStateCurrent = 10001;

	public void Start()
	{
	}

	public void playAnimation(int roundFinished)
	{
		animation.Stop();
		if (roundFinished < 0 || roundFinished > 14) roundFinished = 0;
		animation.Play("rnd" + (roundFinished + 1).ToString("00"));
	}

	public void HandleTextures(int number)
	{
		int start;
		int count;
		if (number < 100)
		{
			for (int index = 0; index < 3; index++) digitsRendererArray[index].enabled = false;
			digitsRendererArray[3].enabled = digitsRendererArray[4].enabled = true;
			start = 3; count = 2;
		}
		else
		{
			for (int index = 0; index < 3; index++) digitsRendererArray[index].enabled = true;
			digitsRendererArray[3].enabled = digitsRendererArray[4].enabled = false;
			start = 0; count = 3;
		}
		int divisor = 1;
		for (int offset = 0; offset < count; offset++)
		{
			int digit = number / divisor % 10;
			digitsMaterialArray[start + offset].mainTexture = digitsTextureArray[digit];
			divisor *= 10;
		}
	}

	public void DisableAllDigitRenders()
	{
		for (int index = 0; index < 5; index++) digitsRendererArray[index].enabled = false;
	}

	public void Update()
	{
		if (triggerExciterRoundFinished)
		{
			playAnimation(roundToDisplay);
			rfStateCurrent = rfStateIsRunning;
			triggerExciterRoundFinished = false;
		}
		else if (triggerExciterNewRoundHigh)
		{
			animation.Play("newroundhigh");
			rfStateCurrent = rfStateIsRunning;
			triggerExciterNewRoundHigh = false;
			HandleTextures(displayScore);
		}
		else if (rfStateCurrent == rfStateIsRunning && !animation.isPlaying)
		{
			rfStateCurrent = rfStateEnding;
			DisableAllDigitRenders();
		}
		else if (rfStateCurrent == rfStateEnding)
		{
			rfStateCurrent = rfStateIdle;
			RoundCompleteObject.SetActiveRecursively(false);
		}
	}

	public void Main()
	{
	}
}
