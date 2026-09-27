using UnityEngine;

// Moves an object back and forth between its start pose and a target transform, one transition per
// transitionDuration seconds.
// Source listing: recovery/aot_listings/Assembly-CSharp/PathMoverAI.txt
public class PathMoverAI : MonoBehaviour
{
	public Transform targetTransform;

	// RECUPERADO-AOT PathMoverAI::.ctor token 0x06000099 @0x000ce7a8 (field initializers)
	public float transitionDuration = 1f;

	private Vector3 originPosition;

	private Quaternion originRotation;

	private bool travelDirection = true;

	private Vector3 transitionStartPos = Vector3.zero;

	private Quaternion transitionStartRot = Quaternion.identity;

	private Vector3 transitionTargetPos = Vector3.zero;

	private Quaternion transitionTargetRot = Quaternion.identity;

	private float transitionAccumulatedTime;

	// RECUPERADO-AOT PathMoverAI::StartTransition token 0x0600009a @0x000ce89c
	private void StartTransition(Vector3 desiredPos, Quaternion desiredRot)
	{
		transitionStartPos = base.transform.position;
		transitionStartRot = base.transform.rotation;
		transitionAccumulatedTime = 0f;
		transitionTargetPos = desiredPos;
		transitionTargetRot = desiredRot;
	}

	// RECUPERADO-AOT PathMoverAI::Start token 0x0600009b @0x000ce9c4
	private void Start()
	{
		originPosition = base.transform.position;
		originRotation = base.transform.rotation;
	}

	// RECUPERADO-AOT PathMoverAI::FixedUpdate token 0x0600009c @0x000cea68
	// (the first transition runs from the zero pose set by the constructor, as in the original)
	private void FixedUpdate()
	{
		if (transitionAccumulatedTime < transitionDuration)
		{
			transitionAccumulatedTime += Time.deltaTime;
			float t = transitionAccumulatedTime / transitionDuration;
			base.transform.position = Vector3.Lerp(transitionStartPos, transitionTargetPos, t);
			base.transform.rotation = Quaternion.Slerp(transitionStartRot, transitionTargetRot, t);
			return;
		}
		if (travelDirection)
		{
			StartTransition(originPosition, originRotation);
		}
		else
		{
			StartTransition(targetTransform.position, targetTransform.rotation);
		}
		travelDirection = !travelDirection;
	}
}
