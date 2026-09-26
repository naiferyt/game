namespace System.Xml.Schema
{
	public abstract class XmlSchemaParticle : XmlSchemaAnnotated
	{
		private decimal minOccurs;

		private decimal maxOccurs;

		private string minstr;

		private string maxstr;

		private static XmlSchemaParticle empty;

		private decimal validatedMinOccurs;

		private decimal validatedMaxOccurs;

		internal int recursionDepth;

		private decimal minEffectiveTotalRange;

		internal bool parentIsGroupDefinition;

		internal XmlSchemaParticle OptimizedParticle;
	}
}
