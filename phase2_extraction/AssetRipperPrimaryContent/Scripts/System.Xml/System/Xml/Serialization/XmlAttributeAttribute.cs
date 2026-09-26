using System.Xml.Schema;

namespace System.Xml.Serialization
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
	public class XmlAttributeAttribute : Attribute
	{
		private string attributeName;

		private string dataType;

		private Type type;

		private XmlSchemaForm form;

		private string ns;

		public XmlAttributeAttribute(string attributeName)
		{
		}
	}
}
