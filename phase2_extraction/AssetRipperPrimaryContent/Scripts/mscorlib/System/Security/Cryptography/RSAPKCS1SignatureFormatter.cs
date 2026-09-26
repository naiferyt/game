using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class RSAPKCS1SignatureFormatter : AsymmetricSignatureFormatter
	{
		private RSA rsa;

		private HashAlgorithm hash;

		public RSAPKCS1SignatureFormatter()
		{
		}

		public RSAPKCS1SignatureFormatter(AsymmetricAlgorithm key)
		{
		}

		public override byte[] CreateSignature(byte[] rgbHash)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void SetHashAlgorithm(string strName)
		{
		}

		public override void SetKey(AsymmetricAlgorithm key)
		{
		}
	}
}
