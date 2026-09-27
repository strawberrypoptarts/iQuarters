using System;
using UnityEngine;

[Serializable]
public class PauseButtonScript : MonoBehaviour
{
	public int debugState = -1;

	public Renderer pauseButtonRenderer;

	public bool enableButtonView;

	public GUISkin dummySkin;

	public GameObject pauseMenuObject;

	private int waitForAnimState = 100;

	private int idleState = 101;

	private int currentState;

	private bool oneTimeFlag;

	public void Awake()
	{
		if (!oneTimeFlag)
		{
			oneTimeFlag = true;
			ReplayController.InitReplayData();
			ReplayController.LoadAllReplays();
		}
	}

	public void Start()
	{
		if (GameManagerScript.is_iPad())
		{
			transform.localScale = GameManagerScript.iPadUIScale;
			Vector3 position = transform.localPosition;
			position.x = -GameManagerScript.iPadUIPosition.x;
			position.y = -GameManagerScript.iPadUIPosition.y;
			position.z = GameManagerScript.iPadUIPosition.z;
			transform.localPosition = position;
		}
		currentState = idleState;
	}

	public void OnGUI()
	{
		if (QuarterTrigger.state != QuarterTrigger.stateWaitForShot)
		{
			currentState = idleState;
			pauseButtonRenderer.enabled = false;
			return;
		}
		if (currentState == idleState)
		{
			pauseButtonRenderer.enabled = true;
			if (!enableButtonView) GUI.skin = dummySkin;
			Rect buttonRect = new Rect(60f, 15f, 64f, 64f);
			if (GameManagerScript.is_iPad()) buttonRect = GameManagerScript.GetiPadRect(buttonRect, false);
			if (GUI.Button(buttonRect, string.Empty))
			{
				animation.Play();
				AnnouncerScript.triggerClickSound = true;
				currentState = waitForAnimState;
				GameManagerScript.ResetUserSecretCodes();
			}
		}
		else if (currentState == waitForAnimState && !animation.isPlaying)
		{
			QuarterTrigger.state = QuarterTrigger.stateOptionsMenu;
			CoinHolder.triggerCoinHolderOut = GameManagerScript.curMadeShotsThisRound;
			InGameAngleIcon.triggerOffScreen = true;
			RoundIndicator.TriggerSlideOut = true;
			pauseMenuObject.SetActiveRecursively(true);
			PauseMenu.triggerAnimIn = true;
			debugState++;
		}
	}

	public void CheckToDisableHOFButton()
	{
	}

	public void Main()
	{
	}
}
