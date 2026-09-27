using System;
using UnityEngine;

[Serializable]
public class TapControl : MonoBehaviour
{
	public GameObject cameraObject;

	public Transform cameraPivot;

	public GUITexture jumpButton;

	public float speed;

	public float jumpSpeed;

	public float inAirMultiplier = 0.25f;

	public float minimumDistanceToMove = 1f;

	public float minimumTimeUntilMove = 0.25f;

	public bool zoomEnabled;

	public float zoomEpsilon;

	public float zoomRate;

	public bool rotateEnabled;

	public float rotateEpsilon = 1f;

	private ZoomCamera zoomCamera;

	private Camera cam;

	private Transform thisTransform;

	private CharacterController character;

	private Vector3 targetLocation;

	private bool moving;

	private float rotationTarget;

	private float rotationVelocity;

	private Vector3 velocity;

	private ControlState state;

	private int[] fingerDown = new int[2];

	private Vector2[] fingerDownPosition = new Vector2[2];

	private int[] fingerDownFrame = new int[2];

	private float firstTouchTime;

	public void Start()
	{
		thisTransform = transform;
		zoomCamera = (ZoomCamera)cameraObject.GetComponent(typeof(ZoomCamera));
		cam = cameraObject.camera;
		character = (CharacterController)GetComponent(typeof(CharacterController));
		ResetControlState();
		GameObject spawn = GameObject.Find("PlayerSpawn");
		if (spawn) thisTransform.position = spawn.transform.position;
	}

	public void OnEndGame()
	{
		enabled = false;
	}

	public void FaceMovementDirection()
	{
		Vector3 direction = character.velocity;
		direction.y = 0f;
		if (direction.magnitude > 0.1f) thisTransform.forward = direction.normalized;
	}

	public void CameraControl(iPhoneTouch touch0, iPhoneTouch touch1)
	{
		Vector2 old0 = touch0.position - touch0.deltaPosition;
		Vector2 old1 = touch1.position - touch1.deltaPosition;
		if (rotateEnabled && state == ControlState.RotatingCamera)
		{
			Vector2 previous = (old1 - old0).normalized;
			Vector2 current = (touch1.position - touch0.position).normalized;
			float dot = Vector2.Dot(previous, current);
			if (dot < 1f)
			{
				float sign = Mathf.Sign(Vector3.Cross(new Vector3(previous.x, 0f, previous.y), new Vector3(current.x, 0f, current.y)).y);
				rotationTarget += Mathf.Acos(dot) * Mathf.Rad2Deg * sign;
				if (rotationTarget < 0f) rotationTarget += 360f;
				else if (rotationTarget >= 360f) rotationTarget -= 360f;
			}
		}
		else if (zoomEnabled && state == ControlState.ZoomingCamera)
		{
			float oldDistance = (old1 - old0).magnitude;
			float newDistance = (touch1.position - touch0.position).magnitude;
			zoomCamera.zoom += (oldDistance - newDistance) * zoomRate * Time.deltaTime;
		}
	}

	public void CharacterControl()
	{
		if (iPhoneInput.touchCount == 1 && state == ControlState.MovingCharacter)
		{
			iPhoneTouch touch = iPhoneInput.GetTouch(0);
			if (character.isGrounded && jumpButton && jumpButton.HitTest(touch.position))
			{
				velocity = character.velocity;
				velocity.y = jumpSpeed;
			}
			else if ((!jumpButton || !jumpButton.HitTest(touch.position)) && touch.tapCount != 0)
			{
				Ray ray = cam.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0f));
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					if ((hit.point - transform.position).magnitude > minimumDistanceToMove) targetLocation = hit.point;
					moving = true;
				}
			}
		}
		Vector3 movement = Vector3.zero;
		if (moving)
		{
			movement = targetLocation - transform.position;
			movement.y = 0f;
			if (movement.magnitude < 1f) moving = false;
			else movement = movement.normalized * speed;
		}
		if (!character.isGrounded)
		{
			velocity.y += Physics.gravity.y * Time.deltaTime;
			movement *= inAirMultiplier;
		}
		character.Move((movement + velocity + Physics.gravity) * Time.deltaTime);
		if (character.isGrounded) velocity = Vector3.zero;
		FaceMovementDirection();
	}

	public void ResetControlState()
	{
		state = ControlState.WaitingForFirstTouch;
		fingerDown[0] = fingerDown[1] = -1;
	}

	public void Update()
	{
		int touchCount = iPhoneInput.touchCount;
		if (touchCount == 0)
		{
			ResetControlState();
		}
		else
		{
			iPhoneTouch[] touches = iPhoneInput.touches;
			if (state == ControlState.WaitingForFirstTouch)
			{
				for (int i = 0; i < touches.Length; i++)
				{
					if (touches[i].phase == iPhoneTouchPhase.Ended || touches[i].phase == iPhoneTouchPhase.Canceled) continue;
					state = ControlState.WaitingForSecondTouch;
					firstTouchTime = Time.time;
					fingerDown[0] = touches[i].fingerId;
					fingerDownPosition[0] = touches[i].position;
					fingerDownFrame[0] = Time.frameCount;
					break;
				}
			}
			if (state == ControlState.WaitingForSecondTouch)
			{
				for (int i = 0; i < touches.Length; i++)
				{
					if (touches[i].phase == iPhoneTouchPhase.Canceled) continue;
					if (touchCount > 1 && touches[i].fingerId != fingerDown[0])
					{
						state = ControlState.WaitingForMovement;
						fingerDown[1] = touches[i].fingerId;
						fingerDownPosition[1] = touches[i].position;
						fingerDownFrame[1] = Time.frameCount;
						break;
					}
					if (touchCount == 1 && touches[i].fingerId == fingerDown[0] &&
						(Time.time > firstTouchTime + minimumTimeUntilMove || touches[i].phase == iPhoneTouchPhase.Ended))
					{
						state = ControlState.MovingCharacter;
						break;
					}
				}
			}
			if (state == ControlState.WaitingForMovement && touchCount >= 2)
			{
				iPhoneTouch touch0 = touches[0];
				iPhoneTouch touch1 = touches[1];
				Vector2 oldVector = fingerDownPosition[1] - fingerDownPosition[0];
				Vector2 newVector = touch1.position - touch0.position;
				float angle = Vector2.Angle(oldVector, newVector);
				if (rotateEnabled && angle > rotateEpsilon) state = ControlState.RotatingCamera;
				else if (zoomEnabled && Mathf.Abs(oldVector.magnitude - newVector.magnitude) > zoomEpsilon) state = ControlState.ZoomingCamera;
			}
			if ((state == ControlState.RotatingCamera || state == ControlState.ZoomingCamera) && touchCount >= 2)
			{
				CameraControl(touches[0], touches[1]);
			}
		}
		CharacterControl();
	}

	public void LateUpdate()
	{
		Vector3 angles = cameraPivot.eulerAngles;
		angles.y = Mathf.SmoothDampAngle(angles.y, rotationTarget, ref rotationVelocity, 0.3f);
		cameraPivot.eulerAngles = angles;
	}

	public void Main()
	{
	}
}
