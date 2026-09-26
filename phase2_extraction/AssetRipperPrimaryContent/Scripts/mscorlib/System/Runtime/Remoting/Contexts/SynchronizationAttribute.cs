using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace System.Runtime.Remoting.Contexts
{
	[Serializable]
	[ComVisible(true)]
	[AttributeUsage(AttributeTargets.Class)]
	public class SynchronizationAttribute : ContextAttribute, IContributeClientContextSink, IContributeServerContextSink
	{
		public const int NOT_SUPPORTED = 1;

		public const int SUPPORTED = 2;

		public const int REQUIRED = 4;

		public const int REQUIRES_NEW = 8;

		private bool _bReEntrant;

		private int _flavor;

		[NonSerialized]
		private bool _locked;

		[NonSerialized]
		private int _lockCount;

		[NonSerialized]
		private Mutex _mutex;

		[NonSerialized]
		private Thread _ownerThread;

		public virtual bool IsReEntrant
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool Locked
		{
			set
			{
			}
		}

		public SynchronizationAttribute()
		{
		}

		public SynchronizationAttribute(int flag, bool reEntrant)
		{
		}

		internal void AcquireLock()
		{
		}

		internal void ReleaseLock()
		{
		}

		[ComVisible(true)]
		public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
		}

		public virtual IMessageSink GetClientContextSink(IMessageSink nextSink)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual IMessageSink GetServerContextSink(IMessageSink nextSink)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(true)]
		public override bool IsContextOK(Context ctx, IConstructionCallMessage msg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static void ExitContext()
		{
		}

		internal static void EnterContext()
		{
		}
	}
}
