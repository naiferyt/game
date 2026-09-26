using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting
{
	[Serializable]
	[ComVisible(true)]
	public class ObjRef : IObjectReference, ISerializable
	{
		private IChannelInfo channel_info;

		private string uri;

		private IRemotingTypeInfo typeInfo;

		private IEnvoyInfo envoyInfo;

		private int flags;

		private Type _serverType;

		private static int MarshalledObjectRef;

		private static int WellKnowObjectRef;

		internal bool IsReferenceToWellKnow
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual IChannelInfo ChannelInfo
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual IEnvoyInfo EnvoyInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual IRemotingTypeInfo TypeInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual string URI
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		internal Type ServerType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ObjRef()
		{
		}

		internal ObjRef(Type type, string url, object remoteChannelData)
		{
		}

		protected ObjRef(SerializationInfo info, StreamingContext context)
		{
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public virtual object GetRealObject(StreamingContext context)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void UpdateChannelInfo()
		{
		}
	}
}
