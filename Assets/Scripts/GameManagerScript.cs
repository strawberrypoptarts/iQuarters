using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class GameManagerScript : MonoBehaviour
{
	public static ArrayList playerData = new ArrayList();

	private int maxPlayers = 4;

	public static bool replayFlag;

	public static float shotMagnitude = 6f;

	public static float defaultShotAngle = 50f;

	public static float shotAngle = 50f;

	public static float shotMagX;

	public static float shotVelZ;

	public static int shotsPerRound = 3;

	public static int curShotThisRound;

	public static int curMadeShotsThisRound;

	public static int numRounds = 12;

	public static int curRound;

	public static int curPlayer;

	public static int totPlayers = 1;

	public static int flagNone;

	public static int flagPlayerChange = 1;

	public static int flagRoundChange = 2;

	public static int flagPlayerGameOver = 4;

	public static int flagGameOver = 8;

	public static int flagOutOfShotsReason = 16;

	public static int inputTypeShake;

	public static int inputTypeFlick = 1;

	public static int inputTypeMax = 2;

	public static bool secretRoundUnlocked;

	public static int secretRoundNumber = 12;

	public static int roundBeforeSecretRound = 8;

	public static int roundAfterSecretRound = 9;

	public static Vector3 iPadUIScale = new Vector3(25f, 25f, 1f);

	public static Vector3 iPadUIPosition;

	public static float iPadBackEndScaleX = 1.11f;

	public static int[] userSecretCodes;

	public static int numUserSecretCodes;

	public static int maxUserSecretCodes = 8;

	public static int[] unlockSecretCodes;

	public static int numUnlockSecretCodes;

	public static float iPhoneTallWidth = 320f;

	public static float iPhoneTallHeight = 480f;

	public static float iPadTallWidth = 768f;

	public static float iPadTallHeight = 1024f;

	public void Start()
	{
		userSecretCodes = new int[maxUserSecretCodes];
		ResetUserSecretCodes();
		numUnlockSecretCodes = 6;
		unlockSecretCodes = new int[numUnlockSecretCodes] { 1, 2, 3, 1, 2, 0 };
		secretRoundUnlocked = false;
	}

	public static bool is_iPad()
	{
		return Screen.height > 480;
	}

	public static void StoreSecretRoundUnlockCode(int code)
	{
		if (mainmenu.feGameType != mainmenu.gtClassic || secretRoundUnlocked || totPlayers != 1 ||
			curRound != roundBeforeSecretRound || curMadeShotsThisRound != shotsPerRound - 1 ||
			numUserSecretCodes >= numUnlockSecretCodes)
		{
			return;
		}

		userSecretCodes[numUserSecretCodes++] = code;
		bool matches = true;
		for (int index = 0; index < numUserSecretCodes; index++)
		{
			if (userSecretCodes[index] != unlockSecretCodes[index])
			{
				matches = false;
				break;
			}
		}

		if (!matches)
		{
			ResetUserSecretCodes();
		}
		else if (numUserSecretCodes == numUnlockSecretCodes)
		{
			AnnouncerScript.triggerUnlockSound = true;
			secretRoundUnlocked = true;
		}
	}

	public static void ResetUserSecretCodes()
	{
		numUserSecretCodes = 0;
		for (int index = 0; index < maxUserSecretCodes; index++)
		{
			userSecretCodes[index] = -1;
		}
	}

	public static bool IsLastActivePlayer(int player)
	{
		if (player < 0 || player >= totPlayers)
		{
			return false;
		}
		int lastActive = 0;
		for (int index = 0; index < totPlayers; index++)
		{
			if (PlayerAt(index).shotsLeft > 0)
			{
				lastActive = index;
			}
		}
		return player == lastActive;
	}

	public static void ResetShotAngleToDefault()
	{
		shotAngle = defaultShotAngle;
	}

	public static int GetCurrentRoundScore()
	{
		return IsValidPlayer(curPlayer) ? PlayerAt(curPlayer).roundScore : 0;
	}

	public static int SetCurrentRoundScore(int roundScore)
	{
		if (IsValidPlayer(curPlayer)) PlayerAt(curPlayer).roundScore = roundScore;
		return 0;
	}

	public static int UpdateCurRicochet(int curRicochet)
	{
		if (IsValidPlayer(curPlayer) && PlayerAt(curPlayer).maxRicochet < curRicochet)
		{
			PlayerAt(curPlayer).maxRicochet = curRicochet;
		}
		return 0;
	}

	public static void AddRoundScore(int scoreAddition)
	{
		SetCurrentRoundScore(GetCurrentRoundScore() + scoreAddition);
	}

	public static void AddScore(int scoreAddition)
	{
		AddRoundScore(scoreAddition);
		SetCurrentScore(GetCurrentScore() + scoreAddition);
		if (scoreAddition == 0)
		{
			SetCurrentTotalStreak(0);
			SetCurrentRoundStreak(0);
		}
	}

	public static void IncrementCurrentStreak()
	{
		SetCurrentTotalStreak(GetCurrentTotalStreak() + 1);
		SetCurrentRoundStreak(GetCurrentRoundStreak() + 1);
	}

	public static void SetCurrentStreak(int score)
	{
		SetCurrentTotalStreak(score == 0 ? 0 : GetCurrentTotalStreak() + 1);
		SetCurrentRoundStreak(score == 0 ? 0 : GetCurrentRoundStreak() + 1);
	}

	public static void ClearAllScores()
	{
		ClearScores();
		ClearTotalStreaks();
		ClearRoundStreaks();
		ClearAllGameOverFlags();
	}

	public static void ResetGameManagerVars()
	{
		curPlayer = 0;
		curShotThisRound = 0;
		curMadeShotsThisRound = 0;
		curRound = 0;
		ClearAllScores();
	}

	public static void UpdateRound()
	{
		ClearRoundStreaks();
		ClearAllPlayedThisRoundFlags();
		SetCurrentRoundScore(0);
		if (secretRoundUnlocked && curRound == roundBeforeSecretRound)
		{
			curRound = secretRoundNumber;
		}
		else if (curRound == secretRoundNumber)
		{
			curRound = roundAfterSecretRound;
		}
		else
		{
			curRound++;
			if (curRound >= numRounds) curRound = 0;
		}
	}

	public static bool GetNextCurrentPlayer()
	{
		int previousPlayer = curPlayer;
		for (int player = previousPlayer; player < totPlayers; player++)
		{
			if (!GetPlayedThisRound(player) && GetPlayerShotsLeft(player) > 0)
			{
				curPlayer = player;
				return true;
			}
		}
		for (int player = 0; player < previousPlayer; player++)
		{
			if (!GetPlayedThisRound(player) && GetPlayerShotsLeft(player) > 0)
			{
				curPlayer = player;
				return true;
			}
		}

		if (curRound < numRounds - 1)
		{
			int playedWithShots = 0;
			int outOfShots = 0;
			int firstPlayedWithShots = -1;
			for (int player = 0; player < totPlayers; player++)
			{
				if (GetPlayedThisRound(player) && GetPlayerShotsLeft(player) > 0)
				{
					playedWithShots++;
					if (firstPlayedWithShots == -1) firstPlayedWithShots = player;
				}
				else if (GetPlayerShotsLeft(player) == 0)
				{
					outOfShots++;
				}
			}
			if (playedWithShots + outOfShots == totPlayers && playedWithShots > 0)
			{
				curPlayer = firstPlayedWithShots;
				return false;
			}
		}
		curPlayer = 0;
		return false;
	}

	public static int UpdateShotCount(int score)
	{
		int result = flagNone;
		int previousRound = curRound;
		int previousPlayer = curPlayer;
		if (score == 0)
		{
			if (DecrementCurrentShotsLeft() == 1) SetCurrentPlayedThisRound(true);
		}
		else
		{
			curMadeShotsThisRound++;
		}
		curShotThisRound++;

		if (curMadeShotsThisRound >= shotsPerRound || GetCurrentShotsLeft() < 1)
		{
			SetCurrentPlayedThisRound(true);
			SetCurrentRoundScore(0);
			if ((curRound >= numRounds - 1 && curRound != secretRoundNumber) || GetCurrentShotsLeft() < 1)
			{
				result |= flagPlayerGameOver;
				SetCurrentGameOverFlag(true);
				if (AllPlayersGameOver()) result |= flagGameOver;
				if (GetCurrentShotsLeft() < 1) result |= flagOutOfShotsReason;
			}
			curShotThisRound = 0;
			curMadeShotsThisRound = 0;
			if (!GetNextCurrentPlayer()) UpdateRound();
		}

		if (curPlayer != previousPlayer) result |= flagPlayerChange;
		if (curRound != previousRound) result |= flagRoundChange;
		return result;
	}

	public static void ClearAllGameOverFlags()
	{
		foreach (PlayerInfoClass player in playerData) player.gameOver = false;
	}

	public static int SetCurrentGameOverFlag(bool playedF)
	{
		if (IsValidPlayer(curPlayer)) PlayerAt(curPlayer).gameOver = playedF;
		return 0;
	}

	public static bool AllPlayersGameOver()
	{
		foreach (PlayerInfoClass player in playerData)
		{
			if (!player.gameOver) return false;
		}
		return true;
	}

	public static void ClearAllPlayedThisRoundFlags()
	{
		foreach (PlayerInfoClass player in playerData) player.playedThisRound = false;
	}

	public static int SetCurrentPlayedThisRound(bool playedF)
	{
		if (IsValidPlayer(curPlayer)) PlayerAt(curPlayer).playedThisRound = playedF;
		return 0;
	}

	public static bool GetCurrentPlayedThisRound()
	{
		return IsValidPlayer(curPlayer) ? PlayerAt(curPlayer).playedThisRound : true;
	}

	public static bool GetPlayedThisRound(int playerNumber)
	{
		return IsValidPlayer(playerNumber) ? PlayerAt(playerNumber).playedThisRound : true;
	}

	public static void SetAllShotsLeft(int shotsLeft)
	{
		foreach (PlayerInfoClass player in playerData) player.shotsLeft = shotsLeft;
	}

	public static bool AllPlayersOutOfShots()
	{
		foreach (PlayerInfoClass player in playerData)
		{
			if (player.shotsLeft > 0) return false;
		}
		return true;
	}

	public static int SetCurrentInputType(int input)
	{
		if (IsValidPlayer(curPlayer) && input >= 0 && input < inputTypeMax)
		{
			PlayerAt(curPlayer).inputType = input;
		}
		return 0;
	}

	public static int GetCurrentInputType()
	{
		return IsValidPlayer(curPlayer) ? PlayerAt(curPlayer).inputType : 0;
	}

	public static int SetCurrentShotsLeft(int shotsLeft)
	{
		if (IsValidPlayer(curPlayer)) PlayerAt(curPlayer).shotsLeft = shotsLeft;
		return 0;
	}

	public static int GetCurrentShotsLeft(int curPlayer)
	{
		return IsValidPlayer(curPlayer) ? PlayerAt(curPlayer).shotsLeft : 0;
	}

	public static int GetPlayerShotsLeft(int playerNumber)
	{
		return IsValidPlayer(playerNumber) ? PlayerAt(playerNumber).shotsLeft : 0;
	}

	public static int DecrementCurrentShotsLeft()
	{
		if (!IsValidPlayer(curPlayer)) return 0;
		PlayerInfoClass player = PlayerAt(curPlayer);
		player.shotsLeft--;
		if (player.shotsLeft < 1)
		{
			player.shotsLeft = 0;
			return 1;
		}
		return 0;
	}

	public static int GetCurrentShotsLeft()
	{
		return IsValidPlayer(curPlayer) ? PlayerAt(curPlayer).shotsLeft : 0;
	}

	public static void ClearScores()
	{
		foreach (PlayerInfoClass player in playerData)
		{
			player.score = 0;
			player.roundScore = 0;
		}
	}

	public static int AddPlayerScore(int addedScore, int playerNumber)
	{
		if (IsValidPlayer(playerNumber)) PlayerAt(playerNumber).score += addedScore;
		return 0;
	}

	public static int SetCurrentScore(int score)
	{
		if (IsValidPlayer(curPlayer)) PlayerAt(curPlayer).score = score;
		return 0;
	}

	public static int GetCurrentScore()
	{
		return IsValidPlayer(curPlayer) ? PlayerAt(curPlayer).score : 0;
	}

	public static int GetPlayerScore(int playerNumber)
	{
		return IsValidPlayer(playerNumber) ? PlayerAt(playerNumber).score : 0;
	}

	public static void ClearRoundStreaks()
	{
		foreach (PlayerInfoClass player in playerData) player.roundStreak = 0;
	}

	public static int SetCurrentRoundStreak(int newStreak)
	{
		if (IsValidPlayer(curPlayer)) PlayerAt(curPlayer).roundStreak = newStreak;
		return 0;
	}

	public static int GetPlayerMaxStreak(int playerNumber)
	{
		return IsValidPlayer(playerNumber) ? PlayerAt(playerNumber).maxStreak : 0;
	}

	public static int GetPlayerMaxRicochet(int playerNumber)
	{
		return IsValidPlayer(playerNumber) ? PlayerAt(playerNumber).maxRicochet : 0;
	}

	public static int GetCurrentRoundStreak()
	{
		return IsValidPlayer(curPlayer) ? PlayerAt(curPlayer).roundStreak : 0;
	}

	public static int SetCurrentTotalStreak(int newStreak)
	{
		if (IsValidPlayer(curPlayer))
		{
			PlayerInfoClass player = PlayerAt(curPlayer);
			player.streak = newStreak;
			if (player.maxStreak < newStreak) player.maxStreak = newStreak;
		}
		return 0;
	}

	public static void ClearTotalStreaks()
	{
		foreach (PlayerInfoClass player in playerData)
		{
			player.streak = 0;
			player.maxStreak = 0;
		}
	}

	public static int GetCurrentTotalStreak()
	{
		return IsValidPlayer(curPlayer) ? PlayerAt(curPlayer).streak : 0;
	}

	public static bool SetName(string playerName, int playerNumber)
	{
		if (!IsValidPlayer(playerNumber)) return true;
		PlayerAt(playerNumber).playerName = playerName;
		return false;
	}

	public static string GetName(int playerNumber)
	{
		return IsValidPlayer(playerNumber) ? PlayerAt(playerNumber).playerName : "error";
	}

	public static bool GetNameEnteredFlag(int playerNumber)
	{
		return IsValidPlayer(playerNumber) ? PlayerAt(playerNumber).nameEnteredFlag : true;
	}

	public static bool SetNameEnteredFlag(int playerNumber)
	{
		if (!IsValidPlayer(playerNumber)) return true;
		PlayerAt(playerNumber).nameEnteredFlag = true;
		return false;
	}

	public void ResetPlayerData()
	{
		playerData.Clear();
		for (int index = 0; index < maxPlayers; index++)
		{
			playerData.Add(new PlayerInfoClass());
		}
	}

	public void Awake()
	{
		replayFlag = false;
		totPlayers = mainmenu.feNumPlayers;
		ResetPlayerData();
		ClearAllScores();
		ResetGameManagerVars();
	}

	public void OnApplicationQuit()
	{
	}

	public static Rect GetiPadRect(Rect iPhoneRect, bool bTallView)
	{
		float xScale = bTallView ? iPadTallWidth / iPhoneTallWidth : iPadTallHeight / iPhoneTallHeight;
		float yScale = bTallView ? iPadTallHeight / iPhoneTallHeight : iPadTallWidth / iPhoneTallWidth;
		return new Rect(iPhoneRect.x * xScale, iPhoneRect.y * yScale,
			iPhoneRect.width * xScale, iPhoneRect.height * yScale);
	}

	public static Rect GetiPhoneRect(Rect iPadRect, bool bTallView)
	{
		float xScale = bTallView ? iPhoneTallWidth / iPadTallWidth : iPhoneTallHeight / iPadTallHeight;
		float yScale = bTallView ? iPhoneTallHeight / iPadTallHeight : iPhoneTallWidth / iPadTallWidth;
		return new Rect(iPadRect.x * xScale, iPadRect.y * yScale,
			iPadRect.width * xScale, iPadRect.height * yScale);
	}

	private static bool IsValidPlayer(int playerNumber)
	{
		return playerNumber >= 0 && playerNumber < playerData.Count;
	}

	private static PlayerInfoClass PlayerAt(int playerNumber)
	{
		return (PlayerInfoClass)playerData[playerNumber];
	}

	public void Main()
	{
	}
}
