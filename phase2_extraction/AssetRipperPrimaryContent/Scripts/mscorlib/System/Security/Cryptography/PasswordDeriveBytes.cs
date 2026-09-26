using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class PasswordDeriveBytes : DeriveBytes
	{
		private string HashNameValue;

		private byte[] SaltValue;

		private int IterationsValue;

		private HashAlgorithm hash;

		private int state;

		private byte[] password;

		private byte[] initial;

		private byte[] output;

		private int position;

		private int hashnumber;

		public string HashName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public int IterationCount
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public byte[] Salt
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public PasswordDeriveBytes(string strPassword, byte[] rgbSalt)
		{
		}

		public PasswordDeriveBytes(string strPassword, byte[] rgbSalt, CspParameters cspParams)
		{
		}

		public PasswordDeriveBytes(string strPassword, byte[] rgbSalt, string strHashName, int iterations)
		{
		}

		public PasswordDeriveBytes(string strPassword, byte[] rgbSalt, string strHashName, int iterations, CspParameters cspParams)
		{
		}

		public PasswordDeriveBytes(byte[] password, byte[] salt)
		{
		}

		public PasswordDeriveBytes(byte[] password, byte[] salt, CspParameters cspParams)
		{
		}

		public PasswordDeriveBytes(byte[] password, byte[] salt, string hashName, int iterations)
		{
		}

		public PasswordDeriveBytes(byte[] password, byte[] salt, string hashName, int iterations, CspParameters cspParams)
		{
		}

		~PasswordDeriveBytes()
		{
		}

		private void Prepare(string strPassword, byte[] rgbSalt, string strHashName, int iterations)
		{
		}

		private void Prepare(byte[] password, byte[] rgbSalt, string strHashName, int iterations)
		{
		}

		public byte[] CryptDeriveKey(string algname, string alghashname, int keySize, byte[] rgbIV)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[Obsolete("see Rfc2898DeriveBytes for PKCS#5 v2 support")]
		public override byte[] GetBytes(int cb)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Reset()
		{
		}
	}
}
