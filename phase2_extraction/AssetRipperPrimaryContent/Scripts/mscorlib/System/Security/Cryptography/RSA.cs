using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public abstract class RSA : AsymmetricAlgorithm
	{
		public new static RSA Create()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public new static RSA Create(string algName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract byte[] EncryptValue(byte[] rgb);

		public abstract byte[] DecryptValue(byte[] rgb);

		public abstract RSAParameters ExportParameters(bool includePrivateParameters);

		public abstract void ImportParameters(RSAParameters parameters);

		internal void ZeroizePrivateKey(RSAParameters parameters)
		{
		}

		public override void FromXmlString(string xmlString)
		{
		}

		public override string ToXmlString(bool includePrivateParameters)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
