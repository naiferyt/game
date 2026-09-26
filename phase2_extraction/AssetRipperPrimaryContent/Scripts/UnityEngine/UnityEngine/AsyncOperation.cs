using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	[StructLayout((LayoutKind)0)]
	public class AsyncOperation : YieldInstruction
	{
		[NotRenamed]
		internal IntPtr m_Ptr;

		public extern bool isDone
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void InternalDestroy();

		~AsyncOperation()
		{
		}
	}
}
