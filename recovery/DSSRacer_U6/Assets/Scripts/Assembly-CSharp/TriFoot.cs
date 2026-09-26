using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class TriFoot : MonoBehaviour
{
	public const float FOOT_ERROR_THRESHOLD = 4f;

	private Vector3[] footPoints;

	private Vector3[] footDirections;

	public Vector3 groundPoint;

	public int castMask;

	public Vector3 leadFoot
	{
		get
		{
			RecoveryPending.Hit("TriFoot.get_leadFoot");
			return default(Vector3);
		}
		set
		{
			RecoveryPending.Hit("TriFoot.set_leadFoot");
		}
	}

	public Vector3 leftFoot
	{
		get
		{
			RecoveryPending.Hit("TriFoot.get_leftFoot");
			return default(Vector3);
		}
		set
		{
			RecoveryPending.Hit("TriFoot.set_leftFoot");
		}
	}

	public Vector3 rightFoot
	{
		get
		{
			RecoveryPending.Hit("TriFoot.get_rightFoot");
			return default(Vector3);
		}
		set
		{
			RecoveryPending.Hit("TriFoot.set_rightFoot");
		}
	}

	public Vector3 forward
	{
		get
		{
			RecoveryPending.Hit("TriFoot.get_forward");
			return default(Vector3);
		}
		set
		{
			RecoveryPending.Hit("TriFoot.set_forward");
		}
	}

	public Vector3 right
	{
		get
		{
			RecoveryPending.Hit("TriFoot.get_right");
			return default(Vector3);
		}
		set
		{
			RecoveryPending.Hit("TriFoot.set_right");
		}
	}

	public Vector3 up
	{
		get
		{
			RecoveryPending.Hit("TriFoot.get_up");
			return default(Vector3);
		}
		set
		{
			RecoveryPending.Hit("TriFoot.set_up");
		}
	}

	private void TriFootTest()
	{
		RecoveryPending.Hit("TriFoot.TriFootTest");
	}

	private void UpsideDownTest()
	{
		RecoveryPending.Hit("TriFoot.UpsideDownTest");
	}

	private void Start()
	{
		RecoveryPending.Hit("TriFoot.Start");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("TriFoot.FixedUpdate");
	}

	[DebuggerHidden]
	private IEnumerator GimpedTrifootCoroutine()
	{
		RecoveryPending.Hit("TriFoot.GimpedTrifootCoroutine");
		yield break;
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("TriFoot.OnDrawGizmos");
	}
}
