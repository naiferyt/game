using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public abstract class AsymmetricSignatureDeformatter
	{
		public abstract void SetHashAlgorithm(string strName);

		public abstract void SetKey(AsymmetricAlgorithm key);

		public abstract bool VerifySignature(byte[] rgbHash, byte[] rgbSignature);

		public virtual bool VerifySignature(HashAlgorithm hash, byte[] rgbSignature)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
