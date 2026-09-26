namespace System.Xml
{
	public interface IXmlNamespaceResolver
	{
		string LookupNamespace(string prefix);

		string LookupPrefix(string ns);
	}
}
