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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static bool Exists
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	private IEnumerator RestoreVolumeAfterSound()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
