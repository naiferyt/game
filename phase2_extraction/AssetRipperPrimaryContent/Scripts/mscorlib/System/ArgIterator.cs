using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
	[StructLayout((LayoutKind)3)]
	public struct ArgIterator
	{
		private IntPtr sig;

		private IntPtr args;

		private int next_arg;

		private int num_args;

		public ArgIterator(RuntimeArgumentHandle arglist)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Setup(IntPtr argsp, IntPtr start);

		public override bool Equals(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public TypedReference GetNextArg()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern TypedReference IntGetNextArg();

		public int GetRemainingCount()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
