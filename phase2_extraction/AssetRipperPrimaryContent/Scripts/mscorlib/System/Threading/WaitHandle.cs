using System.Runtime.CompilerServices;

namespace System.Threading
{
	public abstract class WaitHandle : MarshalByRefObject, IDisposable
	{
		public const int WaitTimeout = 258;

		private IntPtr os_handle;

		protected static readonly IntPtr InvalidHandle;

		private bool disposed;

		public virtual IntPtr Handle
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		void IDisposable.Dispose()
		{
		}

		private static void CheckArray(WaitHandle[] handles, bool waitAll)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int WaitAny_internal(WaitHandle[] handles, int ms, bool exitContext);

		public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void CheckDisposed()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool WaitOne_internal(IntPtr handle, int ms, bool exitContext);

		protected virtual void Dispose(bool explicitDisposing)
		{
		}

		public virtual bool WaitOne()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		~WaitHandle()
		{
		}
	}
}
