using System.Runtime.Serialization;

namespace System.Runtime.Remoting.Messaging
{
	internal class ObjRefSurrogate : ISerializationSurrogate
	{
		public virtual void GetObjectData(object obj, SerializationInfo si, StreamingContext sc)
		{
		}

		public virtual object SetObjectData(object obj, SerializationInfo si, StreamingContext sc, ISurrogateSelector selector)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
