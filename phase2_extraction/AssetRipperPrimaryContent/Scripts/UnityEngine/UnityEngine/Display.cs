using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class Display
	{
		public delegate void DisplaysUpdatedDelegate();

		internal IntPtr nativeDisplay;

		public static Display[] displays;

		private static Display _mainDisplay;

		public int renderingWidth
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int renderingHeight
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int systemWidth
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int systemHeight
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public RenderBuffer colorBuffer
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public RenderBuffer depthBuffer
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static Display main
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static event DisplaysUpdatedDelegate onDisplaysUpdated
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
			}
		}

		internal Display()
		{
		}

		internal Display(IntPtr nativeDisplay)
		{
		}

		public void SetRenderingResolution(int w, int h)
		{
		}

		private static void RecreateDisplayList(IntPtr[] nativeDisplay)
		{
		}

		private static void FireDisplaysUpdated()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void GetSystemExtImpl(IntPtr nativeDisplay, out int w, out int h);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void GetRenderingExtImpl(IntPtr nativeDisplay, out int w, out int h);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void GetRenderingBuffersImpl(IntPtr nativeDisplay, out RenderBuffer color, out RenderBuffer depth);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void SetRenderingResolutionImpl(IntPtr nativeDisplay, int w, int h);
	}
}
