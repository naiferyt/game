using System.Runtime.InteropServices;
using Mono.Security.Cryptography;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class MACTripleDES : KeyedHashAlgorithm
	{
		private TripleDES tdes;

		private MACAlgorithm mac;

		private bool m_disposed;

		[ComVisible(false)]
		public PaddingMode Padding
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public MACTripleDES()
		{
		}

		public MACTripleDES(byte[] rgbKey)
		{
		}

		public MACTripleDES(string strTripleDES, byte[] rgbKey)
		{
		}

		private void Setup(string strTripleDES, byte[] rgbKey)
		{
		}

		~MACTripleDES()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Initialize()
		{
		}

		protected override void HashCore(byte[] rgbData, int ibStart, int cbSize)
		{
		}

		protected override byte[] HashFinal()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
