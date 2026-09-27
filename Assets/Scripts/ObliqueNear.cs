using System;
using UnityEngine;

[Serializable]
public class ObliqueNear : MonoBehaviour
{
	public Transform plane;

	public Matrix4x4 CalculateObliqueMatrix(Matrix4x4 projection, Vector4 clipPlane)
	{
		Vector4 q = projection.inverse * new Vector4(Mathf.Sign(clipPlane.x), Mathf.Sign(clipPlane.y), 1f, 1f);
		Vector4 c = clipPlane * (2f / Vector4.Dot(clipPlane, q));
		projection[2] = c.x - projection[3];
		projection[6] = c.y - projection[7];
		projection[10] = c.z - projection[11];
		projection[14] = c.w - projection[15];
		return projection;
	}

	public void OnPreCull()
	{
		Matrix4x4 projection = camera.projectionMatrix;
		Matrix4x4 worldToCamera = camera.worldToCameraMatrix;
		Vector3 cameraPosition = worldToCamera.MultiplyPoint(plane.position);
		Vector3 cameraNormal = worldToCamera.MultiplyVector(-plane.up).normalized;
		Vector4 clipPlane = new Vector4(cameraNormal.x, cameraNormal.y, cameraNormal.z,
			-Vector3.Dot(cameraPosition, cameraNormal));
		camera.projectionMatrix = CalculateObliqueMatrix(projection, clipPlane);
	}

	public void Main()
	{
	}
}
