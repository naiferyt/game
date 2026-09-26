using UnityEngine;

public class PathMoverAI : MonoBehaviour
{
	public Transform targetTransform;

	public float transitionDuration;

	private Vector3 originPosition;

	private Quaternion originRotation;

	private bool travelDirection;

	private Vector3 transitionStartPos;

	private Quaternion transitionStartRot;

	private Vector3 transitionTargetPos;

	private Quaternion transitionTargetRot;

	private float transitionAccumulatedTime;

	private void StartTransition(Vector3 desiredPos, Quaternion desiredRot)
	{
		RecoveryPending.Hit("PathMoverAI.StartTransition");
	}

	private void Start()
	{
		RecoveryPending.Hit("PathMoverAI.Start");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("PathMoverAI.FixedUpdate");
	}
}
