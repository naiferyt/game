using System.Runtime.Remoting.Contexts;

namespace System.Runtime.Remoting.Messaging
{
	internal class ClientContextReplySink : IMessageSink
	{
		private IMessageSink _replySink;

		private Context _context;

		public ClientContextReplySink(Context ctx, IMessageSink replySink)
		{
		}

		public IMessage SyncProcessMessage(IMessage msg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
