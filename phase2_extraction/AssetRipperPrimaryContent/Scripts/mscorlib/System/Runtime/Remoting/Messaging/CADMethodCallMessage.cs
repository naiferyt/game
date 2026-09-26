namespace System.Runtime.Remoting.Messaging
{
	internal class CADMethodCallMessage : CADMessageBase
	{
		private string _uri;

		internal RuntimeMethodHandle MethodHandle;

		internal string FullTypeName;

		internal CADMethodCallMessage(IMethodCallMessage callMsg)
		{
		}

		internal static CADMethodCallMessage Create(IMessage callMsg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
