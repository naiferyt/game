using System.IO;
using System.Runtime.InteropServices;
using Mono.Security.Cryptography;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public sealed class DSACryptoServiceProvider : DSA, ICspAsymmetricAlgorithm
	{
		private const int PROV_DSS_DH = 13;

		private KeyPairPersistence store;

		private bool persistKey;

		private bool persisted;

		private bool privateKeyExportable;

		private bool m_disposed;

		private DSAManaged dsa;

		private static bool useMachineKeyStore;

		public override string KeyExchangeAlgorithm
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

		public bool PersistKeyInCsp
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		[ComVisible(false)]
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

		public static bool UseMachineKeyStore
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		[ComVisible(false)]
		[MonoTODO("call into KeyPairPersistence to get details")]
		public CspKeyContainerInfo CspKeyContainerInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DSACryptoServiceProvider()
		{
		}

		public DSACryptoServiceProvider(CspParameters parameters)
		{
		}

		public DSACryptoServiceProvider(int dwKeySize)
		{
		}

		public DSACryptoServiceProvider(int dwKeySize, CspParameters parameters)
		{
		}

		~DSACryptoServiceProvider()
		{
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

		public byte[] SignData(byte[] buffer)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] SignData(byte[] buffer, int offset, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] SignData(Stream inputStream)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] SignHash(byte[] rgbHash, string str)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool VerifyData(byte[] rgbData, byte[] rgbSignature)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool VerifyHash(byte[] rgbHash, string str, byte[] rgbSignature)
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

		private void OnKeyGenerated(object sender, EventArgs e)
		{
		}

		[ComVisible(false)]
		public byte[] ExportCspBlob(bool includePrivateParameters)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public void ImportCspBlob(byte[] keyBlob)
		{
		}
	}
}
