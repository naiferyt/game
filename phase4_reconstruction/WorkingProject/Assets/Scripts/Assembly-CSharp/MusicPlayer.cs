using System.Collections;
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
			return default(MusicPlayer);
		}
	}

	public static bool Exists
	{
		get
		{
			return default(bool);
		}
	}

	private void Start()
	{
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void PlayMusic()
	{
	}

	public void PlayMusic(string levelName)
	{
	}

	public void StopMusic()
	{
	}

	public void UpdateVolume()
	{
	}

	public void HijackMusicPlayerForSoundStings(string stingName, bool loop)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator RestoreVolumeAfterSound()
	{
		return default(IEnumerator);
	}
}
