using System;
using UnityEngine;

[Serializable]
public class LighterScript : MonoBehaviour
{
	public Rigidbody curBody;

	public float contNorm;

	public float xVel = 2.5f;

	public float yVel = 14f;

	public float zVel = 2.5f;

	public GameObject hingeObject;

	private int stateIdle = 100;

	private int stateTriggered = 101;

	private int state;

	public void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			contNorm = contact.normal.y;
			if (contact.normal.y >= -0.707f) continue;
			curBody = contact.otherCollider.attachedRigidbody;
			curBody.velocity = new Vector3(xVel, yVel, zVel);
			animation.Play();
			if (audio && !QuarterTrigger.muteF) audio.Play();
			QuarterTrigger.shotTime += 2f;
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
