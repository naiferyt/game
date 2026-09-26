using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Lifetime counters ("Times Loaded", "Tokens Spent"...) used by achievements; stored as one dictionary entry.
// Source listing: recovery/aot_listings/Assembly-CSharp/LifetimeMetrics.txt
public class LifetimeMetrics
{
	private static Dictionary<string, float> metrics;

	public float this[string key]
	{
		// RECUPERADO-AOT LifetimeMetrics.get_Item token 0x06000289 @0x000e97ec
		get
		{
			if (metrics.ContainsKey(key))
			{
				return metrics[key];
			}
			return float.NaN;
		}
	}

	// RECUPERADO-AOT LifetimeMetrics.ContainsKey token 0x0600028a @0x000e9898
	public bool ContainsKey(string key)
	{
		return metrics.ContainsKey(key);
	}

	// RECUPERADO-AOT LifetimeMetrics.Save token 0x0600028b @0x000e98ec
	public void Save()
	{
		Dictionary<string, string> data;
		if (metrics != null)
		{
			data = new Dictionary<string, string>(metrics.Count);
			foreach (KeyValuePair<string, float> kv in metrics)
			{
				data.Add(kv.Key, kv.Value.ToString());
			}
		}
		else
		{
			data = new Dictionary<string, string>();
		}
		// ELIMINADO (servicio iOS): JCloudData.SetString -> almacén local (LocalSaveStore, RECONSTRUIDO)
		LocalSaveStore.SetString("LifeTimeMetrics", DictionaryToString.ToString(data));
	}

	// RECUPERADO-AOT LifetimeMetrics.Load token 0x0600028c @0x000e9b54
	public void Load()
	{
		// ELIMINADO (servicio iOS): GravCloudPrefs/JCloudData.HasKey/GetString -> almacén local (LocalSaveStore)
		if (!LocalSaveStore.HasKey("LifeTimeMetrics"))
		{
			metrics = new Dictionary<string, float>();
			Signal("Times Loaded");
		}
		else
		{
			Dictionary<string, string> data = DictionaryToString.Parse(LocalSaveStore.GetString("LifeTimeMetrics"));
			metrics = new Dictionary<string, float>(data.Count);
			foreach (KeyValuePair<string, string> kv in data)
			{
				metrics.Add(kv.Key, float.Parse(kv.Value));
			}
			Signal("Times Loaded");
		}
		DebugDump();
	}

	// RECUPERADO-AOT LifetimeMetrics.Signal token 0x0600028d @0x000e9e48
	public static void Signal(string signal, float value)
	{
		if (metrics == null)
		{
			Debug.LogError("ERROR: trying to record metrics, but LifetimeMetrics has not been loaded!");
			return;
		}
		if (metrics.ContainsKey(signal))
		{
			metrics[signal] = metrics[signal] + value;
		}
		else
		{
			metrics.Add(signal, value);
		}
	}

	// RECUPERADO-AOT LifetimeMetrics.Signal token 0x0600028e @0x000e9f8c
	public static void Signal(string signal)
	{
		Signal(signal, 1f);
	}

	// RECUPERADO-AOT LifetimeMetrics.SetMetric token 0x0600028f @0x000e9fdc
	public static void SetMetric(string metric, float value)
	{
		if (metrics == null)
		{
			Debug.LogError("ERROR: trying to record metrics, but LifetimeMetrics has not been loaded!");
			return;
		}
		if (metrics.ContainsKey(metric))
		{
			metrics[metric] = value;
		}
		else
		{
			metrics.Add(metric, value);
		}
	}

	// RECUPERADO-AOT LifetimeMetrics.DebugDump token 0x06000290 @0x000ea0e0
	public static void DebugDump()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("*** LifeTimeMetrics:");
		if (metrics == null)
		{
			sb.AppendLine("metrics is NULL!");
		}
		else if (metrics.Count == 0)
		{
			sb.AppendLine("metrics is empty.");
		}
		else
		{
			foreach (KeyValuePair<string, float> kv in metrics)
			{
				sb.AppendLine(kv.Key + " : " + kv.Value);
			}
		}
		Debug.Log(sb.ToString());
	}
}
