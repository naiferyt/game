using System;
using UnityEngine;

// Garage camera: glides (Slerp) between FrontEndCameraTarget markers when the menu changes.
// Source listing: recovery/aot_listings/Assembly-CSharp/FrontEndCamera.txt
public class FrontEndCamera : MonoBehaviour
{
	// RECUPERADO-AOT FrontEndCamera::.ctor token 0x0600065b @0x00129b14 (field initializers)
	public float transitionDuration = 0.75f;

	public FrontEndCameraTarget[] targetList;

	private FrontEndCameraTarget desiredTarget;

	private Vector3 transitionStartPos = Vector3.zero;

	private Quaternion transitionStartRot = Quaternion.identity;

	private Vector3 transitionTargetPos = Vector3.zero;

	private Quaternion transitionTargetRot = Quaternion.identity;

	private float transitionAccumulatedTime;

	// RECUPERADO-AOT FrontEndCamera::get_isTransitioning token 0x0600065c @0x00129c00
	public bool isTransitioning
	{
		get
		{
			return transitionAccumulatedTime < transitionDuration;
		}
	}

	// RECUPERADO-AOT FrontEndCamera::StartTransition token 0x0600065d @0x00129c50
	private void StartTransition(FrontEndCameraTarget newTarget)
	{
		if (!(newTarget == desiredTarget))
		{
			desiredTarget = newTarget;
			transitionStartPos = base.transform.position;
			transitionStartRot = base.transform.rotation;
			transitionAccumulatedTime = 0f;
			transitionTargetPos = desiredTarget.transform.position;
			transitionTargetRot = Quaternion.LookRotation(desiredTarget.transform.forward.normalized, desiredTarget.transform.up.normalized);
			if ((transitionTargetPos - base.transform.position).magnitude > 0.1f)
			{
				FrontEndLogic.PlayRandomWhoosh();
			}
		}
	}

	// RECUPERADO-AOT FrontEndCamera::Start token 0x0600065e @0x00129efc
	private void Start()
	{
		if (desiredTarget == null)
		{
			StartTransition(targetList[0]);
		}
	}

	// RECUPERADO-AOT FrontEndCamera::FixedUpdate token 0x0600065f @0x00129f68
	private void FixedUpdate()
	{
		if (transitionAccumulatedTime < transitionDuration)
		{
			transitionAccumulatedTime += Time.deltaTime;
			float t = transitionAccumulatedTime / transitionDuration;
			base.transform.position = Vector3.Slerp(transitionStartPos, transitionTargetPos, t);
			base.transform.rotation = Quaternion.Slerp(transitionStartRot, transitionTargetRot, t);
		}
	}

	// RECUPERADO-AOT FrontEndCamera::SetCameraTarget token 0x06000660 @0x0012a160
	private void SetCameraTarget(FrontEndCameraTarget newTarget)
	{
		if (Array.IndexOf(targetList, newTarget) == -1)
		{
			Debug.LogError("Illegal target.");
		}
		else
		{
			StartTransition(newTarget);
		}
	}

	// RECUPERADO-AOT FrontEndCamera::SetCameraTargetByIndex token 0x06000661 @0x0012a1e0
	// The upper bound test is "index > Length", as compiled.
	private void SetCameraTargetByIndex(int index)
	{
		if (index < 0 || index > targetList.Length)
		{
			Debug.LogError("Illegal target index.");
		}
		else
		{
			StartTransition(targetList[index]);
		}
	}

	// RECUPERADO-AOT FrontEndCamera::ForceCameraTarget token 0x06000662 @0x0012a274
	private void ForceCameraTarget(FrontEndCameraTarget newTarget)
	{
		desiredTarget = null;
		StartTransition(newTarget);
	}
}
