using System.Globalization;

namespace System
{
	[Serializable]
	internal sealed class CultureAwareComparer : StringComparer
	{
		private readonly bool _ignoreCase;

		private readonly CompareInfo _compareInfo;

		public CultureAwareComparer(CultureInfo ci, bool ignore_case)
		{
		}

		public override int Compare(string x, string y)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(string x, string y)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode(string s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
