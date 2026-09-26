using System.Runtime.ConstrainedExecution;

namespace System.Security
{
	[MonoTODO("work in progress - encryption is missing")]
	public sealed class SecureString : CriticalFinalizerObject, IDisposable
	{
		private const int BlockSize = 16;

		private const int MaxSize = 65536;

		private int length;

		private bool disposed;

		private bool read_only;

		private byte[] data;

		public int Length
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		static SecureString()
		{
		}

		public void Dispose()
		{
		}

		private void Encrypt()
		{
		}

		private void Decrypt()
		{
		}

		internal byte[] GetBuffer()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
