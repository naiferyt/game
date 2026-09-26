namespace System.Xml.Schema
{
	public class XmlSchemaSimpleTypeUnion : XmlSchemaSimpleTypeContent
	{
		private const string xmlname = "union";

		private XmlSchemaObjectCollection baseTypes;

		private XmlQualifiedName[] memberTypes;

		private object[] validatedTypes;

		private XmlSchemaSimpleType[] validatedSchemaTypes;
	}
}
