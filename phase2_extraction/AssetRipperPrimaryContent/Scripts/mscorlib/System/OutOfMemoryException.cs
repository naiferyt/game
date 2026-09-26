using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class OutOfMemoryException : SystemException
	{
		private const int Result = -2147024882;

		public OutOfMemoryException()
		{
		}

		public OutOfMemoryException(string message)
		{
		}

		public OutOfMemoryException(string message, Exception innerException)
		{
		}

		protected OutOfMemoryException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
