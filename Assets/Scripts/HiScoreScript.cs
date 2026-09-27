using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class HiScoreScript : MonoBehaviour
{
	public static ArrayList entries = new ArrayList();

	public static int maxEntryCount = 10;

	public int maxNameLength = 10;

	public string newName = "Hello";

	public int newScore;

	public static int lockedRoundStartIndex = 1;

	public static string lockedRoundStartString = "lockedRoundStart";

	public GUISkin BoldSkin;

	public GUISkin CoasterSkin;

	public GUISkin backDropSkin;

	public static int guiIndex;

	public static bool cancelPopup;

	public static string nameString = string.Empty;

	public static string scoreString = string.Empty;

	public static int GameMode;

	public static ArrayList GetArray()
	{
		return entries;
	}

	public static void SetPrefStringPrefix(int difficulty)
	{
		if (difficulty == 1)
		{
			nameString = "PrefsNameSpeed ";
			scoreString = "PrefsScoreSpeed ";
		}
		else
		{
			nameString = "PrefsNameNormal ";
			scoreString = "PrefsScoreNormal ";
		}
	}

	public void Awake()
	{
		LoadEntries(GameMode);
		LoadLocks();
	}

	public static void LoadEntries(int difficulty)
	{
		SetPrefStringPrefix(GameMode);
		entries.Clear();
		for (int i = 0; i < maxEntryCount; i++)
		{
			Entry entry = new Entry
			{
				name = PlayerPrefs.GetString(nameString + i),
				score = PlayerPrefs.GetFloat(scoreString + i)
			};
			if (entry.score != 0f)
				entries.Add(entry);
		}
		while (entries.Count < maxEntryCount)
			entries.Add(new Entry { name = "Empty", score = 0f });
		while (entries.Count > maxEntryCount)
			entries.RemoveAt(entries.Count - 1);
	}

	public static void SaveEntries()
	{
		SetPrefStringPrefix(GameMode);
		for (int i = 0; i < entries.Count; i++)
		{
			Entry entry = (Entry)entries[i];
			PlayerPrefs.SetString(nameString + i, entry.name);
			PlayerPrefs.SetFloat(scoreString + i, entry.score);
		}
	}

	public static void SetHiScoreName(int index, string name)
	{
		if (index >= 0 && index < maxEntryCount)
		{
			((Entry)entries[index]).name = name;
			SaveEntries();
		}
	}

	public static int GetHighScorePosition(float score)
	{
		for (int i = 0; i < entries.Count; i++)
			if (score > ((Entry)entries[i]).score)
				return i;
		return -1;
	}

	public static int InsertHiScore(float score, string playerName)
	{
		Entry entry = new Entry { name = playerName, score = score };
		int position = GetHighScorePosition(score);
		if (position < 0)
			return -1;

		entries.Insert(position, entry);
		if (entries.Count > maxEntryCount)
			entries.RemoveAt(entries.Count - 1);
		SaveEntries();
		return position;
	}

	public static void LoadLocks()
	{
		lockedRoundStartIndex = PlayerPrefs.GetInt(lockedRoundStartString);
		if (lockedRoundStartIndex < 1)
			lockedRoundStartIndex = 1;
	}

	public static void UpdateLockedRoundIndex(int roundCompleted)
	{
		if (lockedRoundStartIndex < roundCompleted + 1)
		{
			lockedRoundStartIndex = roundCompleted + 1;
			PlayerPrefs.SetInt(lockedRoundStartString, lockedRoundStartIndex);
		}
	}

	public static void WipeoutPrefs()
	{
		SetPrefStringPrefix(GameMode);
		for (int i = 0; i < maxEntryCount; i++)
		{
			PlayerPrefs.DeleteKey(nameString + i);
			PlayerPrefs.DeleteKey(scoreString + i);
		}
		LoadEntries(GameMode);
	}

	public static void WipeoutAllPrefs()
	{
		QuarterTrigger.SavePlayerNameToPrefs("PLR1", 0);
		QuarterTrigger.SavePlayerNameToPrefs("PLR2", 1);
		QuarterTrigger.SavePlayerNameToPrefs("PLR3", 2);
		QuarterTrigger.SavePlayerNameToPrefs("PLR4", 3);
		SetPrefStringPrefix(0);
		if (GameOrRoundButtons.gameButtonSelected)
			WipeoutPrefs();
		else
			HiScoreRoundScript.WipeoutPrefs();
		SetPrefStringPrefix(1);
	}

	public void Main()
	{
	}
}
