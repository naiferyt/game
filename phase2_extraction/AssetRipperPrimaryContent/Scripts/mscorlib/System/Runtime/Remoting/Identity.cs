using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting
{
	internal abstract class Identity
	{
		protected string _objectUri;

		protected IMessageSink _channelSink;

		protected IMessageSink _envoySink;

		private DynamicPropertyCollection _clientDynamicProperties;

		private DynamicPropertyCollection _serverDynamicProperties;

		protected ObjRef _objRef;

		private bool _disposed;

		public IMessageSink ChannelSink
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public IMessageSink EnvoySink
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string ObjectUri
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public bool IsConnected
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool Disposed
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public Identity(string objectUri)
		{
		}

		public abstract ObjRef CreateObjRef(Type requestedType);

		public void NotifyClientDynamicSinks(bool start, IMessage req_msg, bool client_site, bool async)
		{
		}
	}
}
