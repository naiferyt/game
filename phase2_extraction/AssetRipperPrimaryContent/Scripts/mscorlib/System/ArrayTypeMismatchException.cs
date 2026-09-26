using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class ArrayTypeMismatchException : SystemException
	{
		private const int Result = -2146233085;

		public ArrayTypeMismatchException()
		{
		}

		public ArrayTypeMismatchException(string message)
		{
		}

		protected ArrayTypeMismatchException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
