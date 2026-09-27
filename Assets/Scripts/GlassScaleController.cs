using System;
using UnityEngine;

[Serializable]
public class GlassScaleController : MonoBehaviour
{
	public static bool triggerGlassScale;

	public static GameObject inThisGlassObject;

	private GameObject inThisGlassObjectCopy;

	private int stateIdle = 100;

	private int stateScaleUp = 101;

	private int stateScaleDown = 102;

	private int stateCurrent = 100;

	private Vector3 originalScale;

	private float maxScale = 1.2f;

	private float currentScale = 1f;

	private float scaleRate = 0.06f;

	public void Start()
	{
		foreach (AnimationState animationState in animation)
		{
			animationState.speed = animationState.length * 1.5f;
		}
	}

	public void Update()
	{
		if (triggerGlassScale)
		{
			if (inThisGlassObject && inThisGlassObject.tag != "IgnoreGlassEffect")
			{
				Renderer childRenderer = (Renderer)inThisGlassObject.GetComponentInChildren(typeof(Renderer));
				if (childRenderer)
				{
					inThisGlassObjectCopy = childRenderer.gameObject;
					if (inThisGlassObjectCopy)
					{
						originalScale = inThisGlassObjectCopy.transform.localScale;
						currentScale = 1f;
						stateCurrent = stateScaleUp;
						animation.Play();
					}
				}
			}
			triggerGlassScale = false;
		}

		if (stateCurrent == stateScaleUp)
		{
			float factor = (transform.localScale.x - 1f) * 0.75f + 1f;
			Vector3 scale = inThisGlassObjectCopy.transform.localScale;
			scale.x = originalScale.x * factor;
			inThisGlassObjectCopy.transform.localScale = scale;
			scale = inThisGlassObjectCopy.transform.localScale;
			scale.y = originalScale.y * factor;
			inThisGlassObjectCopy.transform.localScale = scale;
			if (!animation.isPlaying)
			{
				inThisGlassObjectCopy.transform.localScale = originalScale;
				stateCurrent = stateIdle;
			}
		}
	}

	public void Main()
	{
	}
}
