using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class HMACSHA1 : HMAC
	{
		public HMACSHA1()
		{
		}

		public HMACSHA1(byte[] key)
		{
		}

		public HMACSHA1(byte[] key, bool useManagedSha1)
		{
		}
	}
}
