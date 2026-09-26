using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private void LoadFromFileStream(FileStream reader)
	{
	}

	private void OnGravCloudPrefsFileCallback(string result)
	{
	}

	[DebuggerHidden]
	private IEnumerator WaitForLoadCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private static void Serialize()
	{
	}

	private static GravCloudPrefs Init()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void SetLong(string name, long value)
	{
	}

	public static long GetLong(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static long GetInt64(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void SetFloat(string name, float value)
	{
	}

	public static float GetFloat(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void SetBool(string name, bool value)
	{
	}

	public static bool GetBool(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void SetString(string name, string value)
	{
	}

	public static string GetString(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void SetDictionary(string name, Dictionary<string, string> dictionary)
	{
	}

	public static Dictionary<string, string> GetDictionary(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
