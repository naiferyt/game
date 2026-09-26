using Mono.Security.Cryptography;

namespace System.Security.Cryptography
{
	internal class DESTransform : SymmetricTransform
	{
		internal static readonly int KEY_BIT_SIZE;

		internal static readonly int KEY_BYTE_SIZE;

		internal static readonly int BLOCK_BIT_SIZE;

		internal static readonly int BLOCK_BYTE_SIZE;

		private byte[] keySchedule;

		private byte[] byteBuff;

		private uint[] dwordBuff;

		private static readonly uint[] spBoxes;

		private static readonly byte[] PC1;

		private static readonly byte[] leftRotTotal;

		private static readonly byte[] PC2;

		internal static readonly uint[] ipTab;

		internal static readonly uint[] fpTab;

		internal DESTransform(SymmetricAlgorithm symmAlgo, bool encryption, byte[] key, byte[] iv)
		{
		}

		private uint CipherFunct(uint r, int n)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static void Permutation(byte[] input, byte[] output, uint[] permTab, bool preSwap)
		{
		}

		private static void BSwap(byte[] byteBuff)
		{
		}

		internal void SetKey(byte[] key)
		{
		}

		public void ProcessBlock(byte[] input, byte[] output)
		{
		}

		protected override void ECB(byte[] input, byte[] output)
		{
		}

		internal static byte[] GetStrongKey()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
