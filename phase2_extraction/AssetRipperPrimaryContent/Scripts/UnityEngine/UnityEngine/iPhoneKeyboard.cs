using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
	[Obsolete("iPhoneKeyboard class is deprecated. Please use TouchScreenKeyboard instead.")]
	public sealed class iPhoneKeyboard
	{
		private IntPtr keyboardWrapper;

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void Destroy();

		~iPhoneKeyboard()
		{
		}
	}
}
