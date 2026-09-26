using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
	[Serializable]
	public sealed class GUISettings
	{
		[SerializeField]
		private bool m_DoubleClickSelectsWord;

		[SerializeField]
		private bool m_TripleClickSelectsLine;

		[SerializeField]
		private Color m_CursorColor;

		[SerializeField]
		private float m_CursorFlashSpeed;

		[SerializeField]
		private Color m_SelectionColor;

		public Color cursorColor
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public float cursorFlashSpeed
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Color selectionColor
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern float Internal_GetCursorFlashSpeed();
	}
}
