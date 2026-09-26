using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[CLSCompliant(false)]
	[ComVisible(true)]
	public class ConstructionResponse : MethodResponse, IConstructionReturnMessage, IMessage, IMethodMessage, IMethodReturnMessage
	{
		public override IDictionary Properties
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal ConstructionResponse(object resultObject, LogicalCallContext callCtx, IMethodCallMessage msg)
		{
		}

		internal ConstructionResponse(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
