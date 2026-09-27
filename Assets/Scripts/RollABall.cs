using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Rigidbody))]
public class RollABall : MonoBehaviour
{
	public Vector3 tilt;

	public float speed;

	private float circ;

	private Vector3 previousPosition;

	public void Start()
	{
		circ = Mathf.PI * 2f * collider.bounds.extents.x;
		previousPosition = transform.position;
	}

	public void Update()
	{
		Vector3 acceleration = iPhoneInput.acceleration;
		tilt.x = -acceleration.y;
		tilt.z = acceleration.x;
		rigidbody.AddForce(tilt * speed * Time.deltaTime);
	}

	public void LateUpdate()
	{
		Vector3 movement = transform.position - previousPosition;
		if (circ != 0f && movement.sqrMagnitude > 0f)
		{
			Vector3 axis = new Vector3(-movement.z, 0f, movement.x);
			transform.Rotate(axis, movement.magnitude / circ * 360f, Space.World);
		}
		previousPosition = transform.position;
	}

	public void Main()
	{
	}
}
