namespace System.Collections.Generic
{
	[Serializable]
	public abstract class Comparer<T> : IComparer<T>, IComparer
	{
		private sealed class DefaultComparer : Comparer<T>
		{
			public override int Compare(T x, T y)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private static readonly Comparer<T> _default;

		public static Comparer<T> Default
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		static Comparer()
		{
		}

		int IComparer.Compare(object x, object y)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract int Compare(T x, T y);
	}
}
