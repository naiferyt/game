using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	[Serializable]
	[ComVisible(true)]
	public struct StreamingContext
	{
		private StreamingContextStates state;

		private object additional;

		public object Context
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public StreamingContextStates State
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public StreamingContext(StreamingContextStates state)
		{
		}

		public StreamingContext(StreamingContextStates state, object additional)
		{
		}

		public override bool Equals(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
