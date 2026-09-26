using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Mono.Math;

namespace Mono.Security.Cryptography
{
	internal class RSAManaged : RSA
	{
		public delegate void KeyGeneratedEventHandler(object sender, EventArgs e);

		private const int defaultKeySize = 1024;

		private bool isCRTpossible;

		private bool keyBlinding;

		private bool keypairGenerated;

		private bool m_disposed;

		private BigInteger d;

		private BigInteger p;

		private BigInteger q;

		private BigInteger dp;

		private BigInteger dq;

		private BigInteger qInv;

		private BigInteger n;

		private BigInteger e;

		public override int KeySize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override string KeyExchangeAlgorithm
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool PublicOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override string SignatureAlgorithm
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsCrtPossible
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public event KeyGeneratedEventHandler KeyGenerated
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
			}
		}

		public RSAManaged(int keySize)
		{
		}

		~RSAManaged()
		{
		}

		private void GenerateKeyPair()
		{
		}

		public override byte[] DecryptValue(byte[] rgb)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override byte[] EncryptValue(byte[] rgb)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override RSAParameters ExportParameters(bool includePrivateParameters)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void ImportParameters(RSAParameters parameters)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override string ToXmlString(bool includePrivateParameters)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private byte[] GetPaddedValue(BigInteger value, int length)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
