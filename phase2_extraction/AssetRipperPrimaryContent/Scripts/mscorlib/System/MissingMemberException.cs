using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class MissingMemberException : MemberAccessException
	{
		private const int Result = -2146233070;

		protected string ClassName;

		protected string MemberName;

		protected byte[] Signature;

		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public MissingMemberException()
		{
		}

		public MissingMemberException(string message)
		{
		}

		protected MissingMemberException(SerializationInfo info, StreamingContext context)
		{
		}

		public MissingMemberException(string className, string memberName)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
