using System.Security.Cryptography;

namespace Mono.Math
{
	internal class BigInteger
	{
		private sealed class Kernel
		{
			public static BigInteger AddSameSign(BigInteger bi1, BigInteger bi2)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static BigInteger Subtract(BigInteger big, BigInteger small)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static void MinusEq(BigInteger big, BigInteger small)
			{
			}

			public static void PlusEq(BigInteger bi1, BigInteger bi2)
			{
			}

			public static Sign Compare(BigInteger bi1, BigInteger bi2)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static uint SingleByteDivideInPlace(BigInteger n, uint d)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static uint DwordMod(BigInteger n, uint d)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static BigInteger[] DwordDivMod(BigInteger n, uint d)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static BigInteger[] multiByteDivide(BigInteger bi1, BigInteger bi2)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static BigInteger LeftShift(BigInteger bi, int n)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static BigInteger RightShift(BigInteger bi, int n)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static BigInteger MultiplyByDword(BigInteger n, uint f)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static void Multiply(uint[] x, uint xOffset, uint xLen, uint[] y, uint yOffset, uint yLen, uint[] d, uint dOffset)
			{
			}

			public static void MultiplyMod2p32pmod(uint[] x, int xOffset, int xLen, uint[] y, int yOffest, int yLen, uint[] d, int dOffset, int mod)
			{
			}

			public static uint modInverse(BigInteger bi, uint modulus)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static BigInteger modInverse(BigInteger bi, BigInteger modulus)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal sealed class ModulusRing
		{
			private BigInteger mod;

			private BigInteger constant;

			public ModulusRing(BigInteger modulus)
			{
			}

			public void BarrettReduction(BigInteger x)
			{
			}

			public BigInteger Multiply(BigInteger a, BigInteger b)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public BigInteger Difference(BigInteger a, BigInteger b)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public BigInteger Pow(BigInteger a, BigInteger k)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public BigInteger Pow(uint b, BigInteger exp)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public enum Sign
		{
			Negative = -1,
			Zero = 0,
			Positive = 1
		}

		private const uint DEFAULT_LEN = 20u;

		private const string WouldReturnNegVal = "Operation would return a negative value";

		private uint length;

		private uint[] data;

		internal static readonly uint[] smallPrimes;

		private static RandomNumberGenerator rng;

		private static RandomNumberGenerator Rng
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public BigInteger(Sign sign, uint len)
		{
		}

		public BigInteger(BigInteger bi)
		{
		}

		public BigInteger(BigInteger bi, uint len)
		{
		}

		public BigInteger(byte[] inData)
		{
		}

		public BigInteger(uint ui)
		{
		}

		public static BigInteger GenerateRandom(int bits, RandomNumberGenerator rng)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger GenerateRandom(int bits)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Randomize(RandomNumberGenerator rng)
		{
		}

		public void Randomize()
		{
		}

		public int BitCount()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool TestBit(uint bitNum)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool TestBit(int bitNum)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SetBit(uint bitNum)
		{
		}

		public void SetBit(uint bitNum, bool value)
		{
		}

		public int LowestSetBit()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] GetBytes()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string ToString(uint radix)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string ToString(uint radix, string characterSet)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Normalize()
		{
		}

		public void Clear()
		{
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public BigInteger ModInverse(BigInteger modulus)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public BigInteger ModPow(BigInteger exp, BigInteger n)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool IsProbablePrime()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger GeneratePseudoPrime(int bits)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Incr2()
		{
		}

		public static implicit operator BigInteger(uint value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static implicit operator BigInteger(int value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger operator +(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger operator -(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static uint operator %(BigInteger bi, uint ui)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger operator %(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger operator /(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger operator *(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger operator *(BigInteger bi, int i)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger operator <<(BigInteger bi1, int shiftVal)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static BigInteger operator >>(BigInteger bi1, int shiftVal)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator ==(BigInteger bi1, uint ui)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator !=(BigInteger bi1, uint ui)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator ==(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator !=(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator >(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator <(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator >=(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator <=(BigInteger bi1, BigInteger bi2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
