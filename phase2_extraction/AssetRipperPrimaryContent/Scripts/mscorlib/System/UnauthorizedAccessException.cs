using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class UnauthorizedAccessException : SystemException
	{
		private const int Result = -2146233088;

		public UnauthorizedAccessException()
		{
		}

		public UnauthorizedAccessException(string message)
		{
		}

		protected UnauthorizedAccessException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
