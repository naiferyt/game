using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class SystemInfo
	{
		public static extern string operatingSystem
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			get;
		}

		public static extern string deviceUniqueIdentifier
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			get;
		}
	}
}
