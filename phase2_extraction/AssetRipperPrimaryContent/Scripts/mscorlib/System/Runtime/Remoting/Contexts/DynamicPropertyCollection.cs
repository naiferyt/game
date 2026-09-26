using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting.Contexts
{
	internal class DynamicPropertyCollection
	{
		private class DynamicPropertyReg
		{
			public IDynamicProperty Property;

			public IDynamicMessageSink Sink;
		}

		private ArrayList _properties;

		public bool HasProperties
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public void NotifyMessage(bool start, IMessage msg, bool client_site, bool async)
		{
		}
	}
}
