using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class ArgumentException : SystemException
	{
		private const int Result = -2147024809;

		private string param_name;

		public virtual string ParamName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ArgumentException()
		{
		}

		public ArgumentException(string message)
		{
		}

		public ArgumentException(string message, string paramName)
		{
		}

		public ArgumentException(string message, string paramName, Exception innerException)
		{
		}

		protected ArgumentException(SerializationInfo info, StreamingContext context)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
