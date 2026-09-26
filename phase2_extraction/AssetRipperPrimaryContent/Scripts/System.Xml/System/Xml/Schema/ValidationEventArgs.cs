namespace System.Xml.Schema
{
	public class ValidationEventArgs : EventArgs
	{
		private XmlSchemaException exception;

		private string message;

		private XmlSeverityType severity;
	}
}
