using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public abstract class MulticastDelegate : Delegate
	{
		private MulticastDelegate prev;

		private MulticastDelegate kpm_next;

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public sealed override bool Equals(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public sealed override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public sealed override Delegate[] GetInvocationList()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected sealed override Delegate CombineImpl(Delegate follow)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool BaseEquals(MulticastDelegate value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static MulticastDelegate KPM(MulticastDelegate needle, MulticastDelegate haystack, out MulticastDelegate tail)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected sealed override Delegate RemoveImpl(Delegate value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
