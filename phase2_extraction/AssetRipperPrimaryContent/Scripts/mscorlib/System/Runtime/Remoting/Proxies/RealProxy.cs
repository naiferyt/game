using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting.Proxies
{
	[ComVisible(true)]
	public abstract class RealProxy
	{
		private Type class_to_proxy;

		internal Context _targetContext;

		private MarshalByRefObject _server;

		private int _targetDomainId;

		internal string _targetUri;

		internal Identity _objectIdentity;

		private object _objTP;

		private object _stubData;

		internal Identity ObjectIdentity
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected RealProxy(Type classToProxy)
		{
		}

		internal RealProxy(Type classToProxy, ClientIdentity identity)
		{
		}

		protected RealProxy(Type classToProxy, IntPtr stub, object stubData)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Type InternalGetProxyType(object transparentProxy);

		public Type GetProxiedType()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract IMessage Invoke(IMessage msg);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal virtual extern object InternalGetTransparentProxy(string className);

		public virtual object GetTransparentProxy()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void SetTargetDomain(int domainId)
		{
		}
	}
}
