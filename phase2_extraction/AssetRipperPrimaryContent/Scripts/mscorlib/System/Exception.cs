using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace System
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(_Exception))]
	public class Exception : _Exception, ISerializable
	{
		private IntPtr[] trace_ips;

		private Exception inner_exception;

		internal string message;

		private string help_link;

		private string class_name;

		private string stack_trace;

		private string _remoteStackTraceString;

		private int remote_stack_index;

		internal int hresult;

		private string source;

		private IDictionary _data;

		public Exception InnerException
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected int HResult
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		private string ClassName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string Message
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string Source
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string StackTrace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Exception()
		{
		}

		public Exception(string message)
		{
		}

		protected Exception(SerializationInfo info, StreamingContext context)
		{
		}

		public Exception(string message, Exception innerException)
		{
		}

		internal void SetMessage(string s)
		{
		}

		internal void SetStackTrace(string s)
		{
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void GetFullNameForStackTrace(StringBuilder sb, MethodBase mi)
		{
		}

		public new Type GetType()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
