using System;
using UnityEngine;

[Serializable]
public class ChipRicochetScript : MonoBehaviour
{
	public GameObject thisObject;

	public Texture textureRicochet1;

	public Texture textureRicochet2;

	public Texture textureRicochet3;

	public Texture textureRicochet4;

	public Texture textureRicochet5;

	public Texture textureRicochet6;

	public Texture textureRicochet7;

	public Texture textureRicochet8;

	public Texture textureRicochet9;

	public static bool incrementRicochetsFlag;

	public static int numRicochets;

	public void Update()
	{
		if (incrementRicochetsFlag)
		{
			numRicochets++;
			SetCurTexture(numRicochets);
			incrementRicochetsFlag = false;
		}
	}

	public void Start()
	{
		numRicochets = 0;
		incrementRicochetsFlag = false;
		SetCurTexture(1);
		thisObject.SetActiveRecursively(false);
	}

	public void SetCurTexture(int numRicochets)
	{
		if (numRicochets == 1) guiTexture.texture = textureRicochet1;
		else if (numRicochets == 2) guiTexture.texture = textureRicochet2;
		else if (numRicochets == 3) guiTexture.texture = textureRicochet3;
		else if (numRicochets == 4) guiTexture.texture = textureRicochet4;
		else if (numRicochets == 5) guiTexture.texture = textureRicochet5;
		else if (numRicochets == 6) guiTexture.texture = textureRicochet6;
		else if (numRicochets == 7) guiTexture.texture = textureRicochet7;
		else if (numRicochets == 8) guiTexture.texture = textureRicochet8;
		else guiTexture.texture = textureRicochet9;
	}

	public void Main()
	{
	}
}
