using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public struct Decimal : IComparable<decimal>, IEquatable<decimal>, IComparable, IConvertible, IFormattable
	{
		public const decimal MinValue = -79228162514264337593543950335m;

		public const decimal MaxValue = 79228162514264337593543950335m;

		public const decimal MinusOne = -1m;

		public const decimal One = 1m;

		public const decimal Zero = 0m;

		private const int DECIMAL_DIVIDE_BY_ZERO = 5;

		private const uint MAX_SCALE = 28u;

		private const int iMAX_SCALE = 28;

		private const uint SIGN_FLAG = 2147483648u;

		private const uint SCALE_MASK = 16711680u;

		private const int SCALE_SHIFT = 16;

		private const uint RESERVED_SS32_BITS = 2130771967u;

		private static readonly decimal MaxValueDiv10;

		private uint flags;

		private uint hi;

		private uint lo;

		private uint mid;

		public Decimal(int lo, int mid, int hi, bool isNegative, byte scale)
		{
		}

		public Decimal(int value)
		{
		}

		[CLSCompliant(false)]
		public Decimal(uint value)
		{
		}

		public Decimal(long value)
		{
		}

		[CLSCompliant(false)]
		public Decimal(ulong value)
		{
		}

		public Decimal(float value)
		{
		}

		public Decimal(double value)
		{
		}

		object IConvertible.ToType(Type targetType, IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

		public static int[] GetBits(decimal d)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal Add(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal Subtract(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static ulong u64(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static long s64(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool Equals(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool IsZero()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal Floor(decimal d)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal Multiply(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal Divide(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int Compare(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int CompareTo(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int CompareTo(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool Equals(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal Parse(string s, IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void ThrowAtPos(int pos)
		{
		}

		private static void ThrowInvalidExp()
		{
		}

		private static string stripStyles(string s, NumberStyles style, NumberFormatInfo nfi, out int decPos, out bool isNegative, out bool expFlag, out int exp, bool throwex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal Parse(string s, NumberStyles style, IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool PerformParse(string s, NumberStyles style, IFormatProvider provider, out decimal res, bool throwex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public TypeCode GetTypeCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string ToString(string format, IFormatProvider provider)
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

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int decimal2UInt64(ref decimal val, out ulong result);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int decimal2Int64(ref decimal val, out long result);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int decimalIncr(ref decimal d1, ref decimal d2);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int string2decimal(out decimal val, string sDigits, uint decPos, int sign);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int decimalSetExponent(ref decimal val, int exp);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double decimal2double(ref decimal val);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void decimalFloorAndTrunc(ref decimal val, int floorFlag);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int decimalMult(ref decimal pd1, ref decimal pd2);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int decimalDiv(out decimal pc, ref decimal pa, ref decimal pb);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int decimalCompare(ref decimal d1, ref decimal d2);

		public static decimal operator ++(decimal d)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal operator -(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal operator *(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static decimal operator /(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static explicit operator byte(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public static explicit operator sbyte(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static explicit operator short(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public static explicit operator ushort(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static explicit operator int(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public static explicit operator uint(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static explicit operator long(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public static explicit operator ulong(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static implicit operator decimal(byte value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public static implicit operator decimal(sbyte value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static implicit operator decimal(short value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public static implicit operator decimal(ushort value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static implicit operator decimal(int value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public static implicit operator decimal(uint value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static implicit operator decimal(long value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public static implicit operator decimal(ulong value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static explicit operator decimal(float value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static explicit operator decimal(double value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static explicit operator float(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static explicit operator double(decimal value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator !=(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator ==(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator >(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator <(decimal d1, decimal d2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
