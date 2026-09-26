using System.Collections;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudDocumentAsync : MonoBehaviour
{
	public static bool AcceptJailbrokenDevices;

	protected static int NewCloudDocument(string path, bool isDirectory)
	{
		return default(int);
	}

	protected static void DismissCloudDocument(int uid)
	{
	}

	public static JCloudDocumentAsyncOperation FileExists(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation FileDelete(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation FileWriteAllBytes(string path, byte[] bytes)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation FileReadAllBytes(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation FileModificationDate(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation FileCopy(string sourcePath, string destinationPath, bool overwrite)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation FileMove(string sourcePath, string destinationPath, bool overwrite)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation DirectoryCreate(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation DirectoryExists(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation DirectoryDelete(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation DirectoryGetFiles(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation DirectoryGetDirectories(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation DirectoryModificationDate(string path)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation DirectoryCopy(string sourcePath, string destinationPath, bool overwrite)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	public static JCloudDocumentAsyncOperation DirectoryMove(string sourcePath, string destinationPath, bool overwrite)
	{
		return default(JCloudDocumentAsyncOperation);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator FileExistsOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator FileDeleteOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator FileWriteAllBytesOperation(string path, byte[] bytes, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator FileReadAllBytesOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator FileModificationDateOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator FileCopyOperation(string sourcePath, string destinationPath, bool overwrite, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator FileMoveOperation(string sourcePath, string destinationPath, bool overwrite, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator DirectoryCreateOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator DirectoryExistsOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator DirectoryDeleteOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator DirectoryGetFilesOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator DirectoryGetDirectoriesOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator DirectoryModificationDateOperation(string path, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator DirectoryCopyOperation(string sourcePath, string destinationPath, bool overwrite, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	protected static IEnumerator DirectoryMoveOperation(string sourcePath, string destinationPath, bool overwrite, JCloudDocumentAsyncOperation operation)
	{
		return default(IEnumerator);
	}

	public static bool PollCloudDocumentAvailability()
	{
		return default(bool);
	}
}
