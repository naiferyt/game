using System.Collections;

namespace System.Text.RegularExpressions
{
	internal class IntervalCollection : ICollection, IEnumerable
	{
		public delegate double CostDelegate(Interval i);

		private class Enumerator : IEnumerator
		{
			private IList list;

			private int ptr;

			public object Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public Enumerator(IList list)
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

		private ArrayList intervals;

		public Interval this[int i]
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

		public void Add(Interval i)
		{
		}

		public void Normalize()
		{
		}

		public IntervalCollection GetMetaCollection(CostDelegate cost_del)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Optimize(int begin, int end, IntervalCollection meta, CostDelegate cost_del)
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
}
