using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Serialization.Formatters.Binary
{
	[ComVisible(true)]
	public sealed class BinaryFormatter : IRemotingFormatter, IFormatter
	{
		private FormatterAssemblyStyle assembly_format;

		private SerializationBinder binder;

		private StreamingContext context;

		private ISurrogateSelector surrogate_selector;

		private FormatterTypeStyle type_format;

		private TypeFilterLevel filter_level;

		[CompilerGenerated]
		private static ISurrogateSelector _003CDefaultSurrogateSelector_003Ek__BackingField;

		public static ISurrogateSelector DefaultSurrogateSelector
		{
			[CompilerGenerated]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public FormatterAssemblyStyle AssemblyFormat
		{
			set
			{
			}
		}

		public SerializationBinder Binder
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public StreamingContext Context
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ISurrogateSelector SurrogateSelector
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public TypeFilterLevel FilterLevel
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public BinaryFormatter()
		{
		}

		public BinaryFormatter(ISurrogateSelector selector, StreamingContext context)
		{
		}

		public object Deserialize(Stream serializationStream)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object Deserialize(Stream serializationStream, HeaderHandler handler)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private object NoCheckDeserialize(Stream serializationStream, HeaderHandler handler)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object DeserializeMethodResponse(Stream serializationStream, HeaderHandler handler, IMethodCallMessage methodCallMessage)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private object NoCheckDeserializeMethodResponse(Stream serializationStream, HeaderHandler handler, IMethodCallMessage methodCallMessage)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Serialize(Stream serializationStream, object graph)
		{
		}

		public void Serialize(Stream serializationStream, object graph, Header[] headers)
		{
		}

		private void WriteBinaryHeader(BinaryWriter writer, bool hasHeaders)
		{
		}

		private void ReadBinaryHeader(BinaryReader reader, out bool hasHeaders)
		{
		}
	}
}
