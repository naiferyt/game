using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public abstract class SymmetricAlgorithm : IDisposable
	{
		protected int BlockSizeValue;

		protected byte[] IVValue;

		protected int KeySizeValue;

		protected byte[] KeyValue;

		protected KeySizes[] LegalBlockSizesValue;

		protected KeySizes[] LegalKeySizesValue;

		protected int FeedbackSizeValue;

		protected CipherMode ModeValue;

		protected PaddingMode PaddingValue;

		private bool m_disposed;

		public virtual int BlockSize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual int FeedbackSize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual byte[] IV
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual byte[] Key
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual int KeySize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual KeySizes[] LegalBlockSizes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual KeySizes[] LegalKeySizes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual CipherMode Mode
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual PaddingMode Padding
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		void IDisposable.Dispose()
		{
		}

		~SymmetricAlgorithm()
		{
		}

		public void Clear()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public virtual ICryptoTransform CreateDecryptor()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV);

		public virtual ICryptoTransform CreateEncryptor()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV);

		public abstract void GenerateIV();

		public abstract void GenerateKey();

		public bool ValidKeySize(int bitLength)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static SymmetricAlgorithm Create()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static SymmetricAlgorithm Create(string algName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
