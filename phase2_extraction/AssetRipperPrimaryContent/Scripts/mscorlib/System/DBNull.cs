using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public sealed class DBNull : IConvertible, ISerializable
	{
		public static readonly DBNull Value;

		private DBNull()
		{
		}

		private DBNull(SerializationInfo info, StreamingContext context)
		{
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		object IConvertible.ToType(Type targetType, IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public TypeCode GetTypeCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string ToString(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
