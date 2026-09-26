using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.IO.IsolatedStorage
{
	[Serializable]
	[ComVisible(true)]
	public class IsolatedStorageException : Exception
	{
		public IsolatedStorageException()
		{
		}

		public IsolatedStorageException(string message)
		{
		}

		protected IsolatedStorageException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
