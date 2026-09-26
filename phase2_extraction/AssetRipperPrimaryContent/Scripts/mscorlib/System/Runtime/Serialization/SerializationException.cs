using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	[Serializable]
	[ComVisible(true)]
	public class SerializationException : SystemException
	{
		public SerializationException()
		{
		}

		public SerializationException(string message)
		{
		}

		protected SerializationException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
