// Stage 1 recovery infrastructure (RECONSTRUIDO: backend only; the saved DATA and its keys are RECUPERADO).
// Replaces the iOS key-value stores the original game persisted to (GravCloudPrefs, the older local/iCloud prefs,
// and JCloudData, the newer one; both ELIMINADO, RECOVERY_REPORT.md 11.2). The original code wrote one entry per
// CloudSaveData field (key = field name), plus "LifeTimeMetrics"; DataUtility and LifetimeMetrics keep doing exactly
// that, only the storage is now a local text file:  <Application.persistentDataPath>/DSSRacer_save.txt
// File format: one entry per line, "key<TAB>value", with \\ \t \n escaped; numbers in invariant culture.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

public static class LocalSaveStore
{
	public const string FileName = "DSSRacer_save.txt";

	static Dictionary<string, string> s_Values;

	public static string FilePath
	{
		get { return Path.Combine(Application.persistentDataPath, FileName); }
	}

	static Dictionary<string, string> Values
	{
		get
		{
			if (s_Values == null) Reload();
			return s_Values;
		}
	}

	// Re-reads the file (discarding unsaved changes).
	public static void Reload()
	{
		s_Values = new Dictionary<string, string>();
		try
		{
			if (!File.Exists(FilePath)) return;
			foreach (string line in File.ReadAllLines(FilePath, Encoding.UTF8))
			{
				int tab = line.IndexOf('\t');
				if (tab <= 0) continue;
				s_Values[Unescape(line.Substring(0, tab))] = Unescape(line.Substring(tab + 1));
			}
		}
		catch (Exception e)
		{
			Debug.LogWarning("LocalSaveStore: could not read " + FilePath + ": " + e.Message);
		}
	}

	public static void Save()
	{
		StringBuilder sb = new StringBuilder();
		foreach (KeyValuePair<string, string> kv in Values)
		{
			sb.Append(Escape(kv.Key)).Append('\t').Append(Escape(kv.Value)).Append('\n');
		}
		try
		{
			string tmp = FilePath + ".tmp";
			File.WriteAllText(tmp, sb.ToString(), Encoding.UTF8);
			if (File.Exists(FilePath)) File.Delete(FilePath);
			File.Move(tmp, FilePath);
		}
		catch (Exception e)
		{
			Debug.LogWarning("LocalSaveStore: could not write " + FilePath + ": " + e.Message);
		}
	}

	public static bool HasKey(string key) { return Values.ContainsKey(key); }

	public static void DeleteAll() { Values.Clear(); }

	public static string GetString(string key) { return GetString(key, string.Empty); }

	public static string GetString(string key, string defaultValue)
	{
		string v;
		return Values.TryGetValue(key, out v) ? v : defaultValue;
	}

	public static int GetInt(string key)
	{
		int v;
		return int.TryParse(GetString(key), NumberStyles.Integer, CultureInfo.InvariantCulture, out v) ? v : 0;
	}

	public static long GetInt64(string key)
	{
		long v;
		return long.TryParse(GetString(key), NumberStyles.Integer, CultureInfo.InvariantCulture, out v) ? v : 0L;
	}

	public static float GetFloat(string key)
	{
		float v;
		return float.TryParse(GetString(key), NumberStyles.Float, CultureInfo.InvariantCulture, out v) ? v : 0f;
	}

	public static void SetString(string key, string value) { Values[key] = value ?? string.Empty; }

	public static void SetInt(string key, int value) { Values[key] = value.ToString(CultureInfo.InvariantCulture); }

	public static void SetFloat(string key, float value) { Values[key] = value.ToString("R", CultureInfo.InvariantCulture); }

	static string Escape(string s)
	{
		return s.Replace("\\", "\\\\").Replace("\t", "\\t").Replace("\n", "\\n").Replace("\r", "\\r");
	}

	static string Unescape(string s)
	{
		StringBuilder sb = new StringBuilder(s.Length);
		for (int i = 0; i < s.Length; i++)
		{
			char c = s[i];
			if (c == '\\' && i + 1 < s.Length)
			{
				char n = s[++i];
				sb.Append(n == 't' ? '\t' : n == 'n' ? '\n' : n == 'r' ? '\r' : n);
			}
			else sb.Append(c);
		}
		return sb.ToString();
	}
}
