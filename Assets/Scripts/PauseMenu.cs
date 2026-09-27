using System;
using UnityEngine;

[Serializable]
public class PauseMenu : MonoBehaviour
{
	public GameObject roundIndicatorObject;

	public GameObject helpGameObject;

	public GameObject PauseMenuObject;

	public GameObject PauseMenuBgndObject;

	public GameObject FlickFingerObject;

	public bool enableButtonView;

	public GUISkin dummySkin;

	public GUISkin fontSkin;

	public GUISkin fontSkin_iPad;

	public Material replayMaterial;

	public Texture replayOnTexture;

	public Texture replayGreyTexture;

	public Material soundMaterial;

	public Texture soundOnTexture;

	public Texture soundGreyTexture;

	public static int replayDataMaxSlots = 9;

	public static bool triggerAnimIn;

	public static bool cancelPauseMenu;

	private int statePauseMenuIdle = 1000;

	private int statePauseMenuIn = 1001;

	private int statePauseMenu = 1002;

	private int statePauseMenuOut = 1003;

	private int statePauseMenuOutToHOF = 1004;

	private int statePauseMenuQuitOut = 1005;

	private int statePauseMenuHelpClick = 1006;

	private int statePauseMenuHelpSlideOut = 1007;

	private int statePauseMenuHelpScreen = 1008;

	private int currentState;

	private bool slideInUIFlag = true;

	private int test;

	private string infoClickAnimString = "InfoClick";

	private int currentHelpPage;

	private int numHelpPages = 2;

	public void Start()
	{
		currentState = statePauseMenuIdle;
		if (GameManagerScript.is_iPad())
		{
			Vector3 scale = PauseMenuBgndObject.transform.localScale;
			scale.x = GameManagerScript.iPadBackEndScaleX;
			PauseMenuBgndObject.transform.localScale = scale;
		}
	}

	public void HandleButtonMaterials()
	{
		replayMaterial.mainTexture = ReplayController.IsReplayDataValid() ? replayOnTexture : replayGreyTexture;
		soundMaterial.mainTexture = QuarterTrigger.muteF ? soundGreyTexture : soundOnTexture;
	}

	public bool isFlickShot()
	{
		return GameManagerScript.GetCurrentInputType() != GameManagerScript.inputTypeShake;
	}

	public void DrawHelpText()
	{
		GUI.skin = GameManagerScript.is_iPad() ? fontSkin_iPad : fontSkin;
		string text;
		if (currentHelpPage == 0)
			text = isFlickShot() ? "FLICK UP TO SHOOT\nDRAG TO AIM" : "SHAKE TO SHOOT\nDRAG TO AIM";
		else
			text = "LAND QUARTERS IN GLASSES\nRICOCHETS INCREASE YOUR SCORE";
		Rect rect = new Rect(40f, 90f, 240f, 300f);
		if (GameManagerScript.is_iPad()) rect = GameManagerScript.GetiPadRect(rect, false);
		GUI.Label(rect, text);
	}

	public void HandleHelpScreen()
	{
		DrawHelpText();
		if (!enableButtonView) GUI.skin = dummySkin;
		Rect rect = new Rect(480f, 0f, 50f, 50f);
		if (GameManagerScript.is_iPad()) rect = GameManagerScript.GetiPadRect(rect, false);
		if (GUI.Button(rect, string.Empty))
		{
			if (currentHelpPage == numHelpPages - 1)
			{
				if (GameManagerScript.is_iPad()) FlickFingerObject.renderer.enabled = true;
				HideHelpButton();
				animation.Play("animin");
				AnnouncerScript.triggerClickSound = true;
				currentState = statePauseMenuIn;
			}
			else currentHelpPage++;
		}
	}

	public void HandlePauseMenu()
	{
		if (!enableButtonView) GUI.skin = dummySkin;
		Rect quitRect = new Rect(100f, 200f, 180f, 48f);
		Rect replayRect = new Rect(120f, 256f, 200f, 48f);
		Rect doneRect = new Rect(0f, 426f, 120f, 40f);
		Rect soundRect = new Rect(146f, 426f, 43f, 40f);
		Rect helpRect = new Rect(GameManagerScript.is_iPad() ? 250f : 270f, 0f, 50f, 50f);
		if (GameManagerScript.is_iPad())
		{
			quitRect = GameManagerScript.GetiPadRect(quitRect, false);
			replayRect = GameManagerScript.GetiPadRect(replayRect, false);
			doneRect = GameManagerScript.GetiPadRect(doneRect, false);
			soundRect = GameManagerScript.GetiPadRect(soundRect, false);
			helpRect = GameManagerScript.GetiPadRect(helpRect, false);
		}
		if (GUI.Button(quitRect, string.Empty))
		{
			AnnouncerScript.triggerClickSound = true; animation.Play("quitclick"); animation.PlayQueued("animout");
			HideHelpButton(); GameManagerScript.StoreSecretRoundUnlockCode(6); currentState = statePauseMenuQuitOut;
		}
		if (GUI.Button(replayRect, string.Empty) && ReplayController.RequestReplay())
		{
			AnnouncerScript.triggerClickSound = true; animation.Play("flickclick"); animation.PlayQueued("animout");
			slideInUIFlag = false; GameManagerScript.StoreSecretRoundUnlockCode(5); HideHelpButton(); currentState = statePauseMenuOut;
		}
		if (GUI.Button(doneRect, string.Empty))
		{
			AnnouncerScript.triggerClickSound = true; animation.Play("doneclick"); animation.PlayQueued("animout");
			HideHelpButton(); GameManagerScript.StoreSecretRoundUnlockCode(0); currentState = statePauseMenuOut;
		}
		if (GUI.Button(soundRect, string.Empty))
		{
			animation.Play("soundclick"); QuarterTrigger.muteF = !QuarterTrigger.muteF;
			if (!QuarterTrigger.muteF) { AnnouncerScript.triggerClickSound = true; GameManagerScript.StoreSecretRoundUnlockCode(2); }
			else GameManagerScript.StoreSecretRoundUnlockCode(1);
			QuarterTrigger.SaveMutePref();
		}
		if (GUI.Button(helpRect, string.Empty))
		{
			AnnouncerScript.triggerClickSound = true; helpGameObject.animation.Play(infoClickAnimString);
			GameManagerScript.StoreSecretRoundUnlockCode(3); currentHelpPage = 0; currentState = statePauseMenuHelpClick;
		}
	}

