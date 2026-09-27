using System;
using UnityEngine;

[Serializable]
public class UIPlayer : MonoBehaviour
{
	public static bool triggerPlayer1;

	public static bool triggerPlayer1In;

	public static bool triggerPlayer1Out;

	public void Update()
	{
		if (triggerPlayer1)
		{
			animation.Play(PlayerAnimationName(string.Empty));
			triggerPlayer1 = false;
		}
		else if (triggerPlayer1In)
		{
			animation.Play(PlayerAnimationName("in"));
			triggerPlayer1In = false;
		}
		else if (triggerPlayer1Out)
		{
			animation.Play(PlayerAnimationName("out"));
			triggerPlayer1Out = false;
		}
	}

	private static string PlayerAnimationName(string suffix)
	{
		int playerNumber = GameManagerScript.curPlayer + 1;
		return "player" + playerNumber + suffix;
	}

	public void Main()
	{
	}
}
