using System;
using UnityEngine;

[Serializable]
public class GameOver : MonoBehaviour
{
	public GameObject GameOverExciterObject;

	public static bool triggerExciterOutOfShots;

	public static bool triggerExciterGameComplete;

	public static int roundToDisplay;

	private int rfStateIsRunning = 10000;

	private int rfStateIdle = 10001;

	private int rfStateEnding = 10002;

	private int rfStateCurrent = 10001;

	public void Start()
	{
	}

	public void Update()
	{
		if (triggerExciterOutOfShots)
		{
			animation.Play("outofshots");
			rfStateCurrent = rfStateIsRunning;
			triggerExciterOutOfShots = false;
		}
		else if (triggerExciterGameComplete)
		{
			animation.Play("gamecomplete");
			rfStateCurrent = rfStateIsRunning;
			triggerExciterGameComplete = false;
		}
		else if (rfStateCurrent == rfStateIsRunning && !animation.isPlaying)
		{
			rfStateCurrent = rfStateEnding;
		}
		else if (rfStateCurrent == rfStateEnding)
		{
			rfStateCurrent = rfStateIdle;
			GameOverExciterObject.SetActiveRecursively(false);
		}
	}

	public void Main()
	{
	}
}
