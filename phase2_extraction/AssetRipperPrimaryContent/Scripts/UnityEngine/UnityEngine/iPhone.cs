using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class iPhone
	{
		public static extern iPhoneGeneration generation
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			get;
		}
	}
}
