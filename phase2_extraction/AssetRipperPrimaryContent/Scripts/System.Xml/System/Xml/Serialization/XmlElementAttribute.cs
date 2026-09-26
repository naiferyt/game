using System.Xml.Schema;

namespace System.Xml.Serialization
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
	public class XmlElementAttribute : Attribute
	{
		private string dataType;

		private string elementName;

		private XmlSchemaForm form;

		private string ns;

		private bool isNullable;

		private bool isNullableSpecified;

		private Type type;

		private int order;

		public Type Type
		{
			set
			{
			}
		}

		public XmlElementAttribute(string elementName)
		{
		}

		public XmlElementAttribute(string elementName, Type type)
		{
		}
	}
}
