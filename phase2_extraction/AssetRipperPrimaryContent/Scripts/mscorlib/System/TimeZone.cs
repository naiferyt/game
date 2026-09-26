using System.Globalization;
using System.Runtime.InteropServices;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public abstract class TimeZone
	{
		private static TimeZone currentTimeZone;

		public static TimeZone CurrentTimeZone
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract DaylightTime GetDaylightChanges(int year);

		public abstract TimeSpan GetUtcOffset(DateTime time);

		public virtual bool IsDaylightSavingTime(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsDaylightSavingTime(DateTime time, DaylightTime daylightTimes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual DateTime ToLocalTime(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual DateTime ToUniversalTime(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal TimeSpan GetLocalTimeDiff(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal TimeSpan GetLocalTimeDiff(DateTime time, TimeSpan utc_offset)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
