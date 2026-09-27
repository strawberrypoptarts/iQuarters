using System;
using UnityEngine;

[Serializable]
public class iPhoneWater : MonoBehaviour
{
	public Shader depthShader;

	public void Awake()
	{
		RenderWater renderer = (RenderWater)Camera.main.GetComponent(typeof(RenderWater));
		if (!renderer)
		{
			renderer = (RenderWater)Camera.main.gameObject.AddComponent(typeof(RenderWater));
			renderer.depthShader = depthShader;
			renderer.water = new GameObject[1];
			renderer.water[0] = gameObject;
		}
		else
		{
			GameObject[] previous = renderer.water;
			renderer.water = new GameObject[previous.Length + 1];
			Array.Copy(previous, renderer.water, previous.Length);
			renderer.water[previous.Length] = gameObject;
		}
		UnityEngine.Object.Destroy(this);
	}

	public void Main()
	{
	}
}
