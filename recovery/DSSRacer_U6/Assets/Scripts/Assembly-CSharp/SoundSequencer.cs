using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Per-object sound player (karts, props): play requests are batched per frame by clip hash, reuse the pooled
// source already holding that clip or take a free one from its SourceFactory; loops, pause and a periodic
// recycle of finished sources.
// Source listing: recovery/aot_listings/Assembly-CSharp/SoundSequencer.txt
[Serializable]
public class SoundSequencer : MonoBehaviour
{
	// RECUPERADO-AOT SoundSequencer::.ctor token 0x06000330 @0x000ef564 (field initializers)
	private List<int> loopingHashes = new List<int>();

	public float recycleTimer = 0.25f;

	public Dictionary<int, int> soundRequests;

	public SourceFactory factory;

	private bool wasPaused;

	// RECUPERADO-AOT SoundSequencer::get_isPaused token 0x06000331 @0x000ef5e0
	public bool isPaused
	{
		get
		{
			return wasPaused;
		}
	}

	// RECUPERADO-AOT SoundSequencer::RequestPlay token 0x06000332 @0x000ef614
	public int RequestPlay(string clipName)
	{
		int clipHash = SoundLibrary.GetClipHash(clipName);
		if (soundRequests.ContainsKey(clipHash))
		{
			soundRequests[clipHash] = soundRequests[clipHash] + 1;
		}
		else
		{
			soundRequests.Add(clipHash, 1);
		}
		return clipHash;
	}

	// RECUPERADO-AOT SoundSequencer::RequestPlayLoop token 0x06000333 @0x000ef6c8
	public void RequestPlayLoop(string clipName)
	{
		int item = RequestPlay(clipName);
		if (!loopingHashes.Contains(item))
		{
			loopingHashes.Add(item);
		}
	}

	// RECUPERADO-AOT SoundSequencer::StopLoopingSound token 0x06000334 @0x000ef734
	// Stops the first pooled source playing that clip (the hash stays marked as looping, as in the original).
	public void StopLoopingSound(string clipName)
	{
		foreach (AudioSource used in factory.GetUsedList())
		{
			if (used.clip == SoundLibrary.GetClip(clipName))
			{
				used.Stop();
				break;
			}
		}
	}

	// RECUPERADO-AOT SoundSequencer::DetermineSoundsToPlay token 0x06000335 @0x000ef8b8
	private void DetermineSoundsToPlay()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, int> soundRequest in soundRequests)
		{
			if (soundRequest.Value > 0)
			{
				list.Add(soundRequest.Key);
				if (!SearchUsedList(soundRequest.Key))
				{
					GetNewSourceAndPlay(soundRequest.Key);
				}
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			soundRequests[list[i]] = 0;
		}
	}

	// RECUPERADO-AOT SoundSequencer::SearchUsedList token 0x06000336 @0x000efab8
	// A source already holding the clip is restarted if it has finished (and counts as handled if still playing).
	private bool SearchUsedList(int key)
	{
		foreach (AudioSource used in factory.GetUsedList())
		{
			if (used.clip != null && used.clip == SoundLibrary.GetClip(SoundLibrary.GetClipName(key)))
			{
				if (!used.isPlaying)
				{
					used.loop = loopingHashes.Contains(key);
					used.Play();
				}
				return true;
			}
		}
		return false;
	}

	// RECUPERADO-AOT SoundSequencer::GetNewSourceAndPlay token 0x06000337 @0x000efcac
	private void GetNewSourceAndPlay(int key)
	{
		AudioSource source = factory.GetSource();
		if (source != null)
		{
			source.Stop();
			source.transform.parent = base.gameObject.transform;
			source.clip = SoundLibrary.GetClip(SoundLibrary.GetClipName(key));
			source.loop = loopingHashes.Contains(key);
			if (source.clip != null)
			{
				source.Play();
			}
		}
	}

	// RECUPERADO-AOT SoundSequencer::Awake token 0x06000338 @0x000efdac
	private void Awake()
	{
		soundRequests = new Dictionary<int, int>();
		SourceFactory sourceFactory = new SourceFactory();
		sourceFactory.capacity = 10;
		factory = sourceFactory;
		factory.Init(base.gameObject);
		StartCoroutine(Recycle());
	}

	// RECUPERADO-AOT SoundSequencer::Update token 0x06000339 @0x000efe60
	private void Update()
	{
		if (RaceManager.isPaused && !wasPaused)
		{
			PauseSounds();
		}
		else if (!RaceManager.isPaused && wasPaused)
		{
			UnpauseSounds();
		}
		else
		{
			DetermineSoundsToPlay();
		}
	}

	// RECUPERADO-AOT SoundSequencer::Recycle token 0x0600033a @0x000efedc
	// RECUPERADO-AOT SoundSequencer/<Recycle>c__Iterator26::MoveNext token 0x060008b4 @0x00148704
	[DebuggerHidden]
	private IEnumerator Recycle()
	{
		while (true)
		{
			yield return new WaitForSeconds(recycleTimer);
			factory.RecycleSources();
		}
	}

	// RECUPERADO-AOT SoundSequencer::PauseSounds token 0x0600033b @0x000eff24
	public void PauseSounds()
	{
		foreach (AudioSource used in factory.GetUsedList())
		{
			if (used.isPlaying)
			{
				used.Pause();
			}
		}
		wasPaused = true;
	}

	// RECUPERADO-AOT SoundSequencer::UnpauseSounds token 0x0600033c @0x000f0090
	public void UnpauseSounds()
	{
		foreach (AudioSource used in factory.GetUsedList())
		{
			if (!used.isPlaying)
			{
				used.Play();
			}
		}
		wasPaused = false;
	}

	// RECUPERADO-AOT SoundSequencer::StopSounds token 0x0600033d @0x000f01fc
	public void StopSounds()
	{
		foreach (AudioSource used in factory.GetUsedList())
		{
			used.Stop();
		}
		factory.RecycleSources();
	}

	// RECUPERADO-AOT SoundSequencer::SetPriority token 0x0600033e @0x000f035c
	public void SetPriority(int priority)
	{
		if (factory != null)
		{
			factory.SetPriority(priority);
		}
	}
}
