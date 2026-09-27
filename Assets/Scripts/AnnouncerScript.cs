using System;
using UnityEngine;

[Serializable]
public class AnnouncerScript : MonoBehaviour
{
	public static bool triggerOffTableVO;

	public static int triggerPlayerVO;

	public static bool triggerPerfectRoundVO;

	public static bool triggerClickSound;

	public static bool triggerUnlockSound;

	public AudioClip floorSound;

	public AudioClip perfectRoundVO;

	public AudioClip clickSound;

	public AudioClip unlockSound;

	public void Update()
	{
		if (triggerClickSound)
		{
			if (!QuarterTrigger.muteF)
			{
				audio.clip = clickSound;
				audio.Play();
			}
			triggerClickSound = false;
		}

		if (triggerUnlockSound)
		{
			if (!QuarterTrigger.muteF)
			{
				audio.clip = unlockSound;
				audio.Play();
			}
			triggerUnlockSound = false;
		}

		if (triggerPerfectRoundVO)
		{
			if (!QuarterTrigger.muteF && mainmenu.feGameType == mainmenu.gtPractice)
			{
				audio.clip = perfectRoundVO;
				audio.Play();
			}
			triggerPerfectRoundVO = false;
		}

		if (triggerOffTableVO)
		{
			if (!QuarterTrigger.muteF)
			{
				audio.clip = floorSound;
				audio.Play();
			}
			triggerOffTableVO = false;
		}

		if (triggerPlayerVO != 0)
		{
			triggerPlayerVO = 0;
		}
	}

	public void Main()
	{
	}
}
