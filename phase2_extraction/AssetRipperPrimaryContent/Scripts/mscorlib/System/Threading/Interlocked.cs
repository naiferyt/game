using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace System.Threading
{
	public static class Interlocked
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern int CompareExchange(ref int location1, int value, int comparand);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern int Increment(ref int location);
	}
}
