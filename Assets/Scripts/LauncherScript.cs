using System;
using UnityEngine;

[Serializable]
public class LauncherScript : MonoBehaviour
{
	private Rigidbody curBody;

	public float xVel = -2.5f;

	public float yVel = 14f;

	public float zVel = 2.5f;

	public GameObject hingeObject;

	public float contactAngle = 0.707f;

	public float shotTimeAdd = 2f;

	private int stateIdle = 100;

	private int stateTriggered = 101;

	private int state;

	public void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			if (contact.normal.y >= -contactAngle) continue;
			curBody = contact.otherCollider.attachedRigidbody;
			curBody.velocity = new Vector3(xVel, yVel, zVel);
			animation.Play();
			if (audio && !QuarterTrigger.muteF) audio.Play();
			QuarterTrigger.shotTime += shotTimeAdd;
			state = stateTriggered;
			return;
		}
	}

	public void Start()
	{
		state = stateIdle;
	}

	public void Update()
	{
		if (state == stateTriggered && !animation.isPlaying)
		{
			if (hingeObject) hingeObject.transform.localEulerAngles = Vector3.zero;
			state = stateIdle;
		}
	}

	public void Main()
	{
	}
}
