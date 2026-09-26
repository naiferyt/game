using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public abstract class StringComparer : IComparer<string>, IEqualityComparer<string>, IComparer, IEqualityComparer
	{
		private static StringComparer invariantCultureIgnoreCase;

		private static StringComparer invariantCulture;

		private static StringComparer ordinalIgnoreCase;

		private static StringComparer ordinal;

		public static StringComparer OrdinalIgnoreCase
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int Compare(object x, object y)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public new bool Equals(object x, object y)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int GetHashCode(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract int Compare(string x, string y);

		public abstract bool Equals(string x, string y);

		public abstract int GetHashCode(string obj);
	}
}
