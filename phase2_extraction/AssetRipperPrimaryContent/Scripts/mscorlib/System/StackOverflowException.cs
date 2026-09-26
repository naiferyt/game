using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public sealed class StackOverflowException : SystemException
	{
		public StackOverflowException()
		{
		}

		public StackOverflowException(string message)
		{
		}

		public StackOverflowException(string message, Exception innerException)
		{
		}

		internal StackOverflowException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
