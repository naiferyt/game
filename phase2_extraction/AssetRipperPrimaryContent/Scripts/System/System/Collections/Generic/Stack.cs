using System.Runtime.InteropServices;

namespace System.Collections.Generic
{
	[Serializable]
	[ComVisible(false)]
	public class Stack<T> : IEnumerable<T>, ICollection, IEnumerable
	{
		[Serializable]
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private const int NOT_STARTED = -2;

			private const int FINISHED = -1;

			private Stack<T> parent;

			private int idx;

			private int _version;

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

			internal Enumerator(Stack<T> t)
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

		private const int INITIAL_SIZE = 16;

		private T[] _array;

		private int _size;

		private int _version;

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

		void ICollection.CopyTo(Array dest, int idx)
		{
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool Contains(T t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public T Pop()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Push(T t)
		{
		}

		public Enumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
