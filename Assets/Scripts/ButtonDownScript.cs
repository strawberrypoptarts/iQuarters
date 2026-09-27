using System;
using UnityEngine;

[Serializable]
public class ButtonDownScript : MonoBehaviour
{
	public static bool PlayOneShot;

	public void Update()
	{
		if (PlayOneShot)
		{
			if (!QuarterTrigger.muteF)
			{
				audio.Play();
			}
			PlayOneShot = false;
		}
	}

	public void Main()
	{
	}
}
