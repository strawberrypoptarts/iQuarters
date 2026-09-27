using System;
using UnityEngine;

[Serializable]
public class RenderWater : MonoBehaviour
{
	public GameObject[] water;

	public Shader depthShader;

	public void Start()
	{
		Camera.main.clearFlags = (CameraClearFlags)4;
	}

	public void OnPreCull()
	{
		Plane[] frustum = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		GL.Clear(true, true, Camera.main.backgroundColor);
		for (int index = 0; index < water.Length; index++)
		{
			GameObject waterObject = water[index];
			if (!GeometryUtility.TestPlanesAABB(frustum, waterObject.renderer.bounds)) continue;

			Bounds bounds = waterObject.renderer.bounds;
			GameObject reflectionObject = new GameObject("reflectionCamera");
			Camera reflectionCamera = (Camera)reflectionObject.AddComponent(typeof(Camera));
			reflectionCamera.CopyFrom(Camera.main);
			reflectionCamera.enabled = false;
			ObliqueNear oblique = (ObliqueNear)reflectionObject.AddComponent(typeof(ObliqueNear));
			oblique.plane = waterObject.transform;

			Vector3 mainPosition = Camera.main.transform.position;
			float waterHeight = waterObject.transform.position.y;
			reflectionObject.transform.position = new Vector3(mainPosition.x,
				2f * waterHeight - mainPosition.y, mainPosition.z);
			Plane waterPlane = new Plane(Vector3.up, bounds.center);
			Ray viewRay = new Ray(mainPosition, Camera.main.transform.forward);
			float distance = 0f;
			waterPlane.Raycast(viewRay, out distance);
			reflectionObject.transform.LookAt(mainPosition + Camera.main.transform.forward * distance);

			Matrix4x4 reflectionMatrix = Matrix4x4.identity;
			reflectionMatrix.SetTRS(Vector3.zero, Quaternion.identity, new Vector3(1f, -1f, 1f));
			reflectionCamera.projectionMatrix = reflectionCamera.projectionMatrix * reflectionMatrix;
			reflectionCamera.cullingMask &= ~(1 << waterObject.layer);
			GL.SetRevertBackfacing(true);
			reflectionCamera.Render();
			GL.SetRevertBackfacing(false);
			Destroy(reflectionObject);
		}

		GL.Clear(true, false, Camera.main.backgroundColor);
		GameObject depthObject = new GameObject("depthCam");
		Camera depthCamera = (Camera)depthObject.AddComponent(typeof(Camera));
		depthCamera.CopyFrom(camera);
		if (water.Length > 0) depthCamera.cullingMask = 1 << water[0].layer;
		depthCamera.RenderWithShader(depthShader, string.Empty);
		Destroy(depthObject);
	}

	public void Main()
	{
	}
}
