using System.Collections.Generic;
using UnityEngine;

public class EnumerableScript
{
}
public class EnumerableScript<T> : Script where T : Object
{
	private static List<T> all;

	public virtual void Start()
	{
	}

	public virtual void OnDisable()
	{
	}

	public static List<T> All()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static IEnumerator<T> GetEnumerator()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
