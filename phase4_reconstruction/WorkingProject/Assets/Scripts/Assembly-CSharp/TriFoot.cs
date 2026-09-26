using System.Collections;
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
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 leftFoot
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 rightFoot
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 forward
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 right
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 up
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	private void TriFootTest()
	{
	}

	private void UpsideDownTest()
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator GimpedTrifootCoroutine()
	{
		return default(IEnumerator);
	}

	private void OnDrawGizmos()
	{
	}
}
