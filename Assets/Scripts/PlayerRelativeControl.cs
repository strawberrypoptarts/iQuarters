using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class PlayerRelativeControl : MonoBehaviour
{
	public Joystick moveJoystick;

	public Joystick rotateJoystick;

	public Transform cameraPivot;

	public float forwardSpeed = 4f;

	public float backwardSpeed = 1f;

	public float sidestepSpeed = 1f;

	public float jumpSpeed = 8f;

	public float inAirMultiplier = 0.25f;

	public Vector2 rotationSpeed = new Vector2(50f, 25f);

	private Transform thisTransform;

	private CharacterController character;

	private Vector3 cameraVelocity;

	private Vector3 velocity;

	public void Start()
	{
		thisTransform = (Transform)GetComponent(typeof(Transform));
		character = (CharacterController)GetComponent(typeof(CharacterController));
		GameObject spawn = GameObject.Find("PlayerSpawn");
		if (spawn) thisTransform.position = spawn.transform.position;
	}

	public void OnEndGame()
	{
		moveJoystick.Disable();
		rotateJoystick.Disable();
		enabled = false;
	}

	public void Update()
	{
		Vector3 movement = thisTransform.TransformDirection(new Vector3(moveJoystick.position.x, 0f, moveJoystick.position.y));
		movement.y = 0f;
		movement.Normalize();
		Vector3 cameraTarget = Vector3.zero;
		Vector2 absolute = new Vector2(Mathf.Abs(moveJoystick.position.x), Mathf.Abs(moveJoystick.position.y));
		if (absolute.y > absolute.x)
		{
			if (moveJoystick.position.y > 0f) movement *= forwardSpeed * absolute.y;
			else
			{
				movement *= backwardSpeed * absolute.y;
				cameraTarget.z = moveJoystick.position.y * 0.75f;
			}
		}
		else
		{
			movement *= sidestepSpeed * absolute.x;
			cameraTarget.x = -moveJoystick.position.x * 0.5f;
		}
		if (character.isGrounded)
		{
			if (rotateJoystick.tapCount == 2)
			{
				velocity = character.velocity;
				velocity.y = jumpSpeed;
			}
		}
		else
		{
			velocity.y += Physics.gravity.y * Time.deltaTime;
			cameraTarget.z = -jumpSpeed * 0.25f;
			movement.x *= inAirMultiplier;
			movement.z *= inAirMultiplier;
		}
		movement += velocity;
		movement += Physics.gravity;
		character.Move(movement * Time.deltaTime);
		if (character.isGrounded) velocity = Vector3.zero;
		Vector3 position = cameraPivot.localPosition;
		float velocityX = cameraVelocity.x;
		float velocityZ = cameraVelocity.z;
		position.x = Mathf.SmoothDamp(position.x, cameraTarget.x, ref velocityX, 0.3f);
		position.z = Mathf.SmoothDamp(position.z, cameraTarget.z, ref velocityZ, 0.5f);
		cameraVelocity.x = velocityX;
		cameraVelocity.z = velocityZ;
		cameraPivot.localPosition = position;
		if (character.isGrounded)
		{
			Vector2 rotation = rotateJoystick.position;
			rotation.x *= rotationSpeed.x;
			rotation.y *= rotationSpeed.y;
			rotation *= Time.deltaTime;
			thisTransform.Rotate(0f, rotation.x, 0f, Space.World);
			cameraPivot.Rotate(rotation.y, 0f, 0f);
		}
	}

	public void Main()
	{
	}
}
