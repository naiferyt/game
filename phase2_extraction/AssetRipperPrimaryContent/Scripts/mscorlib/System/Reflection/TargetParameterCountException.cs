using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	[Serializable]
	[ComVisible(true)]
	public sealed class TargetParameterCountException : Exception
	{
		public TargetParameterCountException()
		{
		}

		public TargetParameterCountException(string message)
		{
		}

		internal TargetParameterCountException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
