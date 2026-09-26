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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private void StartTransition(FrontEndCameraTarget newTarget)
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void SetCameraTarget(FrontEndCameraTarget newTarget)
	{
	}

	private void SetCameraTargetByIndex(int index)
	{
	}

	private void ForceCameraTarget(FrontEndCameraTarget newTarget)
	{
	}
}
