using System.Collections;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("Serialization format not compatible with.NET")]
	public class ObjectIDGenerator
	{
		private class InstanceComparer : IComparer, IHashCodeProvider
		{
			int IComparer.Compare(object o1, object o2)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			int IHashCodeProvider.GetHashCode(object o)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private Hashtable table;

		private long current;

		private static InstanceComparer comparer;

		internal long NextId
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual long GetId(object obj, out bool firstTime)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
