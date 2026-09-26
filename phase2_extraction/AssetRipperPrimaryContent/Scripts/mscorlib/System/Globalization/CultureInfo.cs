using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public class CultureInfo : ICloneable, IFormatProvider
	{
		private const int NumOptionalCalendars = 5;

		private const int GregorianTypeMask = 16777215;

		private const int CalendarTypeBits = 24;

		private const int InvariantCultureId = 127;

		private static volatile CultureInfo invariant_culture_info;

		private static object shared_table_lock;

		internal static int BootstrapCultureID;

		private bool m_isReadOnly;

		private int cultureID;

		[NonSerialized]
		private int parent_lcid;

		[NonSerialized]
		private int specific_lcid;

		[NonSerialized]
		private int datetime_index;

		[NonSerialized]
		private int number_index;

		private bool m_useUserOverride;

		[NonSerialized]
		private volatile NumberFormatInfo numInfo;

		private volatile DateTimeFormatInfo dateTimeInfo;

		private volatile TextInfo textInfo;

		private string m_name;

		[NonSerialized]
		private string displayname;

		[NonSerialized]
		private string englishname;

		[NonSerialized]
		private string nativename;

		[NonSerialized]
		private string iso3lang;

		[NonSerialized]
		private string iso2lang;

		[NonSerialized]
		private string icu_name;

		[NonSerialized]
		private string win3lang;

		[NonSerialized]
		private string territory;

		private volatile CompareInfo compareInfo;

		[NonSerialized]
		private unsafe readonly int* calendar_data;

		[NonSerialized]
		private unsafe readonly void* textinfo_data;

		[NonSerialized]
		private Calendar[] optional_calendars;

		[NonSerialized]
		private CultureInfo parent_culture;

		private int m_dataItem;

		private Calendar calendar;

		[NonSerialized]
		private bool constructed;

		[NonSerialized]
		internal byte[] cached_serialized_form;

		private static readonly string MSG_READONLY;

		private static Hashtable shared_by_number;

		private static Hashtable shared_by_name;

		public static CultureInfo InvariantCulture
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static CultureInfo CurrentCulture
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static CultureInfo CurrentUICulture
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal string Territory
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual int LCID
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string Name
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string NativeName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual Calendar Calendar
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual Calendar[] OptionalCalendars
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual CultureInfo Parent
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual TextInfo TextInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string ThreeLetterISOLanguageName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string ThreeLetterWindowsLanguageName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string TwoLetterISOLanguageName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool UseUserOverride
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal string IcuName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual CompareInfo CompareInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool IsNeutralCulture
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual NumberFormatInfo NumberFormat
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual DateTimeFormatInfo DateTimeFormat
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual string DisplayName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string EnglishName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static CultureInfo InstalledUICulture
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public CultureInfo(int culture)
		{
		}

		public CultureInfo(int culture, bool useUserOverride)
		{
		}

		private CultureInfo(int culture, bool useUserOverride, bool read_only)
		{
		}

		public CultureInfo(string name)
		{
		}

		public CultureInfo(string name, bool useUserOverride)
		{
		}

		private CultureInfo(string name, bool useUserOverride, bool read_only)
		{
		}

		private CultureInfo()
		{
		}

		static CultureInfo()
		{
		}

		public static CultureInfo CreateSpecificCulture(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static CultureInfo ConstructCurrentCulture()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static CultureInfo ConstructCurrentUICulture()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void ClearCachedData()
		{
		}

		public virtual object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static CultureInfo[] GetCultures(CultureTypes types)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static CultureInfo ReadOnly(CultureInfo ci)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static bool IsIDNeutralCulture(int lcid)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void CheckNeutral()
		{
		}

		public virtual object GetFormat(Type formatType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Construct()
		{
		}

		private bool ConstructInternalLocaleFromName(string locale)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool ConstructInternalLocaleFromLcid(int lcid)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool ConstructInternalLocaleFromSpecificName(CultureInfo ci, string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool ConstructInternalLocaleFromCurrentLocale(CultureInfo ci)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool construct_internal_locale_from_lcid(int lcid);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool construct_internal_locale_from_name(string name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool construct_internal_locale_from_specific_name(CultureInfo ci, string name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool construct_internal_locale_from_current_locale(CultureInfo ci);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern CultureInfo[] internal_get_cultures(bool neutral, bool specific, bool installed);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void construct_datetime_format();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void construct_number_format();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool internal_is_lcid_neutral(int lcid, out bool is_neutral);

		private void ConstructInvariant(bool read_only)
		{
		}

		private TextInfo CreateTextInfo(bool readOnly)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void insert_into_shared_tables(CultureInfo c)
		{
		}

		public static CultureInfo GetCultureInfo(int culture)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static CultureInfo GetCultureInfo(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MonoTODO("Currently it ignores the altName parameter")]
		public static CultureInfo GetCultureInfo(string name, string altName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static CultureInfo GetCultureInfoByIetfLanguageTag(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static CultureInfo CreateCulture(string name, bool reference)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void ConstructCalendars()
		{
		}
	}
}
