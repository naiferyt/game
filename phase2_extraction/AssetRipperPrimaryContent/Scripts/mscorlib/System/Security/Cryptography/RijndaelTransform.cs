using Mono.Security.Cryptography;

namespace System.Security.Cryptography
{
	internal class RijndaelTransform : SymmetricTransform
	{
		private uint[] expandedKey;

		private int Nb;

		private int Nk;

		private int Nr;

		private static readonly uint[] Rcon;

		private static readonly byte[] SBox;

		private static readonly byte[] iSBox;

		private static readonly uint[] T0;

		private static readonly uint[] T1;

		private static readonly uint[] T2;

		private static readonly uint[] T3;

		private static readonly uint[] iT0;

		private static readonly uint[] iT1;

		private static readonly uint[] iT2;

		private static readonly uint[] iT3;

		public RijndaelTransform(Rijndael algo, bool encryption, byte[] key, byte[] iv)
		{
		}

		public void Clear()
		{
		}

		protected override void ECB(byte[] input, byte[] output)
		{
		}

		private uint SubByte(uint a)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Encrypt128(byte[] indata, byte[] outdata, uint[] ekey)
		{
		}

		private void Encrypt192(byte[] indata, byte[] outdata, uint[] ekey)
		{
		}

		private void Encrypt256(byte[] indata, byte[] outdata, uint[] ekey)
		{
		}

		private void Decrypt128(byte[] indata, byte[] outdata, uint[] ekey)
		{
		}

		private void Decrypt192(byte[] indata, byte[] outdata, uint[] ekey)
		{
		}

		private void Decrypt256(byte[] indata, byte[] outdata, uint[] ekey)
		{
		}
	}
}
