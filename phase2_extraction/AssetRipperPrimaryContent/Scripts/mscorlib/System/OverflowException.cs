using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class OverflowException : ArithmeticException
	{
		private const int Result = -2146233066;

		public OverflowException()
		{
		}

		public OverflowException(string message)
		{
		}

		protected OverflowException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
