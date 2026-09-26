namespace System.Security.Cryptography
{
	public sealed class CspParameters
	{
		private CspProviderFlags _Flags;

		public string KeyContainerName;

		public int KeyNumber;

		public string ProviderName;

		public int ProviderType;

		public CspProviderFlags Flags
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public CspParameters()
		{
		}

		public CspParameters(int dwTypeIn)
		{
		}

		public CspParameters(int dwTypeIn, string strProviderNameIn)
		{
		}

		public CspParameters(int dwTypeIn, string strProviderNameIn, string strContainerNameIn)
		{
		}
	}
}
