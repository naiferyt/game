using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class FormatException : SystemException
	{
		private const int Result = -2146233033;

		public FormatException()
		{
		}

		public FormatException(string message)
		{
		}

		protected FormatException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
