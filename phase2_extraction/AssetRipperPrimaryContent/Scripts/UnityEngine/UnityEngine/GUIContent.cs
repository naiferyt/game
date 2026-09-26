using System;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	[Serializable]
	[StructLayout((LayoutKind)0)]
	public sealed class GUIContent
	{
		[SerializeField]
		private string m_Text;

		[SerializeField]
		private Texture m_Image;

		[SerializeField]
		private string m_Tooltip;

		public static GUIContent none;

		private static GUIContent s_Text;

		private static GUIContent s_Image;

		private static GUIContent s_TextImage;

		public string text
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public Texture image
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string tooltip
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal int hash
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public GUIContent()
		{
		}

		public GUIContent(string text)
		{
		}

		public GUIContent(Texture image)
		{
		}

		internal static GUIContent Temp(string t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static GUIContent Temp(Texture i)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static GUIContent Temp(string t, Texture i)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static void ClearStaticCache()
		{
		}

		internal static GUIContent[] Temp(string[] texts)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static GUIContent[] Temp(Texture[] images)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
