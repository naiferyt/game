using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("IDeserializationCallback isn't implemented.")]
	public class TextInfo : ICloneable, IDeserializationCallback
	{
		private struct Data
		{
			public int ansi;

			public int ebcdic;

			public int mac;

			public int oem;

			public byte list_sep;
		}

		private string m_listSeparator;

		private bool m_isReadOnly;

		private string customCultureName;

		[NonSerialized]
		private int m_nDataItem;

		private bool m_useUserOverride;

		private int m_win32LangID;

		[NonSerialized]
		private readonly CultureInfo ci;

		[NonSerialized]
		private readonly bool handleDotI;

		[NonSerialized]
		private readonly Data data;

		public virtual string ListSeparator
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[ComVisible(false)]
		public string CultureName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal unsafe TextInfo(CultureInfo ci, int lcid, void* data, bool read_only)
		{
		}

		private TextInfo(TextInfo textInfo)
		{
		}

		[MonoTODO]
		void IDeserializationCallback.OnDeserialization(object sender)
		{
		}

		public override bool Equals(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual char ToLower(char c)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual char ToUpper(char c)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string ToLower(string str)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string ToUpper(string str)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public static TextInfo ReadOnly(TextInfo textInfo)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public virtual object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
