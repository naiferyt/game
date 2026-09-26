using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class TypeLoadException : SystemException
	{
		private const int Result = -2146233054;

		private string className;

		private string assemblyName;

		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public TypeLoadException()
		{
		}

		public TypeLoadException(string message)
		{
		}

		public TypeLoadException(string message, Exception inner)
		{
		}

		protected TypeLoadException(SerializationInfo info, StreamingContext context)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
