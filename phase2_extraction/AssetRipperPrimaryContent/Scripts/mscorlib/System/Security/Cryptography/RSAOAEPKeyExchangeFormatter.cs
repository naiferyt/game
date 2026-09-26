using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class RSAOAEPKeyExchangeFormatter : AsymmetricKeyExchangeFormatter
	{
		private RSA rsa;

		private RandomNumberGenerator random;

		private byte[] param;

		public byte[] Parameter
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

		public RSAOAEPKeyExchangeFormatter()
		{
		}

		public RSAOAEPKeyExchangeFormatter(AsymmetricAlgorithm key)
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

		public override void SetKey(AsymmetricAlgorithm key)
		{
		}
	}
}
