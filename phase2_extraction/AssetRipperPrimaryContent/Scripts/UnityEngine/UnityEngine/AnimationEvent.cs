using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	[StructLayout((LayoutKind)0)]
	public sealed class AnimationEvent
	{
		[NotRenamed]
		internal IntPtr m_Ptr;

		private int m_OwnsData;

		~AnimationEvent()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void Destroy();
	}
}
