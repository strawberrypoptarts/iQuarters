using System;
using UnityEngine;

[Serializable]
public class RicochetExciter : MonoBehaviour
{
	public GameObject ricochetParentObject;

	public GameObject ricochetScoreObject;

	public Texture[] digitsTextureArray;

	public GUISkin dummySkin;

	public static int numRicochets;

	public static bool TriggerOn;

	public static int TriggerCoinX;

	public static int TriggerScore;

	private int stateIdle = 100;

	private int stateHolderIn = 101;

	private int stateOnScreen = 102;

	private int stateOnScreenWithScore = 103;

	private int stateHolderOut = 104;

	private int state = 100;

	private int maxCoins = 9;

	private GameObject holderObject;

	public void Start()
	{
		holderObject = GameObject.Find("/RicochetParent/ui_richochet_holder");
		if (holderObject.animation.GetClipCount() == 1)
		{
			holderObject.animation.AddClip(holderObject.animation.clip, "SlideIn", 0, 8);
			holderObject.animation.AddClip(holderObject.animation.clip, "SlideOut", 15, 20);
		}
		ricochetParentObject.SetActiveRecursively(false);
		if (ricochetScoreObject.animation.GetClipCount() == 1)
		{
			ricochetScoreObject.animation.AddClip(ricochetScoreObject.animation.clip, "OnOff", 0, 45);
		}
		ricochetScoreObject.SetActiveRecursively(false);
	}

	public void DisableInstantReplayExciter()
	{
		GameObject gameObject = GameObject.Find("/exciter_instant_replay");
		if (gameObject)
		{
			gameObject.SetActiveRecursively(false);
		}
	}

	public void Update()
	{
		if (TriggerOn && QuarterTrigger.skipToRackupState == 0)
		{
			TriggerOn = false;
			for (int i = 0; i < maxCoins; i++)
			{
				GameObject gameObject = GameObject.Find("/RicochetParent/ui_richochet_coin0" + i);
				if (gameObject)
				{
					gameObject.SetActiveRecursively(false);
				}
			}
			DisableInstantReplayExciter();
			holderObject.animation.Play("SlideIn");
			state = stateHolderIn;
		}

		if (state == stateIdle)
		{
			return;
		}
		if (state == stateHolderIn)
		{
			if (!holderObject.animation.IsPlaying("SlideIn"))
			{
				state = stateOnScreen;
			}
			return;
		}
		if (state == stateOnScreen)
		{
			if (TriggerCoinX != 0 && QuarterTrigger.skipToRackupState == 0)
			{
				if (TriggerCoinX > 0 && TriggerCoinX <= maxCoins)
				{
					DisableInstantReplayExciter();
					ricochetParentObject.SetActiveRecursively(true);
					for (int i = 0; i < maxCoins; i++)
					{
						GameObject gameObject = GameObject.Find("ui_richochet_coin0" + i);
						gameObject.SetActiveRecursively(i < TriggerCoinX - 1);
						if (i == TriggerCoinX - 1)
						{
							gameObject.animation.Play();
						}
					}
					if (!QuarterTrigger.muteF && audio)
					{
						audio.Play();
					}
				}
				TriggerCoinX = 0;
			}
			if (TriggerScore != 0 && QuarterTrigger.skipToRackupState == 0)
			{
				DisableInstantReplayExciter();
				TriggerScore %= 10;
				ricochetScoreObject.SetActiveRecursively(true);
				GameObject.Find("/ui_richochet_score/center_marker").active = false;
				GameObject.Find("/ui_richochet_score/richochet_score/number_parent/rs_01").renderer.material.mainTexture = digitsTextureArray[TriggerScore];
				GameObject.Find("/ui_richochet_score/richochet_score/number_parent/rs_02").renderer.material.mainTexture = digitsTextureArray[0];
				ricochetScoreObject.animation.Play("OnOff");
				TriggerScore = 0;
				state = stateOnScreenWithScore;
			}
			return;
		}
		if (state == stateOnScreenWithScore)
		{
			if (!ricochetScoreObject.animation.IsPlaying("OnOff"))
			{
				for (int i = 0; i < maxCoins; i++)
				{
					GameObject gameObject = GameObject.Find("/RicochetParent/ui_richochet_coin0" + i);
					if (gameObject)
					{
						gameObject.SetActiveRecursively(false);
					}
				}
				holderObject.animation.Play("SlideOut");
				state = stateHolderOut;
			}
			return;
		}
		if (state == stateHolderOut && !holderObject.animation.IsPlaying("SlideOut"))
		{
			ricochetParentObject.SetActiveRecursively(false);
			ricochetScoreObject.SetActiveRecursively(false);
			DisableInstantReplayExciter();
			state = stateIdle;
		}
	}

	public void OnGUI()
	{
		if (QuarterTrigger.state == QuarterTrigger.stateShotInAir && (state == stateHolderIn || state == stateOnScreen))
		{
			GUI.skin = dummySkin;
			Rect position = new Rect(480f, 0f, 50f, 50f);
			if (GameManagerScript.is_iPad())
			{
				position = GameManagerScript.GetiPadRect(position);
			}
			if (GUI.Button(position, string.Empty))
			{
				ricochetParentObject.SetActiveRecursively(false);
				ricochetScoreObject.SetActiveRecursively(false);
				DisableInstantReplayExciter();
				state = stateIdle;
				if (QuarterTrigger.skipToRackupState == 0)
				{
					QuarterTrigger.skipToRackupState = 1;
				}
			}
		}
	}

	public void Main()
	{
	}
}
