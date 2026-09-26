using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class RIPEMD160Managed : RIPEMD160
	{
		private const int BLOCK_SIZE_BYTES = 64;

		private byte[] _ProcessingBuffer;

		private uint[] _X;

		private uint[] _HashValue;

		private ulong _Length;

		private int _ProcessingBufferCount;

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

		~RIPEMD160Managed()
		{
		}

		private void ProcessBlock(byte[] buffer, int offset)
		{
		}

		private void Compress()
		{
		}

		private void CompressFinal(ulong length)
		{
		}

		private uint ROL(uint x, int n)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private uint F(uint x, uint y, uint z)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private uint G(uint x, uint y, uint z)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private uint H(uint x, uint y, uint z)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private uint I(uint x, uint y, uint z)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private uint J(uint x, uint y, uint z)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void FF(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}

		private void GG(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}

		private void HH(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}

		private void II(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}

		private void JJ(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}

		private void FFF(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}

		private void GGG(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}

		private void HHH(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}

		private void III(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}

		private void JJJ(ref uint a, uint b, ref uint c, uint d, uint e, uint x, int s)
		{
		}
	}
}
