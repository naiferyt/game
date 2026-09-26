using UnityEngine;

public class ShiftContentsOnButtonDown : MonoBehaviour
{
	public Vector3 offset;

	public Transform[] transformsToShift;

	private void OnEnable()
	{
		RecoveryPending.Hit("ShiftContentsOnButtonDown.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("ShiftContentsOnButtonDown.OnDisable");
	}

	private void OnDownHandler(UghButton button, bool isDown)
	{
		RecoveryPending.Hit("ShiftContentsOnButtonDown.OnDownHandler");
	}
}
