using System;
using UnityEngine;

// Racing-line chain (tag "SpeedPoint") used by the AI and catch-up logic; works on the flat (xz) plane.
// Source listing: recovery/aot_listings/Assembly-CSharp/SpeedPoint.txt
public class SpeedPoint : MonoBehaviour
{
	[Serializable]
	public class SpeedBranchStruct
	{
		public SpeedPoint target;

		public float weight;
	}

	public SpeedPoint forwardPoint;

	public SpeedPoint backwardPoint;

	// RECUPERADO-AOT SpeedPoint::.ctor token 0x06000570 @0x00114ef0 (field initializer)
	public SpeedBranchStruct[] branches = new SpeedBranchStruct[0];

	// RECUPERADO-AOT SpeedPoint::ProjectOnSPLine token 0x06000571 @0x00114f44
	private bool ProjectOnSPLine(SpeedPoint otherPoint, Vector3 pos, out Vector3 projPoint)
	{
		Vector3 vector = otherPoint.transform.position - base.transform.position;
		Vector3 rhs = pos - base.transform.position;
		vector.y = 0f;
		rhs.y = 0f;
		float num = Vector3.Dot(vector.normalized, rhs);
		if (num + 0.001f < 0f || !(vector.magnitude >= num - 0.001f))
		{
			projPoint = Vector3.zero;
			return false;
		}
		projPoint = new Vector3(base.transform.position.x, 0f, base.transform.position.z) + vector.normalized * num;
		return true;
	}

	// RECUPERADO-AOT SpeedPoint::GetSPLinePoint token 0x06000572 @0x0011530c
	public Vector3 GetSPLinePoint(Vector3 pos)
	{
		pos.y = 0f;
		Vector3 result = base.transform.position;
		result.y = 0f;
		float num = (base.transform.position - pos).sqrMagnitude;
		Vector3 projPoint;
		if (forwardPoint != null && ProjectOnSPLine(forwardPoint, pos, out projPoint))
		{
			float sqrMagnitude = (projPoint - pos).sqrMagnitude;
			if (!(num < sqrMagnitude))
			{
				result = projPoint;
				num = sqrMagnitude;
			}
		}
		Vector3 projPoint2;
		if (backwardPoint != null && ProjectOnSPLine(backwardPoint, pos, out projPoint2))
		{
			float sqrMagnitude2 = (projPoint2 - pos).sqrMagnitude;
			if (!(num < sqrMagnitude2))
			{
				result = projPoint2;
			}
		}
		return result;
	}

	// RECUPERADO-AOT SpeedPoint::GetSPLine token 0x06000573 @0x0011570c
	public Vector3 GetSPLine()
	{
		return forwardPoint.transform.position - base.transform.position;
	}

	// RECUPERADO-AOT SpeedPoint::IsPointForward token 0x06000574 @0x001157c8
	public bool IsPointForward(Vector3 point)
	{
		Vector3 rhs = point - base.transform.position;
		return Vector3.Dot(GetSPLine().normalized, rhs) > 0.6f;
	}

	// RECUPERADO-AOT SpeedPoint::FindClosestSpeedPoint token 0x06000575 @0x001158d4
	public static SpeedPoint FindClosestSpeedPoint(Vector3 pos)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("SpeedPoint");
		GameObject gameObject = null;
		float num = 0f;
		foreach (GameObject gameObject2 in array)
		{
			float sqrMagnitude = (gameObject2.transform.position - pos).sqrMagnitude;
			if (gameObject == null || sqrMagnitude < num)
			{
				gameObject = gameObject2;
				num = sqrMagnitude;
			}
		}
		if (gameObject != null)
		{
			return gameObject.GetComponent<SpeedPoint>();
		}
		return null;
	}

	// RECUPERADO-AOT SpeedPoint::OnDrawGizmos token 0x06000576 @0x00115a84
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(base.transform.position, 0.75f);
		if (forwardPoint != null)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(base.transform.position, forwardPoint.transform.position);
		}
		if (backwardPoint != null)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(base.transform.position, backwardPoint.transform.position);
		}
	}
}
