using System;
using UnityEngine;

[Serializable]
public class AngleAdjustScript : MonoBehaviour
{
	public bool displayButtons;

	public GameObject adjustObject;

	public Renderer adjustRenderer;

	public float minScaleY = 10f;

	public float maxScaleY = -10f;

	public float minScaleZ = -10f;

	public float maxScaleZ = 10f;

	private float InitialScaleY;

	private float InitialScaleZ;

	public void Start()
	{
		InitialScaleY = adjustObject.transform.localScale.y;
		InitialScaleZ = adjustObject.transform.localScale.z;
	}

	public void Update()
	{
		if (QuarterTrigger.state != QuarterTrigger.stateAngleInput)
		{
			adjustRenderer.enabled = false;
			return;
		}
		adjustRenderer.enabled = true;
		float angleRange = QuarterTrigger.maxShotAngle - QuarterTrigger.minShotAngle;
		if (angleRange <= 0f) return;
		float ratio = 1f - (GameManagerScript.shotAngle - QuarterTrigger.minShotAngle) / angleRange;
		Vector3 scale = adjustObject.transform.localScale;
		scale.y = InitialScaleY + minScaleY * (1f - ratio) + maxScaleY * ratio;
		scale.z = InitialScaleZ + minScaleZ * (1f - ratio) + maxScaleZ * ratio;
		adjustObject.transform.localScale = scale;
	}

	public void OnGUI()
	{
		if (!displayButtons || QuarterTrigger.state != QuarterTrigger.stateAngleInput) return;
		GUI.skin = null;
		Rect down = new Rect(16f, 440f, 64f, 32f);
		Rect up = new Rect(240f, 440f, 64f, 32f);
		if (GameManagerScript.is_iPad())
		{
			down = GameManagerScript.GetiPadRect(down, false);
			up = GameManagerScript.GetiPadRect(up, false);
		}
		if (GUI.Button(down, string.Empty))
			GameManagerScript.shotAngle = Mathf.Max(QuarterTrigger.minShotAngle, GameManagerScript.shotAngle - 1f);
		if (GUI.Button(up, string.Empty))
			GameManagerScript.shotAngle = Mathf.Min(QuarterTrigger.maxShotAngle, GameManagerScript.shotAngle + 1f);
	}

	public void Main()
	{
	}
}
