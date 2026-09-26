namespace System.Collections.Generic
{
	[Serializable]
	public abstract class EqualityComparer<T> : IEqualityComparer<T>, IEqualityComparer
	{
		[Serializable]
		private sealed class DefaultComparer : EqualityComparer<T>
		{
			public override int GetHashCode(T obj)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override bool Equals(T x, T y)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private static readonly EqualityComparer<T> _default;

		public static EqualityComparer<T> Default
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		static EqualityComparer()
		{
		}

		int IEqualityComparer.GetHashCode(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		bool IEqualityComparer.Equals(object x, object y)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract int GetHashCode(T obj);

		public abstract bool Equals(T x, T y);
	}
}
