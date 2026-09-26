using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class GUILayer : Behaviour
	{
		public GUIElement HitTest(Vector3 screenPosition)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern GUIElement INTERNAL_CALL_HitTest(GUILayer self, ref Vector3 screenPosition);
	}
}
