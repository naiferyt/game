using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class RSAOAEPKeyExchangeDeformatter : AsymmetricKeyExchangeDeformatter
	{
		private RSA rsa;

		public override string Parameters
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public RSAOAEPKeyExchangeDeformatter()
		{
		}

		public RSAOAEPKeyExchangeDeformatter(AsymmetricAlgorithm key)
		{
		}

		public override byte[] DecryptKeyExchange(byte[] rgbData)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void SetKey(AsymmetricAlgorithm key)
		{
		}
	}
}
