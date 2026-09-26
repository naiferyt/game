namespace System.Xml.XPath
{
	internal class UnionIterator : BaseIterator
	{
		private BaseIterator _left;

		private BaseIterator _right;

		private bool keepLeft;

		private bool keepRight;

		private XPathNavigator _current;

		public override XPathNavigator Current
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public UnionIterator(BaseIterator iter, BaseIterator left, BaseIterator right)
		{
		}

		private UnionIterator(UnionIterator other)
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

		private void SetCurrent(XPathNodeIterator iter)
		{
		}
	}
}
