using System.Runtime.InteropServices;

public class MoreGamesBinding
{
	[DllImport("__Internal")]
	private static extern void _MoreGamesInit();

	public static void Init()
	{
	}

	[DllImport("__Internal")]
	private static extern void _MoreGamesShowWindow();

	public static void ShowWindow()
	{
	}

	[DllImport("__Internal")]
	private static extern void _MoreGamesHideWindow();

	public static void HideWindow()
	{
	}

	[DllImport("__Internal")]
	private static extern bool _MoreGamesIsShowingWindow();

	public static bool IsShowingWindow()
	{
		return default(bool);
	}
}
