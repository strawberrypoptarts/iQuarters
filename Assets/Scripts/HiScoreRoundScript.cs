using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class HiScoreRoundScript : MonoBehaviour
{
	public static ArrayList entries = new ArrayList();

	public static int maxEntryCount = 15;

	public int maxNameLength = 10;

	public static string nameString = "PrefsNamePractice ";

	public static string scoreString = "PrefsScorePractice ";

	public void Awake()
	{
		maxEntryCount = GameManagerScript.numRounds;
		LoadEntries();
	}

	public static ArrayList GetArray()
	{
		return entries;
	}

	public static bool AddRoundHiScore(int round, float score, string playerName)
	{
		if (round < 0 || round >= entries.Count)
			return false;

		Entry entry = (Entry)entries[round];
		if (score <= entry.score)
			return false;

		entry.name = playerName;
		entry.score = score;
		SaveEntries();
		return true;
	}

	public static void SaveEntries()
	{
		for (int i = 0; i < entries.Count; i++)
		{
			Entry entry = (Entry)entries[i];
			PlayerPrefs.SetString(nameString + i, entry.name);
			PlayerPrefs.SetFloat(scoreString + i, entry.score);
		}
	}

	public static void LoadEntries()
	{
		entries.Clear();
		for (int i = 0; i < maxEntryCount; i++)
		{
			Entry entry = new Entry();
			float savedScore = PlayerPrefs.GetFloat(scoreString + i);
			if (savedScore > 0f)
			{
				entry.name = PlayerPrefs.GetString(nameString + i);
				entry.score = savedScore;
			}
			else
			{
				entry.name = "Empty";
				entry.score = 0f;
			}
			entries.Add(entry);
		}
	}

	public static string GetName(int round)
	{
		return round >= 0 && round < entries.Count ? ((Entry)entries[round]).name : string.Empty;
	}

	public static int GetScore(int round)
	{
		return round >= 0 && round < entries.Count ? (int)((Entry)entries[round]).score : 0;
	}

	public static void WipeoutPrefs()
	{
		maxEntryCount = GameManagerScript.numRounds;
		for (int i = 0; i < maxEntryCount; i++)
		{
			PlayerPrefs.DeleteKey(nameString + i);
			PlayerPrefs.DeleteKey(scoreString + i);
		}
		LoadEntries();
	}

	public void Main()
	{
	}
}
