using System;
using UnityEngine;

[Serializable]
public class AudioCrumb
{
	public float playbackSpeed;

	public float volume;

	public AudioClip clip;

	public void Play()
	{
		RecoveryPending.Hit("AudioCrumb.Play");
	}
}
