using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("Serialized objects are not compatible with .NET")]
	public class StackTrace
	{
		public const int METHODS_TO_SKIP = 0;

		private StackFrame[] frames;

		private bool debug_info;

		public virtual int FrameCount
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public StackTrace()
		{
		}

		public StackTrace(int skipFrames, bool fNeedFileInfo)
		{
		}

		public StackTrace(Exception e, bool fNeedFileInfo)
		{
		}

		public StackTrace(Exception e, int skipFrames, bool fNeedFileInfo)
		{
		}

		internal StackTrace(Exception e, int skipFrames, bool fNeedFileInfo, bool returnNativeFrames)
		{
		}

		private void init_frames(int skipFrames, bool fNeedFileInfo)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern StackFrame[] get_trace(Exception e, int skipFrames, bool fNeedFileInfo);

		public virtual StackFrame GetFrame(int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
