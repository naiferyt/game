using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("Serialized objects are not compatible with MS.NET")]
	public class StackFrame
	{
		public const int OFFSET_UNKNOWN = -1;

		private int ilOffset;

		private int nativeOffset;

		private MethodBase methodBase;

		private string fileName;

		private int lineNumber;

		private int columnNumber;

		private string internalMethodName;

		public StackFrame()
		{
		}

		public StackFrame(int skipFrames, bool fNeedFileInfo)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_frame_info(int skip, bool needFileInfo, out MethodBase method, out int iloffset, out int native_offset, out string file, out int line, out int column);

		public virtual int GetFileLineNumber()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string GetFileName()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal string GetSecureFileName()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int GetILOffset()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual MethodBase GetMethod()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int GetNativeOffset()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal string GetInternalMethodName()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
