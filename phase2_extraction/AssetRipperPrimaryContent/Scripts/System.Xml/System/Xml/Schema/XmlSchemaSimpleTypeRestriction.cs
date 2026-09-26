using System.Globalization;
using System.Text.RegularExpressions;

namespace System.Xml.Schema
{
	public class XmlSchemaSimpleTypeRestriction : XmlSchemaSimpleTypeContent
	{
		private const string xmlname = "restriction";

		private XmlSchemaSimpleType baseType;

		private XmlQualifiedName baseTypeName;

		private XmlSchemaObjectCollection facets;

		private string[] enumarationFacetValues;

		private string[] patternFacetValues;

		private Regex[] rexPatterns;

		private decimal lengthFacet;

		private decimal maxLengthFacet;

		private decimal minLengthFacet;

		private decimal fractionDigitsFacet;

		private decimal totalDigitsFacet;

		private object maxInclusiveFacet;

		private object maxExclusiveFacet;

		private object minInclusiveFacet;

		private object minExclusiveFacet;

		private XmlSchemaFacet.Facet fixedFacets;

		private static NumberStyles lengthStyle;

		private static readonly XmlSchemaFacet.Facet listFacets;
	}
}
