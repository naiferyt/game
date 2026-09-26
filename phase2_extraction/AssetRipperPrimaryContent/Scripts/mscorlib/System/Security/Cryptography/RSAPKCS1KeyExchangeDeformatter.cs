using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class RSAPKCS1KeyExchangeDeformatter : AsymmetricKeyExchangeDeformatter
	{
		private RSA rsa;

		private RandomNumberGenerator random;

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

		public RandomNumberGenerator RNG
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public RSAPKCS1KeyExchangeDeformatter()
		{
		}

		public RSAPKCS1KeyExchangeDeformatter(AsymmetricAlgorithm key)
		{
		}

		public override byte[] DecryptKeyExchange(byte[] rgbIn)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void SetKey(AsymmetricAlgorithm key)
		{
		}
	}
}
