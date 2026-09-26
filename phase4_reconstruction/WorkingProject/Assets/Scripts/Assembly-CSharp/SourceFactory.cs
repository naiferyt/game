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
		return default(AudioSource);
	}

	public void RecycleSources()
	{
	}

	public List<AudioSource> GetUsedList()
	{
		return default(List<AudioSource>);
	}

	public void Init(GameObject owner)
	{
	}

	public void SetPriority(int priority)
	{
	}
}
