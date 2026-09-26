using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	[StructLayout((LayoutKind)0)]
	public class ScriptableObject : Object
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void Internal_CreateScriptableObject([Writable] ScriptableObject self);
	}
}
