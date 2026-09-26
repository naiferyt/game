using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class MethodAccessException : MemberAccessException
	{
		private const int Result = -2146233072;

		public MethodAccessException()
		{
		}

		protected MethodAccessException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
