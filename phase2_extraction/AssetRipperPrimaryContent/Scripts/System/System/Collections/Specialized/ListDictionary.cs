namespace System.Collections.Specialized
{
	[Serializable]
	public class ListDictionary : ICollection, IDictionary, IEnumerable
	{
		[Serializable]
		private class DictionaryNode
		{
			public object key;

			public object value;

			public DictionaryNode next;

			public DictionaryNode(object key, object value, DictionaryNode next)
			{
			}
		}

		private class DictionaryNodeCollection : ICollection, IEnumerable
		{
			private class DictionaryNodeCollectionEnumerator : IEnumerator
			{
				private IDictionaryEnumerator inner;

				private bool isKeyList;

				public object Current
				{
					get
					{
						/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
					}
				}

				public DictionaryNodeCollectionEnumerator(IDictionaryEnumerator inner, bool isKeyList)
				{
				}

				public bool MoveNext()
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}

				public void Reset()
				{
				}
			}

			private ListDictionary dict;

			private bool isKeyList;

			public int Count
			{
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

			public DictionaryNodeCollection(ListDictionary dict, bool isKeyList)
			{
			}

			public void CopyTo(Array array, int index)
			{
			}

			public IEnumerator GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private class DictionaryNodeEnumerator : IDictionaryEnumerator, IEnumerator
		{
			private ListDictionary dict;

			private bool isAtStart;

			private DictionaryNode current;

			private int version;

			public object Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			private DictionaryNode DictionaryNode
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

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

			public DictionaryNodeEnumerator(ListDictionary dict)
			{
			}

			private void FailFast()
			{
			}

			public bool MoveNext()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void Reset()
			{
			}
		}

		private int count;

		private int version;

		private DictionaryNode head;

		private IComparer comparer;

		public int Count
		{
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

		public object this[object key]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public ICollection Keys
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ICollection Values
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ListDictionary()
		{
		}

		public ListDictionary(IComparer comparer)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private DictionaryNode FindEntry(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private DictionaryNode FindEntry(object key, out DictionaryNode prev)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void AddImpl(object key, object value, DictionaryNode prev)
		{
		}

		public void CopyTo(Array array, int index)
		{
		}

		public void Add(object key, object value)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public IDictionaryEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Remove(object key)
		{
		}
	}
}
