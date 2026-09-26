using System.Collections.Specialized;
using System.Net.Security;
using System.Runtime.Serialization;

namespace System.Net
{
	[Serializable]
	public abstract class WebRequest : MarshalByRefObject, ISerializable
	{
		private static HybridDictionary prefixes;

		private static bool isDefaultWebProxySet;

		private static IWebProxy defaultWebProxy;

		private AuthenticationLevel authentication_level;

		private static readonly object lockobj;

		public virtual ICredentials Credentials
		{
			set
			{
			}
		}

		protected WebRequest()
		{
		}

		protected WebRequest(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		static WebRequest()
		{
		}

		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		private static void AddDynamicPrefix(string protocol, string implementor)
		{
		}

		private static Exception GetMustImplement()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static WebRequest Create(Uri requestUri)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual WebResponse GetResponse()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		private static IWebRequestCreate GetCreator(string prefix)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static void AddPrefix(string prefix, Type type)
		{
		}
	}
}
