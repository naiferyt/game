using System.Collections;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[ComVisible(true)]
	public sealed class CallContext
	{
		[ThreadStatic]
		private static Header[] Headers;

		[ThreadStatic]
		private static Hashtable datastore;

		private static Hashtable Datastore
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private CallContext()
		{
		}

		public static void SetData(string name, object data)
		{
		}

		internal static LogicalCallContext CreateLogicalCallContext(bool createEmpty)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static object SetCurrentCallContext(LogicalCallContext ctx)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static void UpdateCurrentCallContext(LogicalCallContext ctx)
		{
		}

		internal static void RestoreCallContext(object oldContext)
		{
		}
	}
}
