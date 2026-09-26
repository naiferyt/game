using System.Reflection;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	internal class UnitySerializationHolder : IObjectReference, ISerializable
	{
		private enum UnityType : byte
		{
			DBNull = 2,
			Type = 4,
			Module = 5,
			Assembly = 6
		}

		private string _data;

		private UnityType _unityType;

		private string _assemblyName;

		private UnitySerializationHolder(SerializationInfo info, StreamingContext ctx)
		{
		}

		public static void GetTypeData(Type instance, SerializationInfo info, StreamingContext ctx)
		{
		}

		public static void GetDBNullData(DBNull instance, SerializationInfo info, StreamingContext ctx)
		{
		}

		public static void GetModuleData(Module instance, SerializationInfo info, StreamingContext ctx)
		{
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public virtual object GetRealObject(StreamingContext context)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
