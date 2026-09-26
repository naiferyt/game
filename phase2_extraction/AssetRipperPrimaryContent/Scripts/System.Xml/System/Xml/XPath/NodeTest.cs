namespace System.Xml.XPath
{
	internal abstract class NodeTest : NodeSet
	{
		protected AxisSpecifier _axis;

		public AxisSpecifier Axis
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool RequireSorting
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal override bool Peer
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal override bool Subtree
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public NodeTest(Axes axis)
		{
		}

		public abstract bool Match(IXmlNamespaceResolver nsm, XPathNavigator nav);

		public override object Evaluate(BaseIterator iter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
