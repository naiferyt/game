using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Mono.Interop
{
	internal class ComInteropProxy : RealProxy, IRemotingTypeInfo
	{
		private __ComObject com_object;

		private int ref_count;

		private string type_name;

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

		private ComInteropProxy(IntPtr pUnk)
		{
		}

		internal ComInteropProxy(IntPtr pUnk, Type t)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddProxy(IntPtr pItf, ComInteropProxy proxy);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern ComInteropProxy FindProxy(IntPtr pItf);

		private void CacheProxy()
		{
		}

		internal static ComInteropProxy GetProxy(IntPtr pItf, Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override IMessage Invoke(IMessage msg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool CanCastTo(Type fromType, object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
