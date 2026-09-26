using System.Runtime.InteropServices;

namespace System.Globalization
{
	[Serializable]
	[MonoTODO("Serialization format not compatible with .NET")]
	[ComVisible(true)]
	public class GregorianCalendar : Calendar
	{
		public const int ADEra = 1;

		[NonSerialized]
		internal GregorianCalendarTypes m_type;

		private static DateTime? Min;

		private static DateTime? Max;

		public override int[] Eras
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual GregorianCalendarTypes CalendarType
		{
			set
			{
			}
		}

		public GregorianCalendar(GregorianCalendarTypes type)
		{
		}

		public GregorianCalendar()
		{
		}

		public override int GetDayOfMonth(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetEra(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetMonth(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetYear(DateTime time)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
