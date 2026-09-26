using System;
using UnityEngine;

// A clip with its volume and playback speed, played at the main camera.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/AudioCrumb.txt
[Serializable]
public class AudioCrumb
{
	// RECUPERADO-AOT AudioCrumb::.ctor token 0x060000fc @0x000157c0 (field initializers)
	public float playbackSpeed = 1f;

	public float volume = 1f;

	public AudioClip clip;

	// RECUPERADO-AOT AudioCrumb::Play token 0x060000fd @0x00015820
	// The volume is scaled by SoundEffectsVolume here and again inside PlayClipAtPosition, as compiled.
	public void Play()
	{
		if (volume > 0f && clip != null)
		{
			AudioSourcex.PlayClipAtPosition(clip, Camera.main.transform.position, volume * AudioManager.instance.SoundEffectsVolume, playbackSpeed);
		}
	}
}
