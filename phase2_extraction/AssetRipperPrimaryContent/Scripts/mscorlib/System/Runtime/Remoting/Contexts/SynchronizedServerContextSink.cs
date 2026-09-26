using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting.Contexts
{
	internal class SynchronizedServerContextSink : IMessageSink
	{
		private IMessageSink _next;

		private SynchronizationAttribute _att;

		public SynchronizedServerContextSink(IMessageSink next, SynchronizationAttribute att)
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
