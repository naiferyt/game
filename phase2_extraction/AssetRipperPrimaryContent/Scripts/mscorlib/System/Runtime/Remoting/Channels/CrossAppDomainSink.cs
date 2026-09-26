using System.Collections;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting.Channels
{
	[MonoTODO("Handle domain unloading?")]
	internal class CrossAppDomainSink : IMessageSink
	{
		private struct ProcessMessageRes
		{
			public byte[] arrResponse;

			public CADMethodReturnMessage cadMrm;
		}

		private static Hashtable s_sinks;

		private static MethodInfo processMessageMethod;

		private int _domainID;

		internal int TargetDomainId
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual IMessage SyncProcessMessage(IMessage msgRequest)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SendAsyncMessage(object data)
		{
		}
	}
}
