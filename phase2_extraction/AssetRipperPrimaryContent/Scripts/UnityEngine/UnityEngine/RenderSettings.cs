using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class RenderSettings : Object
	{
		public static extern bool fog
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			set;
		}

		public static Color fogColor
		{
			set
			{
			}
		}

		public static extern float fogDensity
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			set;
		}

		public static Color ambientLight
		{
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_set_fogColor(ref Color value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_set_ambientLight(ref Color value);
	}
}
