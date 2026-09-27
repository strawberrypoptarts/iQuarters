using System;
using UnityEngine;

[Serializable]
public class lightray : MonoBehaviour
{
	public static bool triggerLightRay;

	public GameObject lightRayObject;

	public GameObject quarterObject;

	public GameObject lazySusanGlassObject;

	public MeshFilter thisFilter;

	public MeshFilter thisFilter2;

	private int stateIdle = 100;

	private int statePlaying = 101;

	private int curState = 100;

	public void TintMesh(MeshFilter curFilter)
	{
		Mesh mesh = curFilter.mesh;
		Vector3[] vertices = mesh.vertices;
		Color[] original = mesh.colors;
		Color[] colors = new Color[vertices.Length];
		for (int i = 0; i < colors.Length; i++)
			colors[i] = new Color(0f, 0f, 0f, original[i].g > 0f ? 0f : 1f);
		mesh.colors = colors;
	}

	public void PositionOffScreen()
	{
		Vector3 position = transform.position;
		position.y = 1000f;
		transform.position = position;
	}

	public void Start()
	{
		TintMesh(thisFilter);
		TintMesh(thisFilter2);
		PositionOffScreen();
	}

	public void Update()
	{
		if (triggerLightRay)
		{
			lightRayObject.SetActiveRecursively(true);
			animation.Play();
			curState = statePlaying;
			triggerLightRay = false;
			return;
		}
		if (curState != statePlaying) return;
		if (GameManagerScript.curRound == 11)
		{
			Vector3 position = transform.position;
			position.x = lazySusanGlassObject.transform.position.x;
			position.z = lazySusanGlassObject.transform.position.z;
			transform.position = position;
		}
		if (!animation.isPlaying)
		{
			PositionOffScreen();
			lightRayObject.SetActiveRecursively(false);
			curState = stateIdle;
		}
	}

	public void Main()
	{
	}
}
