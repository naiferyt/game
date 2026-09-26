namespace System.Xml.Xsl
{
	public interface IXsltContextVariable
	{
		object Evaluate(XsltContext xsltContext);
	}
}
