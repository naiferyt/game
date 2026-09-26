using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices
{
	[MonoTODO("Struct should be [StructLayout(LayoutKind.Sequential)] but will need to be reordered for that.")]
	[ComVisible(true)]
	public struct GCHandle
	{
		private int handle;

		public bool IsAllocated
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public object Target
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private GCHandle(object value, GCHandleType type)
		{
		}

		public static GCHandle Alloc(object value, GCHandleType type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Free()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetTarget(int handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetTargetHandle(object obj, int handle, GCHandleType type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FreeHandle(int handle);

		public override bool Equals(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
