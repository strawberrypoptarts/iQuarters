using System;
using UnityEngine;

[Serializable]
public class ReplayController : MonoBehaviour
{
	public GameObject ReplaySaveDoneButtonsObject;

	public GUISkin dummySkin;

	public bool enableButtonView;

	public static bool triggerSlideIn;

	public static int rcButtonsStateIdle = 100;

	public static int rcButtonsStateSlideIn = 101;

	public static int rcButtonsStateOnScreen = 102;

	public static int rcButtonsStateSlideOut = 103;

	public static int rcButtonsStateCurrent = rcButtonsStateIdle;

	public static int rcButtonClickedDone = 200;

	public static int rcButtonClickedSave = 201;

	public static int rcButtonClickedValue = rcButtonClickedDone;

	public static bool stateAskToSaveReplay_OverFlag;

	public static bool replayDataValid;

	public static int replayRound;

	public static float replayshotmag;

	public static float replayshotmagx;

	public static float replayshotvelz;

	public static float replayshotangle;

	public static int savedCurrentRound;

	public static bool hallOfFameReplay;

	public static int replayDataMaxSlots = 6;

	public static int replayDataCurIndex;

	public static bool[] store_replayDataValid;

	public static int[] store_replayStar;

	public static int[] store_replayRound;

	public static string[] store_replayName;

	public static float[] store_replayshotmag;

	public static float[] store_replayshotmagx;

	public static float[] store_replayshotvelz;

	public static float[] store_replayshotangle;

	public static float[] storeTime;

	public static int[] storeTicks;

	public static float[] storeSpeed;

	public static float[] storenormalizedSpeed;

	public static int replayDataPlayerNumber;

	public static float shotTime;

	public static float shotSpeed;

	public static float shotnormalizedSpeed;

	public static int shotTick;

	public static string separatorChar = ";";

	public static void InitReplayData()
	{
		replayDataCurIndex = 0;
		store_replayDataValid = new bool[replayDataMaxSlots];
		store_replayStar = new int[replayDataMaxSlots];
		store_replayRound = new int[replayDataMaxSlots];
		store_replayName = new string[replayDataMaxSlots];
		store_replayshotmag = new float[replayDataMaxSlots];
		store_replayshotmagx = new float[replayDataMaxSlots];
		store_replayshotvelz = new float[replayDataMaxSlots];
		store_replayshotangle = new float[replayDataMaxSlots];
		storeTime = new float[replayDataMaxSlots];
		storeTicks = new int[replayDataMaxSlots];
		storeSpeed = new float[replayDataMaxSlots];
		storenormalizedSpeed = new float[replayDataMaxSlots];
		for (int i = 0; i < replayDataMaxSlots; i++)
			store_replayName[i] = string.Empty;
	}

	public static void LoadAllReplays()
	{
		if (store_replayDataValid == null || store_replayDataValid.Length != replayDataMaxSlots)
			InitReplayData();
		for (int i = 0; i < replayDataMaxSlots; i++)
		{
			store_replayDataValid[i] = PlayerPrefs.GetInt("IsValid" + i) != 0;
			if (!store_replayDataValid[i])
				continue;
			store_replayStar[i] = PlayerPrefs.GetInt("Star" + i);
			store_replayRound[i] = PlayerPrefs.GetInt("Round" + i);
			store_replayName[i] = PlayerPrefs.GetString("Name" + i);
			store_replayshotmag[i] = PlayerPrefs.GetFloat("ShotMag" + i);
			store_replayshotmagx[i] = PlayerPrefs.GetFloat("ShotMagX" + i);
			store_replayshotvelz[i] = PlayerPrefs.GetFloat("ShotVelZ" + i);
			store_replayshotangle[i] = PlayerPrefs.GetFloat("ShotAngle" + i);
			storeTime[i] = PlayerPrefs.GetFloat("Time" + i);
			storeTicks[i] = PlayerPrefs.GetInt("Ticks" + i);
			storeSpeed[i] = PlayerPrefs.GetFloat("Speed" + i);
			storenormalizedSpeed[i] = PlayerPrefs.GetFloat("NormalizedSpeed" + i);
		}
	}

	public static void ClearAllReplays()
	{
		for (int i = 0; i < replayDataMaxSlots; i++)
		{
			string[] keys = { "IsValid", "Star", "Round", "Name", "ShotMag", "ShotMagX", "ShotVelZ", "ShotAngle", "Time", "Ticks", "Speed", "NormalizedSpeed" };
			foreach (string key in keys)
				PlayerPrefs.DeleteKey(key + i);
		}
		InitReplayData();
	}

