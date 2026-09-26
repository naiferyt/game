using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngineInternal;

namespace UnityEngine
{
	public class GUILayoutUtility
	{
		internal sealed class LayoutCache
		{
			internal GUILayoutGroup topLevel;

			internal GenericStack layoutGroups;

			internal GUILayoutGroup windows;

			internal LayoutCache()
			{
			}
		}

		private static Dictionary<int, LayoutCache> storedLayouts;

		private static Dictionary<int, LayoutCache> storedWindows;

		internal static LayoutCache current;

		private static Rect kDummyRect;

		private static GUIStyle s_SpaceStyle;

		internal static GUIStyle spaceStyle
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static LayoutCache SelectIDList(int instanceID, bool isWindow)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static void Begin(int instanceID)
		{
		}

		internal static void BeginWindow(int windowID, GUIStyle style, GUILayoutOption[] options)
		{
		}

		internal static void Layout()
		{
		}

		internal static void LayoutFromEditorWindow()
		{
		}

		internal static void LayoutFreeGroup(GUILayoutGroup toplevel)
		{
		}

		private static void LayoutSingleGroup(GUILayoutGroup i)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern Rect Internal_GetWindowRect(int windowID);

		private static void Internal_MoveWindow(int windowID, Rect r)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void INTERNAL_CALL_Internal_MoveWindow(int windowID, ref Rect r);
	}
}
