using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudManager : MonoBehaviour
{
	private struct DocumentLock
	{
		public int index;

		public int count;

		public DocumentLock(int index, int count)
		{
		}
	}

	public static Dictionary<int, JCloudExtern.JCloudDocumentState> documentState;

	public static Dictionary<int, long> documentResult;

	public static Dictionary<int, int> documentAccess;

	private static Dictionary<int, DocumentLock> documentLock;

	protected static JCloudManager sharedManager;

	protected static object checkLock;

	public static void CheckManagerStatus()
	{
	}

	public static JCloudManager GetSharedManager()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void WatchDocument(int uid)
	{
	}

	public static void WatchAsyncDocument(int uid)
	{
	}

	public static JCloudExtern.JCloudDocumentState GetDocumentState(int uid)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void UnwatchDocument(int uid)
	{
	}

	public static bool GetDocumentResult(int uid, out long result)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static int GetDocumentLock(int uid)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static bool CheckDocumentLock(int uid, int lockId)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void ReleaseDocumentLock(int uid)
	{
	}

	private void DocumentStateDidChange(string message)
	{
	}

	private void DocumentResultDidChange(string message)
	{
	}

	public static string[] PathListFromBytes(byte[] bytes, bool directories)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void CopyDirectory(string src, string dst)
	{
	}
}
