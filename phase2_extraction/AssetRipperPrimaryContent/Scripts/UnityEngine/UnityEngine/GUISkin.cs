using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine
{
	[Serializable]
	[ExecuteInEditMode]
	public sealed class GUISkin : ScriptableObject
	{
		internal delegate void SkinChangedDelegate();

		[SerializeField]
		private Font m_Font;

		[SerializeField]
		private GUIStyle m_box;

		[SerializeField]
		private GUIStyle m_button;

		[SerializeField]
		private GUIStyle m_toggle;

		[SerializeField]
		private GUIStyle m_label;

		[SerializeField]
		private GUIStyle m_textField;

		[SerializeField]
		private GUIStyle m_textArea;

		[SerializeField]
		private GUIStyle m_window;

		[SerializeField]
		private GUIStyle m_horizontalSlider;

		[SerializeField]
		private GUIStyle m_horizontalSliderThumb;

		[SerializeField]
		private GUIStyle m_verticalSlider;

		[SerializeField]
		private GUIStyle m_verticalSliderThumb;

		[SerializeField]
		private GUIStyle m_horizontalScrollbar;

		[SerializeField]
		private GUIStyle m_horizontalScrollbarThumb;

		[SerializeField]
		private GUIStyle m_horizontalScrollbarLeftButton;

		[SerializeField]
		private GUIStyle m_horizontalScrollbarRightButton;

		[SerializeField]
		private GUIStyle m_verticalScrollbar;

		[SerializeField]
		private GUIStyle m_verticalScrollbarThumb;

		[SerializeField]
		private GUIStyle m_verticalScrollbarUpButton;

		[SerializeField]
		private GUIStyle m_verticalScrollbarDownButton;

		[SerializeField]
		private GUIStyle m_ScrollView;

		[SerializeField]
		internal GUIStyle[] m_CustomStyles;

		[SerializeField]
		private GUISettings m_Settings;

		internal static GUIStyle ms_Error;

		private Dictionary<string, GUIStyle> styles;

		internal static SkinChangedDelegate m_SkinChanged;

		internal static GUISkin current;

		public Font font
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle box
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle label
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle textField
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle textArea
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle button
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle toggle
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle window
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle horizontalSlider
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle horizontalSliderThumb
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle verticalSlider
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle verticalSliderThumb
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle horizontalScrollbar
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle horizontalScrollbarThumb
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle horizontalScrollbarLeftButton
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle horizontalScrollbarRightButton
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle verticalScrollbar
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle verticalScrollbarThumb
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle verticalScrollbarUpButton
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle verticalScrollbarDownButton
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle scrollView
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUIStyle[] customStyles
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public GUISettings settings
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static GUIStyle error
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal void OnEnable()
		{
		}

		internal void Apply()
		{
		}

		private void BuildStyleCache()
		{
		}

		public GUIStyle GetStyle(string styleName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public GUIStyle FindStyle(string styleName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void MakeCurrent()
		{
		}

		public IEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
