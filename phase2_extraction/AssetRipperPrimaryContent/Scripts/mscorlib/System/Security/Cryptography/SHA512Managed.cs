using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class SHA512Managed : SHA512
	{
		private byte[] xBuf;

		private int xBufOff;

		private ulong byteCount1;

		private ulong byteCount2;

		private ulong H1;

		private ulong H2;

		private ulong H3;

		private ulong H4;

		private ulong H5;

		private ulong H6;

		private ulong H7;

		private ulong H8;

		private ulong[] W;

		private int wOff;

		private void Initialize(bool reuse)
		{
		}

		public override void Initialize()
		{
		}

		protected override void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
		}

		protected override byte[] HashFinal()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void update(byte input)
		{
		}

		private void processWord(byte[] input, int inOff)
		{
		}

		private void unpackWord(ulong word, byte[] output, int outOff)
		{
		}

		private void adjustByteCounts()
		{
		}

		private void processLength(ulong lowW, ulong hiW)
		{
		}

		private void processBlock()
		{
		}

		private ulong rotateRight(ulong x, int n)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private ulong Ch(ulong x, ulong y, ulong z)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private ulong Maj(ulong x, ulong y, ulong z)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private ulong Sum0(ulong x)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private ulong Sum1(ulong x)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private ulong Sigma0(ulong x)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private ulong Sigma1(ulong x)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
