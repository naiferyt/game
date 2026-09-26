using System.Collections;

namespace System.Xml.Schema
{
	public class XmlSchemaElement : XmlSchemaParticle
	{
		private const string xmlname = "element";

		private XmlSchemaDerivationMethod block;

		private XmlSchemaObjectCollection constraints;

		private string defaultValue;

		private object elementType;

		private XmlSchemaType elementSchemaType;

		private XmlSchemaDerivationMethod final;

		private string fixedValue;

		private XmlSchemaForm form;

		private bool isAbstract;

		private bool isNillable;

		private string name;

		private XmlQualifiedName refName;

		private XmlSchemaType schemaType;

		private XmlQualifiedName schemaTypeName;

		private XmlQualifiedName substitutionGroup;

		private XmlSchema schema;

		internal bool parentIsSchema;

		private XmlQualifiedName qName;

		private XmlSchemaDerivationMethod blockResolved;

		private XmlSchemaDerivationMethod finalResolved;

		private XmlSchemaElement referencedElement;

		private ArrayList substitutingElements;

		private XmlSchemaElement substitutionGroupElement;

		private bool actualIsAbstract;

		private bool actualIsNillable;

		private string validatedDefaultValue;

		private string validatedFixedValue;
	}
}
