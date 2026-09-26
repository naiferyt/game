using System.Collections;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal class MessageFormatter
	{
		public static void WriteMethodCall(BinaryWriter writer, object obj, Header[] headers, ISurrogateSelector surrogateSelector, StreamingContext context, FormatterAssemblyStyle assemblyFormat, FormatterTypeStyle typeFormat)
		{
		}

		public static void WriteMethodResponse(BinaryWriter writer, object obj, Header[] headers, ISurrogateSelector surrogateSelector, StreamingContext context, FormatterAssemblyStyle assemblyFormat, FormatterTypeStyle typeFormat)
		{
		}

		public static object ReadMethodCall(BinaryElement elem, BinaryReader reader, bool hasHeaders, HeaderHandler headerHandler, BinaryFormatter formatter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static object ReadMethodResponse(BinaryReader reader, bool hasHeaders, HeaderHandler headerHandler, IMethodCallMessage methodCallMessage, BinaryFormatter formatter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static object ReadMethodResponse(BinaryElement elem, BinaryReader reader, bool hasHeaders, HeaderHandler headerHandler, IMethodCallMessage methodCallMessage, BinaryFormatter formatter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool AllTypesArePrimitive(object[] objects)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsMethodPrimitive(Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static object[] GetExtraProperties(IDictionary properties, string[] internalKeys)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsInternalKey(string key, string[] internalKeys)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
