namespace System.Xml.Schema
{
	public class XmlSchemaAttribute : XmlSchemaAnnotated
	{
		private const string xmlname = "attribute";

		private object attributeType;

		private XmlSchemaSimpleType attributeSchemaType;

		private string defaultValue;

		private string fixedValue;

		private string validatedDefaultValue;

		private string validatedFixedValue;

		private object validatedFixedTypedValue;

		private XmlSchemaForm form;

		private string name;

		private string targetNamespace;

		private XmlQualifiedName qualifiedName;

		private XmlQualifiedName refName;

		private XmlSchemaSimpleType schemaType;

		private XmlQualifiedName schemaTypeName;

		private XmlSchemaUse use;

		private XmlSchemaUse validatedUse;

		private XmlSchemaAttribute referencedAttribute;
	}
}
