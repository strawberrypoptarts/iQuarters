using System;
using UnityEngine;

[Serializable]
public class ZoomCamera : MonoBehaviour
{
	public Transform origin;

	public float zoom;

	public float zoomMin = -5f;

	public float zoomMax = 5f;

	public float seekTime = 1f;

	public bool smoothZoomIn;

	private Vector3 defaultLocalPosition;

	private Transform thisTransform;

	private float currentZoom;

	private float targetZoom;

	private float zoomVelocity;

	public void Start()
	{
		thisTransform = transform;
		defaultLocalPosition = thisTransform.localPosition;
		currentZoom = zoom;
	}

	public void Update()
	{
		zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
		Vector3 desiredLocal = defaultLocalPosition + thisTransform.parent.InverseTransformDirection(origin.forward * zoom);
		Vector3 desiredWorld = thisTransform.parent.TransformPoint(desiredLocal);
		RaycastHit hit;
		if (!Physics.Linecast(origin.position, desiredWorld, out hit))
			targetZoom = zoom;
		else
		{
			Vector3 safePoint = hit.point + thisTransform.TransformDirection(Vector3.forward);
			targetZoom = (safePoint - thisTransform.parent.TransformPoint(defaultLocalPosition)).magnitude;
		}
		targetZoom = Mathf.Clamp(targetZoom, zoomMin, zoomMax);
		if (smoothZoomIn || targetZoom - currentZoom <= 0f)
			currentZoom = Mathf.SmoothDamp(currentZoom, targetZoom, ref zoomVelocity, seekTime);
		else
			currentZoom = targetZoom;
		thisTransform.localPosition = defaultLocalPosition
			+ thisTransform.parent.InverseTransformDirection(origin.forward * currentZoom);
	}

	public void Main()
	{
	}
}
