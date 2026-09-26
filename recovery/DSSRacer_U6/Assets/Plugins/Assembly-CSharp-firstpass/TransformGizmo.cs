using UnityEngine;

public class TransformGizmo : MonoBehaviour
{
	private void OnDrawGizmosSelected()
	{
		RecoveryPending.Hit("TransformGizmo.OnDrawGizmosSelected");
	}
}
