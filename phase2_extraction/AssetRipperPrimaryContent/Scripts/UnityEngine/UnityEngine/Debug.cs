using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class Debug
	{
		public static extern bool isDebugBuild
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public static extern void Break();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void Internal_Log(int level, string msg, [Writable] Object obj);

		public static void Log(object message)
		{
		}

		public static void LogError(object message)
		{
		}

		public static void LogError(object message, Object context)
		{
		}

		public static void LogWarning(object message)
		{
		}
	}
}
