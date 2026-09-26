using System.Runtime.CompilerServices;

namespace System.Security.Cryptography
{
	public sealed class RNGCryptoServiceProvider : RandomNumberGenerator
	{
		private static object _lock;

		private IntPtr _handle;

		static RNGCryptoServiceProvider()
		{
		}

		private void Check()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool RngOpen();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr RngInitialize(byte[] seed);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr RngGetBytes(IntPtr handle, byte[] data);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RngClose(IntPtr handle);

		public override void GetBytes(byte[] data)
		{
		}

		public override void GetNonZeroBytes(byte[] data)
		{
		}

		~RNGCryptoServiceProvider()
		{
		}
	}
}
