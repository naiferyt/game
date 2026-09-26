using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SoundSequencer : MonoBehaviour
{
	private List<int> loopingHashes;

	public float recycleTimer;

	public Dictionary<int, int> soundRequests;

	public SourceFactory factory;

	private bool wasPaused;

	public bool isPaused
	{
		get
		{
			return default(bool);
		}
	}

	public int RequestPlay(string clipName)
	{
		return default(int);
	}

	public void RequestPlayLoop(string clipName)
	{
	}

	public void StopLoopingSound(string clipName)
	{
	}

	private void DetermineSoundsToPlay()
	{
	}

	private bool SearchUsedList(int key)
	{
		return default(bool);
	}

	private void GetNewSourceAndPlay(int key)
	{
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Recycle()
	{
		return default(IEnumerator);
	}

	public void PauseSounds()
	{
	}

	public void UnpauseSounds()
	{
	}

	public void StopSounds()
	{
	}

	public void SetPriority(int priority)
	{
	}
}
