using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class CameraRelativeControl : MonoBehaviour
{
	public Joystick moveJoystick;

	public Joystick rotateJoystick;

	public Transform cameraPivot;

	public Transform cameraTransform;

	public float speed = 5f;

	public float jumpSpeed = 8f;

	public float inAirMultiplier = 0.25f;

	public Vector2 rotationSpeed = new Vector2(50f, 25f);

	private Transform thisTransform;

	private CharacterController character;

	private Vector3 velocity;

	private bool canJump = true;

	public void Start()
	{
		thisTransform = (Transform)GetComponent(typeof(Transform));
		character = (CharacterController)GetComponent(typeof(CharacterController));
		GameObject spawn = GameObject.Find("PlayerSpawn");
		if (spawn) thisTransform.position = spawn.transform.position;
	}

	public void FaceMovementDirection()
	{
		Vector3 horizontalVelocity = character.velocity;
		horizontalVelocity.y = 0f;
		if (horizontalVelocity.magnitude > 0.1f)
			thisTransform.forward = horizontalVelocity.normalized;
	}

	public void OnEndGame()
	{
		moveJoystick.Disable();
		rotateJoystick.Disable();
		enabled = false;
	}

	public void Update()
	{
		Vector3 movement = cameraTransform.TransformDirection(new Vector3(moveJoystick.position.x, 0f, moveJoystick.position.y));
		movement.y = 0f;
		movement.Normalize();
		Vector2 absolute = new Vector2(Mathf.Abs(moveJoystick.position.x), Mathf.Abs(moveJoystick.position.y));
		movement *= speed * Mathf.Max(absolute.x, absolute.y);
		if (character.isGrounded)
		{
			if (!rotateJoystick.IsFingerDown()) canJump = true;
			if (canJump && rotateJoystick.tapCount == 2)
			{
				velocity = character.velocity;
				velocity.y = jumpSpeed;
				canJump = false;
			}
		}
		else
		{
			velocity.y += Physics.gravity.y * Time.deltaTime;
			movement.x *= inAirMultiplier;
			movement.z *= inAirMultiplier;
		}
		movement += velocity;
		movement += Physics.gravity;
		character.Move(movement * Time.deltaTime);
		if (character.isGrounded) velocity = Vector3.zero;
		FaceMovementDirection();
		Vector2 rotation = rotateJoystick.position;
		rotation.x *= rotationSpeed.x;
		rotation.y *= rotationSpeed.y;
		rotation *= Time.deltaTime;
		cameraPivot.Rotate(0f, rotation.x, 0f, Space.World);
		cameraPivot.Rotate(rotation.y, 0f, 0f);
	}

	public void Main()
	{
	}
}
