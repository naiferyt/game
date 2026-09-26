using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	[Serializable]
	[ComVisible(true)]
	public sealed class TargetInvocationException : Exception
	{
		public TargetInvocationException(Exception inner)
		{
		}

		internal TargetInvocationException(SerializationInfo info, StreamingContext sc)
		{
		}
	}
}
