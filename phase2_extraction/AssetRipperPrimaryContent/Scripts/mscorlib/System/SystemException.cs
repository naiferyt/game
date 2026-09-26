using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class SystemException : Exception
	{
		private const int Result = -2146233087;

		public SystemException()
		{
		}

		public SystemException(string message)
		{
		}

		protected SystemException(SerializationInfo info, StreamingContext context)
		{
		}

		public SystemException(string message, Exception innerException)
		{
		}
	}
}
