using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	[StructLayout((LayoutKind)0)]
	public sealed class Coroutine : YieldInstruction
	{
		internal IntPtr m_Ptr;

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void ReleaseCoroutine();

		~Coroutine()
		{
		}
	}
}
