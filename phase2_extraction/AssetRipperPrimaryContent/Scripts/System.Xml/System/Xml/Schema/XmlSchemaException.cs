using System.Runtime.Serialization;

namespace System.Xml.Schema
{
	[Serializable]
	public class XmlSchemaException : SystemException
	{
		private bool hasLineInfo;

		private int lineNumber;

		private int linePosition;

		private XmlSchemaObject sourceObj;

		private string sourceUri;

		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlSchemaException()
		{
		}

		protected XmlSchemaException(SerializationInfo info, StreamingContext context)
		{
		}

		public XmlSchemaException(string message, Exception innerException)
		{
		}

		private static string GetMessage(string message, string sourceUri, int lineNumber, int linePosition, XmlSchemaObject sourceObj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
