using System.Xml.Serialization;

namespace System.Xml.Schema
{
	public class XmlSchemaSimpleType : XmlSchemaType
	{
		private const string xmlname = "simpleType";

		private static XmlSchemaSimpleType schemaLocationType;

		private XmlSchemaSimpleTypeContent content;

		internal bool islocal;

		private bool recursed;

		private XmlSchemaDerivationMethod variety;

		internal static readonly XmlSchemaSimpleType XsAnySimpleType;

		internal static readonly XmlSchemaSimpleType XsString;

		internal static readonly XmlSchemaSimpleType XsBoolean;

		internal static readonly XmlSchemaSimpleType XsDecimal;

		internal static readonly XmlSchemaSimpleType XsFloat;

		internal static readonly XmlSchemaSimpleType XsDouble;

		internal static readonly XmlSchemaSimpleType XsDuration;

		internal static readonly XmlSchemaSimpleType XsDateTime;

		internal static readonly XmlSchemaSimpleType XsTime;

		internal static readonly XmlSchemaSimpleType XsDate;

		internal static readonly XmlSchemaSimpleType XsGYearMonth;

		internal static readonly XmlSchemaSimpleType XsGYear;

		internal static readonly XmlSchemaSimpleType XsGMonthDay;

		internal static readonly XmlSchemaSimpleType XsGDay;

		internal static readonly XmlSchemaSimpleType XsGMonth;

		internal static readonly XmlSchemaSimpleType XsHexBinary;

		internal static readonly XmlSchemaSimpleType XsBase64Binary;

		internal static readonly XmlSchemaSimpleType XsAnyUri;

		internal static readonly XmlSchemaSimpleType XsQName;

		internal static readonly XmlSchemaSimpleType XsNotation;

		internal static readonly XmlSchemaSimpleType XsNormalizedString;

		internal static readonly XmlSchemaSimpleType XsToken;

		internal static readonly XmlSchemaSimpleType XsLanguage;

		internal static readonly XmlSchemaSimpleType XsNMToken;

		internal static readonly XmlSchemaSimpleType XsNMTokens;

		internal static readonly XmlSchemaSimpleType XsName;

		internal static readonly XmlSchemaSimpleType XsNCName;

		internal static readonly XmlSchemaSimpleType XsID;

		internal static readonly XmlSchemaSimpleType XsIDRef;

		internal static readonly XmlSchemaSimpleType XsIDRefs;

		internal static readonly XmlSchemaSimpleType XsEntity;

		internal static readonly XmlSchemaSimpleType XsEntities;

		internal static readonly XmlSchemaSimpleType XsInteger;

		internal static readonly XmlSchemaSimpleType XsNonPositiveInteger;

		internal static readonly XmlSchemaSimpleType XsNegativeInteger;

		internal static readonly XmlSchemaSimpleType XsLong;

		internal static readonly XmlSchemaSimpleType XsInt;

		internal static readonly XmlSchemaSimpleType XsShort;

		internal static readonly XmlSchemaSimpleType XsByte;

		internal static readonly XmlSchemaSimpleType XsNonNegativeInteger;

		internal static readonly XmlSchemaSimpleType XsUnsignedLong;

		internal static readonly XmlSchemaSimpleType XsUnsignedInt;

		internal static readonly XmlSchemaSimpleType XsUnsignedShort;

		internal static readonly XmlSchemaSimpleType XsUnsignedByte;

		internal static readonly XmlSchemaSimpleType XsPositiveInteger;

		internal static readonly XmlSchemaSimpleType XdtUntypedAtomic;

		internal static readonly XmlSchemaSimpleType XdtAnyAtomicType;

		internal static readonly XmlSchemaSimpleType XdtYearMonthDuration;

		internal static readonly XmlSchemaSimpleType XdtDayTimeDuration;

		[XmlElement("union", typeof(XmlSchemaSimpleTypeUnion))]
		[XmlElement("restriction", typeof(XmlSchemaSimpleTypeRestriction))]
		[XmlElement("list", typeof(XmlSchemaSimpleTypeList))]
		public XmlSchemaSimpleTypeContent Content
		{
			set
			{
			}
		}

		static XmlSchemaSimpleType()
		{
		}

		private static XmlSchemaSimpleType BuildSchemaType(string name, string baseName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static XmlSchemaSimpleType BuildSchemaType(string name, string baseName, bool xdt, bool baseXdt)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
