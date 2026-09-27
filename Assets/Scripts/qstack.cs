using System;
using UnityEngine;

[Serializable]
public class qstack : MonoBehaviour
{
	public Renderer coin1Renderer;

	public void Start()
	{
		coin1Renderer.enabled = false;
		animation.Play("twocoin");
	}

	public void Update()
	{
	}

	public void Main()
	{
	}
}
