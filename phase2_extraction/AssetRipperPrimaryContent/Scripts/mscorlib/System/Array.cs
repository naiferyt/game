using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public abstract class Array : ICollection, IEnumerable, IList, ICloneable
	{
		private class ArrayReadOnlyList<T> : ICollection<T>, IEnumerable<T>, IList<T>, IEnumerable
		{
			private T[] array;

			public T this[int index]
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public int Count
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public ArrayReadOnlyList(T[] array)
			{
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void Add(T item)
			{
			}

			public void Clear()
			{
			}

			public bool Contains(T item)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void CopyTo(T[] array, int index)
			{
			}

			[DebuggerHidden]
			public IEnumerator<T> GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public int IndexOf(T item)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void Insert(int index, T item)
			{
			}

			public bool Remove(T item)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void RemoveAt(int index)
			{
			}

			private static Exception ReadOnlyError()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal struct InternalEnumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
		{
			private const int NOT_STARTED = -2;

			private const int FINISHED = -1;

			private Array array;

			private int idx;

			object IEnumerator.Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public T Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			internal InternalEnumerator(Array array)
			{
			}

			void IEnumerator.Reset()
			{
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal class SimpleEnumerator : IEnumerator, ICloneable
		{
			private Array enumeratee;

			private int currentpos;

			private int length;

			public object Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public SimpleEnumerator(Array arrayToEnumerate)
			{
			}

			public bool MoveNext()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void Reset()
			{
			}

			public object Clone()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private delegate void Swapper(int i, int j);

		object IList.this[int index]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		int ICollection.Count
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int Length
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[ComVisible(false)]
		public long LongLength
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int Rank
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public object SyncRoot
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private Array()
		{
		}

		int IList.Add(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		void IList.Clear()
		{
		}

		bool IList.Contains(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		int IList.IndexOf(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		void IList.Insert(int index, object value)
		{
		}

		void IList.Remove(object value)
		{
		}

		void IList.RemoveAt(int index)
		{
		}

		internal int InternalArray__ICollection_get_Count()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal bool InternalArray__ICollection_get_IsReadOnly()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal IEnumerator<T> InternalArray__IEnumerable_GetEnumerator<T>()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void InternalArray__ICollection_Clear()
		{
		}

		internal void InternalArray__ICollection_Add<T>(T item)
		{
		}

		internal bool InternalArray__ICollection_Remove<T>(T item)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal bool InternalArray__ICollection_Contains<T>(T item)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void InternalArray__ICollection_CopyTo<T>(T[] array, int index)
		{
		}

		internal void InternalArray__Insert<T>(int index, T item)
		{
		}

		internal void InternalArray__RemoveAt(int index)
		{
		}

		internal int InternalArray__IndexOf<T>(T item)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal T InternalArray__get_Item<T>(int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void InternalArray__set_Item<T>(int index, T item)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void GetGenericValueImpl<T>(int pos, out T value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void SetGenericValueImpl<T>(int pos, ref T value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetRank();

		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetLength(int dimension);

		[ComVisible(false)]
		public long GetLongLength(int dimension)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public extern int GetLowerBound(int dimension);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern object GetValue(params int[] indices);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetValue(object value, params int[] indices);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern object GetValueImpl(int pos);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void SetValueImpl(object value, int pos);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool FastCopy(Array source, int source_idx, Array dest, int dest_idx, int length);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Array CreateInstanceImpl(Type elementType, int[] lengths, int[] bounds);

		public IEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public int GetUpperBound(int dimension)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object GetValue(int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object GetValue(int index1, int index2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public object GetValue(int index1, int index2, int index3)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public object GetValue(long index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public object GetValue(long index1, long index2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public object GetValue(long index1, long index2, long index3)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public void SetValue(object value, long index)
		{
		}

		[ComVisible(false)]
		public void SetValue(object value, long index1, long index2)
		{
		}

		[ComVisible(false)]
		public void SetValue(object value, long index1, long index2, long index3)
		{
		}

		public void SetValue(object value, int index)
		{
		}

		public void SetValue(object value, int index1, int index2)
		{
		}

		public void SetValue(object value, int index1, int index2, int index3)
		{
		}

		public static Array CreateInstance(Type elementType, int length)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Array CreateInstance(Type elementType, int length1, int length2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Array CreateInstance(Type elementType, int length1, int length2, int length3)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Array CreateInstance(Type elementType, params int[] lengths)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Array CreateInstance(Type elementType, int[] lengths, int[] lowerBounds)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static int[] GetIntArray(long[] values)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Array CreateInstance(Type elementType, params long[] lengths)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public object GetValue(params long[] indices)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public void SetValue(object value, params long[] indices)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int BinarySearch(Array array, object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int BinarySearch(Array array, object value, IComparer comparer)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int BinarySearch(Array array, int index, int length, object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int BinarySearch(Array array, int index, int length, object value, IComparer comparer)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static int DoBinarySearch(Array array, int index, int length, object value, IComparer comparer)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void Clear(Array array, int index, int length)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClearInternal(Array a, int index, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern object Clone();

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Copy(Array sourceArray, Array destinationArray, int length)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Copy(Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Copy(Array sourceArray, Array destinationArray, long length)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int IndexOf(Array array, object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int IndexOf(Array array, object value, int startIndex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int IndexOf(Array array, object value, int startIndex, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Initialize()
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int LastIndexOf(Array array, object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int LastIndexOf(Array array, object value, int startIndex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int LastIndexOf(Array array, object value, int startIndex, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static Swapper get_swapper(Array array)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static Swapper get_swapper<T>(T[] array)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Reverse(Array array)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Reverse(Array array, int index, int length)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort(Array array)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort(Array keys, Array items)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort(Array array, IComparer comparer)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort(Array array, int index, int length)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort(Array keys, Array items, IComparer comparer)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort(Array keys, Array items, int index, int length)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort(Array array, int index, int length, IComparer comparer)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort(Array keys, Array items, int index, int length, IComparer comparer)
		{
		}

		private void int_swapper(int i, int j)
		{
		}

		private void obj_swapper(int i, int j)
		{
		}

		private void slow_swapper(int i, int j)
		{
		}

		private void double_swapper(int i, int j)
		{
		}

		private static int new_gap(int gap)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void combsort(double[] array, int start, int size, Swapper swap_items)
		{
		}

		private static void combsort(int[] array, int start, int size, Swapper swap_items)
		{
		}

		private static void combsort(char[] array, int start, int size, Swapper swap_items)
		{
		}

		private static void qsort(Array keys, Array items, int low0, int high0, IComparer comparer)
		{
		}

		private static void swap(Array keys, Array items, int i, int j)
		{
		}

		private static int compare(object value1, object value2, IComparer comparer)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort<T>(T[] array)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort<T>(T[] array, IComparer<T> comparer)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, IComparer<TKey> comparer)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort<T>(T[] array, int index, int length)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort<T>(T[] array, int index, int length, IComparer<T> comparer)
		{
		}

		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length, IComparer<TKey> comparer)
		{
		}

		public static void Sort<T>(T[] array, Comparison<T> comparison)
		{
		}

		internal static void Sort<T>(T[] array, int length, Comparison<T> comparison)
		{
		}

		private static void qsort<K, V>(K[] keys, V[] items, int low0, int high0, IComparer<K> comparer)
		{
		}

		private static int compare<T>(T value1, T value2, IComparer<T> comparer)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void qsort<T>(T[] array, int low0, int high0, Comparison<T> comparison)
		{
		}

		private static void swap<K, V>(K[] keys, V[] items, int i, int j)
		{
		}

		private static void swap<T>(T[] array, int i, int j)
		{
		}

		public void CopyTo(Array array, int index)
		{
		}

		[ComVisible(false)]
		public void CopyTo(Array array, long index)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void Resize<T>(ref T[] array, int newSize)
		{
		}

		internal static void Resize<T>(ref T[] array, int length, int newSize)
		{
		}

		public static bool TrueForAll<T>(T[] array, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void ForEach<T>(T[] array, Action<T> action)
		{
		}

		public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Converter<TInput, TOutput> converter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int FindLastIndex<T>(T[] array, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int FindLastIndex<T>(T[] array, int startIndex, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int FindLastIndex<T>(T[] array, int startIndex, int count, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int FindIndex<T>(T[] array, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int FindIndex<T>(T[] array, int startIndex, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int FindIndex<T>(T[] array, int startIndex, int count, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int BinarySearch<T>(T[] array, T value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int BinarySearch<T>(T[] array, int index, int length, T value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int BinarySearch<T>(T[] array, int index, int length, T value, IComparer<T> comparer)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int IndexOf<T>(T[] array, T value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int IndexOf<T>(T[] array, T value, int startIndex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int IndexOf<T>(T[] array, T value, int startIndex, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int LastIndexOf<T>(T[] array, T value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int LastIndexOf<T>(T[] array, T value, int startIndex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int LastIndexOf<T>(T[] array, T value, int startIndex, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static T[] FindAll<T>(T[] array, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool Exists<T>(T[] array, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static ReadOnlyCollection<T> AsReadOnly<T>(T[] array)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static T Find<T>(T[] array, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static T FindLast<T>(T[] array, Predicate<T> match)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void ConstrainedCopy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
		{
		}
	}
}
