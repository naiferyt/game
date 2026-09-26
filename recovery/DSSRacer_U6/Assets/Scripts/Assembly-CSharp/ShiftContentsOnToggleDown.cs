using UnityEngine;

public class ShiftContentsOnToggleDown : MonoBehaviour
{
	public Vector3 offset;

	public Transform[] transformsToShift;

	private void OnEnable()
	{
		RecoveryPending.Hit("ShiftContentsOnToggleDown.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("ShiftContentsOnToggleDown.OnDisable");
	}

	private void OnDownHandler(UghToggle button, bool isDown)
	{
		RecoveryPending.Hit("ShiftContentsOnToggleDown.OnDownHandler");
	}
}
