namespace System.Xml
{
	public class NameTable : XmlNameTable
	{
		private class Entry
		{
			public string str;

			public int hash;

			public int len;

			public Entry next;

			public Entry(string str, int hash, Entry next)
			{
			}
		}

		private const int INITIAL_BUCKETS = 128;

		private int count;

		private Entry[] buckets;

		private int size;

		public override string Add(char[] key, int start, int len)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string Add(string key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string Get(string value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string AddEntry(string str, int hash)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool StrEqArray(string str, char[] str2, int start)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
