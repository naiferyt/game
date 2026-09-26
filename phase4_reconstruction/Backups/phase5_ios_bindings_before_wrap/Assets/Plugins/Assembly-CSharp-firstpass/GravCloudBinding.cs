using System.Runtime.InteropServices;

public static class GravCloudBinding
{
	[DllImport("__Internal")]
	private static extern void _GravCloudInit();

	public static void Init()
	{
	}

	[DllImport("__Internal")]
	private static extern bool _GravCloudHasCloudAccess();

	public static bool HasCloudAccess()
	{
		return default(bool);
	}

	[DllImport("__Internal")]
	private static extern void _GravCloudGetFile(string fileName, string fromPath, string toPath, string callbackObject, string callbackFunction);

	public static void GetFile(string fileName, string fromPath, string toPath, string callbackObject, string callbackFunction)
	{
	}

	[DllImport("__Internal")]
	private static extern void _GravCloudPutFile(string fileName, string fromPath, string toPath);

	public static void PutFile(string fileName, string fromPath, string toPath)
	{
	}

	[DllImport("__Internal")]
	private static extern bool _GravCloudDoesFileExist(string fileName, string atPath);

	public static bool DoesFileExist(string fileName, string atPath)
	{
		return default(bool);
	}
}
