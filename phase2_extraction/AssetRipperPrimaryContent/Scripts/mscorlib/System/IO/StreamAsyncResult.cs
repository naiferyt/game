using System.Threading;

namespace System.IO
{
	internal class StreamAsyncResult : IAsyncResult
	{
		private object state;

		private bool completed;

		private bool done;

		private Exception exc;

		private int nbytes;

		private ManualResetEvent wh;

		public WaitHandle AsyncWaitHandle
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Exception Exception
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int NBytes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool Done
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public StreamAsyncResult(object state)
		{
		}

		public void SetComplete(Exception e)
		{
		}

		public void SetComplete(Exception e, int nbytes)
		{
		}
	}
}
