using System;
using UnityEngine;

[Serializable]
[AddComponentMenu("Camera-Control/Smooth Look At")]
public class ReplayCameraScript : MonoBehaviour
{
	public Transform target;

	public float damping = 2f;

	public bool smooth = true;

	public static GameObject replayCamGameObject;

	public void LateUpdate()
	{
		if (!target)
		{
			return;
		}

		if (!smooth)
		{
			transform.LookAt(target);
		}
		else
		{
			Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * damping);
		}
	}

	public void Start()
	{
		replayCamGameObject = gameObject;
		if (rigidbody)
		{
			rigidbody.freezeRotation = true;
		}
	}

	public void Main()
	{
	}
}
