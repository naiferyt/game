using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting.Messaging
{
	[ComVisible(true)]
	public class RemotingSurrogateSelector : ISurrogateSelector
	{
		private static Type s_cachedTypeObjRef;

		private static ObjRefSurrogate _objRefSurrogate;

		private static RemotingSurrogate _objRemotingSurrogate;

		private object _rootObj;

		private MessageSurrogateFilter _filter;

		private ISurrogateSelector _next;

		public virtual ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector ssout)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
