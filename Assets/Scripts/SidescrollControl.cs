using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class SidescrollControl : MonoBehaviour
{
	public Joystick moveTouchPad;

	public Joystick jumpTouchPad;

	public float forwardSpeed = 4f;

	public float backwardSpeed = 1f;

	public float jumpSpeed = 8f;

	public float inAirMultiplier = 0.25f;

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

	public void OnEndGame()
	{
		moveTouchPad.Disable();
		jumpTouchPad.Disable();
		enabled = false;
	}

	public void Update()
	{
		Vector3 movement = Vector3.zero;
		movement.z = moveTouchPad.position.x * (moveTouchPad.position.x > 0f ? forwardSpeed : backwardSpeed);
		if (character.isGrounded)
		{
			if (!jumpTouchPad.IsFingerDown()) canJump = true;
			if (canJump && jumpTouchPad.IsFingerDown())
			{
				velocity = character.velocity;
				velocity.y = jumpSpeed;
				canJump = false;
			}
		}
		else
		{
			velocity.y += Physics.gravity.y * Time.deltaTime;
			movement.z *= inAirMultiplier;
		}
		movement += velocity;
		movement += Physics.gravity;
		character.Move(movement * Time.deltaTime);
		if (character.isGrounded) velocity = Vector3.zero;
	}

	public void Main()
	{
	}
}
