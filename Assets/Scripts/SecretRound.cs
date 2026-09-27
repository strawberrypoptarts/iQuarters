using System;
using UnityEngine;

[Serializable]
public class SecretRound : MonoBehaviour
{
	public GameObject secretRoundObject;

	public static bool TriggerSecretRoundIntro;

	public static bool TriggerSecretRoundOutro;

	private int stateIdle = 100;

	private int stateOnscreen = 101;

	private int state = 100;

	private GameObject roundCenterObject;

	private GameObject completeObject;

	private GameObject roundObject;

	public void Start()
	{
		roundCenterObject = GameObject.Find("/ex_secret_round/Plane01/round_center");
		completeObject = GameObject.Find("/ex_secret_round/Plane01/complete");
		roundObject = GameObject.Find("/ex_secret_round/Plane01/round_01");
		secretRoundObject.SetActiveRecursively(false);
	}

	public void Update()
	{
		if (TriggerSecretRoundIntro)
		{
			TriggerSecretRoundIntro = false;
			roundCenterObject.renderer.enabled = false;
			completeObject.renderer.enabled = false;
			roundObject.renderer.enabled = true;
			animation.Play();
			state = stateOnscreen;
		}
		else if (TriggerSecretRoundOutro)
		{
			TriggerSecretRoundOutro = false;
			roundCenterObject.renderer.enabled = true;
			completeObject.renderer.enabled = true;
			roundObject.renderer.enabled = false;
			animation.Play();
			state = stateOnscreen;
		}
		else if (state == stateOnscreen && !animation.isPlaying)
		{
			secretRoundObject.SetActiveRecursively(false);
			state = stateIdle;
		}
	}

	public void Main()
	{
	}
}
