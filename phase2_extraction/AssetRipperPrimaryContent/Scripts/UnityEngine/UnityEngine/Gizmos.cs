using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class Gizmos
	{
		public static Color color
		{
			set
			{
			}
		}

		public static void DrawLine(Vector3 from, Vector3 to)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_CALL_DrawLine(ref Vector3 from, ref Vector3 to);

		public static void DrawWireSphere(Vector3 center, float radius)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_CALL_DrawWireSphere(ref Vector3 center, float radius);

		public static void DrawSphere(Vector3 center, float radius)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_CALL_DrawSphere(ref Vector3 center, float radius);

		public static void DrawWireCube(Vector3 center, Vector3 size)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_CALL_DrawWireCube(ref Vector3 center, ref Vector3 size);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_set_color(ref Color value);
	}
}
