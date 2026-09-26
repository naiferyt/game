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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public virtual void SingletonCreated()
	{
	}

	public static bool Exists_VERY_EXPENSIVE()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static bool Existed()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public virtual void OnLevelWasLoaded()
	{
	}

	public static void ForceReload()
	{
	}
}
