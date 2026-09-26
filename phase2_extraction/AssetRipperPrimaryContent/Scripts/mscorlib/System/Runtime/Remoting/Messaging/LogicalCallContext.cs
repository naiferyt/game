using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[ComVisible(true)]
	public sealed class LogicalCallContext : ICloneable, ISerializable
	{
		private Hashtable _data;

		private CallContextRemotingData _remotingData;

		public bool HasInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal Hashtable Datastore
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal LogicalCallContext()
		{
		}

		internal LogicalCallContext(SerializationInfo info, StreamingContext context)
		{
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public void SetData(string name, object data)
		{
		}

		public object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
