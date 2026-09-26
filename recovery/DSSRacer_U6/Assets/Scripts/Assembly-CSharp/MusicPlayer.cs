using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
	private static MusicPlayer s_Instance;

	private bool paused;

	public static MusicPlayer Instance
	{
		get
		{
			RecoveryPending.Hit("MusicPlayer.get_Instance");
			return default(MusicPlayer);
		}
	}

	public static bool Exists
	{
		get
		{
			RecoveryPending.Hit("MusicPlayer.get_Exists");
			return default(bool);
		}
	}

	private void Start()
	{
		RecoveryPending.Hit("MusicPlayer.Start");
	}

	private void Awake()
	{
		RecoveryPending.Hit("MusicPlayer.Awake");
	}

	private void Update()
	{
		RecoveryPending.Hit("MusicPlayer.Update");
	}

	public void PlayMusic()
	{
		RecoveryPending.Hit("MusicPlayer.PlayMusic");
	}

	public void PlayMusic(string levelName)
	{
		RecoveryPending.Hit("MusicPlayer.PlayMusic");
	}

	public void StopMusic()
	{
		RecoveryPending.Hit("MusicPlayer.StopMusic");
	}

	public void UpdateVolume()
	{
		RecoveryPending.Hit("MusicPlayer.UpdateVolume");
	}

	public void HijackMusicPlayerForSoundStings(string stingName, bool loop)
	{
		RecoveryPending.Hit("MusicPlayer.HijackMusicPlayerForSoundStings");
	}

	[DebuggerHidden]
	private IEnumerator RestoreVolumeAfterSound()
	{
		RecoveryPending.Hit("MusicPlayer.RestoreVolumeAfterSound");
		yield break;
	}
}
