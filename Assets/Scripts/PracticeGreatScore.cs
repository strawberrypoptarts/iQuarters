using System;
using UnityEngine;

[Serializable]
public class PracticeGreatScore : MonoBehaviour
{
	public GameObject practiceGreatScoreObject;

	public static int displayScore = 10;

	public Material[] gsMaterialArray;

	public Texture[] gsTextureArray;

	public static bool triggerGreatScore;

	private int gsStateIsRunning = 10000;

	private int gsStateIdle = 10001;

	private int gsStateEnding = 10002;

	private int gsStateCurrent = 10001;

	public void Start()
	{
	}

	public void HandleGreatScoreTextures(int number)
	{
		if (number < 10)
		{
			number = 10;
			Debug.Log("Round Score is out of range!");
		}
		else if (number > 999)
		{
			number = 999;
			Debug.Log("Round Score is out of range!");
		}

		Renderer[] renderers = new Renderer[5];
		renderers[0] = GameObject.Find("/ex_great_score/hs_03").renderer;
		renderers[1] = GameObject.Find("/ex_great_score/hs_02").renderer;
		renderers[2] = GameObject.Find("/ex_great_score/hs_01").renderer;
		renderers[3] = GameObject.Find("/ex_great_score/hs_05").renderer;
		renderers[4] = GameObject.Find("/ex_great_score/hs_04").renderer;

		int firstRenderer;
		int digitCount;
		if (number < 100)
		{
			renderers[0].enabled = false;
			renderers[1].enabled = false;
			renderers[2].enabled = false;
			renderers[3].enabled = true;
			renderers[4].enabled = true;
			firstRenderer = 3;
			digitCount = 2;
		}
		else
		{
			renderers[0].enabled = true;
			renderers[1].enabled = true;
			renderers[2].enabled = true;
			renderers[3].enabled = false;
			renderers[4].enabled = false;
			firstRenderer = 0;
			digitCount = 3;
		}

		int[] divisors = new int[3];
		for (int digitIndex = 0; digitIndex < digitCount; digitIndex++)
		{
			divisors[digitIndex] = digitIndex == 0 ? 1 : divisors[digitIndex - 1] * 10;
			int digit = number / divisors[digitIndex] % 10;
			gsMaterialArray[firstRenderer + digitIndex].mainTexture = gsTextureArray[digit];
		}
	}

	public void Update()
	{
		if (triggerGreatScore)
		{
			HandleGreatScoreTextures(displayScore);
			animation.Play();
			gsStateCurrent = gsStateIsRunning;
			triggerGreatScore = false;
		}
		else if (gsStateCurrent == gsStateIsRunning && !animation.isPlaying)
		{
			gsStateCurrent = gsStateEnding;
		}
		else if (gsStateCurrent == gsStateEnding)
		{
			practiceGreatScoreObject.SetActiveRecursively(false);
			gsStateCurrent = gsStateIdle;
		}
	}

	public void Main()
	{
	}
}
