using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	[Serializable]
	[ComVisible(true)]
	public class ExternalException : SystemException
	{
		public ExternalException()
		{
		}

		public ExternalException(string message)
		{
		}

		protected ExternalException(SerializationInfo info, StreamingContext context)
		{
		}

		public ExternalException(string message, int errorCode)
		{
		}
	}
}
