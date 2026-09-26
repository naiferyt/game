using System.Collections.Generic;

public class LifetimeMetrics
{
	private static Dictionary<string, float> metrics;

	public float this[string key]
	{
		get
		{
			return default(float);
		}
	}

	public bool ContainsKey(string key)
	{
		return default(bool);
	}

	public void Save()
	{
	}

	public void Load()
	{
	}

	public static void Signal(string signal, float value)
	{
	}

	public static void Signal(string signal)
	{
	}

	public static void SetMetric(string metric, float value)
	{
	}

	public static void DebugDump()
	{
	}
}
