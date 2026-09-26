using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class EndOfStreamException : IOException
	{
		public EndOfStreamException()
		{
		}

		protected EndOfStreamException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
