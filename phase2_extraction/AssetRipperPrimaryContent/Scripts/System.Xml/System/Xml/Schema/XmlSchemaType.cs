using System.Xml.Serialization;

namespace System.Xml.Schema
{
	public class XmlSchemaType : XmlSchemaAnnotated
	{
		private XmlSchemaDerivationMethod final;

		private bool isMixed;

		private string name;

		private bool recursed;

		internal XmlQualifiedName BaseSchemaTypeName;

		internal XmlSchemaType BaseXmlSchemaTypeInternal;

		internal XmlSchemaDatatype DatatypeInternal;

		internal XmlSchemaDerivationMethod resolvedDerivedBy;

		internal XmlSchemaDerivationMethod finalResolved;

		internal XmlQualifiedName QNameInternal;

		[XmlIgnore]
		public XmlQualifiedName QualifiedName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[System.MonoTODO]
		public static XmlSchemaSimpleType GetBuiltInSimpleType(XmlQualifiedName qualifiedName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
