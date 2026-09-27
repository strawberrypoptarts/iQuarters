using System;
using UnityEngine;

[Serializable]
public class InGameAngleIcon : MonoBehaviour
{
	public bool enableButtonView;

	public GUISkin dummySkin;

	public GUISkin UISkin;

	public bool DoneButtonEnabled = true;

	public static bool triggerScaleReminder;

	public static bool triggerReminder;

	public static bool triggerOffScreen;

	public static bool triggerOnScreen;

	private GameObject angleIconRootObject;

	private int stateOffScreen = 100;

	private int stateSlidingOn = 101;

	private int stateOnScreen = 102;

	private int stateSlidingOff = 103;

	private int state = 100;

	private float angleIconOffScreenX;

	private float angleIconOffScreenX_iPhone = 35f;

	private float angleIconOffScreenX_iPad = 60f;

	private float angleIconOnScreenDeltaX = 35f;

	private float angleIconSlidingTimer;

	private float angleIconSlideTime = 0.3f;

	private int scaleStateIdle = 200;

	private int scaleStateScalingDown = 201;

	private int scaleStateScalingUp = 202;

	private int scaleState = 200;

	private Vector3 angleIconStartScale;

	private Vector3 angleIconEndScale;

	private float angleIconEndScalePercent = 0.99f;

	private float angleIconScalingTimer;

	private Vector3 angleIconDeltaScale;

	private float angleIconScaleTime = 0.05f;

	private Mesh deg_01_mesh;

	private Vector3[] deg_01_verts;

	private Vector2[] deg_01_uv;

	private int[] deg_01_tris;

	private Mesh deg_02_mesh;

	private Vector3[] deg_02_verts;

	private Vector2[] deg_02_uv;

	private int[] deg_02_tris;

	public void Start()
	{
		angleIconRootObject = GameObject.Find("/ui_ingame_angle_root");
		angleIconOnScreenDeltaX = GameManagerScript.is_iPad() ? 30f : 35f;
		if (GameManagerScript.is_iPad())
		{
			transform.localScale = GameManagerScript.iPadUIScale;
			Vector3 position = transform.localPosition;
			position.x = -GameManagerScript.iPadUIPosition.x;
			position.y = GameManagerScript.iPadUIPosition.y;
			position.z = GameManagerScript.iPadUIPosition.z;
			transform.localPosition = position;
		}
		angleIconOffScreenX = angleIconRootObject.transform.localPosition.x;
		angleIconStartScale = angleIconRootObject.transform.localScale;
		angleIconEndScale = angleIconStartScale * angleIconEndScalePercent;
		angleIconDeltaScale = angleIconStartScale - angleIconEndScale;
		triggerScaleReminder = triggerReminder = triggerOffScreen = triggerOnScreen = false;
		state = stateOffScreen;
		scaleState = scaleStateIdle;

		GameObject firstDigit = GameObject.Find("/ui_ingame_angle_root/UI_ingame_angle/button_angle/deg_01");
		deg_01_mesh = ((MeshFilter)firstDigit.GetComponent(typeof(MeshFilter))).mesh;
		deg_01_verts = (Vector3[])deg_01_mesh.vertices.Clone();
		deg_01_uv = (Vector2[])deg_01_mesh.uv.Clone();
		deg_01_tris = (int[])deg_01_mesh.triangles.Clone();
		GameObject secondDigit = GameObject.Find("/ui_ingame_angle_root/UI_ingame_angle/button_angle/deg_02");
		deg_02_mesh = ((MeshFilter)secondDigit.GetComponent(typeof(MeshFilter))).mesh;
		deg_02_verts = (Vector3[])deg_02_mesh.vertices.Clone();
		deg_02_uv = (Vector2[])deg_02_mesh.uv.Clone();
		deg_02_tris = (int[])deg_02_mesh.triangles.Clone();
	}

