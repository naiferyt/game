using System.Text;
using Mono.Xml.Schema;

namespace System.Xml.Schema
{
	public abstract class XmlSchemaDatatype
	{
		internal XsdWhitespaceFacet WhitespaceValue;

		private static char[] wsChars;

		private StringBuilder sb;

		private static readonly XsdAnySimpleType datatypeAnySimpleType;

		private static readonly XsdString datatypeString;

		private static readonly XsdNormalizedString datatypeNormalizedString;

		private static readonly XsdToken datatypeToken;

		private static readonly XsdLanguage datatypeLanguage;

		private static readonly XsdNMToken datatypeNMToken;

		private static readonly XsdNMTokens datatypeNMTokens;

		private static readonly XsdName datatypeName;

		private static readonly XsdNCName datatypeNCName;

		private static readonly XsdID datatypeID;

		private static readonly XsdIDRef datatypeIDRef;

		private static readonly XsdIDRefs datatypeIDRefs;

		private static readonly XsdEntity datatypeEntity;

		private static readonly XsdEntities datatypeEntities;

		private static readonly XsdNotation datatypeNotation;

		private static readonly XsdDecimal datatypeDecimal;

		private static readonly XsdInteger datatypeInteger;

		private static readonly XsdLong datatypeLong;

		private static readonly XsdInt datatypeInt;

		private static readonly XsdShort datatypeShort;

		private static readonly XsdByte datatypeByte;

		private static readonly XsdNonNegativeInteger datatypeNonNegativeInteger;

		private static readonly XsdPositiveInteger datatypePositiveInteger;

		private static readonly XsdUnsignedLong datatypeUnsignedLong;

		private static readonly XsdUnsignedInt datatypeUnsignedInt;

		private static readonly XsdUnsignedShort datatypeUnsignedShort;

		private static readonly XsdUnsignedByte datatypeUnsignedByte;

		private static readonly XsdNonPositiveInteger datatypeNonPositiveInteger;

		private static readonly XsdNegativeInteger datatypeNegativeInteger;

		private static readonly XsdFloat datatypeFloat;

		private static readonly XsdDouble datatypeDouble;

		private static readonly XsdBase64Binary datatypeBase64Binary;

		private static readonly XsdBoolean datatypeBoolean;

		private static readonly XsdAnyURI datatypeAnyURI;

		private static readonly XsdDuration datatypeDuration;

		private static readonly XsdDateTime datatypeDateTime;

		private static readonly XsdDate datatypeDate;

		private static readonly XsdTime datatypeTime;

		private static readonly XsdHexBinary datatypeHexBinary;

		private static readonly XsdQName datatypeQName;

		private static readonly XsdGYearMonth datatypeGYearMonth;

		private static readonly XsdGMonthDay datatypeGMonthDay;

		private static readonly XsdGYear datatypeGYear;

		private static readonly XsdGMonth datatypeGMonth;

		private static readonly XsdGDay datatypeGDay;

		private static readonly XdtAnyAtomicType datatypeAnyAtomicType;

		private static readonly XdtUntypedAtomic datatypeUntypedAtomic;

		private static readonly XdtDayTimeDuration datatypeDayTimeDuration;

		private static readonly XdtYearMonthDuration datatypeYearMonthDuration;

		public abstract XmlTokenizedType TokenizedType { get; }

		internal static XmlSchemaDatatype FromName(XmlQualifiedName qname)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static XmlSchemaDatatype FromName(string localName, string ns)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
