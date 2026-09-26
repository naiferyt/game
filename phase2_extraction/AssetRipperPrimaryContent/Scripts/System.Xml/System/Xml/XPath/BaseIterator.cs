namespace System.Xml.XPath
{
	internal abstract class BaseIterator : XPathNodeIterator
	{
		private IXmlNamespaceResolver _nsm;

		private int position;

		public IXmlNamespaceResolver NamespaceManager
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool ReverseAxis
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int ComparablePosition
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override int CurrentPosition
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal BaseIterator(BaseIterator other)
		{
		}

		internal BaseIterator(IXmlNamespaceResolver nsm)
		{
		}

		internal void SetPosition(int pos)
		{
		}

		public override bool MoveNext()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract bool MoveNextCore();

		internal XPathNavigator PeekNext()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
