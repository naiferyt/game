using System.Runtime.InteropServices;

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public sealed class NumberFormatInfo : ICloneable, IFormatProvider
	{
		private bool isReadOnly;

		private string decimalFormats;

		private string currencyFormats;

		private string percentFormats;

		private string digitPattern;

		private string zeroPattern;

		private int currencyDecimalDigits;

		private string currencyDecimalSeparator;

		private string currencyGroupSeparator;

		private int[] currencyGroupSizes;

		private int currencyNegativePattern;

		private int currencyPositivePattern;

		private string currencySymbol;

		private string nanSymbol;

		private string negativeInfinitySymbol;

		private string negativeSign;

		private int numberDecimalDigits;

		private string numberDecimalSeparator;

		private string numberGroupSeparator;

		private int[] numberGroupSizes;

		private int numberNegativePattern;

		private int percentDecimalDigits;

		private string percentDecimalSeparator;

		private string percentGroupSeparator;

		private int[] percentGroupSizes;

		private int percentNegativePattern;

		private int percentPositivePattern;

		private string percentSymbol;

		private string perMilleSymbol;

		private string positiveInfinitySymbol;

		private string positiveSign;

		private string ansiCurrencySymbol;

		private int m_dataItem;

		private bool m_useUserOverride;

		private bool validForParseAsNumber;

		private bool validForParseAsCurrency;

		private string[] nativeDigits;

		private int digitSubstitution;

		private static readonly string[] invariantNativeDigits;

		public int CurrencyDecimalDigits
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string CurrencyDecimalSeparator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string CurrencyGroupSeparator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal int[] RawCurrencyGroupSizes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int CurrencyNegativePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int CurrencyPositivePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string CurrencySymbol
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static NumberFormatInfo CurrentInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static NumberFormatInfo InvariantInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string NaNSymbol
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string NegativeInfinitySymbol
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string NegativeSign
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int NumberDecimalDigits
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string NumberDecimalSeparator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string NumberGroupSeparator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal int[] RawNumberGroupSizes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int NumberNegativePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public int PercentDecimalDigits
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string PercentDecimalSeparator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string PercentGroupSeparator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal int[] RawPercentGroupSizes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int PercentNegativePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int PercentPositivePattern
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string PercentSymbol
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string PerMilleSymbol
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string PositiveInfinitySymbol
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string PositiveSign
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal NumberFormatInfo(int lcid, bool read_only)
		{
		}

		internal NumberFormatInfo(bool read_only)
		{
		}

		public NumberFormatInfo()
		{
		}

		public object GetFormat(Type formatType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static NumberFormatInfo ReadOnly(NumberFormatInfo nfi)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static NumberFormatInfo GetInstance(IFormatProvider formatProvider)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
