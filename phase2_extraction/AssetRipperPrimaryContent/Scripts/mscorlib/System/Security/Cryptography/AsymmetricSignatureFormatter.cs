using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public abstract class AsymmetricSignatureFormatter
	{
		public abstract void SetHashAlgorithm(string strName);

		public abstract void SetKey(AsymmetricAlgorithm key);

		public abstract byte[] CreateSignature(byte[] rgbHash);

		public virtual byte[] CreateSignature(HashAlgorithm hash)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
