using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[ComVisible(true)]
	[CLSCompliant(false)]
	public class MethodCall : IInternalMessage, IMessage, IMethodCallMessage, IMethodMessage, ISerializationRootObject, ISerializable
	{
		private string _uri;

		private string _typeName;

		private string _methodName;

		private object[] _args;

		private Type[] _methodSignature;

		private MethodBase _methodBase;

		private LogicalCallContext _callContext;

		private ArgInfo _inArgInfo;

		private Identity _targetIdentity;

		private Type[] _genericArguments;

		protected IDictionary ExternalProperties;

		protected IDictionary InternalProperties;

		string IInternalMessage.Uri
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		Identity IInternalMessage.TargetIdentity
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public int ArgCount
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public object[] Args
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool HasVarArgs
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int InArgCount
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public object[] InArgs
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public LogicalCallContext LogicalCallContext
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public MethodBase MethodBase
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string MethodName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public object MethodSignature
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual IDictionary Properties
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string TypeName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string Uri
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		private Type[] GenericArguments
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public MethodCall(Header[] h1)
		{
		}

		internal MethodCall(SerializationInfo info, StreamingContext context)
		{
		}

		internal MethodCall()
		{
		}

		internal virtual void InitMethodProperty(string key, object value)
		{
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		internal virtual void InitDictionary()
		{
		}

		public object GetArg(int argNum)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetArgName(int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object GetInArg(int argNum)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetInArgName(int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Init()
		{
		}

		public void ResolveMethod()
		{
		}
	}
}
