using UnityEngine;

// Marker for a garage camera position; the menu camera moves to it when its menu opens.
// Source listing: recovery/aot_listings/Assembly-CSharp/FrontEndCameraTarget.txt
public class FrontEndCameraTarget : MonoBehaviour
{
	// RECUPERADO-AOT FrontEndCameraTarget::OnDrawGizmos token 0x06000664 @0x0012a2ec
	// The line end is (position.normalized + forward) * 5, as compiled.
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.gray;
		Gizmos.DrawLine(base.transform.position, (base.transform.position.normalized + base.transform.forward) * 5f);
	}
}
