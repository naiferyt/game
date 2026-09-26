using System.Runtime.InteropServices;

namespace UnityEngine
{
	[StructLayout((LayoutKind)0)]
	public class Collision
	{
		internal Vector3 m_RelativeVelocity;

		internal Rigidbody m_Rigidbody;

		internal Collider m_Collider;

		internal ContactPoint[] m_Contacts;

		public Collider collider
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}
	}
}
