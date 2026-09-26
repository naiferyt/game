using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
	internal struct MonoEnumInfo
	{
		internal class IntComparer : IComparer<int>, IComparer
		{
			public int Compare(object x, object y)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public int Compare(int ix, int iy)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal class LongComparer : IComparer<long>, IComparer
		{
			public int Compare(object x, object y)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public int Compare(long ix, long iy)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal class SByteComparer : IComparer<sbyte>, IComparer
		{
			public int Compare(object x, object y)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public int Compare(sbyte ix, sbyte iy)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal class ShortComparer : IComparer<short>, IComparer
		{
			public int Compare(object x, object y)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public int Compare(short ix, short iy)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal Type utype;

		internal Array values;

		internal string[] names;

		internal Hashtable name_hash;

		[ThreadStatic]
		private static Hashtable cache;

		private static Hashtable global_cache;

		private static object global_cache_monitor;

		internal static SByteComparer sbyte_comparer;

		internal static ShortComparer short_comparer;

		internal static IntComparer int_comparer;

		internal static LongComparer long_comparer;

		private static Hashtable Cache
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private MonoEnumInfo(MonoEnumInfo other)
		{
		}

		static MonoEnumInfo()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_enum_info(Type enumType, out MonoEnumInfo info);

		internal static void GetInfo(Type enumType, out MonoEnumInfo info)
		{
		}
	}
}
