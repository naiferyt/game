using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting.Contexts
{
	[ComVisible(true)]
	public class Context
	{
		private int domain_id;

		private int context_id;

		private UIntPtr static_data;

		private static IMessageSink default_server_context_sink;

		private IMessageSink server_context_sink_chain;

		private IMessageSink client_context_sink_chain;

		private object[] datastore;

		private ArrayList context_properties;

		private bool frozen;

		private static int global_count;

		private static Hashtable namedSlots;

		private static DynamicPropertyCollection global_dynamic_properties;

		private DynamicPropertyCollection context_dynamic_properties;

		private ContextCallbackObject callback_object;

		public static Context DefaultContext
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal bool IsDefaultContext
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static bool HasGlobalDynamicSinks
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal bool HasDynamicSinks
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal bool HasExitSinks
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		~Context()
		{
		}

		internal static void NotifyGlobalDynamicSinks(bool start, IMessage req_msg, bool client_site, bool async)
		{
		}

		internal void NotifyDynamicSinks(bool start, IMessage req_msg, bool client_site, bool async)
		{
		}

		public virtual IContextProperty GetProperty(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal IMessageSink GetServerContextSinkChain()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal IMessageSink GetClientContextSinkChain()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal IMessageSink CreateEnvoySink(MarshalByRefObject serverObject)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
