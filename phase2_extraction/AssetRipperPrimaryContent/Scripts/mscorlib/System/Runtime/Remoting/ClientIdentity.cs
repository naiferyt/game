namespace System.Runtime.Remoting
{
	internal class ClientIdentity : Identity
	{
		private WeakReference _proxyReference;

		public MarshalByRefObject ClientProxy
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public string TargetUri
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ClientIdentity(string objectUri, ObjRef objRef)
		{
		}

		public override ObjRef CreateObjRef(Type requestedType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
