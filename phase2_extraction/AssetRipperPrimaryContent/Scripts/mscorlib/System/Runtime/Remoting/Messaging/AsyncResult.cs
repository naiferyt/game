using System.Runtime.InteropServices;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	[ComVisible(true)]
	public class AsyncResult : IAsyncResult, IMessageSink
	{
		private object async_state;

		private WaitHandle handle;

		private object async_delegate;

		private IntPtr data;

		private object object_data;

		private bool sync_completed;

		private bool completed;

		private bool endinvoke_called;

		private object async_callback;

		private ExecutionContext current;

		private ExecutionContext original;

		private MonoMethodMessage call_message;

		private IMessageCtrl message_ctrl;

		private IMessage reply_message;

		public virtual WaitHandle AsyncWaitHandle
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual object AsyncDelegate
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void SetMessageCtrl(IMessageCtrl mc)
		{
		}

		public virtual IMessage SyncProcessMessage(IMessage msg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
