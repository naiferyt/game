using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GravCloudPrefs : MonoBehaviour
{
	private const string prefsFileName = "CloudPrefs.dat";

	private const byte encryptedByteGlyph = 17;

	private const byte unencryptedByteGlyph = 16;

	private static bool encryptFiles;

	private static byte[] rijKey;

	private static bool hasInit;

	private static bool isLoaded;

	private static Dictionary<string, string> data;

	public static Action cloudLoadComplete;

	private bool downloadFailBit;

	public static bool IsLoaded
	{
		get
		{
			return default(bool);
		}
	}

	private void LoadFromFileStream(FileStream reader)
	{
	}

	private void OnGravCloudPrefsFileCallback(string result)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator WaitForLoadCoroutine()
	{
		return default(IEnumerator);
	}

	private static void Serialize()
	{
	}

	private static GravCloudPrefs Init()
	{
		return default(GravCloudPrefs);
	}

	private void OnApplicationQuit()
	{
	}

	private void OnApplicationPause(bool pause)
	{
	}

	public static void Load()
	{
	}

	public static void Save()
	{
	}

	public static bool HasKey(string name)
	{
		return default(bool);
	}

	public static void RemoveKey(string name)
	{
	}

	public static void DeleteAll()
	{
	}

	public static void EditorDeleteAll()
	{
	}

	public static void DeleteGravCloudFile()
	{
	}

	public static void SetInt(string name, int value)
	{
	}

	public static void SetInt64(string name, long value)
	{
	}

	public static int GetInt(string name)
	{
		return default(int);
	}

	public static void SetLong(string name, long value)
	{
	}

	public static long GetLong(string name)
	{
		return default(long);
	}

	public static long GetInt64(string name)
	{
		return default(long);
	}

	public static void SetFloat(string name, float value)
	{
	}

	public static float GetFloat(string name)
	{
		return default(float);
	}

	public static void SetBool(string name, bool value)
	{
	}

	public static bool GetBool(string name)
	{
		return default(bool);
	}

	public static void SetString(string name, string value)
	{
	}

	public static string GetString(string name)
	{
		return default(string);
	}

	public static void SetDictionary(string name, Dictionary<string, string> dictionary)
	{
	}

	public static Dictionary<string, string> GetDictionary(string name)
	{
		return default(Dictionary<string, string>);
	}
}
