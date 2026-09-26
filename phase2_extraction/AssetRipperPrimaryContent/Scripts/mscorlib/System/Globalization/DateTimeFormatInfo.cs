using System.Runtime.InteropServices;

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public sealed class DateTimeFormatInfo : ICloneable, IFormatProvider
	{
		private const string _RoundtripPattern = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK";

		private static readonly string MSG_READONLY;

		private static readonly string MSG_ARRAYSIZE_MONTH;

		private static readonly string MSG_ARRAYSIZE_DAY;

		private static readonly string[] INVARIANT_ABBREVIATED_DAY_NAMES;

		private static readonly string[] INVARIANT_DAY_NAMES;

		private static readonly string[] INVARIANT_ABBREVIATED_MONTH_NAMES;

		private static readonly string[] INVARIANT_MONTH_NAMES;

		private static readonly string[] INVARIANT_SHORT_DAY_NAMES;

		private static DateTimeFormatInfo theInvariantDateTimeFormatInfo;

		private bool m_isReadOnly;

		private string amDesignator;

		private string pmDesignator;

		private string dateSeparator;

		private string timeSeparator;

		private string shortDatePattern;

		private string longDatePattern;

		private string shortTimePattern;

		private string longTimePattern;

		private string monthDayPattern;

		private string yearMonthPattern;

		private string fullDateTimePattern;

		private string _RFC1123Pattern;

		private string _SortableDateTimePattern;

		private string _UniversalSortableDateTimePattern;

		private int firstDayOfWeek;

		private Calendar calendar;

		private int calendarWeekRule;

		private string[] abbreviatedDayNames;

		private string[] dayNames;

		private string[] monthNames;

		private string[] abbreviatedMonthNames;

		private string[] allShortDatePatterns;

		private string[] allLongDatePatterns;

		private string[] allShortTimePatterns;

		private string[] allLongTimePatterns;

		private string[] monthDayPatterns;

		private string[] yearMonthPatterns;

		private string[] shortDayNames;

		private int nDataItem;

		private bool m_useUserOverride;

		private bool m_isDefaultCalendar;

		private int CultureID;

		private bool bUseCalendarInfo;

		private string generalShortTimePattern;

		private string generalLongTimePattern;

		private string[] m_eraNames;

		private string[] m_abbrevEraNames;

		private string[] m_abbrevEnglishEraNames;

		private string[] m_dateWords;

		private int[] optionalCalendars;

		private string[] m_superShortDayNames;

		private string[] genitiveMonthNames;

		private string[] m_genitiveAbbreviatedMonthNames;

		private string[] leapYearMonthNames;

		private DateTimeFormatFlags formatFlags;

		private string m_name;

		private volatile string[] all_date_time_patterns;

		public bool IsReadOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal string[] RawAbbreviatedDayNames
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal string[] RawAbbreviatedMonthNames
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal string[] RawDayNames
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal string[] RawMonthNames
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string AMDesignator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string PMDesignator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string DateSeparator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string TimeSeparator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string LongDatePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string ShortDatePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string ShortTimePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string LongTimePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string MonthDayPattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string YearMonthPattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string FullDateTimePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static DateTimeFormatInfo CurrentInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static DateTimeFormatInfo InvariantInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Calendar Calendar
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public string RFC1123Pattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal string RoundtripPattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string SortableDateTimePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string UniversalSortableDateTimePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal DateTimeFormatInfo(bool read_only)
		{
		}

		public DateTimeFormatInfo()
		{
		}

		public static DateTimeFormatInfo GetInstance(IFormatProvider provider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static DateTimeFormatInfo ReadOnly(DateTimeFormatInfo dtfi)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object GetFormat(Type formatType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetAbbreviatedMonthName(int month)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetEraName(int era)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetMonthName(int month)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal string[] GetAllDateTimePatternsInternal()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void FillAllDateTimePatterns()
		{
		}

		internal string[] GetAllRawDateTimePatterns(char format)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetDayName(DayOfWeek dayofweek)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetAbbreviatedDayName(DayOfWeek dayofweek)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void FillInvariantPatterns()
		{
		}

		private string[] PopulateCombinedList(string[] dates, string[] times)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
