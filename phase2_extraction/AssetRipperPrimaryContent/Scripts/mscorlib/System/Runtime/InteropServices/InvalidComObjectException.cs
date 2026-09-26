using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	[Serializable]
	[ComVisible(true)]
	public class InvalidComObjectException : SystemException
	{
		private const int ErrorCode = -2146233049;

		public InvalidComObjectException()
		{
		}

		public InvalidComObjectException(string message)
		{
		}

		protected InvalidComObjectException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
