using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public sealed class SHA1CryptoServiceProvider : SHA1
	{
		private SHA1Internal sha;

		~SHA1CryptoServiceProvider()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		protected override void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
		}

		protected override byte[] HashFinal()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Initialize()
		{
		}
	}
}
