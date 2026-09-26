using System.Runtime.InteropServices;

namespace System.Runtime.Remoting
{
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class ObjectHandle : MarshalByRefObject, IObjectHandle
	{
		private object _wrapped;

		public ObjectHandle(object o)
		{
		}

		public override object InitializeLifetimeService()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object Unwrap()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
