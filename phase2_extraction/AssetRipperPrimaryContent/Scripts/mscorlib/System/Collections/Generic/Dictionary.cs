using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Collections.Generic
{
	[Serializable]
	[DebuggerTypeProxy(typeof(CollectionDebuggerView<, >))]
	[ComVisible(false)]
	[DebuggerDisplay("Count={Count}")]
	public class Dictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, ICollection, IDictionary, IEnumerable, IDeserializationCallback, ISerializable
	{
		[Serializable]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator, IEnumerator, IDisposable
		{
			private Dictionary<TKey, TValue> dictionary;

			private int next;

			private int stamp;

			internal KeyValuePair<TKey, TValue> current;

			object IEnumerator.Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public KeyValuePair<TKey, TValue> Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			internal TKey CurrentKey
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			internal TValue CurrentValue
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			internal Enumerator(Dictionary<TKey, TValue> dictionary)
			{
			}

			void IEnumerator.Reset()
			{
			}

			public bool MoveNext()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			internal void Reset()
			{
			}

			private void VerifyState()
			{
			}

			private void VerifyCurrent()
			{
			}

			public void Dispose()
			{
			}
		}

		[Serializable]
		[DebuggerDisplay("Count={Count}")]
		[DebuggerTypeProxy(typeof(CollectionDebuggerView<, >))]
		public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, ICollection, IEnumerable
		{
			[Serializable]
			public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
			{
				private Dictionary<TKey, TValue>.Enumerator host_enumerator;

				object IEnumerator.Current
				{
					get
					{
						/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
					}
				}

				public TKey Current
				{
					get
					{
						/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
					}
				}

				internal Enumerator(Dictionary<TKey, TValue> host)
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

			private Dictionary<TKey, TValue> dictionary;

			bool ICollection<TKey>.IsReadOnly
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public int Count
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public KeyCollection(Dictionary<TKey, TValue> dictionary)
			{
			}

			void ICollection<TKey>.Add(TKey item)
			{
			}

			void ICollection<TKey>.Clear()
			{
			}

			bool ICollection<TKey>.Contains(TKey item)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			bool ICollection<TKey>.Remove(TKey item)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void CopyTo(TKey[] array, int index)
			{
			}

			public Enumerator GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[Serializable]
		private class ShimEnumerator : IDictionaryEnumerator, IEnumerator
		{
			private Enumerator host_enumerator;

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

			public ShimEnumerator(Dictionary<TKey, TValue> host)
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

		private delegate TRet Transform<TRet>(TKey key, TValue value);

		[Serializable]
		[DebuggerTypeProxy(typeof(CollectionDebuggerView<, >))]
		[DebuggerDisplay("Count={Count}")]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, ICollection, IEnumerable
		{
			[Serializable]
			public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				private Dictionary<TKey, TValue>.Enumerator host_enumerator;

				object IEnumerator.Current
				{
					get
					{
						/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
					}
				}

				public TValue Current
				{
					get
					{
						/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
					}
				}

				internal Enumerator(Dictionary<TKey, TValue> host)
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

			private Dictionary<TKey, TValue> dictionary;

			bool ICollection<TValue>.IsReadOnly
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public int Count
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public ValueCollection(Dictionary<TKey, TValue> dictionary)
			{
			}

			void ICollection<TValue>.Add(TValue item)
			{
			}

			void ICollection<TValue>.Clear()
			{
			}

			bool ICollection<TValue>.Contains(TValue item)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			bool ICollection<TValue>.Remove(TValue item)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void CopyTo(TValue[] array, int index)
			{
			}

			public Enumerator GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private const int INITIAL_SIZE = 10;

		private const float DEFAULT_LOAD_FACTOR = 0.9f;

		private const int NO_SLOT = -1;

		private const int HASH_FLAG = int.MinValue;

		private int[] table;

		private Link[] linkSlots;

		private TKey[] keySlots;

		private TValue[] valueSlots;

		private int touchedSlots;

		private int emptySlot;

		private int count;

		private int threshold;

		private IEqualityComparer<TKey> hcp;

		private SerializationInfo serialization_info;

		private int generation;

		ICollection IDictionary.Keys
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		ICollection IDictionary.Values
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		bool IDictionary.IsFixedSize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		bool IDictionary.IsReadOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		object IDictionary.this[object key]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		bool ICollection.IsSynchronized
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int Count
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public KeyCollection Keys
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ValueCollection Values
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Dictionary()
		{
		}

		public Dictionary(IEqualityComparer<TKey> comparer)
		{
		}

		public Dictionary(IDictionary<TKey, TValue> dictionary)
		{
		}

		public Dictionary(int capacity)
		{
		}

		public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
		}

		protected Dictionary(SerializationInfo info, StreamingContext context)
		{
		}

		void IDictionary.Add(object key, object value)
		{
		}

		bool IDictionary.Contains(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		void IDictionary.Remove(object key)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Init(int capacity, IEqualityComparer<TKey> hcp)
		{
		}

		private void InitArrays(int size)
		{
		}

		private void CopyToCheck(Array array, int index)
		{
		}

		private void Do_CopyTo<TRet, TElem>(TElem[] array, int index, Transform<TRet> transform) where TRet : TElem
		{
		}

		private static KeyValuePair<TKey, TValue> make_pair(TKey key, TValue value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static TKey pick_key(TKey key, TValue value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static TValue pick_value(TKey key, TValue value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
		}

		private void Do_ICollectionCopyTo<TRet>(Array array, int index, Transform<TRet> transform)
		{
		}

		private void Resize()
		{
		}

		public void Add(TKey key, TValue value)
		{
		}

		public void Clear()
		{
		}

		public bool ContainsKey(TKey key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool ContainsValue(TValue value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public virtual void OnDeserialization(object sender)
		{
		}

		public bool Remove(TKey key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private TKey ToTKey(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private TValue ToTValue(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool ContainsKeyValuePair(KeyValuePair<TKey, TValue> pair)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public Enumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
