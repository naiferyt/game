using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class ArgumentNullException : ArgumentException
	{
		private const int Result = -2147467261;

		public ArgumentNullException()
		{
		}

		public ArgumentNullException(string paramName)
		{
		}

		public ArgumentNullException(string paramName, string message)
		{
		}

		protected ArgumentNullException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
