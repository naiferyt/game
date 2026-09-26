using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Globalization
{
	[Serializable]
	public class CompareInfo : IDeserializationCallback
	{
		private const CompareOptions ValidCompareOptions_NoStringSort = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.Ordinal | CompareOptions.OrdinalIgnoreCase;

		private const CompareOptions ValidCompareOptions = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.StringSort | CompareOptions.Ordinal | CompareOptions.OrdinalIgnoreCase;

		private static readonly bool useManagedCollation;

		private int culture;

		[NonSerialized]
		private string icu_name;

		private int win32LCID;

		private string m_name;

		private static Hashtable collators;

		[NonSerialized]
		private static object monitor;

		public int LCID
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private CompareInfo()
		{
		}

		internal CompareInfo(CultureInfo ci)
		{
		}

		void IDeserializationCallback.OnDeserialization(object sender)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void construct_compareinfo(string locale);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void free_internal_collator();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void assign_sortkey(object key, string source, CompareOptions options);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int internal_index(string source, int sindex, int count, string value, CompareOptions options, bool first);

		~CompareInfo()
		{
		}

		private int string_invariant_compare_char(char c1, char c2, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int internal_compare_micro(string str1, int offset1, int len1, string str2, int offset2, int len2, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int internal_compare_switch(string str1, int offset1, int length1, string str2, int offset2, int length2, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int Compare(string string1, string string2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int Compare(string string1, string string2, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int Compare(string string1, int offset1, int length1, string string2, int offset2, int length2, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual SortKey GetSortKey(string source, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int IndexOf(string source, string value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int IndexOf(string source, string value, int startIndex, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int internal_index_switch(string s1, int sindex, int count, string s2, CompareOptions opt, bool first)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int IndexOf(string source, string value, int startIndex, int count, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual bool IsPrefix(string source, string prefix, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual bool IsSuffix(string source, string suffix, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int LastIndexOf(string source, string value, int startIndex, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int LastIndexOf(string source, string value, int startIndex, int count, CompareOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
