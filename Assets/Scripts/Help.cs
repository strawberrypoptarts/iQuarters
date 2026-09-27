using System;
using UnityEngine;

[Serializable]
public class Help : MonoBehaviour
{
	public void Start()
	{
		if (GameManagerScript.is_iPad())
		{
			GameObject help = GameObject.Find("ui_help/help");
			Vector3 position = help.transform.localPosition;
			position.x = -1.7f;
			help.transform.localPosition = position;
		}
	}

	public void Main()
	{
	}
}
