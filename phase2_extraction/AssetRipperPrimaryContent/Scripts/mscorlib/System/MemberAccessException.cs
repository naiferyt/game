using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class MemberAccessException : SystemException
	{
		private const int Result = -2146233062;

		public MemberAccessException()
		{
		}

		public MemberAccessException(string message)
		{
		}

		protected MemberAccessException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
