using System;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudExtern
{
	public enum JCloudDocumentState
	{
		JCloudDocumentStateClosed,
		JCloudDocumentStateOpening,
		JCloudDocumentStateNormal,
		JCloudDocumentStateInConflict,
		JCloudDocumentStateEditingDisabled
	}

	private const string importString = "__Internal";

	public static bool platformIsCloudCompatible;

	public static string JCloudDocumentFallbackPath;

	[DllImport("__Internal")]
	public static extern int PrepareCloudItem(string path, bool directory);

	[DllImport("__Internal")]
	public static extern int DismissCloudItem(int uid);

	[DllImport("__Internal")]
	public static extern JCloudDocumentState GetCloudItemState(int uid);

	[DllImport("__Internal")]
	public static extern bool CreateOrOpenCloudItem(int uid);

	[DllImport("__Internal")]
	public static extern bool CreateOrOpenCloudItemSync(int uid);

	[DllImport("__Internal")]
	public static extern bool OpenCloudItem(int uid);

	[DllImport("__Internal")]
	public static extern bool OpenCloudItemSync(int uid);

	[DllImport("__Internal")]
	public static extern bool DeleteCloudItem(int uid);

	[DllImport("__Internal")]
	public static extern bool DeleteCloudItemSync(int uid);

	[DllImport("__Internal")]
	public static extern bool WriteCloudItemContents(byte[] contents, int length, int uid);

	[DllImport("__Internal")]
	public static extern int ReadCloudItemContents(int uid, out IntPtr bytes);

	[DllImport("__Internal")]
	public static extern bool SetPersistentDataPath(string path);

	[DllImport("__Internal")]
	public static extern bool GetCloudDirectoryPath(out IntPtr value);

	[DllImport("__Internal")]
	public static extern bool GetCloudItemExistence(int uid);

	[DllImport("__Internal")]
	public static extern bool GetCloudItemExistenceSync(int uid);

	[DllImport("__Internal")]
	public static extern bool GetCloudItemModificationDate(int uid);

	[DllImport("__Internal")]
	public static extern bool GetCloudItemModificationDateSync(int uid, ref long interval);

	[DllImport("__Internal")]
	public static extern bool CopyCloudItem(int uid, string destinationPath, bool overwrite);

	[DllImport("__Internal")]
	public static extern bool CopyCloudItemSync(int uid, string destinationPath, bool overwrite);

	[DllImport("__Internal")]
	public static extern bool MoveCloudItem(int uid, string destinationPath, bool overwrite);

	[DllImport("__Internal")]
	public static extern bool MoveCloudItemSync(int uid, string destinationPath, bool overwrite);

	[DllImport("__Internal")]
	public static extern void SetStateChangeCallbackPointer(IntPtr pointer);

	[DllImport("__Internal")]
	public static extern void SetResultChangeCallbackPointer(IntPtr pointer);

	[DllImport("__Internal")]
	public static extern void CloudDataSetInt(string key, int value);

	[DllImport("__Internal")]
	public static extern bool CloudDataGetInt(string key, ref int value);

	[DllImport("__Internal")]
	public static extern void CloudDataSetFloat(string key, float value);

	[DllImport("__Internal")]
	public static extern bool CloudDataGetFloat(string key, ref float value);

	[DllImport("__Internal")]
	public static extern void CloudDataSetString(string key, string value);

	[DllImport("__Internal")]
	public static extern bool CloudDataGetString(string key, out IntPtr value);

	[DllImport("__Internal")]
	public static extern bool CloudDataHasKey(string key);

	[DllImport("__Internal")]
	public static extern void CloudDataDeleteKey(string key);

	[DllImport("__Internal")]
	public static extern void CloudDataDeleteAll();

	[DllImport("__Internal")]
	public static extern void CloudDataSave();

	[DllImport("__Internal")]
	public static extern void CloudDataSetShouldMessage(bool message);

	[DllImport("__Internal")]
	public static extern void CloudDataSetCallbackPointer(IntPtr pointer);

	[DllImport("__Internal")]
	public static extern void CloudDictionaryDocumentSetInt(string key, int value);

	[DllImport("__Internal")]
	public static extern bool CloudDictionaryDocumentGetInt(string key, ref int value);

	[DllImport("__Internal")]
	public static extern void CloudDictionaryDocumentSetFloat(string key, float value);

	[DllImport("__Internal")]
	public static extern bool CloudDictionaryDocumentGetFloat(string key, ref float value);

	[DllImport("__Internal")]
	public static extern void CloudDictionaryDocumentSetString(string key, string value);

	[DllImport("__Internal")]
	public static extern bool CloudDictionaryDocumentGetString(string key, out IntPtr value);

	[DllImport("__Internal")]
	public static extern bool CloudDictionaryDocumentHasKey(string key);

	[DllImport("__Internal")]
	public static extern void CloudDictionaryDocumentDeleteKey(string key);

	[DllImport("__Internal")]
	public static extern void CloudDictionaryDocumentDeleteAll();

	[DllImport("__Internal")]
	public static extern void CloudDictionaryDocumentSave();

	[DllImport("__Internal")]
	public static extern void CloudDictionaryDocumentSetShouldMessage(bool message);

	[DllImport("__Internal")]
	public static extern void CloudDictionaryDocumentSetCallbackPointer(IntPtr pointer);

	[DllImport("__Internal")]
	public static extern bool GetUbiquitousContainerAvailability();

	[DllImport("__Internal")]
	public static extern bool GetUbiquitousStoreAvailability();

	[DllImport("__Internal")]
	public static extern void FreeMemory(IntPtr pointer);

	[DllImport("__Internal")]
	public static extern bool IsJailbroken();
}
