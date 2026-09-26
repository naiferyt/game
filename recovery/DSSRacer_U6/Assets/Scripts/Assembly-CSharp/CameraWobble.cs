using UnityEngine;

// Slight wandering skew of the camera projection (m01 and m10 oscillate by 0.002).
// Source listing: recovery/aot_listings/Assembly-CSharp/CameraWobble.txt
public class CameraWobble : MonoBehaviour
{
	// RECUPERADO-AOT CameraWobble::Update token 0x06000402 @0x000fb3d0
	// ADAPTADO-U6: Component.camera -> GetComponent<Camera>().
	private void Update()
	{
		Matrix4x4 projectionMatrix = GetComponent<Camera>().projectionMatrix;
		projectionMatrix.m01 += Mathf.Sin(Time.time * 2.2f) * 0.002f;
		projectionMatrix.m10 += Mathf.Cos(Time.time * 3.5f) * 0.002f;
		GetComponent<Camera>().projectionMatrix = projectionMatrix;
	}
}
