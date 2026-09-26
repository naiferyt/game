using System;
using System.Collections.Generic;
using System.Text;

// Flattens a string dictionary as "key::value;;key::value;;" (':' and ';' inside keys/values are escaped).
// It is the on-disk format of the dictionary fields of the save data (unlocks, cart parts, paint jobs, metrics).
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/DictionaryToString.txt
public static class DictionaryToString
{
	// RECUPERADO-AOT DictionaryToString.ToString token 0x060000e8 @0x000145c8
	public static string ToString(Dictionary<string, string> dictionary)
	{
		StringBuilder sb = new StringBuilder();
		foreach (KeyValuePair<string, string> kv in dictionary)
		{
			string key = kv.Key;
			if (key == null)
			{
				continue;
			}
			key = key.Replace(":", "\\<col>\\");
			key = key.Replace(";", "\\<semi>\\");
			string value = kv.Value;
			if (value == null)
			{
				continue;
			}
			value = value.Replace(":", "\\<col>\\");
			value = value.Replace(";", "\\<semi>\\");
			sb.Append(key + "::" + value + ";;");
		}
		return sb.ToString();
	}

	// RECUPERADO-AOT DictionaryToString.Parse token 0x060000e9 @0x000148a0
	public static Dictionary<string, string> Parse(string input)
	{
		Dictionary<string, string> result = new Dictionary<string, string>();
		string[] entries = input.Split(new string[] { ";;" }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < entries.Length; i++)
		{
			string[] parts = entries[i].Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
			parts[0] = parts[0].Replace("\\<col>\\", ":");
			parts[0] = parts[0].Replace("\\<semi>\\", ";");
			if (parts.Length > 1)
			{
				parts[1] = parts[1].Replace("\\<col>\\", ":");
				parts[1] = parts[1].Replace("\\<semi>\\", ";");
				result.Add(parts[0], parts[1]);
			}
			else
			{
				result.Add(parts[0], string.Empty);
			}
		}
		return result;
	}
}