	public void ReturnToGame()
	{
		QuarterTrigger.state = QuarterTrigger.stateWaitForShot;
		if (slideInUIFlag)
		{
			CoinHolder.triggerCoinHolderIn = GameManagerScript.curMadeShotsThisRound;
			InGameAngleIcon.triggerOnScreen = true;
			roundIndicatorObject.SetActiveRecursively(true);
			RoundIndicator.TriggerSlideIn = true;
		}
		PauseMenuObject.SetActiveRecursively(false);
	}

	public static void PlayAnimatingObjects(bool soundFlag, bool animFlag)
	{
		string[] paths = { "/biplane_00", "/helicopter_00", "/lazy_susan_00" };
		foreach (string path in paths)
		{
			GameObject animatedObject = GameObject.Find(path);
			if (animatedObject && animatedObject.animation)
			{
				if (animFlag) animatedObject.animation.Play(); else animatedObject.animation.Stop();
			}
		}
	}

	public void Update()
	{
		if (triggerAnimIn)
		{
			animation.Play("animin"); triggerAnimIn = false; slideInUIFlag = true;
			HandleButtonMaterials(); PlayAnimatingObjects(false, true); currentState = statePauseMenuIn;
		}
		if (currentState == statePauseMenuIn)
		{
			if (animation["animin"].time > 0.25f) QuarterTrigger.DisplayBackDrop(true);
			if (!animation.isPlaying) { DisplayHelpButton(); currentState = statePauseMenu; }
		}
		else if (currentState == statePauseMenuOut)
		{
			if (!animation.isPlaying)
			{
				PlayAnimatingObjects(!QuarterTrigger.muteF, true);
				if (!QuarterTrigger.requestLastReplay) QuarterTrigger.DisplayBackDrop(false);
				ReturnToGame(); currentState = statePauseMenuIdle;
			}
		}
		else if (currentState == statePauseMenuOutToHOF)
		{
			if (!animation.isPlaying) { PauseMenuObject.SetActiveRecursively(false); currentState = statePauseMenuIdle; }
		}
		else if (currentState == statePauseMenuQuitOut)
		{
			if (!animation.isPlaying)
			{
				QuarterTrigger.state = QuarterTrigger.stateGameOver; cancelPauseMenu = true;
				mainmenu.DeleteLastGame(); mainmenu.resumeQuitFromGame = true; currentState = statePauseMenuIdle;
			}
		}
		else if (currentState == statePauseMenuHelpClick && !helpGameObject.animation.IsPlaying(infoClickAnimString))
		{
			HideHelpButton(); animation.Play("animout"); currentState = statePauseMenuHelpSlideOut;
		}
		else if (currentState == statePauseMenuHelpSlideOut && !animation.IsPlaying("animout"))
		{
			if (GameManagerScript.is_iPad()) FlickFingerObject.renderer.enabled = false;
			DisplayHelpScreen(); currentState = statePauseMenuHelpScreen;
		}
	}

	public void HideHelpButton()
	{
		GameObject.Find("/ui_help/background01").renderer.enabled = false;
		GameObject.Find("/ui_help/dimplane").renderer.enabled = false;
		GameObject.Find("/ui_help/help").renderer.enabled = false;
		GameObject.Find("/ui_help/help_text").renderer.enabled = false;
	}

	public void DisplayHelpButton()
	{
		GameObject.Find("/ui_help/background01").renderer.enabled = false;
		GameObject.Find("/ui_help/dimplane").renderer.enabled = false;
		GameObject.Find("/ui_help/help").renderer.enabled = true;
		GameObject.Find("/ui_help/help_text").renderer.enabled = false;
	}

	public void DisplayHelpScreen()
	{
		GameObject.Find("/ui_help/background01").renderer.enabled = false;
		GameObject.Find("/ui_help/dimplane").renderer.enabled = true;
		GameObject.Find("/ui_help/help").renderer.enabled = false;
		GameObject.Find("/ui_help/help_text").renderer.enabled = true;
	}

	public void OnGUI()
	{
		if (currentState == statePauseMenu)
		{
			HandleButtonMaterials(); HandlePauseMenu();
		}
		else if (currentState == statePauseMenuHelpScreen) HandleHelpScreen();
	}

	public void Main()
	{
	}
}
