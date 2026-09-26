using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class ApplicationException : Exception
	{
		private const int Result = -2146232832;

		public ApplicationException()
		{
		}

		public ApplicationException(string message)
		{
		}

		protected ApplicationException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
