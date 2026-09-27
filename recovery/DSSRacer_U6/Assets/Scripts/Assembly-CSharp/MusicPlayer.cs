using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
	private static MusicPlayer s_Instance;

	private bool paused;

	// RECUPERADO-AOT MusicPlayer::get_Instance token 0x060002f8 @0x000ed238
	// (Adelantado de la Etapa 4 en 3.9: la meta lo usa para la música de victoria/derrota.)
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	public static MusicPlayer Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(MusicPlayer)) as MusicPlayer;
				if (s_Instance == null)
				{
					UnityEngine.Debug.LogWarning("There needs to be a MusicPlayer in the scene!");
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT MusicPlayer::get_Exists token 0x060002f9 @0x000ed330
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	public static bool Exists
	{
		get
		{
			return U4Compat.FindObjectOfType(typeof(MusicPlayer)) != null;
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
