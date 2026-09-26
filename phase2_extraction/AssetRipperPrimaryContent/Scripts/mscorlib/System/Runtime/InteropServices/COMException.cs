using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	[Serializable]
	[ComVisible(true)]
	public class COMException : ExternalException
	{
		public COMException()
		{
		}

		public COMException(string message)
		{
		}

		public COMException(string message, int errorCode)
		{
		}

		protected COMException(SerializationInfo info, StreamingContext context)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