	public void Update()
	{
		if (triggerScaleReminder || triggerReminder)
		{
			triggerScaleReminder = triggerReminder = false;
		}
		if (triggerOffScreen)
		{
			angleIconSlidingTimer = Time.time;
			state = stateSlidingOff;
			triggerOffScreen = false;
		}
		if (triggerOnScreen)
		{
			HandleTextures((int)GameManagerScript.shotAngle);
			angleIconSlidingTimer = Time.time;
			state = stateSlidingOn;
			triggerOnScreen = false;
		}

		if (state == stateSlidingOn || state == stateSlidingOff)
		{
			Vector3 position = angleIconRootObject.transform.localPosition;
			float direction = state == stateSlidingOn ? 1f : -1f;
			position.x += direction * (Time.time - angleIconSlidingTimer) * angleIconOnScreenDeltaX / angleIconSlideTime;
			angleIconSlidingTimer = Time.time;
			float target = state == stateSlidingOn ? angleIconOffScreenX + angleIconOnScreenDeltaX : angleIconOffScreenX;
			if ((direction > 0f && position.x >= target) || (direction < 0f && position.x <= target))
			{
				position.x = target;
				state = state == stateSlidingOn ? stateOnScreen : stateOffScreen;
			}
			angleIconRootObject.transform.localPosition = position;
		}
		if (QuarterTrigger.state == QuarterTrigger.stateAngleInput) DisplayDoneButton(true);

		if (scaleState == scaleStateScalingDown || scaleState == scaleStateScalingUp)
		{
			DisplayDoneButton(false);
			float direction = scaleState == scaleStateScalingDown ? -1f : 1f;
			angleIconRootObject.transform.localScale += direction * angleIconDeltaScale * ((Time.time - angleIconScalingTimer) / angleIconScaleTime);
			angleIconScalingTimer = Time.time;
			if (scaleState == scaleStateScalingDown && angleIconRootObject.transform.localScale.x <= angleIconEndScale.x)
			{
				angleIconRootObject.transform.localScale = angleIconEndScale;
				scaleState = scaleStateScalingUp;
			}
			else if (scaleState == scaleStateScalingUp && angleIconRootObject.transform.localScale.x >= angleIconStartScale.x)
			{
				angleIconRootObject.transform.localScale = angleIconStartScale;
				scaleState = scaleStateIdle;
			}
		}
	}

	public void DisplayDoneButton(bool flag)
	{
		if (!DoneButtonEnabled) return;
		GameObject doneButton = GameObject.Find("/ui_ingame_angle_root/UI_ingame_angle/button_done2");
		if (doneButton) doneButton.renderer.enabled = flag;
	}

	public void OnGUI()
	{
		Rect angleButton = new Rect(64f, 208f, 128f, 96f);
		Rect doneButton = new Rect(288f, 208f, 128f, 96f);
		if (GameManagerScript.is_iPad())
		{
			angleButton = GameManagerScript.GetiPadRect(angleButton);
			doneButton = GameManagerScript.GetiPadRect(doneButton);
		}
		if (!enableButtonView) GUI.skin = dummySkin;
		if (QuarterTrigger.state == QuarterTrigger.stateWaitForShot && GUI.Button(angleButton, string.Empty))
		{
			DisplayDoneButton(true);
			angleIconScalingTimer = Time.time;
			scaleState = scaleStateScalingDown;
			CoinHolder.triggerCoinHolderOut = GameManagerScript.curMadeShotsThisRound;
			AnnouncerScript.triggerClickSound = true;
			QuarterTrigger.requestAngleInput = true;
			return;
		}
		if (QuarterTrigger.state != QuarterTrigger.stateAngleInput) return;
		HandleTextures((int)GameManagerScript.shotAngle);
		bool done = GUI.Button(angleButton, string.Empty);
		if (DoneButtonEnabled) done |= GUI.Button(doneButton, string.Empty);
		if (done)
		{
			DisplayDoneButton(false);
			angleIconScalingTimer = Time.time;
			scaleState = scaleStateScalingDown;
			CoinHolder.triggerCoinHolderIn = GameManagerScript.curMadeShotsThisRound;
			AnnouncerScript.triggerClickSound = true;
			QuarterTrigger.state = QuarterTrigger.stateWaitForShot;
		}
	}

	public void HandleTextures(int number)
	{
		if (number < 10 || number > 99)
		{
			Debug.Log("Round Score is out of range!");
			number = Mathf.Clamp(number, 10, 99);
		}
		CoinHolder.DisplayDigit(deg_01_mesh, deg_01_verts, deg_01_uv, deg_01_tris, number / 10);
		CoinHolder.DisplayDigit(deg_02_mesh, deg_02_verts, deg_02_uv, deg_02_tris, number % 10);
	}

	public void Main()
	{
	}
}
