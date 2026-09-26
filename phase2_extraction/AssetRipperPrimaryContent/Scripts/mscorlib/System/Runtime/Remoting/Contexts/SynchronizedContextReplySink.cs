using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting.Contexts
{
	internal class SynchronizedContextReplySink : IMessageSink
	{
		private IMessageSink _next;

		private bool _newLock;

		private SynchronizationAttribute _att;

		public SynchronizedContextReplySink(IMessageSink next, SynchronizationAttribute att, bool newLock)
		{
		}

		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public IMessage SyncProcessMessage(IMessage msg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
