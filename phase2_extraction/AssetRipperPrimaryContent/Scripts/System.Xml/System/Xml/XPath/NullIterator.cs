namespace System.Xml.XPath
{
	internal class NullIterator : SelfIterator
	{
		public override int CurrentPosition
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override XPathNavigator Current
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public NullIterator(BaseIterator iter)
		{
		}

		public NullIterator(XPathNavigator nav, IXmlNamespaceResolver nsm)
		{
		}

		private NullIterator(NullIterator other)
		{
		}

		public override XPathNodeIterator Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool MoveNextCore()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
