using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class BoxCollider : Collider
	{
		public Vector3 center
		{
			set
			{
			}
		}

		public Vector3 size
		{
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void INTERNAL_set_center(ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void INTERNAL_set_size(ref Vector3 value);
	}
}
