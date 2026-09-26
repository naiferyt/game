using System.Xml;
using System.Xml.Schema;

namespace Mono.Xml.Schema
{
	internal class XsdAnySimpleType : XmlSchemaDatatype
	{
		private static XsdAnySimpleType instance;

		private static readonly char[] whitespaceArray;

		internal static readonly XmlSchemaFacet.Facet booleanAllowedFacets;

		internal static readonly XmlSchemaFacet.Facet decimalAllowedFacets;

		internal static readonly XmlSchemaFacet.Facet durationAllowedFacets;

		internal static readonly XmlSchemaFacet.Facet stringAllowedFacets;

		public static XsdAnySimpleType Instance
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override XmlTokenizedType TokenizedType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected XsdAnySimpleType()
		{
		}

		static XsdAnySimpleType()
		{
		}
	}
}
