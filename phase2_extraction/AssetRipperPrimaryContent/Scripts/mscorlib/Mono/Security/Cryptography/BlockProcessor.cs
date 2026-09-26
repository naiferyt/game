using System.Security.Cryptography;

namespace Mono.Security.Cryptography
{
	internal class BlockProcessor
	{
		private ICryptoTransform transform;

		private byte[] block;

		private int blockSize;

		private int blockCount;

		public BlockProcessor(ICryptoTransform transform, int blockSize)
		{
		}

		~BlockProcessor()
		{
		}

		public void Initialize()
		{
		}

		public void Core(byte[] rgb)
		{
		}

		public void Core(byte[] rgb, int ib, int cb)
		{
		}

		public byte[] Final()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
