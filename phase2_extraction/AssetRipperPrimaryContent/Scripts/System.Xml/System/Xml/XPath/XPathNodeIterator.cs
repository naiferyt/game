using System.Collections;
using System.Diagnostics;

namespace System.Xml.XPath
{
	public abstract class XPathNodeIterator : IEnumerable, ICloneable
	{
		private int _count;

		public virtual int Count
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract XPathNavigator Current { get; }

		public abstract int CurrentPosition { get; }

		object ICloneable.Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract XPathNodeIterator Clone();

		[DebuggerHidden]
		public virtual IEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract bool MoveNext();
	}
}
