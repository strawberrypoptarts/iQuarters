using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(GUITexture))]
public class Joystick : MonoBehaviour
{
	private static Joystick[] joysticks;

	private static bool enumeratedJoysticks;

	private static float tapTimeDelta = 0.3f;

	public bool touchPad;

	public Rect touchZone;

	public Vector2 deadZone;

	public bool normalize;

	public Vector2 position;

	public int tapCount;

	private int lastFingerId = -1;

	private float tapTimeWindow;

	private Vector2 fingerDownPos;

	private float fingerDownTime;

	private float firstDeltaTime = 0.5f;

	private GUITexture gui;

	private Rect defaultRect;

	private Boundary guiBoundary = new Boundary();

	private Vector2 guiTouchOffset;

	private Vector2 guiCenter;

	public void Start()
	{
		gui = (GUITexture)GetComponent(typeof(GUITexture));
		defaultRect = gui.pixelInset;
		if (touchPad)
		{
			if (gui.texture) touchZone = defaultRect;
		}
		else
		{
			guiTouchOffset = new Vector2(defaultRect.width * 0.5f, defaultRect.height * 0.5f);
			guiCenter = new Vector2(defaultRect.x + guiTouchOffset.x, defaultRect.y + guiTouchOffset.y);
			guiBoundary.min = new Vector2(defaultRect.x - guiTouchOffset.x, defaultRect.y - guiTouchOffset.y);
			guiBoundary.max = new Vector2(defaultRect.x + guiTouchOffset.x, defaultRect.y + guiTouchOffset.y);
		}
	}

	public void Disable()
	{
		gameObject.active = false;
		enumeratedJoysticks = false;
	}

	public void ResetJoystick()
	{
		gui.pixelInset = defaultRect;
		lastFingerId = -1;
		position = Vector2.zero;
		fingerDownPos = Vector2.zero;
		if (touchPad)
		{
			Color color = gui.color;
			color.a = 0.025f;
			gui.color = color;
		}
	}

	public bool IsFingerDown()
	{
		return lastFingerId != -1;
	}

	public void LatchedFinger(int fingerId)
	{
		if (lastFingerId == fingerId) ResetJoystick();
	}

	public void Update()
	{
		if (!enumeratedJoysticks)
		{
			joysticks = (Joystick[])FindObjectsOfType(typeof(Joystick));
			enumeratedJoysticks = true;
		}
		if (tapTimeWindow > 0f) tapTimeWindow -= Time.deltaTime;
		else tapCount = 0;
		if (Input.touchCount == 0)
		{
			ResetJoystick();
			return;
		}
		for (int i = 0; i < Input.touchCount; i++)
		{
			iPhoneTouch touch = iPhoneInput.GetTouch(i);
			Vector2 touchPosition = touch.position;
			Vector2 guiTouchPosition = touchPosition - guiTouchOffset;
			bool shouldLatch = touchPad ? touchZone.Contains(touchPosition) : gui.HitTest(touchPosition);
			if (shouldLatch && (lastFingerId == -1 || lastFingerId != touch.fingerId))
			{
				if (touchPad)
				{
					Color color = gui.color; color.a = 0.15f; gui.color = color;
					fingerDownPos = touchPosition;
					fingerDownTime = Time.time;
				}
				lastFingerId = touch.fingerId;
				if (tapTimeWindow > 0f) tapCount++;
				else { tapCount = 1; tapTimeWindow = tapTimeDelta; }
				foreach (Joystick joystick in joysticks)
					if (joystick != this) joystick.LatchedFinger(touch.fingerId);
			}
			if (lastFingerId != touch.fingerId) continue;
			if (touch.tapCount > tapCount) tapCount = touch.tapCount;
			if (touchPad)
			{
				position.x = Mathf.Clamp((touchPosition.x - fingerDownPos.x) / (touchZone.width * 0.5f), -1f, 1f);
				position.y = Mathf.Clamp((touchPosition.y - fingerDownPos.y) / (touchZone.height * 0.5f), -1f, 1f);
			}
			else
			{
				Rect inset = gui.pixelInset;
				inset.x = Mathf.Clamp(guiTouchPosition.x, guiBoundary.min.x, guiBoundary.max.x);
				inset.y = Mathf.Clamp(guiTouchPosition.y, guiBoundary.min.y, guiBoundary.max.y);
				gui.pixelInset = inset;
			}
			if (touch.phase == iPhoneTouchPhase.Ended || touch.phase == iPhoneTouchPhase.Canceled)
				ResetJoystick();
		}
		if (!touchPad)
		{
			Rect inset = gui.pixelInset;
			position.x = (inset.x + guiTouchOffset.x - guiCenter.x) / guiTouchOffset.x;
			position.y = (inset.y + guiTouchOffset.y - guiCenter.y) / guiTouchOffset.y;
		}
		float absoluteX = Mathf.Abs(position.x);
		float absoluteY = Mathf.Abs(position.y);
		if (absoluteX < deadZone.x) position.x = 0f;
		else if (normalize) position.x = Mathf.Sign(position.x) * (absoluteX - deadZone.x) / (1f - deadZone.x);
		if (absoluteY < deadZone.y) position.y = 0f;
		else if (normalize) position.y = Mathf.Sign(position.y) * (absoluteY - deadZone.y) / (1f - deadZone.y);
	}

	public void Main()
	{
	}
}
