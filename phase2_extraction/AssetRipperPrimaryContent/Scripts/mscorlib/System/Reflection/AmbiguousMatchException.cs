using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	[Serializable]
	[ComVisible(true)]
	public sealed class AmbiguousMatchException : SystemException
	{
		public AmbiguousMatchException()
		{
		}

		public AmbiguousMatchException(string message)
		{
		}

		internal AmbiguousMatchException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
