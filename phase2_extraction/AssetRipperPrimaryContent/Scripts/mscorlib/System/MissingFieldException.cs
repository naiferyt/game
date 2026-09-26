using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class MissingFieldException : MissingMemberException
	{
		private const int Result = -2146233071;

		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public MissingFieldException()
		{
		}

		public MissingFieldException(string message)
		{
		}

		protected MissingFieldException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
