using System;
using UnityEngine;

[Serializable]
public class ChipRackupScript : MonoBehaviour
{
	public GameObject thisObject;

	public GameObject sourceObject;

	public float endPositionX;

	public float endPositionY;

	public GameObject chipText;

	public GUIText chipTextGUI;

	public float chipSpeed = 1f;

	private float startTime;

	private float tParam;

	private float startScaleX = -1f;

	private float startScaleY = -1f;

	private float endScaleX;

	private float endScaleY;

	public static int crStateNone = 100;

	public static int crStateMotionInit = 101;

	public static int crStateMotion = 102;

	public static int curState = crStateNone;

	public static string chipScoreText = string.Empty;

	public void MoveChipInit()
	{
		Vector3 scale = transform.localScale;
		scale.x = startScaleX; scale.y = startScaleY;
		transform.localScale = scale;
		Vector3 position = transform.position;
		position.x = sourceObject.transform.position.x;
		position.y = sourceObject.transform.position.y;
		transform.position = position;
		startTime = Time.time;
		curState = crStateMotion;
	}

	public void MoveChip()
	{
		Vector3 position = transform.position;
		position.x = Mathf.Lerp(sourceObject.transform.position.x, endPositionX, tParam);
		position.y = Mathf.Lerp(sourceObject.transform.position.y, endPositionY, tParam);
		transform.position = position;
		Vector3 scale = transform.localScale;
		scale.x = Mathf.Lerp(startScaleX, endScaleX, tParam);
		scale.y = Mathf.Lerp(startScaleY, endScaleY, tParam);
		transform.localScale = scale;
		tParam = (Time.time - startTime) * chipSpeed;
		if (tParam <= 1f) return;
		tParam = 1f;
		position.x = endPositionX; position.y = endPositionY; transform.position = position;
		scale.x = endScaleX; scale.y = endScaleY; transform.localScale = scale;
		if (!QuarterTrigger.muteF) audio.Play();
		chipTextGUI.text = chipScoreText;
		Vector3 textPosition = chipText.transform.position;
		textPosition.x = endPositionX; textPosition.y = endPositionY;
		chipText.transform.position = textPosition;
		chipText.SetActiveRecursively(true);
		curState = crStateNone;
		tParam = 0f;
	}

	public void Update()
	{
		if (curState == crStateMotionInit) MoveChipInit();
		else if (curState == crStateMotion) MoveChip();
	}

	public void ResetVariables()
	{
		curState = crStateNone;
		tParam = 0f;
	}

	public void Start()
	{
		thisObject.SetActiveRecursively(false);
	}

	public static void TriggerRackup()
	{
		curState = crStateMotionInit;
	}

	public static void SetRicochetScore(int score)
	{
		chipScoreText = score >= 1 && score <= 8 ? (score * 10).ToString() : "90";
	}

	public void Main()
	{
	}
}
