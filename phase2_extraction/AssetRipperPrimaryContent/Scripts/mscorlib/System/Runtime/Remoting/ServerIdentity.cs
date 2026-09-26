using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting
{
	internal abstract class ServerIdentity : Identity
	{
		protected Type _objectType;

		protected MarshalByRefObject _serverObject;

		protected IMessageSink _serverSink;

		protected Context _context;

		protected Lease _lease;

		public Type ObjectType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Lease Lease
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Context Context
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ServerIdentity(string objectUri, Context context, Type objectType)
		{
		}

		public void StartTrackingLifetime(ILease lease)
		{
		}

		public virtual void OnLifetimeExpired()
		{
		}

		public override ObjRef CreateObjRef(Type requestedType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void AttachServerObject(MarshalByRefObject serverObject, Context context)
		{
		}

		protected void DisposeServerObject()
		{
		}
	}
}
