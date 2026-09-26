using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace System
{
	public static class Math
	{
		public const double E = 2.718281828459045;

		public const double PI = 3.141592653589793;

		public static float Abs(float value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int Abs(int value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static long Abs(long value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static double Ceiling(double a)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Floor(double d);

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int Max(int val1, int val2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int Min(int val1, int val2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal Round(decimal d)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Round(double a);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Sin(double a);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Cos(double d);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Acos(double d);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Log(double d);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Pow(double x, double y);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static extern double Sqrt(double d);
	}
}
