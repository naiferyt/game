using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class Shader : Object
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public static extern Shader Find(string name);

		public static void SetGlobalColor(string propertyName, Color color)
		{
		}

		public static void SetGlobalColor(int nameID, Color color)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_CALL_SetGlobalColor(int nameID, ref Color color);

		public static void SetGlobalVector(string propertyName, Vector4 vec)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public static extern int PropertyToID(string name);
	}
}
