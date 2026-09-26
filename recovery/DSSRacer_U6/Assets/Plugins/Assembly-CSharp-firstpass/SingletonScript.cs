using UnityEngine;

public class SingletonScript
{
}
public class SingletonScript<T> : Script where T : Object
{
	protected static T instance;

	public static T i
	{
		get
		{
			RecoveryPending.Hit("SingletonScript.get_i");
			return default(T);
		}
	}

	public virtual void SingletonCreated()
	{
		RecoveryPending.Hit("SingletonScript.SingletonCreated");
	}

	public static bool Exists_VERY_EXPENSIVE()
	{
		RecoveryPending.Hit("SingletonScript.Exists_VERY_EXPENSIVE");
		return default(bool);
	}

	public static bool Existed()
	{
		RecoveryPending.Hit("SingletonScript.Existed");
		return default(bool);
	}

	public virtual void OnLevelWasLoaded()
	{
		RecoveryPending.Hit("SingletonScript.OnLevelWasLoaded");
	}

	public static void ForceReload()
	{
		RecoveryPending.Hit("SingletonScript.ForceReload");
	}
}
