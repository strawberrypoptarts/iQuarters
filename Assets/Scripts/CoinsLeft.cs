using System;
using UnityEngine;

[Serializable]
public class CoinsLeft : MonoBehaviour
{
	public GameObject coinsLeftBonusObect;

	public GameObject coinsLeftBarGraphic;

	public AudioClip stackingSFX;

	public AudioClip scoreSFX;

	public GUISkin UISkin;

	public GameObject[] coinArray;

	public Renderer[] clDigitsRendererArray;

	public Material[] clDigitsMaterialArray;

	public Texture[] clDigitsTextureArray;

	public static int bonusMultiplier = 5;

	public static int numCoinsLeft;

	public static int maxCoinsLeft = 40;

	public static int numCoinsDisplay;

	public static int maxCoinsDisplay;

	public static int clStateIdle = 100;

	public static int clStateTrigger = 101;

	public static int clStatePlaying = 102;

	public static int clStateBonusSlideIn = 103;

	public static int clStateBonusOnScreen = 104;

	public static int clStateBonusSlideOut = 105;

	public static int clStateCurrent = 100;

	public static int coinsLeftTextX = 150;

	public static int coinsLeftTextY = 385;

	public static float scaleFactorY = 79f;

	public static float coinsLeftBarGraphicStartY;

	public static Rect screenRect;

	public static float bonusOnScreenStartTime;

	public void Start()
	{
		coinsLeftBarGraphicStartY = coinsLeftBarGraphic.transform.localPosition.y;
		screenRect = new Rect(30f, coinsLeftTextY, 100f, 40f);
		numCoinsDisplay = maxCoinsDisplay = 0;
		coinArray = new GameObject[maxCoinsLeft + 1];
		for (int index = 1; index <= maxCoinsLeft; index++)
		{
			string name = "quarter_" + (index < 11 ? "0" : string.Empty) + (index - 1);
			coinArray[index] = GameObject.Find(name);
		}
	}

	public void Update()
	{
		if (clStateCurrent == clStateTrigger)
		{
			string clipName = "CoinsLeft" + numCoinsLeft;
			float speed = 1f;
			if (numCoinsLeft > 11) speed += (numCoinsLeft - 12) * 1.5f / (maxCoinsLeft - 12);
			animation[clipName].speed = speed;
			animation.Play(clipName);
			for (int index = numCoinsLeft + 1; index <= maxCoinsLeft; index++) coinArray[index].active = false;
			GameObject.Find("/ui_stack/coin_amount/hs_01").renderer.enabled = false;
			if (!QuarterTrigger.muteF) { audio.clip = stackingSFX; audio.Play(); }
			clStateCurrent = clStatePlaying;
		}
		else if (clStateCurrent == clStatePlaying)
		{
			Vector3 barPosition = coinsLeftBarGraphic.transform.localPosition;
			screenRect.y = coinsLeftTextY - (int)((barPosition.y - coinsLeftBarGraphicStartY) * scaleFactorY);
			string clipName = "CoinsLeft" + numCoinsLeft;
			numCoinsDisplay = (int)((animation[clipName].time / animation[clipName].length) * numCoinsLeft + 1f);
			if (numCoinsDisplay > maxCoinsDisplay)
			{
				maxCoinsDisplay = numCoinsDisplay + 1;
				if (maxCoinsDisplay > numCoinsLeft) { audio.Stop(); maxCoinsDisplay = numCoinsLeft; }
			}
			if (!animation.isPlaying)
			{
				HandleCoinsLeftTextures(maxCoinsDisplay);
				coinsLeftBonusObect.SetActiveRecursively(true);
				HandleTextures(maxCoinsDisplay * bonusMultiplier);
				coinsLeftBonusObect.animation.Play("SlideIn");
				if (!QuarterTrigger.muteF) { audio.clip = scoreSFX; audio.Play(); }
				clStateCurrent = clStateBonusSlideIn;
			}
		}
		else if (clStateCurrent == clStateBonusSlideIn && !coinsLeftBonusObect.animation.isPlaying)
		{
			bonusOnScreenStartTime = Time.time; clStateCurrent = clStateBonusOnScreen;
		}
		else if (clStateCurrent == clStateBonusOnScreen && Time.time > bonusOnScreenStartTime + 2f)
		{
			coinsLeftBonusObect.animation.Play("SlideOut"); clStateCurrent = clStateBonusSlideOut;
		}
		else if (clStateCurrent == clStateBonusSlideOut && !coinsLeftBonusObect.animation.isPlaying)
		{
			DisableAllDigitRenders(); coinsLeftBonusObect.SetActiveRecursively(false); clStateCurrent = clStateIdle;
		}
	}

	public void OnGUI()
	{
		if (clStateCurrent == clStatePlaying) { GUI.skin = UISkin; HandleCoinsLeftTextures(maxCoinsDisplay); }
	}

	public void HandleCoinsLeftTextures(int numCoins)
	{
		int tens = numCoins / 10;
		GameObject tensObject = GameObject.Find("/ui_stack/coin_amount/hs_01");
		if (tens != 0)
		{
			tensObject.renderer.enabled = true;
			tensObject.renderer.material.mainTexture = clDigitsTextureArray[tens];
		}
		GameObject.Find("/ui_stack/coin_amount/hs_02").renderer.material.mainTexture = clDigitsTextureArray[maxCoinsDisplay % 10];
	}

	public static void TriggerAnim(int numCoins)
	{
		numCoinsDisplay = maxCoinsDisplay = 0;
		numCoinsLeft = numCoins;
		if (numCoinsLeft > 0 && numCoinsLeft <= maxCoinsLeft) clStateCurrent = clStateTrigger;
	}

	public static bool IsDonePlaying()
	{
		return clStateCurrent == clStateIdle;
	}

	public void HandleTextures(int number)
	{
		if (number < 0 || number > 999) { Debug.Log("stack bonus is out of range!    " + number); return; }
		int start, count;
		if (number < 10) { start = 1; count = 1; }
		else if (number < 100) { start = 3; count = 2; }
		else { start = 0; count = 3; }
		DisableAllDigitRenders();
		int divisor = 1;
		for (int offset = 0; offset < count; offset++)
		{
			int rendererIndex = start + offset;
			clDigitsRendererArray[rendererIndex].enabled = true;
			clDigitsMaterialArray[rendererIndex].mainTexture = clDigitsTextureArray[number / divisor % 10];
			divisor *= 10;
		}
	}

	public void DisableAllDigitRenders()
	{
		for (int index = 0; index < 5; index++) clDigitsRendererArray[index].enabled = false;
	}

	public void Main()
	{
	}
}
