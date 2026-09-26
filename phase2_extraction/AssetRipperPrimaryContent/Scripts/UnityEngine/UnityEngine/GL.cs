using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class GL
	{
		public const int TRIANGLES = 4;

		public const int TRIANGLE_STRIP = 5;

		public const int QUADS = 7;

		public const int LINES = 1;

		public static void Vertex(Vector3 v)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_CALL_Vertex(ref Vector3 v);

		public static void Color(Color c)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_CALL_Color(ref Color c);
	}
}
