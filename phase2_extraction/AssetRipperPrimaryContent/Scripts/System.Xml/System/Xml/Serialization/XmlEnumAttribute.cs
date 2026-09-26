namespace System.Xml.Serialization
{
	[AttributeUsage(AttributeTargets.Field)]
	public class XmlEnumAttribute : Attribute
	{
		private string name;

		public XmlEnumAttribute(string name)
		{
		}
	}
}
