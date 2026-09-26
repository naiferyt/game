using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class HMACSHA512 : HMAC
	{
		private static bool legacy_mode;

		private bool legacy;

		public bool ProduceLegacyHmacValues
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public HMACSHA512()
		{
		}

		public HMACSHA512(byte[] key)
		{
		}

		static HMACSHA512()
		{
		}
	}
}
