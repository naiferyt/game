using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class InvalidOperationException : SystemException
	{
		private const int Result = -2146233079;

		public InvalidOperationException()
		{
		}

		public InvalidOperationException(string message)
		{
		}

		public InvalidOperationException(string message, Exception innerException)
		{
		}

		protected InvalidOperationException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
