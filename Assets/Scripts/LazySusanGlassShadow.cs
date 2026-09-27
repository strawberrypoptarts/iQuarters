using System;
using UnityEngine;

[Serializable]
public class LazySusanGlassShadow : MonoBehaviour
{
	public GameObject lazySusanObject;

	public GameObject lazySusanGlassObject;

	public GameObject glassShadowObject;

	public void Update()
	{
		if (!IsLazySusanActive()) return;
		glassShadowObject.renderer.enabled = true;
		Vector3 position = lazySusanGlassObject.transform.position;
		position.y += 0.23f;
		glassShadowObject.transform.position = position;
		Vector3 scale = glassShadowObject.transform.localScale;
		scale.x = 0.17f;
		scale.z = 0.17f;
		glassShadowObject.transform.localScale = scale;
	}

	public bool IsLazySusanActive()
	{
		return lazySusanObject.active;
	}

	public void Main()
	{
	}
}
