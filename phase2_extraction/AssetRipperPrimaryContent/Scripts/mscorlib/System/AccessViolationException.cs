using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class AccessViolationException : SystemException
	{
		private const int Result = -2147467261;

		public AccessViolationException()
		{
		}

		protected AccessViolationException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
