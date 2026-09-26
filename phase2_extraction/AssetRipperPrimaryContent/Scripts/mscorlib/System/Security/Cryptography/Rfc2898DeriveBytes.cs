using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class Rfc2898DeriveBytes : DeriveBytes
	{
		private const int defaultIterations = 1000;

		private int _iteration;

		private byte[] _salt;

		private HMACSHA1 _hmac;

		private byte[] _buffer;

		private int _pos;

		private int _f;

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

		public Rfc2898DeriveBytes(string password, byte[] salt)
		{
		}

		public Rfc2898DeriveBytes(string password, byte[] salt, int iterations)
		{
		}

		public Rfc2898DeriveBytes(byte[] password, byte[] salt, int iterations)
		{
		}

		public Rfc2898DeriveBytes(string password, int saltSize)
		{
		}

		public Rfc2898DeriveBytes(string password, int saltSize, int iterations)
		{
		}

		private byte[] F(byte[] s, int c, int i)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override byte[] GetBytes(int cb)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Reset()
		{
		}
	}
}
