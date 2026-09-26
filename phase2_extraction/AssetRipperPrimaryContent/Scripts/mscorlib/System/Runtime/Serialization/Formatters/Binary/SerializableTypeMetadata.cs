using System.IO;

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal class SerializableTypeMetadata : TypeMetadata
	{
		private Type[] types;

		private string[] names;

		public override bool RequiresTypes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public SerializableTypeMetadata(Type itype, SerializationInfo info)
		{
		}

		public override bool IsCompatible(TypeMetadata other)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void WriteAssemblies(ObjectWriter ow, BinaryWriter writer)
		{
		}

		public override void WriteTypeData(ObjectWriter ow, BinaryWriter writer, bool writeTypes)
		{
		}

		public override void WriteObjectData(ObjectWriter ow, BinaryWriter writer, object data)
		{
		}
	}
}
