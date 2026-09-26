namespace System.Xml.Schema
{
	public class XmlSchemaAnnotation : XmlSchemaObject
	{
		private const string xmlname = "annotation";

		private string id;

		private XmlSchemaObjectCollection items;

		private XmlAttribute[] unhandledAttributes;
	}
}
