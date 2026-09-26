namespace System.Collections
{
	[Serializable]
	public class Queue : ICollection, IEnumerable, ICloneable
	{
		[Serializable]
		private class QueueEnumerator : IEnumerator, ICloneable
		{
			private Queue queue;

			private int _version;

			private int current;

			public virtual object Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			internal QueueEnumerator(Queue q)
			{
			}

			public object Clone()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public virtual bool MoveNext()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public virtual void Reset()
			{
			}
		}

		private object[] _array;

		private int _head;

		private int _size;

		private int _tail;

		private int _growFactor;

		private int _version;

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

		public Queue()
		{
		}

		public Queue(int capacity)
		{
		}

		public Queue(ICollection col)
		{
		}

		public Queue(int capacity, float growFactor)
		{
		}

		public virtual void CopyTo(Array array, int index)
		{
		}

		public virtual IEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Clear()
		{
		}

		public virtual object Dequeue()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Enqueue(object obj)
		{
		}

		public virtual object Peek()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void grow()
		{
		}
	}
}
