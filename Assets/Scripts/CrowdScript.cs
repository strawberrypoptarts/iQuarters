using System;
using UnityEngine;

[Serializable]
public class CrowdScript : MonoBehaviour
{
	public AudioClip applause1;

	public AudioClip applause3;

	public static int playApplauseSound;

	public void ApplauseSound(int sound)
	{
		if (QuarterTrigger.muteF)
		{
			return;
		}

		if (sound == 1)
		{
			audio.volume = 0.5f;
			audio.clip = applause1;
			audio.Play();
		}
		else if (sound == 2)
		{
			audio.volume = 0.5f;
			audio.PlayOneShot(applause1);
		}
		else if (sound == 3)
		{
			audio.volume = 1f;
			audio.PlayOneShot(applause3);
		}
	}

	public void FixedUpdate()
	{
		if (playApplauseSound != 0)
		{
			ApplauseSound(playApplauseSound);
			playApplauseSound = 0;
		}
	}

	public void Main()
	{
	}
}
