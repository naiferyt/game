using System.Runtime.Serialization;

namespace System.Xml.XPath
{
	[Serializable]
	public class XPathException : SystemException
	{
		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XPathException()
		{
		}

		protected XPathException(SerializationInfo info, StreamingContext context)
		{
		}

		public XPathException(string message, Exception innerException)
		{
		}

		public XPathException(string message)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
