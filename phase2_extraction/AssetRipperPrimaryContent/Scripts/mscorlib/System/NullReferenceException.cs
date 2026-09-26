using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class NullReferenceException : SystemException
	{
		private const int Result = -2147467261;

		public NullReferenceException()
		{
		}

		public NullReferenceException(string message)
		{
		}

		public NullReferenceException(string message, Exception innerException)
		{
		}

		protected NullReferenceException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
