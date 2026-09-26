using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
	internal class __ComObject : MarshalByRefObject
	{
		private IntPtr iunknown;

		private IntPtr hash_table;

		internal IntPtr IUnknown
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal IntPtr IDispatch
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static Guid IID_IUnknown
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static Guid IID_IDispatch
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public __ComObject()
		{
		}

		internal __ComObject(Type t)
		{
		}

		internal __ComObject(IntPtr pItf)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern __ComObject CreateRCW(Type t);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ReleaseInterfaces();

		~__ComObject()
		{
		}

		internal void Initialize(Type t)
		{
		}

		private static Guid GetCLSID(Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern IntPtr GetInterfaceInternal(Type t, bool throwException);

		internal IntPtr GetInterface(Type t, bool throwException)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal IntPtr GetInterface(Type t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void CheckIUnknown()
		{
		}

		public override bool Equals(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[DllImport("ole32.dll", CallingConvention = (CallingConvention)3, ExactSpelling = true)]
		private static extern int CoCreateInstance([In][MarshalAs((UnmanagedType)43)] Guid rclsid, IntPtr pUnkOuter, uint dwClsContext, [In][MarshalAs((UnmanagedType)43)] Guid riid, out IntPtr pUnk);
	}
}
