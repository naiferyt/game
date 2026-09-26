using System.Xml.XPath;

namespace System.Xml.Xsl
{
	public abstract class XsltContext : XmlNamespaceManager
	{
		public abstract IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] argTypes);

		public abstract IXsltContextVariable ResolveVariable(string prefix, string name);

		internal virtual IXsltContextVariable ResolveVariable(XmlQualifiedName name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal virtual IXsltContextFunction ResolveFunction(XmlQualifiedName name, XPathResultType[] argTypes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
