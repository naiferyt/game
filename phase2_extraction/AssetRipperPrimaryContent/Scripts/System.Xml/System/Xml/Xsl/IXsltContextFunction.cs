using System.Xml.XPath;

namespace System.Xml.Xsl
{
	public interface IXsltContextFunction
	{
		XPathResultType[] ArgTypes { get; }

		int Maxargs { get; }

		object Invoke(XsltContext xsltContext, object[] args, XPathNavigator docContext);
	}
}
