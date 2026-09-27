using System;
using UnityEngine;

[Serializable]
public class ChipBounceScript : MonoBehaviour
{
	public GameObject thisObject;

	public Texture textureBounce1;

	public Texture textureBounce2;

	public Texture textureBounce3;

	public Texture textureBounce4;

	public Texture textureBounce5;

	public Texture textureBounce6;

	public Texture textureBounce7;

	public Texture textureBounce8;

	public Texture textureBounce9;

	public static bool incrementBouncesFlag;

	public static int numBounces;

	public void Update()
	{
		if (incrementBouncesFlag)
		{
			numBounces++;
			SetCurTexture(numBounces);
			incrementBouncesFlag = false;
		}
	}

	public void Start()
	{
		numBounces = 0;
		incrementBouncesFlag = false;
		SetCurTexture(1);
		thisObject.SetActiveRecursively(false);
	}

	public void SetCurTexture(int nBounces)
	{
		if (nBounces == 1) guiTexture.texture = textureBounce1;
		else if (nBounces == 2) guiTexture.texture = textureBounce2;
		else if (nBounces == 3) guiTexture.texture = textureBounce3;
		else if (nBounces == 4) guiTexture.texture = textureBounce4;
		else if (nBounces == 5) guiTexture.texture = textureBounce5;
		else if (nBounces == 6) guiTexture.texture = textureBounce6;
		else if (nBounces == 7) guiTexture.texture = textureBounce7;
		else if (nBounces == 8) guiTexture.texture = textureBounce8;
		else guiTexture.texture = textureBounce9;
	}

	public void Main()
	{
	}
}
