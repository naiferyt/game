using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Collections
{
	[Serializable]
	[ComVisible(true)]
	[Obsolete("Please use StringComparer instead.")]
	public class CaseInsensitiveHashCodeProvider : IHashCodeProvider
	{
		private static readonly CaseInsensitiveHashCodeProvider singletonInvariant;

		private static CaseInsensitiveHashCodeProvider singleton;

		private static readonly object sync;

		private TextInfo m_text;

		public static CaseInsensitiveHashCodeProvider Default
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static CaseInsensitiveHashCodeProvider DefaultInvariant
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public CaseInsensitiveHashCodeProvider()
		{
		}

		public CaseInsensitiveHashCodeProvider(CultureInfo culture)
		{
		}

		private static bool AreEqual(CultureInfo a, CultureInfo b)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool AreEqual(TextInfo info, CultureInfo culture)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int GetHashCode(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
