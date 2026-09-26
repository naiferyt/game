using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class AppDomainUnloadedException : SystemException
	{
		private const int Result = -2146234348;

		public AppDomainUnloadedException()
		{
		}

		public AppDomainUnloadedException(string message)
		{
		}

		public AppDomainUnloadedException(string message, Exception innerException)
		{
		}

		protected AppDomainUnloadedException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
