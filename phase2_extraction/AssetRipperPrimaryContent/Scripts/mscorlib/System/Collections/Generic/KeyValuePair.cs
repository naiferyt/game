using System.Diagnostics;

namespace System.Collections.Generic
{
	[Serializable]
	[DebuggerDisplay("{value}", Name = "[{key}]")]
	public struct KeyValuePair<TKey, TValue>
	{
		private TKey key;

		private TValue value;

		public TKey Key
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			private set
			{
			}
		}

		public TValue Value
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			private set
			{
			}
		}

		public KeyValuePair(TKey key, TValue value)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
