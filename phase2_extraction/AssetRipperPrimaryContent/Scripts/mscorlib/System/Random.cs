using System.Runtime.InteropServices;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class Random
	{
		private const int MBIG = int.MaxValue;

		private const int MSEED = 161803398;

		private const int MZ = 0;

		private int inext;

		private int inextp;

		private int[] SeedArray;

		public Random()
		{
		}

		public Random(int Seed)
		{
		}

		protected virtual double Sample()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int Next()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
