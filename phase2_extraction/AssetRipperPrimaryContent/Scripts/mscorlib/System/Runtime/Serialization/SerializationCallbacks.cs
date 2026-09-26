using System.Collections;
using System.Reflection;

namespace System.Runtime.Serialization
{
	internal sealed class SerializationCallbacks
	{
		public delegate void CallbackHandler(StreamingContext context);

		private const BindingFlags DefaultBindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		private readonly ArrayList onSerializingList;

		private readonly ArrayList onSerializedList;

		private readonly ArrayList onDeserializingList;

		private readonly ArrayList onDeserializedList;

		private static Hashtable cache;

		private static object cache_lock;

		public bool HasSerializedCallbacks
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool HasDeserializedCallbacks
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public SerializationCallbacks(Type type)
		{
		}

		private static ArrayList GetMethodsByAttribute(Type type, Type attr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void Invoke(ArrayList list, object target, StreamingContext context)
		{
		}

		public void RaiseOnSerializing(object target, StreamingContext contex)
		{
		}

		public void RaiseOnSerialized(object target, StreamingContext contex)
		{
		}

		public void RaiseOnDeserializing(object target, StreamingContext contex)
		{
		}

		public void RaiseOnDeserialized(object target, StreamingContext contex)
		{
		}

		public static SerializationCallbacks GetSerializationCallbacks(Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
