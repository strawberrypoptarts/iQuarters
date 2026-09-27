using System;
using UnityEngine;

[Serializable]
public class SmoothFollow2D : MonoBehaviour
{
	public Transform target;

	public float smoothTime = 0.3f;

	private Transform thisTransform;

	private Vector2 velocity;

	public void Start()
	{
		thisTransform = transform;
	}

	public void Update()
	{
		Vector3 position = thisTransform.position;
		Vector3 targetPosition = target.position;
		float velocityX = velocity.x;
		position.x = Mathf.SmoothDamp(position.x, targetPosition.x, ref velocityX, smoothTime);
		velocity.x = velocityX;
		thisTransform.position = position;

		position = thisTransform.position;
		targetPosition = target.position;
		float velocityY = velocity.y;
		position.y = Mathf.SmoothDamp(position.y, targetPosition.y, ref velocityY, smoothTime);
		velocity.y = velocityY;
		thisTransform.position = position;
	}

	public void Main()
	{
	}
}
