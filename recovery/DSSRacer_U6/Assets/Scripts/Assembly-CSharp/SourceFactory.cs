using System;
using System.Collections.Generic;
using UnityEngine;

// Pool of AudioSources on a child object of the owner; used sources return to the pool once they stop playing.
// Source listing: recovery/aot_listings/Assembly-CSharp/SourceFactory.txt
[Serializable]
public class SourceFactory
{
	// RECUPERADO-AOT SourceFactory::.ctor token 0x0600032a @0x000eef24 (field initializer)
	public int capacity = 10;

	private List<AudioSource> available;

	private List<AudioSource> used;

	// RECUPERADO-AOT SourceFactory::GetSource token 0x0600032b @0x000eef5c
	public AudioSource GetSource()
	{
		if (available.Count > 0)
		{
			AudioSource audioSource = available[0];
			used.Add(audioSource);
			available.RemoveAt(0);
			return audioSource;
		}
		return null;
	}

	// RECUPERADO-AOT SourceFactory::RecycleSources token 0x0600032c @0x000eefe8
	public void RecycleSources()
	{
		for (int i = 0; i < used.Count; i++)
		{
			AudioSource audioSource = used[i];
			if (!audioSource.isPlaying)
			{
				audioSource.clip = null;
				available.Add(audioSource);
				used.RemoveAt(i--);
			}
		}
	}

	// RECUPERADO-AOT SourceFactory::GetUsedList token 0x0600032d @0x000ef0a4
	public List<AudioSource> GetUsedList()
	{
		return used;
	}

	// RECUPERADO-AOT SourceFactory::Init token 0x0600032e @0x000ef0d8
	// The loop runs up to the list capacity inclusive, so the pool holds capacity + 1 sources (as in the original).
	public void Init(GameObject owner)
	{
		GameObject gameObject = new GameObject("Audio Source Factory");
		gameObject.transform.parent = owner.transform;
		gameObject.transform.localPosition = Vector3.zero;
		available = new List<AudioSource>(capacity);
		used = new List<AudioSource>();
		int num = available.Capacity;
		for (int i = 0; i <= num; i++)
		{
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.playOnAwake = false;
			audioSource.rolloffMode = AudioRolloffMode.Linear;
			audioSource.maxDistance = 100f;
			audioSource.priority = 1;
			audioSource.volume = DataUtility.Instance.localOptions.sfxVolumeLevel;
			available.Add(audioSource);
		}
	}

	// RECUPERADO-AOT SourceFactory::SetPriority token 0x0600032f @0x000ef304
	public void SetPriority(int priority)
	{
		foreach (AudioSource item in available)
		{
			item.priority = priority;
		}
		foreach (AudioSource item2 in used)
		{
			item2.priority = priority;
		}
	}
}
