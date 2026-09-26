using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class WeakReference : ISerializable
	{
		private bool isLongReference;

		private GCHandle gcHandle;

		public virtual object Target
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool TrackResurrection
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected WeakReference()
		{
		}

		public WeakReference(object target)
		{
		}

		public WeakReference(object target, bool trackResurrection)
		{
		}

		protected WeakReference(SerializationInfo info, StreamingContext context)
		{
		}

		private void AllocateHandle(object target)
		{
		}

		~WeakReference()
		{
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
