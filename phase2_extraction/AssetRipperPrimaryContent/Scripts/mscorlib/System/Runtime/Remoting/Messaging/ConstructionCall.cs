using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[ComVisible(true)]
	[CLSCompliant(false)]
	public class ConstructionCall : MethodCall, IConstructionCallMessage, IMessage, IMethodCallMessage, IMethodMessage
	{
		private IActivator _activator;

		private object[] _activationAttributes;

		private IList _contextProperties;

		private Type _activationType;

		private string _activationTypeName;

		private bool _isContextOk;

		[NonSerialized]
		private RemotingProxy _sourceProxy;

		internal bool IsContextOk
		{
			set
			{
			}
		}

		public Type ActivationType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string ActivationTypeName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public IActivator Activator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public object[] CallSiteActivationAttributes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public IList ContextProperties
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override IDictionary Properties
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal ConstructionCall(Type type)
		{
		}

		internal ConstructionCall(SerializationInfo info, StreamingContext context)
		{
		}

		internal override void InitDictionary()
		{
		}

		internal void SetActivationAttributes(object[] attributes)
		{
		}

		internal override void InitMethodProperty(string key, object value)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
