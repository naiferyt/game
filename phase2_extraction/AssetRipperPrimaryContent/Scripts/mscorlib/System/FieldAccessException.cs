using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class FieldAccessException : MemberAccessException
	{
		private const int Result = -2146233081;

		public FieldAccessException()
		{
		}

		public FieldAccessException(string message)
		{
		}

		protected FieldAccessException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
