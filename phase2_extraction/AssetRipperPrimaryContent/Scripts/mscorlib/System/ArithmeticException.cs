using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class ArithmeticException : SystemException
	{
		private const int Result = -2147024362;

		public ArithmeticException()
		{
		}

		public ArithmeticException(string message)
		{
		}

		public ArithmeticException(string message, Exception innerException)
		{
		}

		protected ArithmeticException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
