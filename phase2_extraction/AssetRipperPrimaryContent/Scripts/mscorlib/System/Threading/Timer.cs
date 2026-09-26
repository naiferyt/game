using System.Collections;
using System.Runtime.InteropServices;

namespace System.Threading
{
	[ComVisible(true)]
	public sealed class Timer : MarshalByRefObject, IDisposable
	{
		private sealed class Scheduler
		{
			private static Scheduler instance;

			private SortedList list;

			public static Scheduler Instance
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			private Scheduler()
			{
			}

			static Scheduler()
			{
			}

			public void Remove(Timer timer)
			{
			}

			public void Change(Timer timer, long new_next_run)
			{
			}

			private void Add(Timer timer)
			{
			}

			private int InternalRemove(Timer timer)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			private void SchedulerThread()
			{
			}

			private void ShrinkIfNeeded(ArrayList list, int initial)
			{
			}
		}

		private sealed class TimerComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private const long MaxValue = 4294967294L;

		private static Scheduler scheduler;

		private TimerCallback callback;

		private object state;

		private long due_time_ms;

		private long period_ms;

		private long next_run;

		private bool disposed;

		public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
		{
		}

		private void Init(TimerCallback callback, object state, long dueTime, long period)
		{
		}

		public void Dispose()
		{
		}

		private bool Change(long dueTime, long period, bool first)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
