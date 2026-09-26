using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class Graphics
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void DrawTexture(ref InternalDrawTextureArguments arguments);
	}
}
