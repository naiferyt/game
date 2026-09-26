using System.Collections;

namespace System.Runtime.InteropServices
{
	[ComVisible(true)]
	public sealed class ExtensibleClassFactory
	{
		private static Hashtable hashtable;

		static ExtensibleClassFactory()
		{
		}

		internal static ObjectCreationDelegate GetObjectCreationCallback(Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
