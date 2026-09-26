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
		RecoveryPending.Hit("SourceFactory.GetSource");
		return default(AudioSource);
	}

	public void RecycleSources()
	{
		RecoveryPending.Hit("SourceFactory.RecycleSources");
	}

	public List<AudioSource> GetUsedList()
	{
		RecoveryPending.Hit("SourceFactory.GetUsedList");
		return default(List<AudioSource>);
	}

	public void Init(GameObject owner)
	{
		RecoveryPending.Hit("SourceFactory.Init");
	}

	public void SetPriority(int priority)
	{
		RecoveryPending.Hit("SourceFactory.SetPriority");
	}
}
