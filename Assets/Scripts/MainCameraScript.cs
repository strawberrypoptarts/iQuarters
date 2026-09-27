using System;
using UnityEngine;

[Serializable]
public class MainCameraScript : MonoBehaviour
{
	public Transform target;

	public float damping = 2f;

	public bool smooth = true;

	public float yOffset;

	public Vector3 deltaV;

	private float currentT;

	private Vector3 startPosition;

	public void Start()
	{
		startPosition = transform.position;
		if (GameManagerScript.is_iPad() && Camera.main)
			Camera.main.fieldOfView = 70f;
	}

	public void LateUpdate()
	{
		if (!target) return;
		float targetT = (GameManagerScript.shotAngle - GameManagerScript.defaultShotAngle)
			/ (QuarterTrigger.maxShotAngle - GameManagerScript.defaultShotAngle);
		currentT += (targetT - currentT) * 0.2f;
		deltaV.x = 0f;
		deltaV.y = Mathf.Lerp(-0.007f, 0.007f, currentT);
		deltaV.z = Mathf.Lerp(-0.05f, 0.05f, currentT);
		transform.position = startPosition + deltaV;
		if (!smooth)
		{
			transform.LookAt(target);
			return;
		}
		Vector3 direction = target.position - transform.position;
		direction.y = Mathf.Max(direction.y + yOffset, -5f);
		Quaternion rotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	public void Main()
	{
	}
}
