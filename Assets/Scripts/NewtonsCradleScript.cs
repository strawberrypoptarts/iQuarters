using System;
using UnityEngine;

[Serializable]
public class NewtonsCradleScript : MonoBehaviour
{
	public Rigidbody curBody;

	public float xVel = -2.5f;

	public float yVel = 14f;

	public float zVel = 2.5f;

	public float time;

	public float speed;

	public float normalizedSpeed;

	public int lastTriggered = -1;

	public int restartAnim = -1;

	public float animSpeedScale = 1f;

	public void Start()
	{
		foreach (AnimationState animationState in animation)
			animationState.speed *= animSpeedScale;
	}

	public void FixedUpdate()
	{
		if (QuarterTrigger.birdAnimState == 1)
		{
			foreach (AnimationState animationState in animation)
			{
				time = animationState.time;
				speed = animationState.speed;
				normalizedSpeed = animationState.normalizedSpeed;
			}
		}
		else if (QuarterTrigger.birdAnimState == 2)
		{
			foreach (AnimationState animationState in animation)
			{
				animationState.time = time;
				animationState.speed = speed;
				animationState.normalizedSpeed = normalizedSpeed;
			}
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			if (contact.normal.y >= -0.707f)
			{
				continue;
			}

			curBody = contact.otherCollider.attachedRigidbody;
			Vector3 velocity = curBody.velocity;
			velocity.x = xVel;
			velocity.y = yVel;
			velocity.z = zVel;
			curBody.velocity = velocity;
			animation.Play();
			QuarterTrigger.shotTime += 2f;
			return;
		}
	}

	public void Main()
	{
	}
}
