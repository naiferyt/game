namespace System.Xml.Serialization
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.ReturnValue)]
	public class XmlRootAttribute : Attribute
	{
		private string dataType;

		private string elementName;

		private bool isNullable;

		private bool isNullableSpecified;

		private string ns;

		public string Namespace
		{
			set
			{
			}
		}

		public XmlRootAttribute(string elementName)
		{
		}
	}
}
