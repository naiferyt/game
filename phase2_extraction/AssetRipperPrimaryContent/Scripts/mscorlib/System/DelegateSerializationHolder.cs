using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	internal class DelegateSerializationHolder : IObjectReference, ISerializable
	{
		[Serializable]
		private class DelegateEntry
		{
			private string type;

			private string assembly;

			public object target;

			private string targetTypeAssembly;

			private string targetTypeName;

			private string methodName;

			public DelegateEntry delegateEntry;

			public DelegateEntry(Delegate del, string targetLabel)
			{
			}

			public Delegate DeserializeDelegate(SerializationInfo info)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private Delegate _delegate;

		private DelegateSerializationHolder(SerializationInfo info, StreamingContext ctx)
		{
		}

		public static void GetDelegateData(Delegate instance, SerializationInfo info, StreamingContext ctx)
		{
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public object GetRealObject(StreamingContext context)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
