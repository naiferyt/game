using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public struct Guid : IComparable<Guid>, IEquatable<Guid>, IComparable, IFormattable
	{
		internal class GuidParser
		{
			private string _src;

			private int _length;

			private int _cur;

			public GuidParser(string src)
			{
			}

			private void Reset()
			{
			}

			private bool AtEnd()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			private void ThrowFormatException()
			{
			}

			private ulong ParseHex(int length, bool strictLength)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			private bool ParseOptChar(char c)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			private void ParseChar(char c)
			{
			}

			private Guid ParseGuid1()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			private void ParseHexPrefix()
			{
			}

			private Guid ParseGuid2()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public Guid Parse()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private int _a;

		private short _b;

		private short _c;

		private byte _d;

		private byte _e;

		private byte _f;

		private byte _g;

		private byte _h;

		private byte _i;

		private byte _j;

		private byte _k;

		public static readonly Guid Empty;

		private static object _rngAccess;

		private static RandomNumberGenerator _rng;

		private static RandomNumberGenerator _fastRng;

		public Guid(byte[] b)
		{
		}

		public Guid(string g)
		{
		}

		public Guid(int a, short b, short c, byte[] d)
		{
		}

		public Guid(int a, short b, short c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
		{
		}

		[CLSCompliant(false)]
		public Guid(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
		{
		}

		private static void CheckNull(object o)
		{
		}

		private static void CheckLength(byte[] o, int l)
		{
		}

		private static void CheckArray(byte[] o, int l)
		{
		}

		private static int Compare(int x, int y)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int CompareTo(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int CompareTo(Guid value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool Equals(Guid g)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static char ToHex(int b)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Guid NewGuid()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static byte[] FastNewGuidArray()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] ToByteArray()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void AppendInt(StringBuilder builder, int value)
		{
		}

		private static void AppendShort(StringBuilder builder, short value)
		{
		}

		private static void AppendByte(StringBuilder builder, byte value)
		{
		}

		private string BaseToString(bool h, bool p, bool b)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string ToString(string format)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string ToString(string format, IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator ==(Guid a, Guid b)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator !=(Guid a, Guid b)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
