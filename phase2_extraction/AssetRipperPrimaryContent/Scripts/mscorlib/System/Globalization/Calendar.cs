using System.Runtime.InteropServices;

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public abstract class Calendar : ICloneable
	{
		public const int CurrentEra = 0;

		[NonSerialized]
		private bool m_isReadOnly;

		[NonSerialized]
		internal int twoDigitYearMax;

		[NonSerialized]
		private int M_MaxYearValue;

		[NonSerialized]
		internal string[] M_AbbrEraNames;

		[NonSerialized]
		internal string[] M_EraNames;

		internal int m_currentEraValue;

		public abstract int[] Eras { get; }

		internal string[] EraNames
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[ComVisible(false)]
		public virtual object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void CheckReadOnly()
		{
		}

		public abstract int GetDayOfMonth(DateTime time);

		public abstract DayOfWeek GetDayOfWeek(DateTime time);

		public abstract int GetEra(DateTime time);

		public abstract int GetMonth(DateTime time);

		public abstract int GetYear(DateTime time);
	}
}
