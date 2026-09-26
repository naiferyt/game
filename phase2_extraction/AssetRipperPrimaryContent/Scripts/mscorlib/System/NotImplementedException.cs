using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class NotImplementedException : SystemException
	{
		private const int Result = -2147467263;

		public NotImplementedException()
		{
		}

		public NotImplementedException(string message)
		{
		}

		public NotImplementedException(string message, Exception inner)
		{
		}

		protected NotImplementedException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
