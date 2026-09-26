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
			return default(T);
		}
	}

	public virtual void SingletonCreated()
	{
	}

	public static bool Exists_VERY_EXPENSIVE()
	{
		return default(bool);
	}

	public static bool Existed()
	{
		return default(bool);
	}

	public virtual void OnLevelWasLoaded()
	{
	}

	public static void ForceReload()
	{
	}
}
