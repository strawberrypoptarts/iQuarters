using System;
using UnityEngine;

[Serializable]
public class ShadowQuarterScript : MonoBehaviour
{
	public GameObject ThisObject;

	public GameObject QuarterObject;

	public float baseScale = 0.1f;

	public float shadowScaleFactor = 0.02f;

	public float zScale;

	public float xScale;

	public float tableDistFromCenterX;

	public float tableDistFromCenterZ;

	private float minZposition = -3.5f;

	public float radiusThresh = 3f;

	public float lazySusanHeight = 0.17f;

	private int lazySusanRound = 11;

	public void Update()
	{
		Vector3 quarterPosition = QuarterObject.transform.position;
		Vector3 shadowPosition = ThisObject.transform.position;
		shadowPosition.x = quarterPosition.x;
		shadowPosition.z = quarterPosition.z;
		if (shadowPosition.z < minZposition) shadowPosition.z = minZposition;
		shadowPosition.y = quarterPosition.y < 0.1f ? -10f : 0.05f;

		if (GameManagerScript.curRound == lazySusanRound)
		{
			GameObject lazySusan = GameObject.Find("/lazy_susan_00");
			if (lazySusan)
			{
				Vector2 distance = new Vector2(lazySusan.transform.position.x - shadowPosition.x,
					lazySusan.transform.position.z - shadowPosition.z);
				if (distance.magnitude < radiusThresh) shadowPosition.y += lazySusanHeight;
			}
		}
		ThisObject.transform.position = shadowPosition;

		float scaleAmount = quarterPosition.y < 0f ? baseScale : baseScale + quarterPosition.y * shadowScaleFactor;
		if (Mathf.Abs(shadowPosition.x) > tableDistFromCenterX || Mathf.Abs(shadowPosition.z) > tableDistFromCenterZ)
			scaleAmount = 0f;
		Vector3 scale = ThisObject.transform.localScale;
		scale.x = scaleAmount;
		scale.z = scaleAmount;
		ThisObject.transform.localScale = scale;
	}

	public void Main()
	{
	}
}
