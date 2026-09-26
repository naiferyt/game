using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public struct AnimationInfo
	{
		private int m_ClipInstanceID;

		private float m_Weight;

		public AnimationClip clip
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public float weight
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern AnimationClip ClipInstanceToScriptingObject(int instanceID);
	}
}
