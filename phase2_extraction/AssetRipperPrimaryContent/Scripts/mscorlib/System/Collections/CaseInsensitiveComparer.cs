using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Collections
{
	[Serializable]
	[ComVisible(true)]
	public class CaseInsensitiveComparer : IComparer
	{
		private static CaseInsensitiveComparer defaultComparer;

		private static CaseInsensitiveComparer defaultInvariantComparer;

		private CultureInfo culture;

		public static CaseInsensitiveComparer Default
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static CaseInsensitiveComparer DefaultInvariant
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public CaseInsensitiveComparer()
		{
		}

		private CaseInsensitiveComparer(bool invariant)
		{
		}

		public int Compare(object a, object b)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
