using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace System.Threading
{
	[ComVisible(true)]
	public static class Monitor
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Enter(object obj);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern void Exit(object obj);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Monitor_pulse(object obj);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Monitor_test_synchronised(object obj);

		public static void Pulse(object obj)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Monitor_wait(object obj, int ms);

		public static bool Wait(object obj, int millisecondsTimeout)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
