using System;
using UnityEngine;

[Serializable]
public class ChipBounceBounceScript : MonoBehaviour
{
	public GameObject thisObject;

	public GameObject targetObject;

	public static GameObject localTargetObject;

	public GameObject quarterObject;

	public Texture textureBounce0;

	public Texture textureBounce1;

	public Texture textureBounce2;

	public Texture textureBounce3;

	public Texture textureBounce4;

	public Texture textureBounce5;

	public Texture textureBounce6;

	public static int cbStateNone = 100;

	public static int cbStateMotionInit = 101;

	public static int cbStateMotion = 102;

	public static int curState = cbStateNone;

	public float startPositionX = 0.5f;

	public float startPositionY = 0.5f;

	public float tParam;

	public float chipSpeed = 1f;

	public static float startTime;

	public Vector3 screenPos;

	private Camera curCam;

	public void MoveChipInit()
	{
		startTime = Time.time;
		startPositionX = startPositionY = 0.5f;
		Camera[] cameras = Camera.allCameras;
		curCam = cameras.Length > 0 ? cameras[0] : null;
		if (curCam)
		{
			screenPos = curCam.WorldToViewportPoint(quarterObject.transform.position);
			startPositionX = screenPos.x; startPositionY = screenPos.y;
		}
		curState = cbStateMotion;
	}

	public void MoveChip()
	{
		Vector3 position = transform.position;
		position.x = Mathf.Lerp(startPositionX, targetObject.transform.position.x, tParam);
		position.y = Mathf.Lerp(startPositionY, targetObject.transform.position.y, tParam);
		transform.position = position;
		tParam = (Time.time - startTime) * chipSpeed;
		if (tParam <= 1f) return;
		position.x = -0.5f; transform.position = position;
		ResetVariables();
		targetObject.SetActiveRecursively(true);
		ChipBounceScript.incrementBouncesFlag = true;
		thisObject.SetActiveRecursively(false);
	}

	public void Update()
	{
		if (curState == cbStateMotionInit) MoveChipInit();
		else if (curState == cbStateMotion) MoveChip();
	}

	public static void TriggerBounceToChipStack()
	{
		if (curState != cbStateNone)
		{
			if (localTargetObject) localTargetObject.SetActiveRecursively(true);
			ChipBounceScript.incrementBouncesFlag = true;
		}
		curState = cbStateMotionInit;
	}

	public void ResetVariables()
	{
		startPositionX = startPositionY = 0.5f;
		curState = cbStateNone;
		tParam = 0f;
	}

	public void Start()
	{
		localTargetObject = targetObject;
		ResetVariables();
		thisObject.SetActiveRecursively(false);
	}

	public void Main()
	{
	}
}
