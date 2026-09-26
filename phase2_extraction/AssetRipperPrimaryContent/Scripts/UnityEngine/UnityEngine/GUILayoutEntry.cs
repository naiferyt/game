namespace UnityEngine
{
	internal class GUILayoutEntry
	{
		public float minWidth;

		public float maxWidth;

		public float minHeight;

		public float maxHeight;

		public Rect rect;

		public int stretchWidth;

		public int stretchHeight;

		private GUIStyle m_Style;

		internal static Rect kDummyRect;

		protected static int indent;

		public GUIStyle style
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual RectOffset margin
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public GUILayoutEntry(float _minWidth, float _maxWidth, float _minHeight, float _maxHeight, GUIStyle _style)
		{
		}

		public virtual void CalcWidth()
		{
		}

		public virtual void CalcHeight()
		{
		}

		public virtual void SetHorizontal(float x, float width)
		{
		}

		public virtual void SetVertical(float y, float height)
		{
		}

		protected virtual void ApplyStyleSettings(GUIStyle style)
		{
		}

		public virtual void ApplyOptions(GUILayoutOption[] options)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
