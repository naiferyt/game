using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class DllNotFoundException : TypeLoadException
	{
		private const int Result = -2146233052;

		public DllNotFoundException()
		{
		}

		public DllNotFoundException(string message)
		{
		}

		protected DllNotFoundException(SerializationInfo info, StreamingContext context)
		{
		}

		public DllNotFoundException(string message, Exception inner)
		{
		}
	}
}
