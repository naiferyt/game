using System.Collections;

namespace System.Runtime.Remoting.Messaging
{
	internal class CADMessageBase
	{
		protected object[] _args;

		protected byte[] _serializedArgs;

		protected int _propertyCount;

		protected CADArgHolder _callContext;

		internal static int MarshalProperties(IDictionary dict, ref ArrayList args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static void UnmarshalProperties(IDictionary dict, int count, ArrayList args)
		{
		}

		private static bool IsPossibleToIgnoreMarshal(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected object MarshalArgument(object arg, ref ArrayList args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected object UnmarshalArgument(object arg, ArrayList args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal object[] MarshalArguments(object[] arguments, ref ArrayList args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal object[] UnmarshalArguments(object[] arguments, ArrayList args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected void SaveLogicalCallContext(IMethodMessage msg, ref ArrayList serializeList)
		{
		}

		internal LogicalCallContext GetLogicalCallContext(ArrayList args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
