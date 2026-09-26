using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	[Serializable]
	[ComVisible(true)]
	public sealed class ThreadAbortException : SystemException
	{
		private ThreadAbortException()
		{
		}

		private ThreadAbortException(SerializationInfo info, StreamingContext sc)
		{
		}
	}
}
