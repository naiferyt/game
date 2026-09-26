using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Collections.Generic
{
	[Serializable]
	[ComVisible(true)]
	public class KeyNotFoundException : SystemException, ISerializable
	{
		public KeyNotFoundException()
		{
		}

		protected KeyNotFoundException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
