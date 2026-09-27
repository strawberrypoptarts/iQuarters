using System;

[Serializable]
public class PlayerInfoClass
{
	public bool nameEnteredFlag;

	public string playerName = "plyr";

	public int score;

	public int roundScore;

	public int shotsLeft = 40;

	public int streak;

	public int maxStreak;

	public int roundStreak;

	public bool playedThisRound;

	public bool gameOver;

	public int inputType = 1;

	public int maxRicochet;
}
