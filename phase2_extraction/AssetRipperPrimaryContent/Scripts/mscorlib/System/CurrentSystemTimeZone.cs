using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	internal class CurrentSystemTimeZone : TimeZone, IDeserializationCallback
	{
		private string m_standardName;

		private string m_daylightName;

		private Hashtable m_CachedDaylightChanges;

		private long m_ticksOffset;

		[NonSerialized]
		private TimeSpan utcOffsetWithOutDLS;

		[NonSerialized]
		private TimeSpan utcOffsetWithDLS;

		private static int this_year;

		private static DaylightTime this_year_dlt;

		internal CurrentSystemTimeZone()
		{
		}

		internal CurrentSystemTimeZone(long lnow)
		{
		}

		void IDeserializationCallback.OnDeserialization(object sender)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetTimeZoneData(int year, out long[] data, out string[] names);

		public override DaylightTime GetDaylightChanges(int year)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override TimeSpan GetUtcOffset(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void OnDeserialization(DaylightTime dlt)
		{
		}

		private DaylightTime GetDaylightTimeFromData(long[] data)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
