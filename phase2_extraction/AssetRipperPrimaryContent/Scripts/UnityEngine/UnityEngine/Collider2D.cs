using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public class Collider2D : Behaviour
	{
		public extern Rigidbody2D attachedRigidbody
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			get;
		}
	}
}
