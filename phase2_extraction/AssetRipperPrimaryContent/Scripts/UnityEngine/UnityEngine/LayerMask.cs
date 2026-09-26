using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public struct LayerMask
	{
		private int m_Mask;

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public static extern int NameToLayer(string layerName);
	}
}
