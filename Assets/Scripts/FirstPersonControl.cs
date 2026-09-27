using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class FirstPersonControl : MonoBehaviour
{
	public Joystick moveTouchPad;

	public Joystick rotateTouchPad;

	public Transform cameraPivot;

	public float forwardSpeed = 4f;

	public float backwardSpeed = 1f;

	public float sidestepSpeed = 1f;

	public float jumpSpeed = 8f;

	public float inAirMultiplier = 0.25f;

	public Vector2 rotationSpeed = new Vector2(50f, 25f);

	public float tiltPositiveYAxis = 0.6f;

	public float tiltNegativeYAxis = 0.4f;

	public float tiltXAxisMinimum = 0.1f;

	private Transform thisTransform;

	private CharacterController character;

	private Vector3 cameraVelocity;

	private Vector3 velocity;

	private bool canJump = true;

	public void Start()
	{
		thisTransform = (Transform)GetComponent(typeof(Transform));
		character = (CharacterController)GetComponent(typeof(CharacterController));
		GameObject spawn = GameObject.Find("PlayerSpawn");
		if (spawn) thisTransform.position = spawn.transform.position;
	}

	public void OnEndGame()
	{
		moveTouchPad.Disable();
		if (rotateTouchPad) rotateTouchPad.Disable();
		enabled = false;
	}

	public void Update()
	{
		Vector3 movement = thisTransform.TransformDirection(new Vector3(moveTouchPad.position.x, 0f, moveTouchPad.position.y));
		movement.y = 0f;
		movement.Normalize();
		Vector2 absolute = new Vector2(Mathf.Abs(moveTouchPad.position.x), Mathf.Abs(moveTouchPad.position.y));
		if (absolute.y > absolute.x)
			movement *= (moveTouchPad.position.y > 0f ? forwardSpeed : backwardSpeed) * absolute.y;
		else
			movement *= sidestepSpeed * absolute.x;

		Joystick jumpPad = rotateTouchPad ? rotateTouchPad : moveTouchPad;
		if (character.isGrounded)
		{
			if (!jumpPad.IsFingerDown()) canJump = true;
			if (canJump && jumpPad.tapCount == 2)
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

		Vector2 rotation = Vector2.zero;
		if (rotateTouchPad)
			rotation = rotateTouchPad.position;
		else
		{
			Vector3 acceleration = Input.acceleration;
			float absoluteTiltX = Mathf.Abs(acceleration.x);
			if (acceleration.z < 0f && acceleration.x < 0f)
			{
				if (absoluteTiltX >= tiltPositiveYAxis)
					rotation.y = (absoluteTiltX - tiltPositiveYAxis) / (1f - tiltPositiveYAxis);
				else if (absoluteTiltX <= tiltNegativeYAxis)
					rotation.y = -(tiltNegativeYAxis - absoluteTiltX) / tiltNegativeYAxis;
			}
			if (Mathf.Abs(acceleration.y) >= tiltXAxisMinimum)
				rotation.x = -(acceleration.y - tiltXAxisMinimum) / (1f - tiltXAxisMinimum);
		}
		rotation.x *= rotationSpeed.x;
		rotation.y *= rotationSpeed.y;
		rotation *= Time.deltaTime;
		thisTransform.Rotate(0f, rotation.x, 0f, Space.World);
		cameraPivot.Rotate(-rotation.y, 0f, 0f);
	}

	public void Main()
	{
	}
}
