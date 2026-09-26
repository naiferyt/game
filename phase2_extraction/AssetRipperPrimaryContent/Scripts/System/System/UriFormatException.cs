using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	public class UriFormatException : FormatException, ISerializable
	{
		public UriFormatException()
		{
		}

		public UriFormatException(string message)
		{
		}

		protected UriFormatException(SerializationInfo info, StreamingContext context)
		{
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
