using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace System
{
	public static class GC
	{
		public static extern int MaxGeneration
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalCollect(int generation);

		public static void Collect()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern void SuppressFinalize(object obj);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void WaitForPendingFinalizers();
	}
}
