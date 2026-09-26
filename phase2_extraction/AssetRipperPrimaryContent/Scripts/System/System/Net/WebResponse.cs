using System.IO;
using System.Runtime.Serialization;

namespace System.Net
{
	[Serializable]
	public abstract class WebResponse : MarshalByRefObject, IDisposable, ISerializable
	{
		protected WebResponse()
		{
		}

		protected WebResponse(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		void IDisposable.Dispose()
		{
		}

		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		private static Exception GetMustImplement()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Close()
		{
		}

		public virtual Stream GetResponseStream()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[System.MonoTODO]
		protected virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}
	}
}
