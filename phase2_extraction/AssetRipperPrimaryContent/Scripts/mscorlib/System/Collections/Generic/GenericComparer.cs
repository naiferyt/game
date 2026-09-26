namespace System.Collections.Generic
{
	[Serializable]
	internal sealed class GenericComparer<T> : Comparer<T> where T : IComparable<T>
	{
		public override int Compare(T x, T y)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
