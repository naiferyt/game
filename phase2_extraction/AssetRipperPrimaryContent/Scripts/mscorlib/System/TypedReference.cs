using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
	[CLSCompliant(false)]
	[ComVisible(true)]
	public struct TypedReference
	{
		private RuntimeTypeHandle type;

		private IntPtr value;

		private IntPtr klass;

		public override bool Equals(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object ToObject(TypedReference value);
	}
}
