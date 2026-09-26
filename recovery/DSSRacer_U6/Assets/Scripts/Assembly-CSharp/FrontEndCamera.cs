using UnityEngine;

public class FrontEndCamera : MonoBehaviour
{
	public float transitionDuration;

	public FrontEndCameraTarget[] targetList;

	private FrontEndCameraTarget desiredTarget;

	private Vector3 transitionStartPos;

	private Quaternion transitionStartRot;

	private Vector3 transitionTargetPos;

	private Quaternion transitionTargetRot;

	private float transitionAccumulatedTime;

	public bool isTransitioning
	{
		get
		{
			RecoveryPending.Hit("FrontEndCamera.get_isTransitioning");
			return default(bool);
		}
	}

	private void StartTransition(FrontEndCameraTarget newTarget)
	{
		RecoveryPending.Hit("FrontEndCamera.StartTransition");
	}

	private void Start()
	{
		RecoveryPending.Hit("FrontEndCamera.Start");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("FrontEndCamera.FixedUpdate");
	}

	private void SetCameraTarget(FrontEndCameraTarget newTarget)
	{
		RecoveryPending.Hit("FrontEndCamera.SetCameraTarget");
	}

	private void SetCameraTargetByIndex(int index)
	{
		RecoveryPending.Hit("FrontEndCamera.SetCameraTargetByIndex");
	}

	private void ForceCameraTarget(FrontEndCameraTarget newTarget)
	{
		RecoveryPending.Hit("FrontEndCamera.ForceCameraTarget");
	}
}
