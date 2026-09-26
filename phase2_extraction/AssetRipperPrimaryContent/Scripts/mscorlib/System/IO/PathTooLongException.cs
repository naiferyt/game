using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class PathTooLongException : IOException
	{
		public PathTooLongException()
		{
		}

		public PathTooLongException(string message)
		{
		}

		protected PathTooLongException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
