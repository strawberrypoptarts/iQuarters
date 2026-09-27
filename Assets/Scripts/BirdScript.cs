using System;
using UnityEngine;

[Serializable]
public class BirdScript : MonoBehaviour
{
	public static float time;

	public static float speed;

	public static float normalizedSpeed;

	public float ltime;

	public float lspeed;

	public float lnormalizedSpeed;

	public float lweight;

	public int lwrapMode;

	public float lntime;

	public float llength;

	public int llayer;

	public float lclip;

	public int lblendMode;

	public static Animation anim;

	public void Start()
	{
		anim = gameObject.GetComponent<Animation>();
	}

	public void OnDisable()
	{
		anim = null;
	}

	public static bool AnimationPresent()
	{
		return false;
	}

	public static void RewindAnim()
	{
	}

	public static void ChecktoRewindAnim()
	{
	}

	public static void SaveAnimationData()
	{
	}

	public static void LoadAnimationData()
	{
	}

	public void FixedUpdate()
	{
		if (QuarterTrigger.birdAnimState == 1)
		{
			foreach (AnimationState animationState in animation)
			{
				time = animationState.time;
				speed = animationState.speed;
				normalizedSpeed = animationState.normalizedSpeed;
				ReplayController.SaveAnimationData(0, time, speed, normalizedSpeed);
			}
		}
		else if (QuarterTrigger.birdAnimState == 2)
		{
			if (ReplayController.hallOfFameReplay)
			{
				int index = ReplayController.replayDataCurIndex;
				time = ReplayController.storeTime[index];
				speed = ReplayController.storeSpeed[index];
				normalizedSpeed = ReplayController.storenormalizedSpeed[index];
			}
			foreach (AnimationState animationState in animation)
			{
				animationState.time = time;
				animationState.speed = speed;
				animationState.normalizedSpeed = normalizedSpeed;
			}
		}
		else if (QuarterTrigger.birdAnimState == 3)
		{
			foreach (AnimationState animationState in animation) animationState.time = 0f;
		}
	}

	public void Main()
	{
	}
}
