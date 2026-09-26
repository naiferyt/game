using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Collections
{
	[Serializable]
	[DebuggerDisplay("{_value}", Name = "[{_key}]")]
	[ComVisible(true)]
	public struct DictionaryEntry
	{
		private object _key;

		private object _value;

		public object Key
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public object Value
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DictionaryEntry(object key, object value)
		{
		}
	}
}
