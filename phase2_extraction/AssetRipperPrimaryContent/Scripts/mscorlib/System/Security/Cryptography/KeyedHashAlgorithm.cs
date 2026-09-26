using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public abstract class KeyedHashAlgorithm : HashAlgorithm
	{
		protected byte[] KeyValue;

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

		~KeyedHashAlgorithm()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void ZeroizeKey()
		{
		}

		public new static KeyedHashAlgorithm Create()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public new static KeyedHashAlgorithm Create(string algName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
