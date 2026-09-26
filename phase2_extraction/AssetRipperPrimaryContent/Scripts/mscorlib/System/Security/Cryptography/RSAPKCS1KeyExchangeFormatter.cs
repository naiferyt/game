using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class RSAPKCS1KeyExchangeFormatter : AsymmetricKeyExchangeFormatter
	{
		private RSA rsa;

		private RandomNumberGenerator random;

		public RandomNumberGenerator Rng
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public override string Parameters
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public RSAPKCS1KeyExchangeFormatter()
		{
		}

		public RSAPKCS1KeyExchangeFormatter(AsymmetricAlgorithm key)
		{
		}

		public override byte[] CreateKeyExchange(byte[] rgbData)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override byte[] CreateKeyExchange(byte[] rgbData, Type symAlgType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void SetRSAKey(AsymmetricAlgorithm key)
		{
		}

		public override void SetKey(AsymmetricAlgorithm key)
		{
		}
	}
}
