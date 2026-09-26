using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using UnityEngine;

// Per-character configuration read from XML (cost, unlock string, time-limited "sync" messages).
// No scene or prefab of the shipped game contains this component; only GetCharacterCost works without it.
// Source listing: recovery/aot_listings/Assembly-CSharp/CharacterConfigData.txt
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

	// RECUPERADO-AOT CharacterConfigData::get_Instance token 0x060001e2 @0x000de75c
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static CharacterConfigData Instance
	{
		get
		{
			CharacterConfigData characterConfigData = (CharacterConfigData)U4Compat.FindObjectOfType(typeof(CharacterConfigData));
			if (characterConfigData == null)
			{
				UnityEngine.Debug.LogError("Scene requires a CharacterConfigData!");
			}
			return characterConfigData;
		}
	}

	// RECUPERADO-AOT CharacterConfigData::ProcXML token 0x060001e3 @0x000de80c
	// ADAPTADO-U6: DateTime.Parse with the invariant culture (the file uses MM/dd/yyyy, the iOS en-US format).
	private void ProcXML(string xmlText)
	{
		if (xmlText == null)
		{
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			xmlDocument.LoadXml(xmlText);
		}
		catch (Exception)
		{
			UnityEngine.Debug.LogError("Bad XML read:\n" + xmlText);
			return;
		}
		configData = new Dictionary<string, ConfigData>();
		foreach (XmlNode item in xmlDocument.GetElementsByTagName("Character"))
		{
			ConfigData configData2 = new ConfigData();
			configData2.name = item.SelectSingleNode("name").InnerText;
			configData2.cost = int.Parse(item.SelectSingleNode("cost").InnerText);
			configData2.unlockString = item.SelectSingleNode("unlockString").InnerText;
			configData2.syncStart = DateTime.Parse(item.SelectSingleNode("syncStart").InnerText, CultureInfo.InvariantCulture);
			configData2.syncEnd = DateTime.Parse(item.SelectSingleNode("syncEnd").InnerText, CultureInfo.InvariantCulture);
			configData2.noSyncMessage = item.SelectSingleNode("noSyncMessage").InnerText;
			configData2.syncMessage = item.SelectSingleNode("syncMessage").InnerText;
			configData.Add(configData2.name, configData2);
		}
	}

	// RECUPERADO-AOT CharacterConfigData::LoadDefaultConfig token 0x060001e4 @0x000ded50
	private void LoadDefaultConfig()
	{
		TextAsset textAsset = (TextAsset)Resources.Load("CharacterConfig");
		ProcXML(textAsset.text);
		Resources.UnloadAsset(textAsset);
	}

	// RECUPERADO-AOT CharacterConfigData::LoadWebConfig token 0x060001e5 @0x000dedf8
	// (iterator <LoadWebConfig>c__Iterator1D MoveNext token 0x0600087e @0x00145628)
	[DebuggerHidden]
	private IEnumerator LoadWebConfig()
	{
		ExternalPersistentArchive archive = GetComponent<ExternalPersistentArchive>();
		if (archive == null)
		{
			UnityEngine.Debug.LogError("No ExternalPersistentArchive component!");
			yield break;
		}
		while (archive.TextData == null)
		{
			yield return null;
		}
		ProcXML(archive.TextData);
	}

	// RECUPERADO-AOT CharacterConfigData::OnExternalArchiveRead token 0x060001e6 @0x000dee40
	private void OnExternalArchiveRead(ExternalPersistentArchive archive)
	{
		ProcXML(archive.TextData);
	}

	// RECUPERADO-AOT CharacterConfigData::OnEnable token 0x060001e7 @0x000dee80
	private void OnEnable()
	{
		ExternalPersistentArchive component = GetComponent<ExternalPersistentArchive>();
		if (component != null)
		{
			component.OnExternalAchiveRead = (Action<ExternalPersistentArchive>)Delegate.Combine(component.OnExternalAchiveRead, new Action<ExternalPersistentArchive>(OnExternalArchiveRead));
		}
	}

	// RECUPERADO-AOT CharacterConfigData::OnDisable token 0x060001e8 @0x000def94
	private void OnDisable()
	{
		ExternalPersistentArchive component = GetComponent<ExternalPersistentArchive>();
		if (component != null)
		{
			component.OnExternalAchiveRead = (Action<ExternalPersistentArchive>)Delegate.Remove(component.OnExternalAchiveRead, new Action<ExternalPersistentArchive>(OnExternalArchiveRead));
		}
	}

	// RECUPERADO-AOT CharacterConfigData::Start token 0x060001e9 @0x000df0a8
	private void Start()
	{
		if (Application.isEditor)
		{
			LoadDefaultConfig();
		}
		StartCoroutine(LoadWebConfig());
	}

	// RECUPERADO-AOT CharacterConfigData::GetCharacterCost token 0x060001ea @0x000df10c
	public static int GetCharacterCost(string name)
	{
		CartPart part = CartPartList.GetPart(name);
		if (part != null)
		{
			return part.cost;
		}
		return -1;
	}

	// RECUPERADO-AOT CharacterConfigData::GetCharacterIsSyncable token 0x060001eb @0x000df160
	public static bool GetCharacterIsSyncable(string name)
	{
		return false;
	}

	// RECUPERADO-AOT CharacterConfigData::GetCharacterMessage token 0x060001ec @0x000df190
	public static string GetCharacterMessage(string name)
	{
		Dictionary<string, ConfigData> dictionary = Instance.configData;
		if (dictionary != null && dictionary.ContainsKey(name))
		{
			ConfigData configData = dictionary[name];
			DateTime utcNow = DateTime.UtcNow;
			if (utcNow >= configData.syncStart && utcNow <= configData.syncEnd)
			{
				return configData.syncMessage;
			}
			return configData.noSyncMessage;
		}
		return "ERROR";
	}

	// RECUPERADO-AOT CharacterConfigData::GetCharacterUnlockString token 0x060001ed @0x000df2e4
	public static string GetCharacterUnlockString(string name)
	{
		Dictionary<string, ConfigData> dictionary = Instance.configData;
		if (dictionary != null && dictionary.ContainsKey(name))
		{
			return dictionary[name].unlockString;
		}
		return "ERROR";
	}
}
