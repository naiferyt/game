using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Ground probe for a kart: casts down from three "feet" (front centre, rear left, rear right) and keeps the
// highest hit of each, clamps feet more than FOOT_ERROR_THRESHOLD apart in height to the lower one, and
// derives the ground point (their average) and a forward / right / up frame from them.
// Source listing: recovery/aot_listings/Assembly-CSharp/TriFoot.txt
public class TriFoot : MonoBehaviour
{
	public const float FOOT_ERROR_THRESHOLD = 4f;

	// RECUPERADO-AOT TriFoot::.ctor token 0x06000595 @0x00119944 (field initializers)
	private Vector3[] footPoints = new Vector3[3]
	{
		Vector3.zero,
		Vector3.zero,
		Vector3.zero
	};

	private Vector3[] footDirections = new Vector3[3]
	{
		Vector3.forward,
		Vector3.right,
		Vector3.up
	};

	public Vector3 groundPoint = Vector3.zero;

	public int castMask = -1;

	// RECUPERADO-AOT TriFoot::get_leadFoot token 0x06000596 @0x00119be4
	// RECUPERADO-AOT TriFoot::set_leadFoot token 0x06000597 @0x00119c80
	public Vector3 leadFoot
	{
		get
		{
			return footPoints[0];
		}
		set
		{
			footPoints[0] = value;
		}
	}

	// RECUPERADO-AOT TriFoot::get_leftFoot token 0x06000598 @0x00119d08
	// RECUPERADO-AOT TriFoot::set_leftFoot token 0x06000599 @0x00119da4
	public Vector3 leftFoot
	{
		get
		{
			return footPoints[1];
		}
		set
		{
			footPoints[1] = value;
		}
	}

	// RECUPERADO-AOT TriFoot::get_rightFoot token 0x0600059a @0x00119e2c
	// RECUPERADO-AOT TriFoot::set_rightFoot token 0x0600059b @0x00119ec8
	public Vector3 rightFoot
	{
		get
		{
			return footPoints[2];
		}
		set
		{
			footPoints[2] = value;
		}
	}

	// RECUPERADO-AOT TriFoot::get_forward token 0x0600059c @0x00119f50
	// RECUPERADO-AOT TriFoot::set_forward token 0x0600059d @0x0011a088
	public Vector3 forward
	{
		get
		{
			if (footDirections[0] == Vector3.zero)
			{
				return Vector3.forward;
			}
			return footDirections[0];
		}
		set
		{
			footDirections[0] = value;
		}
	}

	// RECUPERADO-AOT TriFoot::get_right token 0x0600059e @0x0011a110
	// RECUPERADO-AOT TriFoot::set_right token 0x0600059f @0x0011a248
	public Vector3 right
	{
		get
		{
			if (footDirections[1] == Vector3.zero)
			{
				return Vector3.right;
			}
			return footDirections[1];
		}
		set
		{
			footDirections[1] = value;
		}
	}

	// RECUPERADO-AOT TriFoot::get_up token 0x060005a0 @0x0011a2d0
	// RECUPERADO-AOT TriFoot::set_up token 0x060005a1 @0x0011a408
	public Vector3 up
	{
		get
		{
			if (footDirections[2] == Vector3.zero)
			{
				return Vector3.up;
			}
			return footDirections[2];
		}
		set
		{
			footDirections[2] = value;
		}
	}

