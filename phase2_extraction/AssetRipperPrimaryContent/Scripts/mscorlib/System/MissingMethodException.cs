using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class MissingMethodException : MissingMemberException
	{
		private const int Result = -2146233069;

		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public MissingMethodException()
		{
		}

		public MissingMethodException(string message)
		{
		}

		protected MissingMethodException(SerializationInfo info, StreamingContext context)
		{
		}

		public MissingMethodException(string className, string methodName)
		{
		}
	}
}
