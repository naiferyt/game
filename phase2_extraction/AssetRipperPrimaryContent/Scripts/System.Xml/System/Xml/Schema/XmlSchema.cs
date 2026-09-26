using System.Xml.Serialization;

namespace System.Xml.Schema
{
	[XmlRoot("schema", Namespace = "http://www.w3.org/2001/XMLSchema")]
	public class XmlSchema : XmlSchemaObject
	{
		public const string Namespace = "http://www.w3.org/2001/XMLSchema";

		public const string InstanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";

		internal const string XdtNamespace = "http://www.w3.org/2003/11/xpath-datatypes";

		private const string xmlname = "schema";

		private XmlSchemaForm attributeFormDefault;

		private XmlSchemaObjectTable attributeGroups;

		private XmlSchemaObjectTable attributes;

		private XmlSchemaDerivationMethod blockDefault;

		private XmlSchemaForm elementFormDefault;

		private XmlSchemaObjectTable elements;

		private XmlSchemaDerivationMethod finalDefault;

		private XmlSchemaObjectTable groups;

		private string id;

		private XmlSchemaObjectCollection includes;

		private XmlSchemaObjectCollection items;

		private XmlSchemaObjectTable notations;

		private XmlSchemaObjectTable schemaTypes;

		private string targetNamespace;

		private XmlAttribute[] unhandledAttributes;

		private string version;

		private XmlSchemaSet schemas;

		private XmlNameTable nameTable;

		internal bool missedSubComponents;

		private XmlSchemaObjectCollection compilationItems;
	}
}
