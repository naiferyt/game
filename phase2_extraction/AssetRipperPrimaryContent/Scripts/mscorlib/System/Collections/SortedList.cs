using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Collections
{
	[Serializable]
	[DebuggerDisplay("Count={Count}")]
	[ComVisible(true)]
	public class SortedList : ICollection, IDictionary, IEnumerable, ICloneable
	{
		private sealed class Enumerator : IDictionaryEnumerator, IEnumerator, ICloneable
		{
			private SortedList host;

			private int stamp;

			private int pos;

			private int size;

			private EnumeratorMode mode;

			private object currentKey;

			private object currentValue;

			private bool invalid;

			private static readonly string xstr;

			public DictionaryEntry Entry
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public object Key
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public object Value
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public object Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public Enumerator(SortedList host, EnumeratorMode mode)
			{
			}

			public void Reset()
			{
			}

			public bool MoveNext()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public object Clone()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private enum EnumeratorMode
		{
			KEY_MODE = 0,
			VALUE_MODE = 1,
			ENTRY_MODE = 2
		}

		[Serializable]
		private class ListKeys : ICollection, IEnumerable, IList
		{
			private SortedList host;

			public virtual int Count
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual bool IsSynchronized
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual object SyncRoot
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual bool IsFixedSize
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual bool IsReadOnly
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual object this[int index]
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public ListKeys(SortedList host)
			{
			}

			public virtual void CopyTo(Array array, int arrayIndex)
			{
			}

			public virtual int Add(object value)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public virtual void Clear()
			{
			}

			public virtual bool Contains(object key)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public virtual int IndexOf(object key)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public virtual void Insert(int index, object value)
			{
			}

			public virtual void Remove(object value)
			{
			}

			public virtual void RemoveAt(int index)
			{
			}

			public virtual IEnumerator GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[Serializable]
		private class ListValues : ICollection, IEnumerable, IList
		{
			private SortedList host;

			public virtual int Count
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual bool IsSynchronized
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual object SyncRoot
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual bool IsFixedSize
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual bool IsReadOnly
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public virtual object this[int index]
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public ListValues(SortedList host)
			{
			}

			public virtual void CopyTo(Array array, int arrayIndex)
			{
			}

			public virtual int Add(object value)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public virtual void Clear()
			{
			}

			public virtual bool Contains(object value)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public virtual int IndexOf(object value)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public virtual void Insert(int index, object value)
			{
			}

			public virtual void Remove(object value)
			{
			}

			public virtual void RemoveAt(int index)
			{
			}

			public virtual IEnumerator GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[Serializable]
		internal struct Slot
		{
			internal object key;

			internal object value;
		}

		private static readonly int INITIAL_SIZE;

		private int inUse;

		private int modificationCount;

		private Slot[] table;

		private IComparer comparer;

		private int defaultCapacity;

		public virtual int Count
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool IsSynchronized
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual object SyncRoot
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool IsFixedSize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool IsReadOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual ICollection Keys
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual ICollection Values
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual object this[object key]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual int Capacity
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public SortedList()
		{
		}

		public SortedList(IComparer comparer, int capacity)
		{
		}

		public SortedList(IComparer comparer)
		{
		}

		public SortedList(IDictionary d, IComparer comparer)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Add(object key, object value)
		{
		}

		public virtual void Clear()
		{
		}

		public virtual bool Contains(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual IDictionaryEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Remove(object key)
		{
		}

		public virtual void CopyTo(Array array, int arrayIndex)
		{
		}

		public virtual object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void RemoveAt(int index)
		{
		}

		public virtual int IndexOfKey(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int IndexOfValue(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual bool ContainsValue(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual object GetByIndex(int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual object GetKey(int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void EnsureCapacity(int n, int free)
		{
		}

		private void PutImpl(object key, object value, bool overwrite)
		{
		}

		private object GetImpl(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void InitTable(int capacity, bool forceSize)
		{
		}

		private void CopyToArray(Array arr, int i, EnumeratorMode mode)
		{
		}

		private int Find(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
