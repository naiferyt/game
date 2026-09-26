using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	[Serializable]
	[ComVisible(true)]
	public class ThreadStateException : SystemException
	{
		public ThreadStateException()
		{
		}

		public ThreadStateException(string message)
		{
		}

		protected ThreadStateException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
