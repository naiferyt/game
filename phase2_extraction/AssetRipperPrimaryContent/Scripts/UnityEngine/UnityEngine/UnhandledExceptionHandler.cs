using System.Runtime.CompilerServices;

namespace UnityEngine
{
	internal sealed class UnhandledExceptionHandler
	{
		private static void RegisterUECatcher()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void HandleUnhandledException(object sender, object args);
	}
}
