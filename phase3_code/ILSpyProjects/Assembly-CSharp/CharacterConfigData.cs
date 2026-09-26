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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private void ProcXML(string xmlText)
	{
	}

	private void LoadDefaultConfig()
	{
	}

	[DebuggerHidden]
	private IEnumerator LoadWebConfig()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static bool GetCharacterIsSyncable(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static string GetCharacterMessage(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static string GetCharacterUnlockString(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
