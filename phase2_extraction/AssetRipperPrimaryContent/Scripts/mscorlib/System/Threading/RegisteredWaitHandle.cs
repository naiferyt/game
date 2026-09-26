using System.Runtime.InteropServices;

namespace System.Threading
{
	[ComVisible(true)]
	public sealed class RegisteredWaitHandle : MarshalByRefObject
	{
		private WaitHandle _waitObject;

		private WaitOrTimerCallback _callback;

		private TimeSpan _timeout;

		private object _state;

		private bool _executeOnlyOnce;

		private WaitHandle _finalEvent;

		private ManualResetEvent _cancelEvent;

		private int _callsInProcess;

		private bool _unregistered;

		internal RegisteredWaitHandle(WaitHandle waitObject, WaitOrTimerCallback callback, object state, TimeSpan timeout, bool executeOnlyOnce)
		{
		}

		internal void Wait(object state)
		{
		}

		private void DoCallBack(object timedOut)
		{
		}
	}
}
