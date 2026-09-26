using System.Xml.Xsl;

namespace System.Xml.XPath
{
	public abstract class XPathExpression
	{
		internal XPathExpression()
		{
		}

		public abstract void SetContext(XmlNamespaceManager nsManager);

		public static XPathExpression Compile(string xpath)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static XPathExpression Compile(string xpath, IXmlNamespaceResolver nsmgr, IStaticXsltContext ctx)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract void SetContext(IXmlNamespaceResolver nsResolver);
	}
}
