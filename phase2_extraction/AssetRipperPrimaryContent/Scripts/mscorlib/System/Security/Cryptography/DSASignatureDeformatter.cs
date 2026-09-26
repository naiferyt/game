using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class DSASignatureDeformatter : AsymmetricSignatureDeformatter
	{
		private DSA dsa;

		public DSASignatureDeformatter()
		{
		}

		public DSASignatureDeformatter(AsymmetricAlgorithm key)
		{
		}

		public override void SetHashAlgorithm(string strName)
		{
		}

		public override void SetKey(AsymmetricAlgorithm key)
		{
		}

		public override bool VerifySignature(byte[] rgbHash, byte[] rgbSignature)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
