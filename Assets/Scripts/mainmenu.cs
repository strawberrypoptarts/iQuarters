using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class mainmenu : MonoBehaviour
{
	public GameObject areYouSureObject;

	public GameObject resumeGameObject;

	public GameObject aboutGameObject;

	public GameObject frontEndBgndObject;

	public Renderer titleLogoRenderer;

	public Renderer titleQLetterRenderer;

	public Material practiceMaterial;

	public Texture practiceTexture;

	public Texture practiceLockedTexture;

	public AudioClip introSound;

	public AudioClip clickSound;

	public static int gtPractice = 1;

	public static int gtClassic;

	public static int feNumPlayers = 1;

	public static int feGameType;

	private int currentHiScoreTable;

	public bool enableButtonView;

	public GUISkin dummySkin;

	public GUISkin fontSkin;

	public GUISkin fontSkin_iPad;

	private int feStateMainInit = 99;

	private int feStateMainPlaying = 100;

	private int feStateMainMenu = 101;

	private int feStateMainClick = 102;

	private int feStatePlayNowOutPlaying = 103;

	private int feStateGameTypeIn = 104;

	private int feStateGameTypeMenu = 105;

	private int feStateGameTypeOut = 106;

	private int feStateGameTypeClick = 107;

	private int feStateGameTypeOutBack = 108;

	private int feStateNumPlayersIn = 120;

	private int feStateNumPlayersMenu = 121;

	private int feStateNumPlayersOut = 122;

	private int feStateNumPlayersClick = 123;

	private int feStateHiScoreIn = 130;

	private int feStateHiScoreMenu = 131;

	private int feStateHiScoreOut = 132;

	private int feStateHiScoreClick = 133;

	private int feStateLevelLoadInit = 134;

	private int feStateLevelLoad = 135;

	private int feStateLevelLoadDone = 136;

	private int feStateAboutScreen = 140;

	private int feStateResumeScreen = 150;

	private int feStateHiScoreClearYesNo = 151;

	public int feStateCurrent;

	public int feNextState;

	public static bool resumeQuitFromGame;

	public static bool resumeDelayTriggerUI;

	public static bool resumeTriggerYes;

	public static bool resumeTriggerNo;

	public static string lastGameTotPlayers = "LG_TotPlayers";

	public static string lastGameCurPlayers = "LG_CurPlayer";

	public static string lastGameCurRound = "LG_CurRound";

	public static string lastGameCurShotThisRound = "LG_CurShotThisRound";

	public static string lastGameCurMadeShotsThisRound = "LG_CurMadeShotsThisRound";

	public static string lastGameNameEnteredFlag = "LG_NameEnteredFlag";

	public static string lastGamePlayerName = "LG_PlayerName";

	public static string lastGameScore = "LG_Score";

	public static string lastGameRoundScore = "LG_RoundScore";

	public static string lastGameShotsLeft = "LG_ShotsLeft";

	public static string lastGameStreak = "LG_Streak";

	public static string lastGameMaxStreak = "LG_MaxStreak";

	public static string lastGameRoundStreak = "LG_RoundStreak";

	public static string lastGamePlayedThisRound = "LG_PlayedThisRound";

	public static string lastGameGameOver = "LG_GameOver";

	public static string lastGameInputType = "LG_InputType";

	public static string lastGameMaxRicochet = "LG_MaxRicochet";

	public bool isPracticeLocked()
	{
		return HiScoreScript.lockedRoundStartIndex < 2;
	}

	public void SetPracticeTexture()
	{
		practiceMaterial.mainTexture = isPracticeLocked() ? practiceLockedTexture : practiceTexture;
	}

	public void Start()
	{
		CheckforBgndScale();
		HiScoreScript.LoadLocks();
		SetPracticeTexture();
		areYouSureObject.SetActiveRecursively(true);
		About.TriggerButtonOn = true;
		feNextState = feStateMainInit;
		feNumPlayers = 1;
		feGameType = gtClassic;
		GameObject.Find("ui_main_menu_00/button_back_hs").renderer.enabled = false;
		GameObject.Find("ui_main_menu_00/button_clear_hs").renderer.enabled = false;
		if (!resumeQuitFromGame && DoesLastGameExist())
		{
			resumeDelayTriggerUI = true;
			resumeGameObject.SetActiveRecursively(true);
		}
		resumeQuitFromGame = false;
		for (int index = 0; index < 10; index++)
			GameObject.Find("ui_main_menu_00/high_score_bg_0" + index).renderer.enabled = false;
	}

	public static void DeleteLastGame()
	{
		PlayerPrefs.DeleteKey(lastGameTotPlayers);
		PlayerPrefs.DeleteKey(lastGameCurPlayers);
		PlayerPrefs.DeleteKey(lastGameCurRound);
		PlayerPrefs.DeleteKey(lastGameCurShotThisRound);
		PlayerPrefs.DeleteKey(lastGameCurMadeShotsThisRound);
		for (int index = 0; index < 4; index++)
		{
			PlayerPrefs.DeleteKey(lastGameNameEnteredFlag + index);
			PlayerPrefs.DeleteKey(lastGamePlayerName + index);
			PlayerPrefs.DeleteKey(lastGameScore + index);
			PlayerPrefs.DeleteKey(lastGameRoundScore + index);
			PlayerPrefs.DeleteKey(lastGameShotsLeft + index);
			PlayerPrefs.DeleteKey(lastGameStreak + index);
			PlayerPrefs.DeleteKey(lastGameMaxStreak + index);
			PlayerPrefs.DeleteKey(lastGameRoundStreak + index);
			PlayerPrefs.DeleteKey(lastGamePlayedThisRound + index);
			PlayerPrefs.DeleteKey(lastGameGameOver + index);
			PlayerPrefs.DeleteKey(lastGameInputType + index);
			PlayerPrefs.DeleteKey(lastGameMaxRicochet + index);
		}
	}

	public bool DoesLastGameExist()
	{
		if (!PlayerPrefs.HasKey(lastGameTotPlayers) || !PlayerPrefs.HasKey(lastGameCurPlayers) ||
			!PlayerPrefs.HasKey(lastGameCurRound) || !PlayerPrefs.HasKey(lastGameCurShotThisRound) ||
			!PlayerPrefs.HasKey(lastGameCurMadeShotsThisRound))
		{
			return false;
		}

		int players = PlayerPrefs.GetInt(lastGameTotPlayers);
		for (int index = 0; index < players; index++)
		{
			if (!PlayerPrefs.HasKey(lastGameNameEnteredFlag + index) ||
				!PlayerPrefs.HasKey(lastGamePlayerName + index) ||
				!PlayerPrefs.HasKey(lastGameScore + index) ||
				!PlayerPrefs.HasKey(lastGameRoundScore + index) ||
				!PlayerPrefs.HasKey(lastGameShotsLeft + index) ||
				!PlayerPrefs.HasKey(lastGameStreak + index) ||
				!PlayerPrefs.HasKey(lastGameMaxStreak + index) ||
				!PlayerPrefs.HasKey(lastGameRoundStreak + index) ||
				!PlayerPrefs.HasKey(lastGamePlayedThisRound + index) ||
				!PlayerPrefs.HasKey(lastGameGameOver + index) ||
				!PlayerPrefs.HasKey(lastGameInputType + index) ||
				!PlayerPrefs.HasKey(lastGameMaxRicochet + index))
			{
				return false;
			}
		}
		return true;
	}

	public static void LoadLastGame()
	{
		feGameType = gtClassic;
		GameManagerScript.totPlayers = PlayerPrefs.GetInt(lastGameTotPlayers);
		GameManagerScript.curPlayer = PlayerPrefs.GetInt(lastGameCurPlayers);
		GameManagerScript.curRound = PlayerPrefs.GetInt(lastGameCurRound);
		GameManagerScript.curShotThisRound = PlayerPrefs.GetInt(lastGameCurShotThisRound);
		GameManagerScript.curMadeShotsThisRound = PlayerPrefs.GetInt(lastGameCurMadeShotsThisRound);
		for (int index = 0; index < GameManagerScript.totPlayers; index++)
		{
			PlayerInfoClass player = (PlayerInfoClass)GameManagerScript.playerData[index];
			player.nameEnteredFlag = PlayerPrefs.GetInt(lastGameNameEnteredFlag + index) != 0;
			player.playerName = PlayerPrefs.GetString(lastGamePlayerName + index);
			player.score = PlayerPrefs.GetInt(lastGameScore + index);
			player.roundScore = PlayerPrefs.GetInt(lastGameRoundScore + index);
			player.shotsLeft = PlayerPrefs.GetInt(lastGameShotsLeft + index);
			player.streak = PlayerPrefs.GetInt(lastGameStreak + index);
			player.maxStreak = PlayerPrefs.GetInt(lastGameMaxStreak + index);
			player.roundStreak = PlayerPrefs.GetInt(lastGameRoundStreak + index);
			player.playedThisRound = PlayerPrefs.GetInt(lastGamePlayedThisRound + index) != 0;
			player.gameOver = PlayerPrefs.GetInt(lastGameGameOver + index) != 0;
			player.inputType = PlayerPrefs.GetInt(lastGameInputType + index);
			player.maxRicochet = PlayerPrefs.GetInt(lastGameMaxRicochet + index);
		}
	}

	public static void SaveLastGame()
	{
		PlayerPrefs.SetInt(lastGameTotPlayers, GameManagerScript.totPlayers);
		PlayerPrefs.SetInt(lastGameCurPlayers, GameManagerScript.curPlayer);
		PlayerPrefs.SetInt(lastGameCurRound, GameManagerScript.curRound);
		PlayerPrefs.SetInt(lastGameCurShotThisRound, GameManagerScript.curShotThisRound);
		PlayerPrefs.SetInt(lastGameCurMadeShotsThisRound, GameManagerScript.curMadeShotsThisRound);
		for (int index = 0; index < GameManagerScript.totPlayers; index++)
		{
			PlayerInfoClass player = (PlayerInfoClass)GameManagerScript.playerData[index];
			PlayerPrefs.SetInt(lastGameNameEnteredFlag + index, player.nameEnteredFlag ? 1 : 0);
			PlayerPrefs.SetString(lastGamePlayerName + index, player.playerName);
			PlayerPrefs.SetInt(lastGameScore + index, player.score);
			PlayerPrefs.SetInt(lastGameRoundScore + index, player.roundScore);
			PlayerPrefs.SetInt(lastGameShotsLeft + index, player.shotsLeft);
			PlayerPrefs.SetInt(lastGameStreak + index, player.streak);
			PlayerPrefs.SetInt(lastGameMaxStreak + index, player.maxStreak);
			PlayerPrefs.SetInt(lastGameRoundStreak + index, player.roundStreak);
			PlayerPrefs.SetInt(lastGamePlayedThisRound + index, player.playedThisRound ? 1 : 0);
			PlayerPrefs.SetInt(lastGameGameOver + index, player.gameOver ? 1 : 0);
			PlayerPrefs.SetInt(lastGameInputType + index, player.inputType);
			PlayerPrefs.SetInt(lastGameMaxRicochet + index, player.maxRicochet);
		}
	}

	public void PlayClickSound()
	{
		audio.clip = clickSound;
		audio.Play();
	}

	public void PlayIntroSound()
	{
		audio.clip = introSound;
		audio.Play();
	}

	public void DisplayGameScoreRecords()
	{
		GUI.skin = GameManagerScript.is_iPad() ? fontSkin_iPad : fontSkin;
		ArrayList entries = HiScoreScript.GetArray();
		for (int i = 0; i < entries.Count; i++)
		{
			Entry entry = (Entry)entries[i];
			Rect name = new Rect(115f, 70f + i * 22f, 180f, 24f);
			Rect score = new Rect(300f, 70f + i * 22f, 90f, 24f);
			if (GameManagerScript.is_iPad()) { name = GameManagerScript.GetiPadRect(name); score = GameManagerScript.GetiPadRect(score); }
			GUI.Label(name, entry.name);
			GUI.Label(score, ((int)entry.score).ToString());
		}
	}

	public void DisplayRoundScoreRecords()
	{
		GUI.skin = GameManagerScript.is_iPad() ? fontSkin_iPad : fontSkin;
		TextAnchor alignment = GUI.skin.label.alignment;
		int startY = GameManagerScript.is_iPad() ? 93 : 90;
		for (int i = 0; i < GameManagerScript.numRounds; i++)
		{
			GUI.skin.label.alignment = alignment;
			Rect label = new Rect(30f, startY + i * 28f, 200f, 30f);
			Rect number = new Rect(200f, startY + i * 28f, 40f, 30f);
			Rect score = new Rect(300f, startY + i * 28f, 95f, 30f);
			if (GameManagerScript.is_iPad()) { label = GameManagerScript.GetiPadRect(label); number = GameManagerScript.GetiPadRect(number); score = GameManagerScript.GetiPadRect(score); }
			GUI.Label(label, "Round");
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.Label(number, (i + 1).ToString());
			GUI.Label(score, HiScoreRoundScript.GetScore(i).ToString());
		}
		GUI.skin.label.alignment = alignment;
	}

	public void CheckforBgndScale()
	{
		if (GameManagerScript.is_iPad())
		{
			Vector3 scale = frontEndBgndObject.transform.localScale;
			frontEndBgndObject.transform.localScale = new Vector3(37f, scale.y, scale.z);
		}
	}

	public void OnGUI()
	{
		if (!enableButtonView) GUI.skin = dummySkin;
		if (feStateCurrent == 0 || feStateCurrent == feStateMainInit)
		{
			animation.Play("intro");
			feStateCurrent = feStateMainPlaying;
			return;
		}
		if (feStateCurrent == feStateMainPlaying)
		{
			if (!animation.isPlaying)
			{
				aboutGameObject.SetActiveRecursively(true);
				About.TriggerButtonOn = true;
				feStateCurrent = resumeDelayTriggerUI ? feStateResumeScreen : feStateMainMenu;
				resumeDelayTriggerUI = false;
			}
			return;
		}

		Rect left = new Rect(50f, 110f, 180f, 55f);
		Rect right = new Rect(250f, 110f, 180f, 55f);
		Rect lowerLeft = new Rect(50f, 180f, 180f, 55f);
		Rect lowerRight = new Rect(250f, 180f, 180f, 55f);
		Rect back = new Rect(20f, 250f, 100f, 55f);
		if (GameManagerScript.is_iPad()) { left = GameManagerScript.GetiPadRect(left); right = GameManagerScript.GetiPadRect(right); lowerLeft = GameManagerScript.GetiPadRect(lowerLeft); lowerRight = GameManagerScript.GetiPadRect(lowerRight); back = GameManagerScript.GetiPadRect(back); }

		if (feStateCurrent == feStateMainMenu)
		{
			if (GUI.Button(left, string.Empty))
			{
				feNextState = feStateGameTypeIn; feStateCurrent = feStateMainClick;
				animation.Play("playnowclick"); About.TriggerButtonOff = true; PlayClickSound();
			}
			else if (GUI.Button(right, string.Empty))
			{
				feNextState = feStateHiScoreIn; feStateCurrent = feStateMainClick;
				animation.Play("hiscoreclick"); DisplayMainLogo(false); About.TriggerButtonOff = true; PlayClickSound();
			}
			else if (GUI.Button(lowerLeft, string.Empty))
			{
				titleLogoRenderer.enabled = titleQLetterRenderer.enabled = false;
				animation.Play("playnowout"); About.TriggerTextOn = true; feStateCurrent = feStateAboutScreen; PlayClickSound();
			}
			return;
		}
		if (feStateCurrent == feStateMainClick && !animation.isPlaying)
		{
			animation.Play("playnowout"); feStateCurrent = feStatePlayNowOutPlaying; return;
		}
		if (feStateCurrent == feStatePlayNowOutPlaying && !animation.isPlaying)
		{
			if (feNextState == feStateGameTypeIn) { animation.Play("gtin"); feStateCurrent = feStateGameTypeIn; }
			else
			{
				HiScoreScript.LoadEntries(feGameType); HiScoreRoundScript.LoadEntries();
				BackClearButtons.TriggerIn = GameOrRoundButtons.TriggerIn = GameHighScreen.TriggerIn = Logo.TriggerIn = true;
				feStateCurrent = feStateHiScoreIn;
			}
			return;
		}
		if (feStateCurrent == feStateGameTypeIn && !animation.isPlaying) feStateCurrent = feStateGameTypeMenu;
		if (feStateCurrent == feStateGameTypeMenu)
		{
			if (!isPracticeLocked() && GUI.Button(left, string.Empty)) { feGameType = gtPractice; feNextState = feStateLevelLoadInit; animation.Play("gtpracticeclick"); feStateCurrent = feStateGameTypeClick; PlayClickSound(); }
			else if (GUI.Button(right, string.Empty)) { feGameType = gtClassic; feNextState = feStateNumPlayersIn; animation.Play("gtclassicclick"); feStateCurrent = feStateGameTypeClick; PlayClickSound(); }
			else if (GUI.Button(back, string.Empty)) { feNextState = feStateMainPlaying; animation.Play("gtbackclick"); feStateCurrent = feStateGameTypeClick; PlayClickSound(); }
			return;
		}
		if (feStateCurrent == feStateGameTypeClick && !animation.isPlaying)
		{
			animation.Play(feGameType == gtPractice ? "gtpracticeout" : "gtout"); feStateCurrent = feStateGameTypeOut; return;
		}
		if (feStateCurrent == feStateGameTypeOut && !animation.isPlaying)
		{
			if (feNextState == feStateNumPlayersIn) { animation.Play("npin"); feStateCurrent = feStateNumPlayersIn; }
			else if (feNextState == feStateMainPlaying) { animation.Play("intro"); feStateCurrent = feStateMainPlaying; }
			else feStateCurrent = feStateLevelLoadInit;
			return;
		}
		if (feStateCurrent == feStateNumPlayersIn && !animation.isPlaying) feStateCurrent = feStateNumPlayersMenu;
		if (feStateCurrent == feStateNumPlayersMenu)
		{
			if (GUI.Button(left, string.Empty)) { feNumPlayers = 1; animation.Play("nponeplayer"); feStateCurrent = feStateNumPlayersClick; }
			else if (GUI.Button(right, string.Empty)) { feNumPlayers = 2; animation.Play("nptwoplayer"); feStateCurrent = feStateNumPlayersClick; }
			else if (GUI.Button(lowerLeft, string.Empty)) { feNumPlayers = 3; animation.Play("npthreeplayer"); feStateCurrent = feStateNumPlayersClick; }
			else if (GUI.Button(lowerRight, string.Empty)) { feNumPlayers = 4; animation.Play("npfourplayer"); feStateCurrent = feStateNumPlayersClick; }
			else if (GUI.Button(back, string.Empty)) { feNextState = feStateGameTypeIn; animation.Play("npbackclick"); feStateCurrent = feStateNumPlayersClick; }
			return;
		}
		if (feStateCurrent == feStateNumPlayersClick && !animation.isPlaying)
		{
			animation.Play("npout"); feStateCurrent = feStateNumPlayersOut; PlayClickSound(); return;
		}
		if (feStateCurrent == feStateNumPlayersOut && !animation.isPlaying)
		{
			if (feNextState == feStateGameTypeIn) { animation.Play("gtin"); feStateCurrent = feStateGameTypeIn; }
			else { GameManagerScript.totPlayers = feNumPlayers; feStateCurrent = feStateLevelLoadInit; }
			return;
		}
		if (feStateCurrent == feStateHiScoreIn) feStateCurrent = feStateHiScoreMenu;
		if (feStateCurrent == feStateHiScoreMenu)
		{
			if (GameOrRoundButtons.gameButtonSelected) DisplayGameScoreRecords(); else DisplayRoundScoreRecords();
			if (GUI.Button(back, string.Empty))
			{
				BackClearButtons.TriggerBack = GameOrRoundButtons.TriggerOut = true;
				GameHighScreen.TriggerOut = RoundHighScreen.TriggerOut = Logo.TriggerOut = true;
				DisplayMainLogo(true); animation.Play("intro"); feStateCurrent = feStateMainPlaying; PlayClickSound();
			}
			return;
		}
		if (feStateCurrent == feStateResumeScreen)
		{
			if (!resumeTriggerYes && !resumeTriggerNo)
			{
				if (GUI.Button(left, string.Empty)) { resumeTriggerYes = true; resumeGameObject.animation.Play("YesClick"); PlayClickSound(); }
				else if (GUI.Button(right, string.Empty)) { DeleteLastGame(); resumeTriggerNo = true; resumeGameObject.animation.Play("NoClick"); PlayClickSound(); }
			}
			else if (resumeTriggerYes && !resumeGameObject.animation.IsPlaying("YesClick")) { resumeGameObject.SetActiveRecursively(false); LoadLastGame(); feStateCurrent = feStateLevelLoadInit; }
			else if (resumeTriggerNo && !resumeGameObject.animation.IsPlaying("NoClick")) { resumeTriggerNo = false; resumeGameObject.SetActiveRecursively(false); feStateCurrent = feStateMainMenu; }
			return;
		}
		if (feStateCurrent == feStateAboutScreen)
		{
			if (GUI.Button(back, string.Empty)) { titleLogoRenderer.enabled = titleQLetterRenderer.enabled = true; About.TriggerTextOff = true; animation.Play("intro"); feStateCurrent = feStateMainPlaying; }
			return;
		}
		if (feStateCurrent == feStateLevelLoadInit) { feStateCurrent = feStateLevelLoad; return; }
		if (feStateCurrent == feStateLevelLoad) { DisplayLoadingMessage(); LevelLoad(); feStateCurrent = feStateLevelLoadDone; }
		else if (feStateCurrent == feStateLevelLoadDone) DisplayLoadingMessage();
	}

	public void DisplayMainLogo(bool flag)
	{
		GameObject.Find("/ui_main_menu_00/logo_bg_q_00").renderer.enabled = flag;
		GameObject.Find("/ui_main_menu_00/logo_quarters_00").renderer.enabled = flag;
	}

	public void DisplayLoadingMessage()
	{
		GUI.skin = GameManagerScript.is_iPad() ? fontSkin_iPad : fontSkin;
		Rect rect = new Rect(32f, 270f, 416f, 40f);
		if (GameManagerScript.is_iPad()) rect = GameManagerScript.GetiPadRect(rect);
		GUI.Label(rect, "Loading...");
	}

	public void GameTypeNextState(int nextState)
	{
		if (nextState == feStateMainPlaying)
		{
			feNextState = feStateMainPlaying;
			animation.Play("intro");
		}
		else if (nextState == feStateNumPlayersIn)
		{
			feNextState = feStateNumPlayersIn;
			animation.Play("npin");
		}
	}

	public void LevelLoad()
	{
		Application.LoadLevel("qtr");
	}

	public void Main()
	{
	}
}
