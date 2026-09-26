using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class DirectoryNotFoundException : IOException
	{
		public DirectoryNotFoundException()
		{
		}

		public DirectoryNotFoundException(string message)
		{
		}

		protected DirectoryNotFoundException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
