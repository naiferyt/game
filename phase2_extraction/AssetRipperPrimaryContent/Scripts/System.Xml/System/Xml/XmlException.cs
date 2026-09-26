using System.Runtime.Serialization;

namespace System.Xml
{
	[Serializable]
	public class XmlException : SystemException
	{
		private const string Xml_DefaultException = "Xml_DefaultException";

		private const string Xml_UserException = "Xml_UserException";

		private int lineNumber;

		private int linePosition;

		private string sourceUri;

		private string res;

		private string[] messages;

		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlException()
		{
		}

		public XmlException(string message, Exception innerException)
		{
		}

		protected XmlException(SerializationInfo info, StreamingContext context)
		{
		}

		public XmlException(string message)
		{
		}

		internal XmlException(IXmlLineInfo li, string sourceUri, string message)
		{
		}

		internal XmlException(IXmlLineInfo li, Exception innerException, string sourceUri, string message)
		{
		}

		public XmlException(string message, Exception innerException, int lineNumber, int linePosition)
		{
		}

		internal XmlException(string message, int lineNumber, int linePosition, object sourceObject, string sourceUri, Exception innerException)
		{
		}

		private static string GetMessage(string message, string sourceUri, int lineNumber, int linePosition, object sourceObj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
