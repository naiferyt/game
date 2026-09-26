namespace System.Collections.Generic
{
	[Serializable]
	internal sealed class GenericEqualityComparer<T> : EqualityComparer<T> where T : IEquatable<T>
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
}
