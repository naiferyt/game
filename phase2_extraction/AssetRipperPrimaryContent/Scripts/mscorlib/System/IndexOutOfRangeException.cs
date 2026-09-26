using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public sealed class IndexOutOfRangeException : SystemException
	{
		public IndexOutOfRangeException()
		{
		}

		public IndexOutOfRangeException(string message)
		{
		}

		internal IndexOutOfRangeException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
