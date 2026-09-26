using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class InvalidCastException : SystemException
	{
		private const int Result = -2147467262;

		public InvalidCastException()
		{
		}

		public InvalidCastException(string message)
		{
		}

		protected InvalidCastException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
