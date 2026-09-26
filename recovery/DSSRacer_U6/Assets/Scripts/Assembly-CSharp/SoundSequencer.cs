using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
			RecoveryPending.Hit("SoundSequencer.get_isPaused");
			return default(bool);
		}
	}

	public int RequestPlay(string clipName)
	{
		RecoveryPending.Hit("SoundSequencer.RequestPlay");
		return default(int);
	}

	public void RequestPlayLoop(string clipName)
	{
		RecoveryPending.Hit("SoundSequencer.RequestPlayLoop");
	}

	public void StopLoopingSound(string clipName)
	{
		RecoveryPending.Hit("SoundSequencer.StopLoopingSound");
	}

	private void DetermineSoundsToPlay()
	{
		RecoveryPending.Hit("SoundSequencer.DetermineSoundsToPlay");
	}

	private bool SearchUsedList(int key)
	{
		RecoveryPending.Hit("SoundSequencer.SearchUsedList");
		return default(bool);
	}

	private void GetNewSourceAndPlay(int key)
	{
		RecoveryPending.Hit("SoundSequencer.GetNewSourceAndPlay");
	}

	private void Awake()
	{
		RecoveryPending.Hit("SoundSequencer.Awake");
	}

	private void Update()
	{
		RecoveryPending.Hit("SoundSequencer.Update");
	}

	[DebuggerHidden]
	private IEnumerator Recycle()
	{
		RecoveryPending.Hit("SoundSequencer.Recycle");
		yield break;
	}

	public void PauseSounds()
	{
		RecoveryPending.Hit("SoundSequencer.PauseSounds");
	}

	public void UnpauseSounds()
	{
		RecoveryPending.Hit("SoundSequencer.UnpauseSounds");
	}

	public void StopSounds()
	{
		RecoveryPending.Hit("SoundSequencer.StopSounds");
	}

	public void SetPriority(int priority)
	{
		RecoveryPending.Hit("SoundSequencer.SetPriority");
	}
}
