using System.Collections.Generic;

public class LifetimeMetrics
{
	private static Dictionary<string, float> metrics;

	public float this[string key]
	{
		get
		{
			RecoveryPending.Hit("LifetimeMetrics.get_Item");
			return default(float);
		}
	}

	public bool ContainsKey(string key)
	{
		RecoveryPending.Hit("LifetimeMetrics.ContainsKey");
		return default(bool);
	}

	public void Save()
	{
		RecoveryPending.Hit("LifetimeMetrics.Save");
	}

	public void Load()
	{
		RecoveryPending.Hit("LifetimeMetrics.Load");
	}

	public static void Signal(string signal, float value)
	{
		RecoveryPending.Hit("LifetimeMetrics.Signal");
	}

	public static void Signal(string signal)
	{
		RecoveryPending.Hit("LifetimeMetrics.Signal");
	}

	public static void SetMetric(string metric, float value)
	{
		RecoveryPending.Hit("LifetimeMetrics.SetMetric");
	}

	public static void DebugDump()
	{
		RecoveryPending.Hit("LifetimeMetrics.DebugDump");
	}
}
