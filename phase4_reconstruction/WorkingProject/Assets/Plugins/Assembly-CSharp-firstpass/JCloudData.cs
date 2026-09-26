using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudData : MonoBehaviour
{
	public static bool AcceptJailbrokenDevices;

	private static JCloudData cloudDataWatch;

	private static List<Component> registeredComponents;

	public static void SetInt(string key, int value)
	{
	}

	public static int GetInt(string key, int defaultValue)
	{
		return default(int);
	}

	public static int GetInt(string key)
	{
		return default(int);
	}

	public static void SetFloat(string key, float value)
	{
	}

	public static float GetFloat(string key, float defaultValue)
	{
		return default(float);
	}

	public static float GetFloat(string key)
	{
		return default(float);
	}

	public static void SetString(string key, string value)
	{
	}

	public static string GetString(string key, string defaultValue)
	{
		return default(string);
	}

	public static string GetString(string key)
	{
		return default(string);
	}

	public static bool HasKey(string key)
	{
		return default(bool);
	}

	public static void DeleteKey(string key)
	{
	}

	public static void DeleteAll()
	{
	}

	public static void Save()
	{
	}

	public static bool PollCloudDataAvailability()
	{
		return default(bool);
	}

	public static bool RegisterCloudDataExternalChanges(Component componentOrGameObject)
	{
		return default(bool);
	}

	public static bool UnregisterCloudDataExternalChanges(Component componentOrGameObject)
	{
		return default(bool);
	}

	private void KeyValueStoreDidChangeExternally(string keys)
	{
	}
}
