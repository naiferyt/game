using UnityEngine;

public class SingletonScript
{
}

// Lazily-found scene singleton: i returns the only instance of T in the loaded scenes.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/SingletonScript`1.txt
public class SingletonScript<T> : Script where T : Object
{
	protected static T instance;

	public static T i
	{
		// RECUPERADO-AOT SingletonScript.get_i token 0x06000260 @0x0002da38
		get
		{
			if (instance != null)
			{
				return instance;
			}
			// ADAPTADO-U6: Object.FindObjectsOfType<T> -> U4Compat (FindObjectsByType)
			T[] found = U4Compat.FindObjectsOfType<T>();
			if (found.Length > 1)
			{
				Debug.LogError("More than one " + typeof(T) + " is in the scene!");
				return null;
			}
			if (found.Length == 0)
			{
				return null;
			}
			instance = found[0];
			(instance as SingletonScript<T>).SingletonCreated();
			return instance;
		}
	}

	// RECUPERADO-AOT SingletonScript.SingletonCreated token 0x06000261 @0x0002db9c (empty in the original)
	public virtual void SingletonCreated()
	{
	}

	// RECUPERADO-AOT SingletonScript.Exists_VERY_EXPENSIVE token 0x06000262 @0x0002dbc8
	public static bool Exists_VERY_EXPENSIVE()
	{
		// ADAPTADO-U6: Object.FindObjectsOfType<T> -> U4Compat (FindObjectsByType)
		return U4Compat.FindObjectsOfType<T>().Length >= 1;
	}

	// RECUPERADO-AOT SingletonScript.Existed token 0x06000263 @0x0002dc20
	public static bool Existed()
	{
		return i != null;
	}

	// RECUPERADO-AOT SingletonScript.OnLevelWasLoaded token 0x06000264 @0x0002dc64
	// ADAPTADO-U6: OnLevelWasLoaded -> OnLevelWasLoadedU6, sent by U4Compat after each scene load.
	public virtual void OnLevelWasLoadedU6()
	{
		instance = null;
	}

	// RECUPERADO-AOT SingletonScript.ForceReload token 0x06000265 @0x0002dcc0
	public static void ForceReload()
	{
		instance = null;
	}
}
