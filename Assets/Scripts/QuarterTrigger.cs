using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class QuarterTrigger : MonoBehaviour
{
	public static int fixedUpdateCounter;

	public int inAirTicks;

	public int shotTick;

	public int qdTimeInterval = 10;

	public int curQuarterDataIndex;

	public int quarterDataTicks;

	private int maxQuarterData = 200;

	public int[] replayQTick;

	public Vector3[] replayQPosition;

	public Quaternion[] replayQRotation;

	public Vector3[] replayQVelocity;

	public Vector3[] replayQAngVel;

	public float quarterVelThreshold = 1f;

	public int quarterCountThresh = 20;

	private int quarterVelCount;

	private Vector2 angleStartPosition;

	private Vector2 angleEndPosition;

	private int atsNone = 10;

	private int atsDown = 11;

	private int angleTouchState = 10;

	public int debugAngleTouchy;

	private bool DebugSpacebarShot = true;

	public GameObject lightRayObject;

	public ParticleEmitter GlassFlashEmitter;

	public float DebugXAdd;

	public float DebugZAdd;

	public int debugint;

	public int shotOverFlags;

	private ArrayList colliderSoundArray;

	private int colliderSoundSize;

	private float prevColliderSoundTime;

	private int prevColliderSoundType = -1;

	private float minColliderSoundDelay = 0.01f;

	private int[] colliderSoundPlayedCount;

	private int numColliderSoundTypes = 30;

	public AudioClip ricochetBonusSFX;

	public AudioClip secretRoundSFX;

	public AudioClip[] coinInGlassSFX;

	public int numCoinInGlassSFXs = 3;

	public AudioClip defaultAudioClip;

	public AudioClip[] glassBigSounds;

	public AudioClip[] glassMartiniSounds;

	public AudioClip[] glassMediumSounds;

	public AudioClip[] glassSmallSounds;

	public AudioClip[] glassTallSounds;

	public AudioClip[] lazySusanSounds;

	public AudioClip[] tableTopSounds;

	public AudioClip[] whiskeyBottleSounds;

	public AudioClip[] popBottleSounds;

	public AudioClip[] drinkingBirdSounds;

	public AudioClip[] checkBookSounds;

	public AudioClip[] bobbleHeadSounds;

	public AudioClip[] planeSounds;

	public AudioClip[] lighterSounds;

	public AudioClip[] phoneSounds;

	public AudioClip[] pendulumSounds;

	public AudioClip[] catapultSounds;

	public GameObject enterNameObject;

	public GameObject secretRoundObject;

	public GameObject roundIndicatorObject;

	public GameObject ricochetParentObject;

	public static int skipToRackupState;

	public GameObject streakExciterObject;

	public GameObject coinsLeftObject;

	public GameObject PracticeUIObject;

	public GameObject QuarterDrawObject;

	public GameObject ReplaySaveDoneButtonsObject;

	public GameObject shotTypeHelperObject;

	public int ReplayRicochetIndex;

	public float replayLaunchTime;

	public int lastPlayerNumber;

	public int lastRoundScore;

	public GameObject PracticeGreatScoreObject;

	public GameObject RoundCompleteObject;

	public GameObject GameOverExciterObject;

	public GameObject InGameHSObject;

	public GameObject StatsScreenObject;

	public GameObject PowerXObject;

	public static bool glassMultiplierTriggered;

	private iPhoneKeyboard keyboard;

	public static int birdAnimState;

	public static float minShotAngle = 45f;

	public static float maxShotAngle = 55f;

	public float shotDownZMag = 20f;

	public Vector3 Startpos;

	public Vector3 Startrot;

	public Quaternion Startquat;

	public static Collider NullCollider;

	public Collider inGlassCollider;

	public GameObject[] DEBUG_ColliderGameObjects;

	public ArrayList colliderInfo;

	private int maxColliders = 15;

	public int curColliderIndex;

	public Collider LastHitCollider;

	public Collider LastHitCollider0;

	public Collider LastHitCollider1;

	public Collider LastHitCollider2;

	public Collider LastHitCollider3;

	public Collider LastHitCollider4;

	public Collider LastHitCollider5;

	public Collider LastHitCollider6;

	public Collider LastHitCollider7;

	public Collider LastHitCollider8;

	public Collider LastHitCollider9;

	public Collider LastHitCollider10;

	public Collider LastHitCollider11;

	public Collider LastHitCollider12;

	public Collider LastHitCollider13;

	public Collider LastHitCollider14;

	public ArrayList colliderGameObjectInfo;

	public int curColliderGameObjectIndex;

	private int maxColliderGameObjects = 10;

	public GameObject gameObjectCollider0;

	public GameObject gameObjectCollider1;

	public GameObject gameObjectCollider2;

	public GameObject gameObjectCollider3;

	public GameObject gameObjectCollider4;

	public GameObject gameObjectCollider5;

	public GameObject gameObjectCollider6;

	public GameObject gameObjectCollider7;

	public GameObject gameObjectCollider8;

	public GameObject gameObjectCollider9;

	public GameObject gameObjectCollider10;

	public GameObject gameObjectCollider11;

	public GameObject gameObjectCollider12;

	public GameObject gameObjectCollider13;

	public GameObject gameObjectCollider14;

	public float gameObjectTime0;

	public float gameObjectTime1;

	public float gameObjectTime2;

	public float gameObjectTime3;

	public float gameObjectTime4;

	public float gameObjectTime5;

	public float gameObjectTime6;

	public float gameObjectTime7;

	public float gameObjectTime8;

	public float gameObjectTime9;

	public float gameObjectTime10;

	public float gameObjectTime11;

	public float gameObjectTime12;

	public float gameObjectTime13;

	public float gameObjectTime14;

	public int count = 10;

	public int waitCount;

	public float waitTime;

	private float shotvely = -16f;

	private float shotrotx = 6f;

	public float mag;

	public float xvel;

	public float xVelThresh = 0.7f;

	public float xvelScale = 1f;

	private Vector3 mainCamObjectDefaultPos;

	public GameObject mainCamObject;

	public GameObject replayCamObject;

	public GameObject replayCamObject2;

	public GameObject replayCamObject3;

	public GameObject introCamObject;

	public static int camMainCam;

	public static int camReplay1 = 1;

	public static int camReplay2 = 2;

	public static int camReplay3 = 3;

	public static int camIntro = 4;

	public static int curReplayCam;

	public float curAng = 0.707f;

	public static float shotMagnitude = 9f;

	public static int stateInitGame = 1000;

	public static int stateDisplayRound = 1001;

	public static int stateWaitForFirstTableImpact = 1002;

	public static int stateShotOver = 1003;

	public static int stateGameOver = 1004;

	public static int stateShotResult = 1005;

	public static int stateDisplayRoundIntro = 1007;

	public static int stateOptionsMenu = 1008;

	public static int stateInputNameInit = 1009;

	public static int stateInputName = 1010;

	public static int stateHiScoresTable = 1011;

	public static int stateAngleInput = 1013;

	public static int stateRackup = 1014;

	public static int stateBounceFly = 1015;

	public static int stateSelectLevel = 1016;

	public static int stateWaitForShotIntro = 1018;

	public static int stateWaitForShot;

	public static int stateShotInAir;

	public static int statePlayerRoundFinishedExciter = 1019;

	public static int stateGameOverExciter = 1020;

	public static int stateCoinsLeftStack = 1022;

	public static int stateAskToSaveReplay = 1023;

	public static int stateHallOfFame = 1024;

	public static int stateHallOfFameReplayExit = 1025;

	public static int stateBounceFlyInitWait = 1026;

	public static int stateInputNameLoadKeyboard = 1030;

	public static int stateWaitForHOFLoad = 1031;

	public static int state = 1000;

	public static int levelSelected;

	public static bool requestOptions;

	public static bool requestAngleInput;

	public static bool requestLastReplay;

	public bool doingRequestedReplay;

	public int waitForFirstBounceCount = 5;

	public static bool muteF;

	public float shotLaunchTime;

	public static float shotTime;

	public float shotTimeMax = 3.6f;

	public bool gameShouldEndFlag;

	public string stringPlayerName1 = "Hello2";

	public string playerName1 = "PLR1";

	public string playerName2 = "PLR2";

	public string playerName3 = "PLR3";

	public string playerName4 = "PLR4";

	public int savedCurrentScore;

	public GameObject RoundOneGlass00;

	public GameObject RoundOneGlass01;

	public GameObject RoundOneGlass02;

	public GameObject RoundOneGlass03;

	public GameObject RoundOneGlass04;

	public GameObject RoundOneGlass05;

	public GameObject RoundThreeGlass00;

	public GameObject RoundThreeGlass01;

	public GameObject RoundThreeGlass02;

	public GameObject RoundFourGlass00;

	public GameObject RoundFourGlass01;

	public GameObject RoundFourGlass02;

	public GameObject RoundFourGlass03;

	public GameObject RoundFourGlass04;

	public GameObject RoundSixGlass00;

	public GameObject RoundSixGlass01;

	public GameObject RoundSixGlass02;

	public GameObject RoundSixGlass03;

	public GameObject RoundSixGlass04;

	public GameObject RoundEightGlass00;

	public GameObject RoundEightGlass01;

	public GameObject RoundEightGlass02;

	public GameObject RoundEightGlass03;

	public GameObject RoundEightGlass04;

	public GameObject RoundNineGlass00;

	public GameObject RoundNineGlass01;

	public GameObject RoundNineGlass02;

	public GameObject RoundNineGlass03;

	public GameObject RoundTenGlass00;

	public GameObject RoundTenGlass01;

	public GameObject RoundTenGlass02;

	public GameObject RoundTenGlass03;

	public GameObject RoundElevenGlass00;

	public GameObject RoundElevenGlass01;

	public GameObject RoundElevenGlass02;

	public GameObject RoundTwelveGlass00;

	public GameObject RoundTwelveGlass01;

	public GameObject RoundTwelveGlass02;

	public GameObject RoundTwelveGlass03;

	public GameObject RoundTwelveGlass04;

	public GameObject RoundThirteenGlass00;

	public GameObject RoundThirteenGlass01;

	public GameObject RoundThirteenGlass02;

	public GameObject RoundFourteenGlass00;

	public GameObject RoundFourteenGlass01;

	public GameObject RoundFourteenGlass02;

	public GameObject RoundFourteenGlass03;

	public GameObject RoundFourteenGlass04;

	public GameObject RoundFourteenGlass05;

	public GameObject RoundFifteenGlass00;

	public GameObject RoundFifteenGlass01;

	public GameObject RoundFifteenGlass02;

	public GameObject RoundBonusGlass00;

	public GameObject RoundBonusGlass01;

	public GameObject RoundBonusGlass02;

	public GameObject RoundBonusGlass03;

	public GameObject RoundBonusGlass04;

	public GameObject RoundBonusGlass05;

	public GameObject RoundBonusGlass06;

	public GameObject RoundBonusGlass07;

	public GameObject RoundBonusGlass08;

	public GameObject glassShadow;

	public GameObject glassShadow2;

	public GameObject glassShadow3;

	public GameObject glassShadow4;

	public GameObject glassShadow5;

	public GameObject glassShadow6;

	public GameObject glassShadow7;

	public GameObject glassShadow8;

	public Vector2 debugTotTouchLength;

	public float debugTotTouchTime;

	public float debugFlickPower;

	public float touchYScale = 1f;

	public float debugTargetRange = 0.1f;

	public float magThreshFlick = 1.6f;

	public float shotPowerPower = 0.5f;

	public float shakeYScale = 0.75f;

	public float debugTargetRangeShake = 0.75f;

	public float magThresh = 1.9f;

	public float debugInputMag = 1.2f;

	public float debugScaleMag;

	public float debugScalePowMag;

	private float totAngleTouchTime;

	private Vector2 totAngleTouchLength;

	private int numTouches;

	public int bounceFlyCount;

	public float bounceFlyTime;

	public void InitQuarterData()
	{
		curQuarterDataIndex = 0;
		quarterDataTicks = 0;
		replayQTick = new int[maxQuarterData];
		replayQPosition = new Vector3[maxQuarterData];
		replayQRotation = new Quaternion[maxQuarterData];
		replayQVelocity = new Vector3[maxQuarterData];
		replayQAngVel = new Vector3[maxQuarterData];
	}

	public void ResetQuarterData()
	{
		curQuarterDataIndex = 0;
	}

	public void AddQuarterData(int tick)
	{
		if (tick % qdTimeInterval != 0)
			return;
		if (curQuarterDataIndex >= maxQuarterData)
		{
			Debug.Log("Quarter Data full");
			return;
		}
		Rigidbody body = gameObject.rigidbody;
		replayQPosition[curQuarterDataIndex] = body.position;
		replayQRotation[curQuarterDataIndex] = body.rotation;
		replayQVelocity[curQuarterDataIndex] = body.velocity;
		replayQAngVel[curQuarterDataIndex] = body.angularVelocity;
		curQuarterDataIndex++;
		quarterDataTicks = curQuarterDataIndex;
	}

	public void RestoreQuarterData(int tick)
	{
		if (ReplayController.hallOfFameReplay)
		{
			quarterDataTicks = 0;
			return;
		}
		if (tick % qdTimeInterval != 0 || curQuarterDataIndex >= quarterDataTicks)
			return;
		if (curQuarterDataIndex >= maxQuarterData)
		{
			Debug.Log("Quarter Data full");
			return;
		}
		Rigidbody body = gameObject.rigidbody;
		body.position = replayQPosition[curQuarterDataIndex];
		body.rotation = replayQRotation[curQuarterDataIndex];
		body.velocity = replayQVelocity[curQuarterDataIndex];
		body.angularVelocity = replayQAngVel[curQuarterDataIndex];
		curQuarterDataIndex++;
	}

	public void LoadMutePref()
	{
		muteF = PlayerPrefs.HasKey("MuteValue") && PlayerPrefs.GetInt("MuteValue") != 0;
	}

	public static void DisplayQuarterAndShadow(bool displayFlag)
	{
		GameObject quarter = GameObject.Find("/a_quarter5/root");
		if (quarter) quarter.renderer.enabled = displayFlag;
		GameObject shadow = GameObject.Find("/shadowQuarter");
		if (shadow) shadow.renderer.enabled = displayFlag;
	}

	public static void SaveMutePref()
	{
		PlayerPrefs.SetInt("MuteValue", muteF ? 1 : 0);
	}

	public void LoadPlayerNamesFromPrefs()
	{
		string value = PlayerPrefs.GetString("savedName1");
		if (value != string.Empty) playerName1 = value;
		value = PlayerPrefs.GetString("savedName2");
		if (value != string.Empty) playerName2 = value;
		value = PlayerPrefs.GetString("savedName3");
		if (value != string.Empty) playerName3 = value;
		value = PlayerPrefs.GetString("savedName4");
		if (value != string.Empty) playerName4 = value;
	}

	public static void SavePlayerNameToPrefs(string name, int idx)
	{
		if (idx >= 0 && idx < 4)
			PlayerPrefs.SetString("savedName" + (idx + 1), name);
	}

	public static void DisplayBackDrop(bool displayFlag)
	{
		GameObject backdrop = GameObject.Find("BackDrop");
		if (backdrop) backdrop.renderer.enabled = displayFlag;
	}

	public void Start()
	{
		debugint = 0;
		if (colliderSoundArray == null) colliderSoundArray = new ArrayList();
		if (colliderInfo == null) colliderInfo = new ArrayList();
		if (colliderGameObjectInfo == null) colliderGameObjectInfo = new ArrayList();
		InitQuarterData();
		PracticeUIObject.SetActiveRecursively(false);
		iPhoneKeyboard.autorotateToPortraitUpsideDown = GameManagerScript.is_iPad();
		iPhoneKeyboard.autorotateToLandscapeLeft = false;
		iPhoneKeyboard.autorotateToLandscapeRight = false;
		mainCamObject.active = false;
		mainCamObjectDefaultPos = mainCamObject.transform.position;
		StatsScreenObject.SetActiveRecursively(false);
		colliderSoundPlayedCount = new int[numColliderSoundTypes];
		ResetColliderSoundArray();
		state = stateInitGame;
		requestOptions = requestAngleInput = false;
		Startpos = rigidbody.position;
		Startrot = transform.eulerAngles;
		Startquat = rigidbody.rotation;
		ResetQuarter();
		curReplayCam = camReplay3;
		toggleCamera(camMainCam);
		if (DEBUG_ColliderGameObjects == null || DEBUG_ColliderGameObjects.Length < maxColliders)
			DEBUG_ColliderGameObjects = new GameObject[maxColliders];
		ResetColliderInfo();
		ResetColliderGameObjectInfo();
		LoadPlayerNamesFromPrefs();
		LoadMutePref();
		GameManagerScript.shotAngle = GameManagerScript.defaultShotAngle;
		if (mainmenu.resumeTriggerYes) { mainmenu.resumeTriggerYes = false; mainmenu.LoadLastGame(); }
		else { if (mainmenu.feGameType == mainmenu.gtClassic) mainmenu.DeleteLastGame(); GameManagerScript.curMadeShotsThisRound = 0; }
		if (GameManagerScript.is_iPad())
		{
			GameObject backdrop = GameObject.Find("BackDrop");
			if (backdrop) { Vector3 scale = backdrop.transform.localScale; scale.x = 36.25f; backdrop.transform.localScale = scale; }
		}
		HiScoreScript.guiIndex = -1;
		skipToRackupState = 0;
	}

	public void ResetQuarter()
	{
		skipToRackupState = 0;
		debugint = inAirTicks = quarterVelCount = ReplayRicochetIndex = 0;
		rigidbody.MovePosition(Startpos);
		rigidbody.MoveRotation(Startquat);
		transform.position = Startpos;
		transform.eulerAngles = Startrot;
		GlassScaleController.inThisGlassObject = null;
		inGlassCollider = NullCollider;
		rigidbody.isKinematic = false;
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.isKinematic = true;
		birdAnimState = 0;
		shotLaunchTime = -1f;
		QuarterDrawObject.active = true;
		LastHitCollider = NullCollider;
		ResetColliderSoundArray();
		DisplayQuarterAndShadow(true);
		glassMultiplierTriggered = false;
	}

	public void ComputeQuarterVel()
	{
		if (rigidbody.velocity.sqrMagnitude < quarterVelThreshold * quarterVelThreshold)
			quarterVelCount++;
		else
			quarterVelCount = 0;
	}

	public bool CheckQuarterVel()
	{
		return quarterVelCount > quarterCountThresh;
	}

	public void GlassEmitterFlash(Vector3 pos)
	{
		GlassFlashEmitter.transform.position = pos;
		GlassFlashEmitter.Emit(1);
	}

	public void AddCollisionToList(Collision collision)
	{
		if (state != stateShotInAir)
			return;
		foreach (ContactPoint contact in collision.contacts)
		{
			AddColliderSound(contact.collider);
			PlayColliderSound();
			if (!GameManagerScript.replayFlag && contact.collider != LastHitCollider)
			{
				AddColliderToList(contact.collider);
				LastHitCollider = contact.collider;
				GlassEmitterFlash(contact.point);
			}
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		AddCollisionToList(collision);
	}

	public void OnCollisionStay(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
			if (contact.separation > 0.05f)
				inGlassCollider = contact.collider;
	}

	public void fUpdate()
	{
		if (state == stateShotInAir) ComputeQuarterVel();
		if (state == stateWaitForFirstTableImpact)
		{
			if (waitCount == 5) birdAnimState = GameManagerScript.replayFlag ? 2 : 1;
			waitCount--;
			if (waitCount < 0)
			{
				Vector3 position = rigidbody.position; position.y += 1f; rigidbody.position = position;
				float power = shotMagnitude * GameManagerScript.shotMagnitude;
				float angle = GameManagerScript.shotAngle * Mathf.Deg2Rad;
				rigidbody.velocity = new Vector3(GameManagerScript.shotMagX, power * Mathf.Sin(angle), power * Mathf.Cos(angle));
				rigidbody.AddTorque(Vector3.right * shotrotx);
				shotTime = Time.time + shotTimeMax;
				shotLaunchTime = Time.time;
				if (!muteF && audio) { audio.clip = defaultAudioClip; audio.Play(); }
				state = stateShotInAir;
			}
			if (skipToRackupState == 1 && !doingRequestedReplay)
			{
				GameManagerScript.replayFlag = false; skipToRackupState = 2;
				ricochetParentObject.SetActiveRecursively(false); SetRackupState(true);
			}
		}
	}

	public static void AddtoShotTime(float addTime)
	{
		shotTime += addTime;
	}

	public int isInGlass()
	{
		GlassScaleController.inThisGlassObject = null;
		if (!inGlassCollider)
			return 0;

		int glass = 0;
		switch (inGlassCollider.name)
		{
			case "COL": glass = 1; break;
			case "COL2": glass = 2; break;
			case "COL3": glass = 3; break;
			case "COL4": glass = 4; break;
		}
		if (glass != 0 && inGlassCollider.attachedRigidbody)
			GlassScaleController.inThisGlassObject = inGlassCollider.attachedRigidbody.gameObject;
		return glass;
	}

	public void SetSelectLevelState()
	{
		state = stateSelectLevel;
		waitTime = Time.time + 10f;
		QuarterDrawObject.active = false;
		PracticeUIObject.SetActiveRecursively(true);
		PracticeUI.triggerPracticeUI = true;
		if (GameManagerScript.curRound < 0) GameManagerScript.curRound = 0;
		PracticeUI.curLevelSelected = GameManagerScript.curRound;
		levelSelected = GameManagerScript.curRound;
		GameManagerScript.shotAngle = GameManagerScript.defaultShotAngle;
		GameManagerScript.ClearAllScores();
		GameManagerScript.SetCurrentShotsLeft(40);
		GameManagerScript.curMadeShotsThisRound = 0;
		GameObject.Find("/shadowQuarter").renderer.enabled = false;
	}

	public void SetRoundDisplayState()
	{
		state = stateDisplayRoundIntro;
		waitTime = Time.time + 0.5f;
	}

	public void SetBounceFlyCountState(int shotScore)
	{
		state = stateBounceFlyInitWait;
		waitTime = Time.time + 0.75f;
		bounceFlyCount = Mathf.Min(shotScore, 9);
		CrowdScript.playApplauseSound = GameManagerScript.curMadeShotsThisRound + 1;
		bounceFlyTime = Time.time - 0.1f;
	}

	public void SetShotResultState(bool longerTimeF)
	{
		state = stateShotResult;
		waitTime = Time.time + (longerTimeF ? 1.5f : 0f);
	}

	public void SetRackupState(bool skipFlag)
	{
		if (!skipFlag)
		{
			RicochetExciter.TriggerScore = ReplayRicochetIndex - 1;
			if (!muteF)
			{
				audio.clip = ricochetBonusSFX;
				audio.Play();
			}
		}
		waitTime = skipFlag ? Time.time : Time.time + 1.25f;
		state = stateRackup;
	}

	public void SetShotOverState()
	{
		RicochetExciter.numRicochets = 0;
		skipToRackupState = 0;
		state = stateShotOver;
	}

	public void SetGameOverState()
	{
		state = stateGameOver;
		waitTime = Time.time + 10f;
		DisplayBackDrop(true);
		StatsScreenObject.SetActiveRecursively(true);
		StatsScreen.triggerStatscreen = true;
	}

	public void ExitInputNameState()
	{
		SetHiScoresTableState();
	}

	public void SetInputNameState()
	{
		DisplayBackDrop(true);
		state = stateInputNameInit;
	}

	public void SetHiScoresTableState()
	{
		InGameHSObject.SetActiveRecursively(true);
		InGameHiScore.triggerHiScores = true;
		DisplayBackDrop(true);
		state = stateHiScoresTable;
		waitTime = Time.time + 10f;
	}

	public bool StateRoundDisplayRules()
	{
		return Time.time > waitTime;
	}

	public void ResetAndExitLevel()
	{
		levelSelected = 0;
		Application.LoadLevel("frontend");
	}

	public void ProcessTouchforAngle()
	{
		if (iPhoneInput.touchCount != 1) { angleTouchState = atsNone; return; }
		foreach (iPhoneTouch touch in iPhoneInput.touches)
		{
			if (angleTouchState == atsNone && touch.phase == iPhoneTouchPhase.Began)
			{
				angleStartPosition = angleEndPosition = touch.position; angleTouchState = atsDown;
			}
			else if (angleTouchState == atsDown)
			{
				angleEndPosition = touch.position;
				int delta = (int)Mathf.Floor((angleEndPosition - angleStartPosition).y * 0.075f);
				if (delta != 0)
				{
					angleStartPosition = angleEndPosition;
					GameManagerScript.shotAngle = Mathf.Clamp(GameManagerScript.shotAngle - delta, minShotAngle, maxShotAngle);
				}
			}
		}
	}

	public void ProcessTouchforAngleDeprecated()
	{
		totAngleTouchTime = 0f; totAngleTouchLength = Vector2.zero; numTouches = 0;
		foreach (iPhoneTouch touch in iPhoneInput.touches)
		{
			float limit = GameManagerScript.is_iPad() ? 944f : 414f;
			if (touch.position.y >= limit) break;
			totAngleTouchLength += touch.deltaPosition; totAngleTouchTime += touch.deltaTime; numTouches++;
		}
		if (numTouches > 0)
		{
			float movement = totAngleTouchLength.y * 0.12f;
			if (movement > 1f) GameManagerScript.shotAngle -= 1f;
			if (movement < -1f) GameManagerScript.shotAngle += 1f;
			GameManagerScript.shotAngle = Mathf.Clamp(GameManagerScript.shotAngle, minShotAngle, maxShotAngle);
		}
	}

	public void SetPlayerRoundFinishedPracticeOutofShots(int lastRound, int playerIndex)
	{
		GameOverExciterObject.SetActiveRecursively(true);
		GameOver.triggerExciterOutOfShots = true;
		state = statePlayerRoundFinishedExciter;
		waitTime = Time.time + 2.25f;
	}

	public void SetPlayerRoundFinishedState(int lastRound, int playerIndex)
	{
		bool newRoundHigh = false;
		if (mainmenu.feGameType == mainmenu.gtClassic)
		{
			bool showRoundComplete = true;
			if (GameManagerScript.secretRoundUnlocked && lastRound == GameManagerScript.roundBeforeSecretRound)
			{
				secretRoundObject.SetActiveRecursively(true); SecretRound.TriggerSecretRoundIntro = true;
				if (!muteF) { audio.clip = secretRoundSFX; audio.Play(); }
			}
			else if (lastRound == GameManagerScript.secretRoundNumber)
			{
				secretRoundObject.SetActiveRecursively(true); SecretRound.TriggerSecretRoundOutro = true;
				if (!muteF) { audio.clip = secretRoundSFX; audio.Play(); }
				showRoundComplete = false;
			}
			else
			{
				RoundCompleteObject.SetActiveRecursively(true);
				RoundComplete.roundToDisplay = lastRound;
				RoundComplete.displayScore = lastRoundScore;
			}
			if (showRoundComplete)
			{
				newRoundHigh = HiScoreRoundScript.AddRoundHiScore(lastRound, lastRoundScore, GameManagerScript.GetName(playerIndex));
				if (newRoundHigh) HiScoreRoundScript.SaveEntries();
				HiScoreScript.UpdateLockedRoundIndex(lastRound);
				if ((shotOverFlags & (GameManagerScript.flagPlayerGameOver | GameManagerScript.flagOutOfShotsReason)) != 0)
				{
					GameManagerScript.AddPlayerScore(GameManagerScript.GetPlayerShotsLeft(playerIndex) * 5, playerIndex);
					HiScoreScript.guiIndex = HiScoreScript.InsertHiScore(GameManagerScript.GetPlayerScore(playerIndex), "PLR" + (playerIndex + 1));
					HiScoreScript.SaveEntries();
				}
			}
		}
		else if (lastRoundScore > HiScoreRoundScript.GetScore(lastRound))
		{
			PracticeGreatScoreObject.SetActiveRecursively(true);
			PracticeGreatScore.triggerGreatScore = true;
			PracticeGreatScore.displayScore = lastRoundScore;
		}
		if (newRoundHigh) RoundComplete.triggerExciterNewRoundHigh = true;
		else RoundComplete.triggerExciterRoundFinished = true;
		if (curColliderGameObjectIndex < 2) CoinHolder.triggerCoinHolderOutAll = true;
		state = statePlayerRoundFinishedExciter;
		waitTime = mainmenu.feGameType == mainmenu.gtPractice && !PracticeGreatScore.triggerGreatScore ? Time.time : Time.time + 2.25f;
	}

	public void SetGameOverExciterState()
	{
		GameOverExciterObject.SetActiveRecursively(true);
		if ((shotOverFlags & GameManagerScript.flagOutOfShotsReason) != 0)
		{
			GameOver.triggerExciterOutOfShots = true;
			HiScoreScript.guiIndex = HiScoreScript.InsertHiScore(GameManagerScript.GetPlayerScore(lastPlayerNumber), "PLR" + (lastPlayerNumber + 1));
			HiScoreScript.SaveEntries();
		}
		else GameOver.triggerExciterGameComplete = true;
		if (Mathf.Abs(QuarterDrawObject.transform.position.x) > 20f || Mathf.Abs(QuarterDrawObject.transform.position.z) > 20f)
		{
			rigidbody.velocity = Vector3.zero; rigidbody.angularVelocity = Vector3.zero; rigidbody.isKinematic = true;
		}
		waitTime = Time.time + 2.35f;
		state = stateGameOverExciter;
	}

	public void ExitShotOverState(bool gameShouldEnd)
	{
		gameShouldEndFlag = gameShouldEnd;
		if (HiScoreScript.guiIndex >= 0) SetInputNameState();
		else if (gameShouldEndFlag) SetGameOverState();
		else { SetRoundDisplayState(); ResetQuarter(); }
	}

	public void CheckForAngleReminder()
	{
		if (GameManagerScript.curRound == 0 || GameManagerScript.curRound == 3 || GameManagerScript.curRound == 5 ||
			GameManagerScript.curRound == 6 || GameManagerScript.curRound == 7 || GameManagerScript.curRound == 8 || GameManagerScript.curRound == 10)
			InGameAngleIcon.triggerReminder = true;
	}

	public void FixedUpdate()
	{
		fUpdate();
		if (state == stateInitGame)
		{
			SetGlasses(); state = stateDisplayRoundIntro; return;
		}
		if (state == stateSelectLevel)
		{
			if (PracticeUI.triggerLevelSwitch)
			{
				levelSelected = PracticeUI.curLevelSelected; SetGlasses();
				PracticeUI.triggerDelayedLockAnim = true; PracticeUI.triggerLevelSwitch = false;
			}
			if (PracticeUI.selectLevelDone)
			{
				state = stateDisplayRound; waitTime = Time.time + 0.5f; ResetQuarter();
				PracticeUI.selectLevelDone = false;
				GameObject shadow = GameObject.Find("/shadowQuarter"); if (shadow) shadow.renderer.enabled = true;
			}
			return;
		}
		if (state == stateDisplayRoundIntro)
		{
			if ((GameManagerScript.totPlayers != 1 || GameManagerScript.curRound == 0) && mainmenu.feGameType == mainmenu.gtClassic)
				AnnouncerScript.triggerPlayerVO = GameManagerScript.curPlayer + 1;
			if (mainmenu.feGameType == mainmenu.gtPractice) SetSelectLevelState();
			else
			{
				state = stateDisplayRound; UIPlayer.triggerPlayer1 = true;
				shotTypeHelperObject.SetActiveRecursively(true); ShotTypeHelper.triggerShotTypeHelper = true;
			}
			return;
		}
		if (state == stateDisplayRound)
		{
			if (StateRoundDisplayRules())
			{
				state = stateWaitForShotIntro; CheckForAngleReminder();
				if (!GameManagerScript.replayFlag) CoinHolder.triggerCoinHolderIn = GameManagerScript.curMadeShotsThisRound;
			}
			return;
		}
		if (state == stateWaitForShotIntro)
		{
			if (!GameManagerScript.replayFlag)
			{
				InGameAngleIcon.triggerOnScreen = true; roundIndicatorObject.SetActiveRecursively(true); RoundIndicator.TriggerSlideIn = true;
			}
			state = stateWaitForShot; return;
		}
		if (state == stateWaitForHOFLoad)
		{
			if (Time.time > waitTime) { DisplayBackDrop(false); state = stateWaitForShotIntro; }
			return;
		}
		if (state == stateWaitForShot)
		{
			fixedUpdateCounter++;
			if (GameManagerScript.replayFlag)
			{
				rigidbody.isKinematic = false;
				rigidbody.velocity = new Vector3(ReplayController.replayshotmagx, shotvely, GameManagerScript.shotVelZ);
				rigidbody.WakeUp(); state = stateWaitForFirstTableImpact; waitCount = waitForFirstBounceCount; return;
			}
			if (requestLastReplay)
			{
				GameManagerScript.replayFlag = true; ReplayController.savedCurrentRound = GameManagerScript.curRound;
				bool changedRound = GameManagerScript.curRound != ReplayController.replayRound;
				GameManagerScript.curRound = ReplayController.replayRound;
				if (mainmenu.feGameType == mainmenu.gtPractice) levelSelected = GameManagerScript.curRound;
				if (changedRound) SetGlasses();
				requestLastReplay = false; doingRequestedReplay = true;
				if (changedRound) { DisplayBackDrop(true); waitTime = Time.time + 0.5f; state = stateWaitForHOFLoad; }
				else { DisplayBackDrop(false); state = stateWaitForShotIntro; }
				return;
			}
			if (requestOptions) { state = stateOptionsMenu; requestOptions = false; return; }
			if (requestAngleInput) { state = stateAngleInput; requestAngleInput = false; return; }

			Vector2 accumulated = Vector2.zero; float duration = 0f;
			foreach (iPhoneTouch touch in iPhoneInput.touches) { accumulated += touch.deltaPosition; duration += touch.deltaTime; }
			float inputMagnitude = accumulated.magnitude;
			mag = Mathf.Pow(Mathf.Min(inputMagnitude, 360f) * 0.1f / magThresh, shotPowerPower);
			xvel = inputMagnitude > 0f ? accumulated.x / inputMagnitude * xVelThresh : 0f;
			if (DebugSpacebarShot && Input.GetButtonDown("Jump")) { mag = debugInputMag; xvel += DebugXAdd; }
			if (mag > debugTargetRange)
			{
				shotTick = 5; ReplayController.SaveShotTick(shotTick); fixedUpdateCounter = 0;
				inAirTicks = quarterVelCount = 0;
				float normalizedAngle = Mathf.Clamp01((GameManagerScript.shotAngle - minShotAngle) / (maxShotAngle - minShotAngle));
				GameManagerScript.shotVelZ = (1f - normalizedAngle) * shotDownZMag;
				rigidbody.isKinematic = false;
				rigidbody.velocity = new Vector3(xvel, shotvely, GameManagerScript.shotVelZ);
				GameManagerScript.shotMagnitude = mag; GameManagerScript.shotMagX = xvel;
				rigidbody.WakeUp(); CoinHolder.coinTriggered = false;
				CoinHolder.triggerCoinHolderOut = GameManagerScript.curMadeShotsThisRound;
				InGameAngleIcon.triggerOffScreen = true; RoundIndicator.TriggerSlideOut = true;
				ReplayController.SetShotParameters(mag, xvel, GameManagerScript.shotVelZ, GameManagerScript.shotAngle);
				doingRequestedReplay = false; ReplayController.stateAskToSaveReplay_OverFlag = false;
				state = stateWaitForFirstTableImpact; waitCount = waitForFirstBounceCount;
			}
			return;
		}
		if (state == stateAngleInput) { ProcessTouchforAngle(); return; }
		if (state == stateOptionsMenu) return;
		if (state == stateShotInAir)
		{
			if (GameManagerScript.replayFlag) RestoreQuarterData(inAirTicks); else AddQuarterData(inAirTicks);
			inAirTicks++;
			if (skipToRackupState == 1 && !doingRequestedReplay)
			{
				GameManagerScript.replayFlag = false; skipToRackupState = 2; ricochetParentObject.SetActiveRecursively(false); SetRackupState(true); return;
			}
			if (!rigidbody.IsSleeping() && rigidbody.position.y >= -10f && Time.time <= shotTime && !CheckQuarterVel()) return;
			if (rigidbody.position.y < -10f) { AnnouncerScript.triggerOffTableVO = true; inGlassCollider = NullCollider; }
			if (GameManagerScript.replayFlag)
			{
				GameManagerScript.replayFlag = false;
				if (doingRequestedReplay)
				{
					if (ReplayController.hallOfFameReplay) state = stateHallOfFameReplayExit;
					else { rigidbody.velocity = rigidbody.angularVelocity = Vector3.zero; rigidbody.isKinematic = true; ReplayController.TriggerSlideIn(); ReplaySaveDoneButtonsObject.SetActiveRecursively(true); state = stateAskToSaveReplay; }
				}
				else SetRackupState(false);
				return;
			}
			int shotScore = isInGlass();
			savedCurrentScore = shotScore;
			GameManagerScript.AddScore(shotScore * 25);
			if (shotScore > 1) { glassMultiplierTriggered = true; PowerXObject.SetActiveRecursively(true); PowerX.pUpIndex = shotScore; PowerX.triggerPowerUp = true; }
			BuildCollisionChain();
			if (shotScore == 0)
			{
				if (GameManagerScript.GetCurrentShotsLeft() > 1) { CoinHolder.triggerCoinHolderIn = GameManagerScript.curMadeShotsThisRound; CoinHolder.triggerCoinsLeftAnim = true; }
				toggleCamera(camMainCam); SetShotOverState();
			}
			else
			{
				GameManagerScript.UpdateCurRicochet(curColliderGameObjectIndex - 1); GameManagerScript.IncrementCurrentStreak();
				int streak = GameManagerScript.GetCurrentTotalStreak();
				if (streak > 1) { streakExciterObject.SetActiveRecursively(true); Streak.streakCount = streak; Streak.stateCurrent = Streak.stateTrigger; }
				AnnouncerScript.triggerPerfectRoundVO = true; GlassScaleController.triggerGlassScale = true;
				lightRayObject.SetActiveRecursively(true); lightray.triggerLightRay = true; SetBounceFlyCountState(shotScore);
			}
			return;
		}
		if (state == stateAskToSaveReplay) { if (ReplayController.stateAskToSaveReplay_OverFlag) { RestoreFromReplay(); ReplayController.stateAskToSaveReplay_OverFlag = false; } return; }
		if (state == stateHallOfFameReplayExit) { RestoreFromReplay(); return; }
		if (state == stateBounceFlyInitWait) { if (Time.time > waitTime) state = stateBounceFly; return; }
		if (state == stateBounceFly)
		{
			if (Time.time > bounceFlyTime && bounceFlyCount > 0)
			{
				if (!CoinHolder.coinTriggered) { CoinHolder.triggerCoinHolderIn = GameManagerScript.curMadeShotsThisRound; CoinHolder.TriggerCoinIn(GameManagerScript.curMadeShotsThisRound); }
				bounceFlyCount--; bounceFlyTime = Time.time + 0.2f; if (bounceFlyCount == 0) waitTime = Time.time + 0.5f;
			}
			if (Time.time > waitTime && bounceFlyCount == 0) { if (curColliderGameObjectIndex < 2) { toggleCamera(camMainCam); SetShotOverState(); } else SetShotResultState(false); }
			return;
		}
		if (state == stateShotResult)
		{
			if (Time.time > waitTime)
			{
				if (curColliderGameObjectIndex < 2) state = stateShotOver;
				else
				{
					GameManagerScript.replayFlag = true; ricochetParentObject.SetActiveRecursively(true); RicochetExciter.TriggerOn = true;
					CoinHolder.triggerCoinHolderOut = GameManagerScript.curMadeShotsThisRound + 1; debugint = 0;
					toggleCamera(curReplayCam); curReplayCam = curReplayCam == camReplay1 ? camReplay2 : (curReplayCam == camReplay2 ? camReplay3 : camReplay1);
					ResetQuarter();
				}
			}
			return;
		}
		if (state == stateRackup)
		{
			if (Time.time > waitTime)
			{
				GameManagerScript.AddScore((curColliderGameObjectIndex - 1) * 10);
				if (GameManagerScript.curMadeShotsThisRound + 1 < GameManagerScript.shotsPerRound) CoinHolder.triggerCoinHolderIn = GameManagerScript.curMadeShotsThisRound + 1;
				ResetQuarter(); SetShotOverState(); GameManagerScript.replayFlag = false; toggleCamera(camMainCam);
			}
			return;
		}
		if (state == stateShotOver)
		{
			lastPlayerNumber = GameManagerScript.curPlayer; int lastRound = GameManagerScript.curRound;
			lastRoundScore = GameManagerScript.GetCurrentRoundScore(); shotOverFlags = GameManagerScript.UpdateShotCount(savedCurrentScore);
			if (mainmenu.feGameType == mainmenu.gtClassic) { if ((shotOverFlags & GameManagerScript.flagGameOver) == 0) mainmenu.SaveLastGame(); else mainmenu.DeleteLastGame(); }
			if (shotOverFlags == 0) { state = stateWaitForShotIntro; ResetQuarter(); }
			else if ((shotOverFlags & GameManagerScript.flagOutOfShotsReason) == 0)
			{
				if ((shotOverFlags & (GameManagerScript.flagPlayerChange | GameManagerScript.flagRoundChange)) != 0) SetPlayerRoundFinishedState(lastRound, lastPlayerNumber);
			}
			else if (mainmenu.feGameType == mainmenu.gtPractice) SetPlayerRoundFinishedPracticeOutofShots(lastRound, lastPlayerNumber);
			else { GameManagerScript.shotAngle = GameManagerScript.defaultShotAngle; SetGameOverExciterState(); }
			return;
		}
		if (state == statePlayerRoundFinishedExciter)
		{
			if (Time.time > waitTime)
			{
				if ((shotOverFlags & GameManagerScript.flagPlayerGameOver) != 0 && mainmenu.feGameType == mainmenu.gtClassic) { GameManagerScript.shotAngle = GameManagerScript.defaultShotAngle; SetGameOverExciterState(); }
				else { SetRoundDisplayState(); ResetQuarter(); GameManagerScript.shotAngle = GameManagerScript.defaultShotAngle; SetGlasses(); }
			}
			return;
		}
		if (state == stateGameOverExciter)
		{
			if (Time.time > waitTime)
			{
				if ((shotOverFlags & (GameManagerScript.flagPlayerGameOver | GameManagerScript.flagOutOfShotsReason)) == 0) gameOverExciterRules();
				else { int coins = GameManagerScript.GetPlayerShotsLeft(lastPlayerNumber); coinsLeftObject.SetActiveRecursively(true); CoinsLeft.TriggerAnim(coins); DisplayBackDrop(coins > 0 || (shotOverFlags & GameManagerScript.flagGameOver) != 0); state = stateCoinsLeftStack; }
				TurnBuzzingSoundOff();
			}
			return;
		}
		if (state == stateCoinsLeftStack)
		{
			if (CoinsLeft.IsDonePlaying()) { coinsLeftObject.SetActiveRecursively(false); gameOverExciterRules(); if ((shotOverFlags & GameManagerScript.flagRoundChange) != 0 && (shotOverFlags & GameManagerScript.flagGameOver) == 0) SetGlasses(); }
			return;
		}
		if (state == stateGameOver)
		{
			if (StatsScreen.cancelStatscreen || PauseMenu.cancelPauseMenu || PracticeUI.cancelPracticeScreen) { StatsScreen.cancelStatscreen = PauseMenu.cancelPauseMenu = PracticeUI.cancelPracticeScreen = false; ResetAndExitLevel(); }
			return;
		}
		if (state == stateInputNameInit)
		{
			if (GameManagerScript.GetNameEnteredFlag(lastPlayerNumber)) { stringPlayerName1 = GetPlayerName(lastPlayerNumber); ExitInputNameState(); }
			else { enterNameObject.SetActiveRecursively(true); enterNameObject.animation.Play("SlideIn"); waitTime = Time.time + 0.5f; DisplayBackDrop(true); state = stateInputNameLoadKeyboard; }
			return;
		}
		if (state == stateInputNameLoadKeyboard)
		{
			if (Time.time > waitTime) { stringPlayerName1 = GetPlayerName(lastPlayerNumber); keyboard = iPhoneKeyboard.Open(stringPlayerName1); state = stateInputName; }
			return;
		}
		if (state == stateInputName)
		{
			if (keyboard != null) stringPlayerName1 = keyboard.text;
			if (keyboard != null && (keyboard.done || !keyboard.active))
			{
				enterNameObject.SetActiveRecursively(false); stringPlayerName1 = keyboard.text;
				GameManagerScript.SetNameEnteredFlag(lastPlayerNumber); GameManagerScript.SetName(stringPlayerName1, lastPlayerNumber);
				SavePlayerNameToPrefs(stringPlayerName1, lastPlayerNumber); HiScoreScript.SetHiScoreName(HiScoreScript.guiIndex, GameManagerScript.GetName(lastPlayerNumber)); HiScoreScript.SaveEntries(); ExitInputNameState();
			}
			return;
		}
		if (state == stateHiScoresTable && InGameHiScore.cancelHiScores)
		{
			HiScoreScript.guiIndex = -1; InGameHiScore.cancelHiScores = false;
			if (gameShouldEndFlag) SetGameOverState(); else { SetGlasses(); SetRoundDisplayState(); ResetQuarter(); }
		}
	}

	public void RestoreFromReplay()
	{
		ReplayController.hallOfFameReplay = false;
		doingRequestedReplay = false;
		if (ReplayController.savedCurrentRound != GameManagerScript.curRound)
		{
			GameManagerScript.curRound = ReplayController.savedCurrentRound;
			levelSelected = ReplayController.savedCurrentRound;
			SetGlasses();
		}
		CoinHolder.triggerCoinHolderIn = GameManagerScript.curMadeShotsThisRound;
		state = stateWaitForShotIntro;
		ResetQuarter();
	}

	public void gameOverExciterRules()
	{
		ExitShotOverState((shotOverFlags & GameManagerScript.flagGameOver) != 0);
	}

	public string GetPlayerName(int idx)
	{
		switch (idx)
		{
			case 1: return playerName2;
			case 2: return playerName3;
			case 3: return playerName4;
			default: return playerName1;
		}
	}

	public void DisableAllCams()
	{
		mainCamObject.active = false;
		replayCamObject.active = false;
		replayCamObject2.active = false;
		replayCamObject3.active = false;
		introCamObject.active = false;
	}

	public int GetValidReplayCamera(int camNumber)
	{
		if (ReplayController.replayRound == 3 || ReplayController.replayRound == 6)
			return camReplay3;
		if (ReplayController.replayRound == 8 && curReplayCam == camReplay1)
			return camReplay2;
		if ((ReplayController.replayRound == 10 || ReplayController.replayRound == 12) && curReplayCam == camReplay3)
			return camReplay1;
		return camNumber;
	}

	public void toggleCamera(int camNumber)
	{
		if (GameManagerScript.replayFlag)
		{
			curReplayCam = GetValidReplayCamera(camNumber);
			camNumber = curReplayCam;
		}
		DisableAllCams();
		if (camNumber == camReplay1) replayCamObject.active = true;
		else if (camNumber == camReplay2) replayCamObject2.active = true;
		else if (camNumber == camReplay3) replayCamObject3.active = true;
		else if (camNumber == camIntro) introCamObject.active = true;
		else mainCamObject.active = true;
	}

	public void SetGlassShadow(GameObject glass, int shadowID, float scaleDelta)
	{
		GameObject shadow = glassShadow;
		switch (shadowID)
		{
			case 2: shadow = glassShadow2; break; case 3: shadow = glassShadow3; break;
			case 4: shadow = glassShadow4; break; case 5: shadow = glassShadow5; break;
			case 6: shadow = glassShadow6; break; case 7: shadow = glassShadow7; break;
			case 8: shadow = glassShadow8; break;
		}
		shadow.renderer.enabled = true;
		Vector3 position = shadow.transform.position;
		position.x = glass.transform.position.x;
		position.z = glass.transform.position.z;
		shadow.transform.position = position;
		Vector3 scale = shadow.transform.localScale;
		scale.x = 0.15f + scaleDelta;
		scale.z = 0.15f + scaleDelta;
		shadow.transform.localScale = scale;
	}

	public void SetGlasses()
	{
		GameObject[] glasses = {
			RoundOneGlass00, RoundOneGlass01, RoundOneGlass02, RoundOneGlass03, RoundOneGlass04, RoundOneGlass05,
			RoundThreeGlass00, RoundThreeGlass01, RoundThreeGlass02,
			RoundFourGlass00, RoundFourGlass01, RoundFourGlass02, RoundFourGlass03, RoundFourGlass04,
			RoundSixGlass00, RoundSixGlass01, RoundSixGlass02, RoundSixGlass03, RoundSixGlass04,
			RoundEightGlass00, RoundEightGlass01, RoundEightGlass02, RoundEightGlass03, RoundEightGlass04,
			RoundNineGlass00, RoundNineGlass01, RoundNineGlass02, RoundNineGlass03,
			RoundTenGlass00, RoundTenGlass01, RoundTenGlass02, RoundTenGlass03,
			RoundElevenGlass00, RoundElevenGlass01, RoundElevenGlass02,
			RoundTwelveGlass00, RoundTwelveGlass01, RoundTwelveGlass02, RoundTwelveGlass03, RoundTwelveGlass04,
			RoundThirteenGlass00, RoundThirteenGlass01, RoundThirteenGlass02,
			RoundFourteenGlass00, RoundFourteenGlass01, RoundFourteenGlass02, RoundFourteenGlass03, RoundFourteenGlass04, RoundFourteenGlass05,
			RoundFifteenGlass00, RoundFifteenGlass01, RoundFifteenGlass02,
			RoundBonusGlass00, RoundBonusGlass01, RoundBonusGlass02, RoundBonusGlass03, RoundBonusGlass04,
			RoundBonusGlass05, RoundBonusGlass06, RoundBonusGlass07, RoundBonusGlass08
		};
		foreach (GameObject glass in glasses)
			if (glass) glass.SetActiveRecursively(false);

		GameObject[] shadows = { glassShadow, glassShadow2, glassShadow3, glassShadow4,
			glassShadow5, glassShadow6, glassShadow7, glassShadow8 };
		foreach (GameObject shadow in shadows)
			if (shadow) shadow.renderer.enabled = false;

		if (mainmenu.feGameType == mainmenu.gtPractice)
			GameManagerScript.curRound = levelSelected;
		DisplayBackDrop(false);
		GameObject[] buzzingGlasses = { RoundTwelveGlass02, RoundFourteenGlass03, RoundFifteenGlass00 };
		foreach (GameObject glass in buzzingGlasses)
			if (glass && glass.audio) glass.audio.Stop();

		switch (GameManagerScript.curRound)
		{
			case 0:
				RoundThreeGlass00.SetActiveRecursively(true); RoundThreeGlass01.SetActiveRecursively(true); RoundThreeGlass02.SetActiveRecursively(true);
				SetGlassShadow(RoundThreeGlass00, 1, 0.05f); SetGlassShadow(RoundThreeGlass01, 2, 0.15f); SetGlassShadow(RoundThreeGlass02, 3, 0f);
				break;
			case 1:
				RoundElevenGlass00.SetActiveRecursively(true); RoundElevenGlass01.SetActiveRecursively(true); RoundElevenGlass02.SetActiveRecursively(true);
				SetGlassShadow(RoundElevenGlass00, 1, 0.15f); SetGlassShadow(RoundElevenGlass01, 2, 0.20f); SetGlassShadow(RoundElevenGlass02, 3, 0.05f);
				break;
			case 2:
				RoundEightGlass00.SetActiveRecursively(true); RoundEightGlass01.SetActiveRecursively(true); RoundEightGlass02.SetActiveRecursively(true); RoundEightGlass03.SetActiveRecursively(true); RoundEightGlass04.SetActiveRecursively(true);
				SetGlassShadow(RoundEightGlass00, 1, 0f); SetGlassShadow(RoundEightGlass01, 2, 0.02f); SetGlassShadow(RoundEightGlass02, 3, 0.10f); SetGlassShadow(RoundEightGlass03, 4, 0f);
				break;
			case 3:
				RoundNineGlass00.SetActiveRecursively(true); RoundNineGlass01.SetActiveRecursively(true); RoundNineGlass02.SetActiveRecursively(true); RoundNineGlass03.SetActiveRecursively(true);
				SetGlassShadow(RoundNineGlass00, 1, 0.10f); SetGlassShadow(RoundNineGlass02, 2, 0.05f); SetGlassShadow(RoundNineGlass03, 3, 0.02f);
				break;
			case 4:
				RoundTwelveGlass00.SetActiveRecursively(true); RoundTwelveGlass01.SetActiveRecursively(true); RoundTwelveGlass02.SetActiveRecursively(true); RoundTwelveGlass03.SetActiveRecursively(true); RoundTwelveGlass04.SetActiveRecursively(true);
				SetGlassShadow(RoundTwelveGlass00, 1, 0f); SetGlassShadow(RoundTwelveGlass01, 2, 0.15f); SetGlassShadow(RoundTwelveGlass04, 3, 0f);
				break;
			case 5:
				RoundTenGlass00.SetActiveRecursively(true); RoundTenGlass01.SetActiveRecursively(true); RoundTenGlass02.SetActiveRecursively(true); RoundTenGlass03.SetActiveRecursively(true);
				SetGlassShadow(RoundTenGlass00, 1, 0.02f); SetGlassShadow(RoundTenGlass01, 2, 0.15f); SetGlassShadow(RoundTenGlass02, 3, 0.05f);
				break;
			case 6:
				RoundOneGlass00.SetActiveRecursively(true); RoundOneGlass01.SetActiveRecursively(true); RoundOneGlass02.SetActiveRecursively(true); RoundOneGlass03.SetActiveRecursively(true); RoundOneGlass04.SetActiveRecursively(true); RoundOneGlass05.SetActiveRecursively(true);
				SetGlassShadow(RoundOneGlass00, 1, 0f); SetGlassShadow(RoundOneGlass01, 2, 0f); SetGlassShadow(RoundOneGlass02, 3, 0f); SetGlassShadow(RoundOneGlass03, 4, 0.10f); SetGlassShadow(RoundOneGlass05, 5, 0.05f);
				break;
			case 7:
				RoundFourGlass00.SetActiveRecursively(true); RoundFourGlass01.SetActiveRecursively(true); RoundFourGlass02.SetActiveRecursively(true); RoundFourGlass03.SetActiveRecursively(true); RoundFourGlass04.SetActiveRecursively(true);
				SetGlassShadow(RoundFourGlass01, 1, 0.05f); SetGlassShadow(RoundFourGlass02, 2, 0.05f);
				break;
			case 8:
				RoundSixGlass00.SetActiveRecursively(true); RoundSixGlass01.SetActiveRecursively(true); RoundSixGlass02.SetActiveRecursively(true); RoundSixGlass03.SetActiveRecursively(true); RoundSixGlass04.SetActiveRecursively(true);
				SetGlassShadow(RoundSixGlass00, 1, 0.10f); SetGlassShadow(RoundSixGlass02, 2, 0.10f); SetGlassShadow(RoundSixGlass04, 3, 0.05f);
				break;
			case 9:
				RoundFourteenGlass00.SetActiveRecursively(true); RoundFourteenGlass01.SetActiveRecursively(true); RoundFourteenGlass02.SetActiveRecursively(true); RoundFourteenGlass03.SetActiveRecursively(true); RoundFourteenGlass04.SetActiveRecursively(true); RoundFourteenGlass05.SetActiveRecursively(true);
				SetGlassShadow(RoundFourteenGlass00, 1, 0.15f); SetGlassShadow(RoundFourteenGlass01, 2, 0.10f); SetGlassShadow(RoundFourteenGlass02, 3, 0.05f); SetGlassShadow(RoundFourteenGlass05, 4, 0f);
				break;
			case 10:
				RoundThirteenGlass00.SetActiveRecursively(true); RoundThirteenGlass01.SetActiveRecursively(true); RoundThirteenGlass02.SetActiveRecursively(true);
				SetGlassShadow(RoundThirteenGlass01, 1, 0.02f);
				break;
			case 11:
				RoundFifteenGlass00.SetActiveRecursively(true); RoundFifteenGlass01.SetActiveRecursively(true); RoundFifteenGlass02.SetActiveRecursively(true);
				break;
			case 12:
				RoundBonusGlass00.SetActiveRecursively(true); RoundBonusGlass01.SetActiveRecursively(true); RoundBonusGlass02.SetActiveRecursively(true); RoundBonusGlass03.SetActiveRecursively(true); RoundBonusGlass04.SetActiveRecursively(true); RoundBonusGlass05.SetActiveRecursively(true); RoundBonusGlass06.SetActiveRecursively(true); RoundBonusGlass07.SetActiveRecursively(true); RoundBonusGlass08.SetActiveRecursively(true);
				SetGlassShadow(RoundBonusGlass00, 1, 0.15f); SetGlassShadow(RoundBonusGlass01, 2, 0.02f); SetGlassShadow(RoundBonusGlass02, 3, 0.02f); SetGlassShadow(RoundBonusGlass03, 4, 0.02f); SetGlassShadow(RoundBonusGlass04, 5, 0.02f); SetGlassShadow(RoundBonusGlass05, 6, 0.02f); SetGlassShadow(RoundBonusGlass06, 7, 0.02f); SetGlassShadow(RoundBonusGlass07, 8, 0.02f);
				break;
			default:
				RoundOneGlass00.SetActiveRecursively(true); SetGlassShadow(RoundOneGlass00, 1, 0f);
				break;
		}
	}

	public void ResetColliderInfo()
	{
		colliderInfo.Clear();
		for (int i = 0; i < maxColliders; i++)
		{
			colliderInfo.Add(new ColliderInfoClass());
			DEBUG_ColliderGameObjects[i] = null;
		}
		curColliderIndex = 0;
	}

	public void ResetColliderSoundArray()
	{
		colliderSoundArray.Clear();
		colliderSoundSize = 0;
		for (int i = 0; i < numColliderSoundTypes; i++)
			colliderSoundPlayedCount[i] = 0;
		prevColliderSoundTime = 0f;
		prevColliderSoundType = -1;
	}

	public void AddColliderSound(Collider newCollider)
	{
		colliderSoundArray.Add(newCollider);
		colliderSoundSize++;
	}

	public void PlayColliderSound()
	{
		if (colliderSoundSize == 0) return;
		Collider hit = (Collider)colliderSoundArray[colliderSoundSize - 1];
		int duplicateCount = 0;
		for (int i = 0; i < colliderSoundSize; i++)
			if ((Collider)colliderSoundArray[i] == hit) duplicateCount++;
		if (!hit || !hit.attachedRigidbody) return;

		int soundType = (int)hit.attachedRigidbody.mass;
		AudioClip[] sounds = null;
		switch (soundType)
		{
			case 2: sounds = glassMartiniSounds; break;
			case 3: sounds = UnityEngine.Random.value < 0.5f ? glassMediumSounds : glassBigSounds; break;
			case 4: sounds = glassSmallSounds; break;
			case 5:
			case 6: sounds = UnityEngine.Random.value < 0.5f ? glassMediumSounds : glassBigSounds; break;
			case 7: sounds = glassTallSounds; break;
			case 8: sounds = lazySusanSounds; break;
			case 9: sounds = tableTopSounds; break;
			case 10: sounds = whiskeyBottleSounds; break;
			case 11: sounds = popBottleSounds; break;
			case 12: sounds = drinkingBirdSounds; break;
			case 13: sounds = checkBookSounds; break;
			case 14: sounds = bobbleHeadSounds; break;
			case 15: sounds = planeSounds; break;
			case 16: sounds = lighterSounds; break;
			case 17: sounds = phoneSounds; break;
			case 18: sounds = catapultSounds; break;
			case 19: sounds = pendulumSounds; break;
		}
		if (muteF || sounds == null || sounds.Length == 0) return;
		if (soundType == prevColliderSoundType && Time.time - prevColliderSoundTime <= minColliderSoundDelay) return;

		int soundIndex = Mathf.Clamp(colliderSoundPlayedCount[soundType], 0, sounds.Length - 1);
		if (hit.attachedRigidbody.gameObject == RoundFourteenGlass02)
			soundIndex %= 2;
		audio.clip = sounds[soundIndex];
		audio.Play();
		prevColliderSoundTime = Time.time;
		colliderSoundPlayedCount[soundType]++;
		prevColliderSoundType = soundType;
	}

	public void AddColliderToList(Collider newCollider)
	{
		if (curColliderIndex < 0 || curColliderIndex >= colliderInfo.Count) return;
		ColliderInfoClass info = (ColliderInfoClass)colliderInfo[curColliderIndex];
		info.m_Collider = newCollider;
		info.m_time = Time.time - shotLaunchTime;
		DEBUG_ColliderGameObjects[curColliderIndex] = newCollider.attachedRigidbody.gameObject;
		SetColliderDebugField(curColliderIndex, newCollider);
		curColliderIndex++;
	}

	public void ResetColliderGameObjectInfo()
	{
		colliderGameObjectInfo.Clear();
		for (int i = 0; i < maxColliderGameObjects; i++)
			colliderGameObjectInfo.Add(new ColliderGameObjectClass());
		curColliderGameObjectIndex = 0;
	}

	public void AddColliderToGameObjectList(GameObject newGameObject, float newTime)
	{
		if (curColliderGameObjectIndex < 0 || curColliderGameObjectIndex >= colliderGameObjectInfo.Count) return;
		ColliderGameObjectClass info = (ColliderGameObjectClass)colliderGameObjectInfo[curColliderGameObjectIndex];
		info.m_GameObject = newGameObject;
		info.m_time = newTime;
		curColliderGameObjectIndex++;
	}

	public void BuildCollisionChain()
	{
		ResetColliderGameObjectInfo();
		float previousTime = 0f;
		GameObject previousObject = null;
		for (int i = 0; i < curColliderIndex; i++)
		{
			ColliderInfoClass hit = (ColliderInfoClass)colliderInfo[i];
			if (!hit.m_Collider || !hit.m_Collider.attachedRigidbody) continue;
			GameObject hitObject = hit.m_Collider.attachedRigidbody.gameObject;
			bool add = i == 0 || (previousObject != hitObject &&
				(i == curColliderIndex - 1 || hit.m_time - previousTime > 0.01f));
			if (!add) continue;
			AddColliderToGameObjectList(hitObject, hit.m_time);
			previousObject = hitObject;
			previousTime = hit.m_time;
		}
		for (int i = 0; i < curColliderGameObjectIndex; i++)
		{
			ColliderGameObjectClass info = (ColliderGameObjectClass)colliderGameObjectInfo[i];
			SetGameObjectDebugField(i, info.m_GameObject, info.m_time);
		}
		ResetColliderInfo();
		ResetColliderSoundArray();
	}

	public void TurnBuzzingSoundOff()
	{
		if ((shotOverFlags & (GameManagerScript.flagPlayerGameOver | GameManagerScript.flagGameOver)) == 0)
			return;
		GameObject[] buzzingObjects = { RoundTwelveGlass02, RoundFourteenGlass03, RoundFifteenGlass00 };
		foreach (GameObject buzzingObject in buzzingObjects)
			if (buzzingObject && buzzingObject.audio) buzzingObject.audio.Stop();
	}

	public void Main()
	{
	}

	private void SetColliderDebugField(int index, Collider value)
	{
		switch (index)
		{
			case 0: LastHitCollider0 = value; break; case 1: LastHitCollider1 = value; break;
			case 2: LastHitCollider2 = value; break; case 3: LastHitCollider3 = value; break;
			case 4: LastHitCollider4 = value; break; case 5: LastHitCollider5 = value; break;
			case 6: LastHitCollider6 = value; break; case 7: LastHitCollider7 = value; break;
			case 8: LastHitCollider8 = value; break; case 9: LastHitCollider9 = value; break;
			case 10: LastHitCollider10 = value; break; case 11: LastHitCollider11 = value; break;
			case 12: LastHitCollider12 = value; break; case 13: LastHitCollider13 = value; break;
			case 14: LastHitCollider14 = value; break;
		}
	}

	private void SetGameObjectDebugField(int index, GameObject value, float time)
	{
		switch (index)
		{
			case 0: gameObjectCollider0 = value; gameObjectTime0 = time; break;
			case 1: gameObjectCollider1 = value; gameObjectTime1 = time; break;
			case 2: gameObjectCollider2 = value; gameObjectTime2 = time; break;
			case 3: gameObjectCollider3 = value; gameObjectTime3 = time; break;
			case 4: gameObjectCollider4 = value; gameObjectTime4 = time; break;
			case 5: gameObjectCollider5 = value; gameObjectTime5 = time; break;
			case 6: gameObjectCollider6 = value; gameObjectTime6 = time; break;
			case 7: gameObjectCollider7 = value; gameObjectTime7 = time; break;
			case 8: gameObjectCollider8 = value; gameObjectTime8 = time; break;
			case 9: gameObjectCollider9 = value; gameObjectTime9 = time; break;
			case 10: gameObjectCollider10 = value; gameObjectTime10 = time; break;
			case 11: gameObjectCollider11 = value; gameObjectTime11 = time; break;
			case 12: gameObjectCollider12 = value; gameObjectTime12 = time; break;
			case 13: gameObjectCollider13 = value; gameObjectTime13 = time; break;
			case 14: gameObjectCollider14 = value; gameObjectTime14 = time; break;
		}
	}
}
