using Mono.Security.Cryptography;

namespace System.Security.Cryptography
{
	internal class RC2Transform : SymmetricTransform
	{
		private ushort R0;

		private ushort R1;

		private ushort R2;

		private ushort R3;

		private ushort[] K;

		private int j;

		private static readonly byte[] pitable;

		public RC2Transform(RC2 rc2Algo, bool encryption, byte[] key, byte[] iv)
		{
		}

		protected override void ECB(byte[] input, byte[] output)
		{
		}
	}
}
