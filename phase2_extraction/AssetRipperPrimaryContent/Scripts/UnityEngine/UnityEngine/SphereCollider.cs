using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class SphereCollider : Collider
	{
		public extern float radius
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			get;
		}
	}
}