	public static void SaveReplay(int slotIndex)
	{
		if (!ValidUsedSlot(slotIndex))
			return;
		string playerName = mainmenu.feGameType == mainmenu.gtClassic
			? GameManagerScript.GetName(replayDataPlayerNumber) : "Practice";
		store_replayName[slotIndex] = playerName + separatorChar + DateTime.Today.ToString("d")
			+ separatorChar + "Rnd " + (store_replayRound[slotIndex] + 1);
		PlayerPrefs.SetInt("IsValid" + slotIndex, 1);
		PlayerPrefs.SetInt("Star" + slotIndex, store_replayStar[slotIndex]);
		PlayerPrefs.SetInt("Round" + slotIndex, store_replayRound[slotIndex]);
		PlayerPrefs.SetString("Name" + slotIndex, store_replayName[slotIndex]);
		PlayerPrefs.SetFloat("ShotMag" + slotIndex, store_replayshotmag[slotIndex]);
		PlayerPrefs.SetFloat("ShotMagX" + slotIndex, store_replayshotmagx[slotIndex]);
		PlayerPrefs.SetFloat("ShotVelZ" + slotIndex, store_replayshotvelz[slotIndex]);
		PlayerPrefs.SetFloat("ShotAngle" + slotIndex, store_replayshotangle[slotIndex]);
		PlayerPrefs.SetFloat("Time" + slotIndex, storeTime[slotIndex]);
		PlayerPrefs.SetInt("Ticks" + slotIndex, storeTicks[slotIndex]);
		PlayerPrefs.SetFloat("Speed" + slotIndex, storeSpeed[slotIndex]);
		PlayerPrefs.SetFloat("NormalizedSpeed" + slotIndex, storenormalizedSpeed[slotIndex]);
	}

	public static string GetReplayNameString(int slotIndex)
	{
		if (!ValidUsedSlot(slotIndex)) return string.Empty;
		int separator = store_replayName[slotIndex].IndexOf(separatorChar, StringComparison.Ordinal);
		return separator > 0 ? store_replayName[slotIndex].Substring(0, separator) : string.Empty;
	}

	public static string GetReplayRoundString(int slotIndex)
	{
		if (!ValidUsedSlot(slotIndex)) return string.Empty;
		string value = store_replayName[slotIndex];
		int first = value.IndexOf(separatorChar, StringComparison.Ordinal);
		int second = first < 0 ? -1 : value.IndexOf(separatorChar, first + 1, StringComparison.Ordinal);
		return first >= 0 && second > first ? value.Substring(first + 1, second - first - 1) : string.Empty;
	}

	public static string GetReplayDateString(int slotIndex)
	{
		if (!ValidUsedSlot(slotIndex)) return string.Empty;
		string value = store_replayName[slotIndex];
		int first = value.IndexOf(separatorChar, StringComparison.Ordinal);
		int second = first < 0 ? -1 : value.IndexOf(separatorChar, first + 1, StringComparison.Ordinal);
		return second >= 0 && second + 1 < value.Length ? value.Substring(second + 1) : string.Empty;
	}

	public static int GetReplayRoundNumber(int slotIndex)
	{
		return ValidUsedSlot(slotIndex) ? store_replayRound[slotIndex] : -1;
	}

	public void Start()
	{
		hallOfFameReplay = false;
		replayDataValid = false;
		replayRound = 0;
		replayshotmag = replayshotmagx = replayshotvelz = replayshotangle = 0f;
		savedCurrentRound = 0;
		shotTime = shotSpeed = shotnormalizedSpeed = 0f;
		shotTick = 0;
		replayDataPlayerNumber = 0;
	}

	public static void SetShotParameters(float mag, float magx, float shotVelZ, float shotAngle)
	{
		replayDataValid = true;
		replayRound = GameManagerScript.curRound;
		replayshotmag = mag;
		replayshotmagx = magx;
		replayshotvelz = shotVelZ;
		replayshotangle = shotAngle;
		replayDataPlayerNumber = GameManagerScript.curPlayer;
	}

	public static int GetMaxSlots()
	{
		return replayDataMaxSlots;
	}

	public static bool IsSlotUsed(int slotIndex)
	{
		return ValidUsedSlot(slotIndex);
	}

	public static int GetSavedReplaysRound(int slotIndex)
	{
		return ValidSlot(slotIndex) ? store_replayRound[slotIndex] : -1;
	}

	public static int GetNumSavedSlots()
	{
		int count = 0;
		for (int i = 0; i < replayDataMaxSlots; i++)
			if (store_replayDataValid[i]) count++;
		return count;
	}

	public static bool IsReplayDataValid()
	{
		return replayDataValid;
	}

	public static bool RequestReplay()
	{
		if (!replayDataValid) return false;
		QuarterTrigger.requestLastReplay = true;
		replayDataCurIndex = -1;
		return true;
	}

	public static bool RequestHallOfFameReplay(int slotIndex)
	{
		if (!ValidUsedSlot(slotIndex)) return false;
		replayDataValid = false;
		QuarterTrigger.requestLastReplay = true;
		replayDataCurIndex = slotIndex;
		return true;
	}

