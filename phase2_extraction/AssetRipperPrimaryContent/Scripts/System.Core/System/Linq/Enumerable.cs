using System.Collections.Generic;
using System.Diagnostics;

namespace System.Linq
{
	public static class Enumerable
	{
		private enum Fallback
		{
			Default = 0,
			Throw = 1
		}

		private class PredicateOf<T>
		{
			public static readonly Func<T, bool> Always;
		}

		private static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Fallback fallback)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[DebuggerHidden]
		private static IEnumerable<TSource> CreateWhereIterator<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
