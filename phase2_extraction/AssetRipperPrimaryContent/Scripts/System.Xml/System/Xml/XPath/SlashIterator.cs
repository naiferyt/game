using System.Collections;

namespace System.Xml.XPath
{
	internal class SlashIterator : BaseIterator
	{
		private BaseIterator _iterLeft;

		private BaseIterator _iterRight;

		private NodeSet _expr;

		private SortedList _iterList;

		private bool _finished;

		private BaseIterator _nextIterRight;

		public override XPathNavigator Current
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public SlashIterator(BaseIterator iter, NodeSet expr)
		{
		}

		private SlashIterator(SlashIterator other)
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
