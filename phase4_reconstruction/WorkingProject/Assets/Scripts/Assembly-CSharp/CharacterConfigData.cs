using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConfigData : MonoBehaviour
{
	public class ConfigData
	{
		public string name;

		public int cost;

		public string unlockString;

		public DateTime syncStart;

		public DateTime syncEnd;

		public string noSyncMessage;

		public string syncMessage;
	}

	public Dictionary<string, ConfigData> configData;

	public static CharacterConfigData Instance
	{
		get
		{
			return default(CharacterConfigData);
		}
	}

	private void ProcXML(string xmlText)
	{
	}

	private void LoadDefaultConfig()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LoadWebConfig()
	{
		return default(IEnumerator);
	}

	private void OnExternalArchiveRead(ExternalPersistentArchive archive)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public static int GetCharacterCost(string name)
	{
		return default(int);
	}

	public static bool GetCharacterIsSyncable(string name)
	{
		return default(bool);
	}

	public static string GetCharacterMessage(string name)
	{
		return default(string);
	}

	public static string GetCharacterUnlockString(string name)
	{
		return default(string);
	}
}
