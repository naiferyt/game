using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	[Serializable]
	[StructLayout((LayoutKind)0)]
	public sealed class GUIStyleState
	{
		[NonSerialized]
		[NotRenamed]
		internal IntPtr m_Ptr;

		private GUIStyle m_SourceStyle;

		[NonSerialized]
		private Texture2D m_Background;

		public Texture2D background
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public Color textColor
		{
			set
			{
			}
		}

		public GUIStyleState()
		{
		}

		internal GUIStyleState(GUIStyle sourceStyle, IntPtr source)
		{
		}

		internal void RefreshAssetReference()
		{
		}

		~GUIStyleState()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void Init();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void Cleanup();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void SetBackgroundInternal(Texture2D value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern Texture2D GetBackgroundInternal();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void INTERNAL_set_textColor(ref Color value);
	}
}
