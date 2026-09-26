namespace System.Xml.XPath
{
	internal class CompiledExpression : XPathExpression
	{
		protected IXmlNamespaceResolver _nsm;

		protected Expression _expr;

		private XPathSorters _sorters;

		private string rawExpression;

		internal IXmlNamespaceResolver NamespaceManager
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public CompiledExpression(string raw, Expression expr)
		{
		}

		public override void SetContext(XmlNamespaceManager nsManager)
		{
		}

		public override void SetContext(IXmlNamespaceResolver nsResolver)
		{
		}

		public XPathNodeIterator EvaluateNodeSet(BaseIterator iter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