	// RECUPERADO-AOT TriFoot::TriFootTest token 0x060005a2 @0x0011a490
	// Feet sit at half the collider length ahead (lead) / behind (left, right) and half its width to the
	// sides, cast from twice its height above; without a collider the kart is taken as 1 x 1 x 1.
	// ADAPTADO-U6: Component.collider -> GetComponent<Collider>().
	private void TriFootTest()
	{
		float num = 1f;
		float num2 = 1f;
		float num3 = 2f;
		Collider component = GetComponent<Collider>();
		if (component != null)
		{
			num = component.bounds.size.x;
			num2 = component.bounds.size.z;
			num3 = component.bounds.size.y * 2f;
		}
		Vector3 origin = base.transform.position + base.transform.forward * num2 / 2f + Vector3.up * num3;
		RaycastHit[] array = Physics.RaycastAll(origin, Vector3.down, float.PositiveInfinity, castMask);
		Vector3 vector = new Vector3(0f, float.NegativeInfinity, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit raycastHit = array[i];
			if (!(raycastHit.collider.gameObject == base.gameObject) && raycastHit.point.y > vector.y + 0.1f)
			{
				vector = raycastHit.point;
				footPoints[0] = raycastHit.point;
			}
		}
		origin = base.transform.position - base.transform.right * num / 2f - base.transform.forward * num2 / 2f + Vector3.up * num3;
		array = Physics.RaycastAll(origin, Vector3.down, float.PositiveInfinity, castMask);
		vector = new Vector3(0f, float.NegativeInfinity, 0f);
		for (int j = 0; j < array.Length; j++)
		{
			RaycastHit raycastHit2 = array[j];
			if (!(raycastHit2.collider.gameObject == base.gameObject) && raycastHit2.point.y > vector.y + 0.1f)
			{
				vector = raycastHit2.point;
				footPoints[1] = raycastHit2.point;
			}
		}
		origin = base.transform.position + base.transform.right * num / 2f - base.transform.forward * num2 / 2f + Vector3.up * num3;
		array = Physics.RaycastAll(origin, Vector3.down, float.PositiveInfinity, castMask);
		vector = new Vector3(0f, float.NegativeInfinity, 0f);
		for (int k = 0; k < array.Length; k++)
		{
			RaycastHit raycastHit3 = array[k];
			if (!(raycastHit3.collider.gameObject == base.gameObject) && raycastHit3.point.y > vector.y + 0.1f)
			{
				vector = raycastHit3.point;
				footPoints[2] = raycastHit3.point;
			}
		}
		float num4 = footPoints[0].y - footPoints[2].y;
		if (Mathf.Abs(num4) > 4f)
		{
			if (num4 < 0f)
			{
				footPoints[2] = new Vector3(footPoints[2].x, footPoints[0].y, footPoints[2].z);
			}
			else
			{
				footPoints[0] = new Vector3(footPoints[0].x, footPoints[2].y, footPoints[0].z);
			}
		}
		num4 = footPoints[0].y - footPoints[1].y;
		if (Mathf.Abs(num4) > 4f)
		{
			if (num4 < 0f)
			{
				footPoints[1] = new Vector3(footPoints[1].x, footPoints[0].y, footPoints[1].z);
			}
			else
			{
				footPoints[0] = new Vector3(footPoints[0].x, footPoints[1].y, footPoints[0].z);
			}
		}
		groundPoint = (footPoints[0] + footPoints[1] + footPoints[2]) / 3f;
		footDirections[1] = (footPoints[2] - footPoints[1]).normalized;
		footDirections[0] = (footPoints[0] - groundPoint).normalized;
		footDirections[2] = Vector3.Cross(forward, right).normalized;
		if (UnityEngine.Debug.isDebugBuild)
		{
			UpsideDownTest();
		}
	}

	// RECUPERADO-AOT TriFoot::UpsideDownTest token 0x060005a3 @0x0011bf9c
	private void UpsideDownTest()
	{
		if (up.Equals(Vector3.down))
		{
			UnityEngine.Debug.LogWarning("This car seems to be upside-down.");
		}
	}

	// RECUPERADO-AOT TriFoot::Start token 0x060005a4 @0x0011c04c
	private void Start()
	{
		TriFootTest();
		if (!QualityControl.DoFullTriFoot)
		{
			StartCoroutine(GimpedTrifootCoroutine());
		}
	}

	// RECUPERADO-AOT TriFoot::FixedUpdate token 0x060005a5 @0x0011c0b0
	// Full test every physics step; the reduced mode only tracks the highest ground under the kart
	// (the three-foot test then runs from GimpedTrifootCoroutine at 30 Hz).
	// ADAPTADO-U6: RaycastHit.collider as in U4 (same API).
	private void FixedUpdate()
	{
		if (QualityControl.DoFullTriFoot)
		{
			TriFootTest();
			return;
		}
		RaycastHit[] array = Physics.RaycastAll(base.transform.position + Vector3.up * 2f, Vector3.down, float.PositiveInfinity, castMask);
		Vector3 vector = new Vector3(0f, float.NegativeInfinity, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit raycastHit = array[i];
			if (!(raycastHit.collider.gameObject == base.gameObject) && raycastHit.point.y > vector.y + 0.1f)
			{
				vector = raycastHit.point;
				groundPoint = raycastHit.point;
			}
		}
	}

	// RECUPERADO-AOT TriFoot::GimpedTrifootCoroutine token 0x060005a6 @0x0011c3bc
	// RECUPERADO-AOT TriFoot/<GimpedTrifootCoroutine>c__Iterator4A::MoveNext token 0x06000990 @0x00150c78
	[DebuggerHidden]
	private IEnumerator GimpedTrifootCoroutine()
	{
		while (true)
		{
			TriFootTest();
			yield return new WaitForSeconds(0.03333f);
		}
	}

	// RECUPERADO-AOT TriFoot::OnDrawGizmos token 0x060005a7 @0x0011c404 (empty in the original)
	private void OnDrawGizmos()
	{
	}
}