	public static void SaveAnimationData(int index, float saveTime, float saveSpeed, float saveNS)
	{
		shotTime = saveTime;
		shotSpeed = saveSpeed;
		shotnormalizedSpeed = saveNS;
	}

	public static void SaveShotTick(int tick)
	{
		shotTick = tick;
		if (ValidSlot(replayDataCurIndex))
			storeTicks[replayDataCurIndex] = shotTick;
	}

	public static int RestoreShotTick()
	{
		return shotTick;
	}

	public static void storeReplayData(int curIdx)
	{
		if (!replayDataValid || !ValidSlot(curIdx)) return;
		store_replayDataValid[curIdx] = replayDataValid;
		store_replayRound[curIdx] = replayRound;
		store_replayshotmag[curIdx] = replayshotmag;
		store_replayshotmagx[curIdx] = replayshotmagx;
		store_replayshotvelz[curIdx] = replayshotvelz;
		store_replayshotangle[curIdx] = replayshotangle;
		storeTime[curIdx] = shotTime;
		storeTicks[curIdx] = shotTick;
		storeSpeed[curIdx] = shotSpeed;
		storenormalizedSpeed[curIdx] = shotnormalizedSpeed;
	}

	public static void RestoreReplayData(int curIdx)
	{
		if (!ValidUsedSlot(curIdx)) return;
		replayDataValid = false;
		replayRound = store_replayRound[curIdx];
		replayshotmag = store_replayshotmag[curIdx];
		replayshotmagx = store_replayshotmagx[curIdx];
		replayshotvelz = store_replayshotvelz[curIdx];
		replayshotangle = store_replayshotangle[curIdx];
		GameManagerScript.shotMagnitude = replayshotmag;
		GameManagerScript.shotMagX = replayshotmagx;
		GameManagerScript.shotVelZ = replayshotvelz;
		GameManagerScript.shotAngle = replayshotangle;
		shotTick = storeTicks[curIdx];
		hallOfFameReplay = true;
	}

	public static void TriggerSlideIn()
	{
		triggerSlideIn = true;
		rcButtonsStateCurrent = rcButtonsStateIdle;
		rcButtonClickedValue = rcButtonClickedDone;
	}

	public void OnGUI()
	{
		if (QuarterTrigger.state != QuarterTrigger.stateAskToSaveReplay) return;
		GUI.skin = enableButtonView ? null : dummySkin;
		if (triggerSlideIn)
		{
			triggerSlideIn = false;
			ReplaySaveDoneButtonsObject.animation.Play("SlideIn");
			rcButtonsStateCurrent = rcButtonsStateSlideIn;
			PauseMenu.PlayAnimatingObjects(false, false);
		}
		else if (rcButtonsStateCurrent == rcButtonsStateSlideIn && !ReplaySaveDoneButtonsObject.animation.isPlaying)
		{
			rcButtonsStateCurrent = rcButtonsStateOnScreen;
		}
		else if (rcButtonsStateCurrent == rcButtonsStateOnScreen)
		{
			Rect doneRect = new Rect(32f, 240f, 416f, 72f);
			if (GameManagerScript.is_iPad()) doneRect = GameManagerScript.GetiPadRect(doneRect);
			if (GUI.Button(doneRect, string.Empty))
			{
				AnnouncerScript.triggerClickSound = true;
				rcButtonClickedValue = rcButtonClickedDone;
				rcButtonsStateCurrent = rcButtonsStateSlideOut;
				ReplaySaveDoneButtonsObject.animation.Play("ClickDone");
				ReplaySaveDoneButtonsObject.animation.PlayQueued("SlideOut");
			}
		}
		else if (rcButtonsStateCurrent == rcButtonsStateSlideOut && !ReplaySaveDoneButtonsObject.animation.isPlaying)
		{
			rcButtonsStateCurrent = rcButtonsStateIdle;
			if (rcButtonClickedValue == rcButtonClickedSave)
			{
				QuarterTrigger.DisplayBackDrop(true);
			}
			else
			{
				stateAskToSaveReplay_OverFlag = true;
				PauseMenu.PlayAnimatingObjects(!QuarterTrigger.muteF, true);
				QuarterTrigger.DisplayQuarterAndShadow(false);
			}
			ReplaySaveDoneButtonsObject.SetActiveRecursively(false);
		}
	}

	public void Main()
	{
	}

	private static bool ValidSlot(int slotIndex)
	{
		return slotIndex >= 0 && slotIndex < replayDataMaxSlots && store_replayDataValid != null;
	}

	private static bool ValidUsedSlot(int slotIndex)
	{
		return ValidSlot(slotIndex) && store_replayDataValid[slotIndex];
	}
}
