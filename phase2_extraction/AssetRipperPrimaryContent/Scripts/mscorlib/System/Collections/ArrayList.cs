namespace System.Collections
{
	[Serializable]
	public class ArrayList : ICollection, IEnumerable, IList, ICloneable
	{
		[Serializable]
		private class ArrayListWrapper : ArrayList
		{
			protected ArrayList m_InnerArrayList;

			public override object this[int index]
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public override int Count
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override int Capacity
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public override bool IsFixedSize
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override bool IsReadOnly
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override bool IsSynchronized
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override object SyncRoot
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public ArrayListWrapper(ArrayList innerArrayList)
			{
			}

			public override int Add(object value)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override void Clear()
			{
			}

			public override bool Contains(object value)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override int IndexOf(object value)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override int IndexOf(object value, int startIndex)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override int IndexOf(object value, int startIndex, int count)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override void Insert(int index, object value)
			{
			}

			public override void InsertRange(int index, ICollection c)
			{
			}

			public override void Remove(object value)
			{
			}

			public override void RemoveAt(int index)
			{
			}

			public override void CopyTo(Array array)
			{
			}

			public override void CopyTo(Array array, int index)
			{
			}

			public override void CopyTo(int index, Array array, int arrayIndex, int count)
			{
			}

			public override IEnumerator GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override void AddRange(ICollection c)
			{
			}

			public override object Clone()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override void Sort()
			{
			}

			public override void Sort(IComparer comparer)
			{
			}

			public override object[] ToArray()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override Array ToArray(Type elementType)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[Serializable]
		private class FixedSizeArrayListWrapper : ArrayListWrapper
		{
			protected virtual string ErrorMessage
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override int Capacity
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public override bool IsFixedSize
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public FixedSizeArrayListWrapper(ArrayList innerList)
			{
			}

			public override int Add(object value)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override void AddRange(ICollection c)
			{
			}

			public override void Clear()
			{
			}

			public override void Insert(int index, object value)
			{
			}

			public override void InsertRange(int index, ICollection c)
			{
			}

			public override void Remove(object value)
			{
			}

			public override void RemoveAt(int index)
			{
			}
		}

		[Serializable]
		private sealed class ReadOnlyArrayListWrapper : FixedSizeArrayListWrapper
		{
			protected override string ErrorMessage
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override bool IsReadOnly
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override object this[int index]
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public ReadOnlyArrayListWrapper(ArrayList innerArrayList)
			{
			}

			public override void Sort()
			{
			}

			public override void Sort(IComparer comparer)
			{
			}
		}

		private sealed class SimpleEnumerator : IEnumerator, ICloneable
		{
			private ArrayList list;

			private int index;

			private int version;

			private object currentElement;

			private static object endFlag;

			public object Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public SimpleEnumerator(ArrayList list)
			{
			}

			public object Clone()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public bool MoveNext()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void Reset()
			{
			}
		}

		private const int DefaultInitialCapacity = 4;

		private int _size;

		private object[] _items;

		private int _version;

		private static readonly object[] EmptyArray;

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

		public virtual int Count
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

		public ArrayList()
		{
		}

		public ArrayList(ICollection c)
		{
		}

		public ArrayList(int capacity)
		{
		}

		private ArrayList(object[] array, int index, int count)
		{
		}

		private void EnsureCapacity(int count)
		{
		}

		private void Shift(int index, int count)
		{
		}

		public virtual int Add(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Clear()
		{
		}

		public virtual bool Contains(object item)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int IndexOf(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int IndexOf(object value, int startIndex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int IndexOf(object value, int startIndex, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Insert(int index, object value)
		{
		}

		public virtual void InsertRange(int index, ICollection c)
		{
		}

		public virtual void Remove(object obj)
		{
		}

		public virtual void RemoveAt(int index)
		{
		}

		public virtual void CopyTo(Array array)
		{
		}

		public virtual void CopyTo(Array array, int arrayIndex)
		{
		}

		public virtual void CopyTo(int index, Array array, int arrayIndex, int count)
		{
		}

		public virtual IEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void AddRange(ICollection c)
		{
		}

		public virtual void Sort()
		{
		}

		public virtual void Sort(IComparer comparer)
		{
		}

		public virtual object[] ToArray()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual Array ToArray(Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static void ThrowNewArgumentOutOfRangeException(string name, object actual, string message)
		{
		}

		public static ArrayList ReadOnly(ArrayList list)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
