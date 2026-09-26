using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;

namespace System.Collections
{
	[Serializable]
	public class Hashtable : ICollection, IDictionary, IEnumerable, ICloneable, IDeserializationCallback, ISerializable
	{
		[Serializable]
		private sealed class Enumerator : IDictionaryEnumerator, IEnumerator
		{
			private Hashtable host;

			private int stamp;

			private int pos;

			private int size;

			private EnumeratorMode mode;

			private object currentKey;

			private object currentValue;

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

			public Enumerator(Hashtable host, EnumeratorMode mode)
			{
			}

			private void FailFast()
			{
			}

			public void Reset()
			{
			}

			public bool MoveNext()
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
		private class HashKeys : ICollection, IEnumerable
		{
			private Hashtable host;

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

			public HashKeys(Hashtable host)
			{
			}

			public virtual void CopyTo(Array array, int arrayIndex)
			{
			}

			public virtual IEnumerator GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[Serializable]
		private class HashValues : ICollection, IEnumerable
		{
			private Hashtable host;

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

			public HashValues(Hashtable host)
			{
			}

			public virtual void CopyTo(Array array, int arrayIndex)
			{
			}

			public virtual IEnumerator GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[Serializable]
		internal class KeyMarker
		{
			public static readonly KeyMarker Removed;
		}

		[Serializable]
		internal struct Slot
		{
			internal object key;

			internal object value;
		}

		[Serializable]
		private class SyncHashtable : Hashtable, IEnumerable
		{
			private Hashtable host;

			public override int Count
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

			public override ICollection Keys
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override ICollection Values
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override object this[object key]
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public SyncHashtable(Hashtable host)
			{
			}

			internal SyncHashtable(SerializationInfo info, StreamingContext context)
			{
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override void GetObjectData(SerializationInfo info, StreamingContext context)
			{
			}

			public override void CopyTo(Array array, int arrayIndex)
			{
			}

			public override void Add(object key, object value)
			{
			}

			public override void Clear()
			{
			}

			public override bool Contains(object key)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override IDictionaryEnumerator GetEnumerator()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override void Remove(object key)
			{
			}

			public override bool ContainsKey(object key)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override object Clone()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private const int CHAIN_MARKER = int.MinValue;

		private int inUse;

		private int modificationCount;

		private float loadFactor;

		private Slot[] table;

		private int[] hashes;

		private int threshold;

		private HashKeys hashKeys;

		private HashValues hashValues;

		private IHashCodeProvider hcpRef;

		private IComparer comparerRef;

		private SerializationInfo serializationInfo;

		private IEqualityComparer equalityComparer;

		private static readonly int[] primeTbl;

		[Obsolete("Please use EqualityComparer property.")]
		protected IComparer comparer
		{
			set
			{
			}
		}

		[Obsolete("Please use EqualityComparer property.")]
		protected IHashCodeProvider hcp
		{
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

		public Hashtable()
		{
		}

		[Obsolete("Please use Hashtable(int, float, IEqualityComparer) instead")]
		public Hashtable(int capacity, float loadFactor, IHashCodeProvider hcp, IComparer comparer)
		{
		}

		public Hashtable(int capacity, float loadFactor)
		{
		}

		public Hashtable(int capacity)
		{
		}

		internal Hashtable(Hashtable source)
		{
		}

		[Obsolete("Please use Hashtable(int, IEqualityComparer) instead")]
		public Hashtable(int capacity, IHashCodeProvider hcp, IComparer comparer)
		{
		}

		[Obsolete("Please use Hashtable(IDictionary, float, IEqualityComparer) instead")]
		public Hashtable(IDictionary d, float loadFactor, IHashCodeProvider hcp, IComparer comparer)
		{
		}

		[Obsolete("Please use Hashtable(IDictionary, IEqualityComparer) instead")]
		public Hashtable(IDictionary d, IHashCodeProvider hcp, IComparer comparer)
		{
		}

		[Obsolete("Please use Hashtable(IEqualityComparer) instead")]
		public Hashtable(IHashCodeProvider hcp, IComparer comparer)
		{
		}

		protected Hashtable(SerializationInfo info, StreamingContext context)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void CopyTo(Array array, int arrayIndex)
		{
		}

		public virtual void Add(object key, object value)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
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

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public virtual void Remove(object key)
		{
		}

		public virtual bool ContainsKey(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		[MonoTODO("Serialize equalityComparer")]
		public virtual void OnDeserialization(object sender)
		{
		}

		public static Hashtable Synchronized(Hashtable table)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected virtual int GetHash(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected virtual bool KeyEquals(object item, object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void AdjustThreshold()
		{
		}

		private void SetTable(Slot[] table, int[] hashes)
		{
		}

		private int Find(object key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Rehash()
		{
		}

		private void PutImpl(object key, object value, bool overwrite)
		{
		}

		private void CopyToArray(Array arr, int i, EnumeratorMode mode)
		{
		}

		internal static bool TestPrime(int x)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static int CalcPrime(int x)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static int ToPrime(int x)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
