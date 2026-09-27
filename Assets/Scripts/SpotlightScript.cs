using System;
using UnityEngine;

[Serializable]
public class SpotlightScript : MonoBehaviour
{
	public Transform target;

	public float damping = 2f;

	public bool smooth;

	public void LateUpdate()
	{
		if (target == null)
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
	}

	public void Main()
	{
	}
}
