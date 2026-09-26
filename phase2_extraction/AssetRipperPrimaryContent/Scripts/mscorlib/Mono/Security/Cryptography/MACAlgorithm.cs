using System.Security.Cryptography;

namespace Mono.Security.Cryptography
{
	internal class MACAlgorithm
	{
		private SymmetricAlgorithm algo;

		private ICryptoTransform enc;

		private byte[] block;

		private int blockSize;

		private int blockCount;

		public MACAlgorithm(SymmetricAlgorithm algorithm)
		{
		}

		public void Initialize(byte[] key)
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
