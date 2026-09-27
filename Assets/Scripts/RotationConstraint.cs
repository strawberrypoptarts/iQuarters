using System;
using UnityEngine;

[Serializable]
public class RotationConstraint : MonoBehaviour
{
	public ConstraintAxis axis;

	public float min;

	public float max;

	private Transform thisTransform;

	private Vector3 rotateAround;

	private Quaternion minQuaternion;

	private Quaternion maxQuaternion;

	private float range;

	public void Start()
	{
		thisTransform = transform;
		switch (axis)
		{
		case ConstraintAxis.X:
			rotateAround = Vector3.right;
			break;
		case ConstraintAxis.Y:
			rotateAround = Vector3.up;
			break;
		case ConstraintAxis.Z:
			rotateAround = Vector3.forward;
			break;
		}

		minQuaternion = thisTransform.localRotation * Quaternion.AngleAxis(min, rotateAround);
		maxQuaternion = thisTransform.localRotation * Quaternion.AngleAxis(max, rotateAround);
		range = max - min;
	}

	public void LateUpdate()
	{
		Quaternion localRotation = thisTransform.localRotation;
		Quaternion axisRotation = Quaternion.AngleAxis(localRotation.eulerAngles[(int)axis], rotateAround);
		float angleFromMin = Quaternion.Angle(axisRotation, minQuaternion);
		float angleFromMax = Quaternion.Angle(axisRotation, maxQuaternion);
		if (angleFromMin <= range && angleFromMax <= range)
		{
			return;
		}

		Vector3 euler = localRotation.eulerAngles;
		euler[(int)axis] = angleFromMin > angleFromMax
			? maxQuaternion.eulerAngles[(int)axis]
			: minQuaternion.eulerAngles[(int)axis];
		thisTransform.localEulerAngles = euler;
	}

	public void Main()
	{
	}
}
