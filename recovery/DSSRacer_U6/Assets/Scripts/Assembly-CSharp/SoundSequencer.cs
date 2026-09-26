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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public int RequestPlay(string clipName)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	private IEnumerator Recycle()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
