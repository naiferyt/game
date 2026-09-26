using System.Collections;

namespace System.Runtime.Serialization
{
	public sealed class SerializationObjectManager
	{
		private readonly StreamingContext context;

		private readonly Hashtable seen;

		private SerializationCallbacks.CallbackHandler callbacks;

		public SerializationObjectManager(StreamingContext context)
		{
		}

		public void RegisterObject(object obj)
		{
		}

		public void RaiseOnSerializedEvent()
		{
		}
	}
}
