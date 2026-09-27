using System;
using UnityEngine;

[Serializable]
public class About : MonoBehaviour
{
	public GameObject aboutGameObject;

	public Renderer aboutDimPlaneRenderer;

	public Renderer aboutButtonRenderer;

	public Renderer aboutTextRenderer;

	public GUISkin fontSkin_iPad;

	public static bool TriggerButtonOn;

	public static bool TriggerButtonOff;

	public static bool TriggerTextOn;

	public static bool TriggerTextOff;

	private int stateIdle = 100;

	private int stateButtonOnScreen = 101;

	private int stateTriggerText = 102;

	private int stateTextOnScreen = 103;

	private int stateCurrent = 100;

	private string versionInfo = "V 1.1.0    06/21/2010";

	private int leftRightMargin = 30;

	private int topBottomMargin = 30;

	private int leftRightMargin_iPad = 50;

	private int topBottomMargin_iPad = 70;

	public void Start()
	{
		aboutDimPlaneRenderer.enabled = false;
		aboutButtonRenderer.enabled = false;
		aboutTextRenderer.enabled = false;
		TriggerButtonOn = TriggerButtonOff = TriggerTextOn = false;
		stateCurrent = stateIdle;
		GameObject dimPlane = GameObject.Find("/ui_about/dimplane");
		Vector3 position = dimPlane.transform.localPosition;
		position.z = -3.1f;
		dimPlane.transform.localPosition = position;
		Vector3 scale = dimPlane.transform.localScale;
		scale.z = 2.9f;
		dimPlane.transform.localScale = scale;
	}

	public void Update()
	{
		if (TriggerButtonOn)
		{
			TriggerButtonOn = false;
			stateCurrent = stateButtonOnScreen;
			aboutDimPlaneRenderer.enabled = false;
			aboutButtonRenderer.enabled = true;
			aboutTextRenderer.enabled = false;
		}
		else if (TriggerButtonOff || TriggerTextOff)
		{
			TriggerButtonOff = TriggerTextOff = false;
			stateCurrent = stateIdle;
			aboutDimPlaneRenderer.enabled = false;
			aboutButtonRenderer.enabled = false;
			aboutTextRenderer.enabled = false;
			aboutGameObject.SetActiveRecursively(false);
		}
		else if (TriggerTextOn)
		{
			TriggerTextOn = false;
			stateCurrent = stateTriggerText;
			animation.Play("Click");
		}
		else if (stateCurrent == stateTriggerText && !animation.IsPlaying("Click"))
		{
			aboutDimPlaneRenderer.enabled = true;
			aboutButtonRenderer.enabled = false;
			aboutTextRenderer.enabled = true;
			stateCurrent = stateTextOnScreen;
		}
	}

	public void OnGUI()
	{
		if (stateCurrent == stateTextOnScreen)
		{
			DrawAboutText();
		}
	}

	public void DrawAboutText()
	{
		GUI.skin = GameManagerScript.is_iPad() ? fontSkin_iPad : GUI.skin;
		int horizontal = GameManagerScript.is_iPad() ? leftRightMargin_iPad : leftRightMargin;
		int vertical = GameManagerScript.is_iPad() ? topBottomMargin_iPad : topBottomMargin;
		GUIStyle style = GUI.skin.label;
		TextAnchor oldAlignment = style.alignment;
		Color oldColor = style.normal.textColor;
		style.alignment = TextAnchor.UpperCenter;
		style.normal.textColor = Color.white;
		Rect versionRect = new Rect(horizontal, 320 - horizontal / 2, 480 - horizontal * 2, 40);
		Rect textRect = new Rect(horizontal, vertical, 480 - horizontal * 2, 320 - vertical * 2);
		if (GameManagerScript.is_iPad())
		{
			versionRect = GameManagerScript.GetiPadRect(versionRect);
			textRect = GameManagerScript.GetiPadRect(textRect);
		}
		GUI.Label(versionRect, versionInfo);
		GUI.Label(textRect, "iQuarters\n\nCopyright 2010 iT's Games");
		style.alignment = oldAlignment;
		style.normal.textColor = oldColor;
	}

	public void Main()
	{
	}
}
