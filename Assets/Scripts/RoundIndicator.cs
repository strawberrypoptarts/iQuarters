using System;
using UnityEngine;

[Serializable]
public class RoundIndicator : MonoBehaviour
{
	public GameObject roundIndicatorObject;

	public static bool TriggerSlideIn;

	public static bool TriggerSlideOut;

	public static int CurrentRound = 1;

	private GameObject animObject;

	private GameObject markerObject;

	private float markerDefaultPosX;

	private GameObject roundLabelObject;

	private float roundLabelDefaultPosX;

	private GameObject curRoundNumberObject;

	private int maxRoundNumbers = 15;

	private int stateIdle = 100;

	private int stateSlideIn = 101;

	private int stateOnScreen = 102;

	private int stateSlideOut = 103;

	private int state;

	public void Start()
	{
		if (GameManagerScript.is_iPad())
		{
			transform.localScale = GameManagerScript.iPadUIScale;
			Vector3 position = transform.localPosition;
			position.x = -GameManagerScript.iPadUIPosition.x;
			position.y = GameManagerScript.iPadUIPosition.y;
			position.z = GameManagerScript.iPadUIPosition.z;
			transform.localPosition = position;
		}
		animObject = GameObject.Find("/ex_round_mon");
		animObject.animation.playAutomatically = false;
		if (animObject.animation.GetClipCount() == 1)
		{
			animObject.animation.AddClip(animObject.animation.clip, "SlideIn", 0, 12);
			animObject.animation.AddClip(animObject.animation.clip, "SlideOut", 50, 55);
		}
		markerObject = GameObject.Find("/ex_round_mon/round_move_marker");
		markerDefaultPosX = markerObject.transform.position.x;
		roundLabelObject = GameObject.Find("/ex_round_mon/round_graphic");
		roundLabelDefaultPosX = roundLabelObject.transform.position.x;
		roundIndicatorObject.SetActiveRecursively(false);
		state = stateIdle;
	}

	public void UpdateCurRoundNumberPosition()
	{
		curRoundNumberObject.transform.position = markerObject.transform.position;
		Vector3 labelPosition = roundLabelObject.transform.position;
		labelPosition.x = markerObject.transform.position.x;
		roundLabelObject.transform.position = labelPosition;
	}

	public void UpdateCurRoundNumberRotation()
	{
		Vector3 angles = curRoundNumberObject.transform.localEulerAngles;
		angles.y -= Time.deltaTime * 100f;
		if (angles.y < 360f) angles.y += 360f;
		curRoundNumberObject.transform.localEulerAngles = angles;
	}

	public void Update()
	{
		if (TriggerSlideIn)
		{
			TriggerSlideIn = false;
			markerObject.renderer.enabled = false;
			animObject.animation.Play("SlideIn");
			CurrentRound = GameManagerScript.curRound;
			for (int index = 0; index < maxRoundNumbers; index++)
			{
				string path = index == GameManagerScript.secretRoundNumber ? "/ex_round_mon/secret" :
					(index < 9 ? "/ex_round_mon/0" + (index + 1) : "/ex_round_mon/" + (index + 1));
				GameObject numberObject = GameObject.Find(path);
				bool current = index == CurrentRound;
				numberObject.active = current;
				if (current)
				{
					curRoundNumberObject = numberObject;
					Vector3 angles = curRoundNumberObject.transform.localEulerAngles;
					angles.y = 0f;
					curRoundNumberObject.transform.localEulerAngles = angles;
				}
			}
			state = stateSlideIn;
		}
		else if (state == stateSlideIn)
		{
			UpdateCurRoundNumberPosition();
			if (TriggerSlideOut)
			{
				TriggerSlideOut = false; animObject.animation.Play("SlideOut"); state = stateSlideOut;
			}
			else if (!animObject.animation.IsPlaying("SlideIn")) state = stateOnScreen;
		}
		else if (state == stateOnScreen)
		{
			UpdateCurRoundNumberRotation();
			if (TriggerSlideOut)
			{
				TriggerSlideOut = false; animObject.animation.Play("SlideOut"); state = stateSlideOut;
			}
		}
		else if (state == stateSlideOut)
		{
			UpdateCurRoundNumberPosition();
			if (!animObject.animation.IsPlaying("SlideOut"))
			{
				roundIndicatorObject.SetActiveRecursively(false); state = stateIdle;
			}
		}
	}

	public void Main()
	{
	}
}
