using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class ObjectDisposedException : InvalidOperationException
	{
		private string obj_name;

		private string msg;

		public override string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ObjectDisposedException(string objectName)
		{
		}

		public ObjectDisposedException(string objectName, string message)
		{
		}

		protected ObjectDisposedException(SerializationInfo info, StreamingContext context)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
