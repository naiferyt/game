namespace System.Xml.XPath
{
	internal class PredicateIterator : BaseIterator
	{
		private BaseIterator _iter;

		private Expression _pred;

		private XPathResultType resType;

		private bool finished;

		public override XPathNavigator Current
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool ReverseAxis
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public PredicateIterator(BaseIterator iter, Expression pred)
		{
		}

		private PredicateIterator(PredicateIterator other)
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

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
