namespace System.Security.Cryptography
{
	public abstract class RandomNumberGenerator
	{
		public static RandomNumberGenerator Create()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static RandomNumberGenerator Create(string rngName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract void GetBytes(byte[] data);

		public abstract void GetNonZeroBytes(byte[] data);
	}
}
