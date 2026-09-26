using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class ArgumentOutOfRangeException : ArgumentException
	{
		private const int Result = -2146233086;

		private object actual_value;

		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ArgumentOutOfRangeException()
		{
		}

		public ArgumentOutOfRangeException(string paramName)
		{
		}

		public ArgumentOutOfRangeException(string paramName, string message)
		{
		}

		public ArgumentOutOfRangeException(string paramName, object actualValue, string message)
		{
		}

		protected ArgumentOutOfRangeException(SerializationInfo info, StreamingContext context)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
