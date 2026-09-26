using System.Xml.Serialization;

namespace System.Xml.Schema
{
	public class XmlSchemaSimpleTypeList : XmlSchemaSimpleTypeContent
	{
		private const string xmlname = "list";

		private XmlSchemaSimpleType itemType;

		private XmlQualifiedName itemTypeName;

		private object validatedListItemType;

		private XmlSchemaSimpleType validatedListItemSchemaType;

		[XmlAttribute("itemType")]
		public XmlQualifiedName ItemTypeName
		{
			set
			{
			}
		}

		[XmlElement("simpleType", Type = typeof(XmlSchemaSimpleType))]
		public XmlSchemaSimpleType ItemType
		{
			set
			{
			}
		}
	}
}
