using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class EntryPointNotFoundException : TypeLoadException
	{
		private const int Result = -2146233053;

		public EntryPointNotFoundException()
		{
		}

		public EntryPointNotFoundException(string message)
		{
		}

		protected EntryPointNotFoundException(SerializationInfo info, StreamingContext context)
		{
		}

		public EntryPointNotFoundException(string message, Exception inner)
		{
		}
	}
}
