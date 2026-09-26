namespace System.Xml
{
	internal class XmlNameEntry
	{
		public string Prefix;

		public string LocalName;

		public string NS;

		public int Hash;

		private string prefixed_name_cache;

		public XmlNameEntry(string prefix, string local, string ns)
		{
		}

		public void Update(string prefix, string local, string ns)
		{
		}

		public override bool Equals(object other)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetPrefixedName(XmlNameEntryCache owner)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
