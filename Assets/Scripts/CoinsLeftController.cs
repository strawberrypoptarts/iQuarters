using System;
using UnityEngine;

[Serializable]
public class CoinsLeftController : MonoBehaviour
{
	public GameObject stackObject;

	public static bool triggerCoinsLeft;

	public static bool triggerCoinsOut;

	public static int curCoinsLeft = 1;

	public static void TriggerCoinsLeft(int coinsLeft)
	{
		curCoinsLeft = coinsLeft;
		triggerCoinsLeft = true;
	}

	public void Update()
	{
		if (triggerCoinsLeft)
		{
			stackObject.SetActiveRecursively(true);
			Vector3 position = transform.localPosition;
			position.x = curCoinsLeft;
			transform.localPosition = position;
			triggerCoinsLeft = false;
		}

		if (triggerCoinsOut)
		{
			stackObject.SetActiveRecursively(false);
			triggerCoinsOut = false;
		}
	}

	public void Main()
	{
	}
}
