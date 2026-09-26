using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
	[ComVisible(true)]
	public static class Buffer
	{
		public static int ByteLength(Array array)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void BlockCopy(Array src, int srcOffset, Array dst, int dstOffset, int count)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int ByteLengthInternal(Array array);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool BlockCopyInternal(Array src, int src_offset, Array dest, int dest_offset, int count);
	}
}
