using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SourceFactory
{
	public int capacity;

	private List<AudioSource> available;

	private List<AudioSource> used;

	public AudioSource GetSource()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void RecycleSources()
	{
	}

	public List<AudioSource> GetUsedList()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void Init(GameObject owner)
	{
	}

	public void SetPriority(int priority)
	{
	}
}
