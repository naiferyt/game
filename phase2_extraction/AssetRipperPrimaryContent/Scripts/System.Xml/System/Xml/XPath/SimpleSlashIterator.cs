namespace System.Xml.XPath
{
	internal class SimpleSlashIterator : BaseIterator
	{
		private NodeSet _expr;

		private BaseIterator _left;

		private BaseIterator _right;

		private XPathNavigator _current;

		public override XPathNavigator Current
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public SimpleSlashIterator(BaseIterator left, NodeSet expr)
		{
		}

		private SimpleSlashIterator(SimpleSlashIterator other)
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
