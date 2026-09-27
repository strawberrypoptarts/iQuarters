using System;
using UnityEngine;

[Serializable]
public class SaveReplayButtons : MonoBehaviour
{
	public void Start()
	{
		if (GameManagerScript.is_iPad())
		{
			Transform replayButtons = (Transform)GameObject.Find("/ui_save_replay").GetComponent(typeof(Transform));
			Vector3 scale = replayButtons.localScale;
			scale.x = 37f;
			replayButtons.localScale = scale;
		}
	}

	public void Update()
	{
	}

	public void Main()
	{
	}
}
