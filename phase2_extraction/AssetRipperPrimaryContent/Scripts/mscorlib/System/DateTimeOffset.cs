using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[StructLayout((LayoutKind)3)]
	public struct DateTimeOffset : IComparable<DateTimeOffset>, IEquatable<DateTimeOffset>, IComparable, IFormattable, IDeserializationCallback, ISerializable
	{
		public static readonly DateTimeOffset MaxValue;

		public static readonly DateTimeOffset MinValue;

		private DateTime dt;

		private TimeSpan utc_offset;

		public DateTime DateTime
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public TimeSpan Offset
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DateTime UtcDateTime
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DateTimeOffset(DateTime dateTime)
		{
		}

		public DateTimeOffset(DateTime dateTime, TimeSpan offset)
		{
		}

		public DateTimeOffset(long ticks, TimeSpan offset)
		{
		}

		private DateTimeOffset(SerializationInfo info, StreamingContext context)
		{
		}

		int IComparable.CompareTo(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		[MonoTODO]
		void IDeserializationCallback.OnDeserialization(object sender)
		{
		}

		public int CompareTo(DateTimeOffset other)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool Equals(DateTimeOffset other)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
