using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public sealed class CharEnumerator : IEnumerator<char>, IEnumerator, ICloneable, IDisposable
	{
		private string str;

		private int index;

		private int length;

		object IEnumerator.Current
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public char Current
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal CharEnumerator(string s)
		{
		}

		void IDisposable.Dispose()
		{
		}

		public object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool MoveNext()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Reset()
		{
		}
	}
}
