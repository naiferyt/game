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
		return default(List<T>);
	}

	public static IEnumerator<T> GetEnumerator()
	{
		return default(IEnumerator<T>);
	}
}
