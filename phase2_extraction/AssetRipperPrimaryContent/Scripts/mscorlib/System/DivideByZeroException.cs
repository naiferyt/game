using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class DivideByZeroException : ArithmeticException
	{
		private const int Result = -2147352558;

		public DivideByZeroException()
		{
		}

		public DivideByZeroException(string message)
		{
		}

		public DivideByZeroException(string message, Exception innerException)
		{
		}

		protected DivideByZeroException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
