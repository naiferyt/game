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
		RecoveryPending.Hit("EnumerableScript.Start");
	}

	public virtual void OnDisable()
	{
		RecoveryPending.Hit("EnumerableScript.OnDisable");
	}

	public static List<T> All()
	{
		RecoveryPending.Hit("EnumerableScript.All");
		return default(List<T>);
	}

	public static IEnumerator<T> GetEnumerator()
	{
		RecoveryPending.Hit("EnumerableScript.GetEnumerator");
		return default(IEnumerator<T>);
	}
}
