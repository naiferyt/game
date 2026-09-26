using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	[Serializable]
	[ComVisible(true)]
	public class SynchronizationLockException : SystemException
	{
		public SynchronizationLockException()
		{
		}

		public SynchronizationLockException(string message)
		{
		}

		protected SynchronizationLockException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
