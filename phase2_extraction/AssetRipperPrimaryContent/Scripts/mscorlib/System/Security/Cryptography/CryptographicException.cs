using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Security.Cryptography
{
	[Serializable]
	[ComVisible(true)]
	public class CryptographicException : SystemException, _Exception
	{
		public CryptographicException()
		{
		}

		public CryptographicException(int hr)
		{
		}

		public CryptographicException(string message)
		{
		}

		public CryptographicException(string message, Exception inner)
		{
		}

		public CryptographicException(string format, string insert)
		{
		}

		protected CryptographicException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
