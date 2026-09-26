using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
			RecoveryPending.Hit("CharacterConfigData.get_Instance");
			return default(CharacterConfigData);
		}
	}

	private void ProcXML(string xmlText)
	{
		RecoveryPending.Hit("CharacterConfigData.ProcXML");
	}

	private void LoadDefaultConfig()
	{
		RecoveryPending.Hit("CharacterConfigData.LoadDefaultConfig");
	}

	[DebuggerHidden]
	private IEnumerator LoadWebConfig()
	{
		RecoveryPending.Hit("CharacterConfigData.LoadWebConfig");
		yield break;
	}

	private void OnExternalArchiveRead(ExternalPersistentArchive archive)
	{
		RecoveryPending.Hit("CharacterConfigData.OnExternalArchiveRead");
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("CharacterConfigData.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("CharacterConfigData.OnDisable");
	}

	private void Start()
	{
		RecoveryPending.Hit("CharacterConfigData.Start");
	}

	public static int GetCharacterCost(string name)
	{
		RecoveryPending.Hit("CharacterConfigData.GetCharacterCost");
		return default(int);
	}

	public static bool GetCharacterIsSyncable(string name)
	{
		RecoveryPending.Hit("CharacterConfigData.GetCharacterIsSyncable");
		return default(bool);
	}

	public static string GetCharacterMessage(string name)
	{
		RecoveryPending.Hit("CharacterConfigData.GetCharacterMessage");
		return default(string);
	}

	public static string GetCharacterUnlockString(string name)
	{
		RecoveryPending.Hit("CharacterConfigData.GetCharacterUnlockString");
		return default(string);
	}
}
