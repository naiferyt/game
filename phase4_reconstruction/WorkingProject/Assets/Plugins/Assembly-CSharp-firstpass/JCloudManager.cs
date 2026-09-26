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
			this.index = index;
			this.count = count;
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
		return default(JCloudManager);
	}

	public static void WatchDocument(int uid)
	{
	}

	public static void WatchAsyncDocument(int uid)
	{
	}

	public static JCloudExtern.JCloudDocumentState GetDocumentState(int uid)
	{
		return default(JCloudExtern.JCloudDocumentState);
	}

	public static void UnwatchDocument(int uid)
	{
	}

	public static bool GetDocumentResult(int uid, out long result)
	{
		result = default(long);
		return default(bool);
	}

	public static int GetDocumentLock(int uid)
	{
		return default(int);
	}

	public static bool CheckDocumentLock(int uid, int lockId)
	{
		return default(bool);
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
		return default(string[]);
	}

	public static void CopyDirectory(string src, string dst)
	{
	}
}
