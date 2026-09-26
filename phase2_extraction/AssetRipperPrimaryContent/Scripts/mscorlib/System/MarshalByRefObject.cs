using System.Runtime.InteropServices;
using System.Runtime.Remoting;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public abstract class MarshalByRefObject
	{
		[NonSerialized]
		private ServerIdentity _identity;

		internal ServerIdentity ObjectIdentity
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual ObjRef CreateObjRef(Type requestedType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object GetLifetimeService()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual object InitializeLifetimeService()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
