using System;
using UnityEngine;

[Serializable]
public class CellPhoneScript : MonoBehaviour
{
	public Rigidbody curBody;

	public float xVel = -2.5f;

	public float yVel = 14f;

	public float zVel = 2.5f;

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
			if (audio && !QuarterTrigger.muteF)
			{
				audio.Play();
			}
			QuarterTrigger.shotTime += 2.2f;
			return;
		}
	}

	public void Main()
	{
	}
}
