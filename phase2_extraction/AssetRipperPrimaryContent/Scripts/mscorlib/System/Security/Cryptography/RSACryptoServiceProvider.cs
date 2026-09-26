using System.IO;
using System.Runtime.InteropServices;
using Mono.Security.Cryptography;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public sealed class RSACryptoServiceProvider : RSA, ICspAsymmetricAlgorithm
	{
		private const int PROV_RSA_FULL = 1;

		private KeyPairPersistence store;

		private bool persistKey;

		private bool persisted;

		private bool privateKeyExportable;

		private bool m_disposed;

		private RSAManaged rsa;

		private static bool useMachineKeyStore;

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

		[ComVisible(false)]
		[MonoTODO("Always return null")]
		public CspKeyContainerInfo CspKeyContainerInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public RSACryptoServiceProvider()
		{
		}

		public RSACryptoServiceProvider(CspParameters parameters)
		{
		}

		public RSACryptoServiceProvider(int dwKeySize)
		{
		}

		public RSACryptoServiceProvider(int dwKeySize, CspParameters parameters)
		{
		}

		private void Common(int dwKeySize, CspParameters p)
		{
		}

		~RSACryptoServiceProvider()
		{
		}

		public byte[] Decrypt(byte[] rgb, bool fOAEP)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override byte[] DecryptValue(byte[] rgb)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] Encrypt(byte[] rgb, bool fOAEP)
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

		private HashAlgorithm GetHash(object halg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] SignData(byte[] buffer, object halg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] SignData(Stream inputStream, object halg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] SignData(byte[] buffer, int offset, int count, object halg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string GetHashNameFromOID(string oid)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] SignHash(byte[] rgbHash, string str)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool VerifyData(byte[] buffer, object halg, byte[] signature)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool VerifyHash(byte[] rgbHash, string str, byte[] rgbSignature)
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
