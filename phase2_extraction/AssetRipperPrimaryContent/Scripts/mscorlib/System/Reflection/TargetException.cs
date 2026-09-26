using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	[Serializable]
	[ComVisible(true)]
	public class TargetException : Exception
	{
		public TargetException()
		{
		}

		public TargetException(string message)
		{
		}

		protected TargetException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
