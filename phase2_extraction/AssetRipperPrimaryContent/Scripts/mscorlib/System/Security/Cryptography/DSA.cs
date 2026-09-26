using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public abstract class DSA : AsymmetricAlgorithm
	{
		public new static DSA Create()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public new static DSA Create(string algName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract byte[] CreateSignature(byte[] rgbHash);

		public abstract DSAParameters ExportParameters(bool includePrivateParameters);

		internal void ZeroizePrivateKey(DSAParameters parameters)
		{
		}

		public override void FromXmlString(string xmlString)
		{
		}

		public abstract void ImportParameters(DSAParameters parameters);

		public override string ToXmlString(bool includePrivateParameters)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract bool VerifySignature(byte[] rgbHash, byte[] rgbSignature);
	}
}
