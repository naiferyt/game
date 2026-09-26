namespace UnityEngine
{
	public struct ContactPoint
	{
		internal Vector3 m_Point;

		internal Vector3 m_Normal;

		internal Collider m_ThisCollider;

		internal Collider m_OtherCollider;
	}
}
