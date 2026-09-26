using System.Runtime.CompilerServices;

namespace System.Threading
{
	public sealed class Mutex : WaitHandle
	{
		public Mutex(bool initiallyOwned)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr CreateMutex_internal(bool initiallyOwned, string name, out bool created);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ReleaseMutex_internal(IntPtr handle);

		public void ReleaseMutex()
		{
		}
	}
}
