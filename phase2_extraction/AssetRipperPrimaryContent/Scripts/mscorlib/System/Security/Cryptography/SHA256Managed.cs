using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class SHA256Managed : SHA256
	{
		private const int BLOCK_SIZE_BYTES = 64;

		private const int HASH_SIZE_BYTES = 32;

		private uint[] _H;

		private ulong count;

		private byte[] _ProcessingBuffer;

		private int _ProcessingBufferCount;

		private uint[] buff;

		protected override void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
		}

		protected override byte[] HashFinal()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Initialize()
		{
		}

		private void ProcessBlock(byte[] inputBuffer, int inputOffset)
		{
		}

		private void ProcessFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
		}

		internal void AddLength(ulong length, byte[] buffer, int position)
		{
		}
	}
}
