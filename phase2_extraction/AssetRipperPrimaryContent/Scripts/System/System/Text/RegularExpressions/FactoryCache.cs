using System.Collections;

namespace System.Text.RegularExpressions
{
	internal class FactoryCache
	{
		private class Key
		{
			public string pattern;

			public RegexOptions options;

			public Key(string pattern, RegexOptions options)
			{
			}

			public override int GetHashCode()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override bool Equals(object o)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override string ToString()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private int capacity;

		private Hashtable factories;

		private MRUList mru_list;

		public FactoryCache(int capacity)
		{
		}

		public void Add(string pattern, RegexOptions options, IMachineFactory factory)
		{
		}

		private void Cleanup()
		{
		}

		public IMachineFactory Lookup(string pattern, RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
