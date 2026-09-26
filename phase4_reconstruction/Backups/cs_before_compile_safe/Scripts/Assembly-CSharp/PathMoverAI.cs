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
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}
}
