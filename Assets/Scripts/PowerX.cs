using System;
using UnityEngine;

[Serializable]
public class PowerX : MonoBehaviour
{
	public float scaleX;

	public float scaleY;

	public GameObject quarterObject;

	public GameObject PowerXObject;

	public GameObject scaleControllerObject;

	public Material pUpMaterial;

	public Texture power1UpTexture;

	public Texture power2UpTexture;

	public Texture power3UpTexture;

	public Texture power4UpTexture;

	public static bool triggerStatscreen;

	public static int pUpIndex = 1;

	public static bool triggerPowerUp;

	private int puStateIdle = 100;

	private int puStateInit = 101;

	private int puStateAnimating = 102;

	private int puStateCurrent = 100;

	public Color startColor;

	public float startPositionX = 0.5f;

	public float startPositionY = 0.5f;

	public void Start()
	{
		pUpMaterial.SetColor("_Color", Color.clear);
	}

	public static void DisplayPowerUp(int powerUp)
	{
		pUpIndex = powerUp;
		triggerPowerUp = true;
	}

	public void GetStartPosition()
	{
		startPositionX = startPositionY = 0.5f;
		Camera[] cameras = Camera.allCameras;
		if (cameras.Length > 0)
		{
			Vector3 viewport = cameras[0].WorldToViewportPoint(quarterObject.transform.position);
			startPositionX = viewport.x;
			startPositionY = viewport.y;
		}
	}

	public void SetTexture(int idx)
	{
		switch (idx)
		{
			case 2: pUpMaterial.mainTexture = power2UpTexture; break;
			case 3: pUpMaterial.mainTexture = power3UpTexture; break;
			case 4: pUpMaterial.mainTexture = power4UpTexture; break;
			default: pUpMaterial.mainTexture = power1UpTexture; break;
		}
	}

	public void Update()
	{
		if (triggerPowerUp)
		{
			GetStartPosition();
			SetTexture(pUpIndex);
			pUpMaterial.SetColor("_Color", Color.clear);
			animation.Play();
			puStateCurrent = puStateInit;
			triggerPowerUp = false;
			return;
		}
		if (puStateCurrent == puStateInit)
		{
			Vector3 position = transform.position;
			position.x = startPositionX; position.y = startPositionY;
			transform.position = position;
			puStateCurrent = puStateAnimating;
		}
		else if (puStateCurrent == puStateAnimating)
		{
			startColor.a = scaleControllerObject.transform.localScale.x - 1f;
			pUpMaterial.SetColor("_Color", startColor);
			scaleX = scaleControllerObject.transform.localScale.x;
			scaleY = scaleControllerObject.transform.localScale.y;
			if (!animation.isPlaying)
			{
				pUpMaterial.SetColor("_Color", Color.clear);
				PowerXObject.SetActiveRecursively(false);
				puStateCurrent = puStateIdle;
			}
		}
	}

	public void Main()
	{
	}
}
