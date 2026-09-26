using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Mono.Math;

namespace Mono.Security.Cryptography
{
	internal class DSAManaged : DSA
	{
		public delegate void KeyGeneratedEventHandler(object sender, EventArgs e);

		private const int defaultKeySize = 1024;

		private bool keypairGenerated;

		private bool m_disposed;

		private BigInteger p;

		private BigInteger q;

		private BigInteger g;

		private BigInteger x;

		private BigInteger y;

		private BigInteger j;

		private BigInteger seed;

		private int counter;

		private bool j_missing;

		private RandomNumberGenerator rng;

		private RandomNumberGenerator Random
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

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

		public DSAManaged(int dwKeySize)
		{
		}

		~DSAManaged()
		{
		}

		private void Generate()
		{
		}

		private void GenerateKeyPair()
		{
		}

		private void add(byte[] a, byte[] b, int value)
		{
		}

		private void GenerateParams(int keyLength)
		{
		}

		private byte[] NormalizeArray(byte[] array)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override DSAParameters ExportParameters(bool includePrivateParameters)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void ImportParameters(DSAParameters parameters)
		{
		}

		public override byte[] CreateSignature(byte[] rgbHash)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool VerifySignature(byte[] rgbHash, byte[] rgbSignature)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
