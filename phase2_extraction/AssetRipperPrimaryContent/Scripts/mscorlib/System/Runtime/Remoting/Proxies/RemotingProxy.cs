using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting.Proxies
{
	internal class RemotingProxy : RealProxy, IRemotingTypeInfo
	{
		private static MethodInfo _cache_GetTypeMethod;

		private static MethodInfo _cache_GetHashCodeMethod;

		private IMessageSink _sink;

		private bool _hasEnvoySink;

		private ConstructionCall _ctorCall;

		public string TypeName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		internal RemotingProxy(Type type, ClientIdentity identity)
		{
		}

		internal RemotingProxy(Type type, string activationUrl, object[] activationAttributes)
		{
		}

		public override IMessage Invoke(IMessage request)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool CanCastTo(Type fromType, object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		~RemotingProxy()
		{
		}
	}
}
