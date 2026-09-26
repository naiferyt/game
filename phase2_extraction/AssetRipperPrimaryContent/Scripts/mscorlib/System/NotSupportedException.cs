using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class NotSupportedException : SystemException
	{
		private const int Result = -2146233067;

		public NotSupportedException()
		{
		}

		public NotSupportedException(string message)
		{
		}

		protected NotSupportedException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
