using System;
using UnityEngine;

[Serializable]
public class IntroCamScript : MonoBehaviour
{
	public Transform target;

	public float distance = 10f;

	public float height = 5f;

	public float heightDamping = 2f;

	public float rotationDamping = 3f;

	public void LateUpdate()
	{
		if (!target)
		{
			return;
		}

		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		Quaternion currentRotation = Quaternion.Euler(0f, currentRotationAngle, 0f);
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		Vector3 position = transform.position;
		position.y = currentHeight;
		transform.position = position;
		transform.LookAt(target);
	}

	public void Main()
	{
	}
}
