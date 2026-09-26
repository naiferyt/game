using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class Animator : Behaviour
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public static extern int StringToHash(string name);
	}
}
