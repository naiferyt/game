namespace System.Xml.XPath
{
	internal abstract class SimpleIterator : BaseIterator
	{
		protected readonly XPathNavigator _nav;

		protected XPathNavigator _current;

		private bool skipfirst;

		public override XPathNavigator Current
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public SimpleIterator(BaseIterator iter)
		{
		}

		protected SimpleIterator(SimpleIterator other, bool clone)
		{
		}

		public SimpleIterator(XPathNavigator nav, IXmlNamespaceResolver nsm)
		{
		}

		public override bool MoveNext()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
