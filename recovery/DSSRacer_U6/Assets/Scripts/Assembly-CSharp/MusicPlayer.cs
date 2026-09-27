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

	// RECUPERADO-AOT MusicPlayer::Start token 0x060002fa @0x000ed370
	// ADAPTADO-U6 (whole class): Component.audio -> GetComponent<AudioSource>().
	private void Start()
	{
		UpdateVolume();
		GetComponent<AudioSource>().maxDistance = float.MaxValue;
	}

	// RECUPERADO-AOT MusicPlayer::Awake token 0x060002fb @0x000ed3d8
	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// RECUPERADO-AOT MusicPlayer::Update token 0x060002fc @0x000ed410
	// The music pauses with the race.
	private void Update()
	{
		if (RaceManager.isPaused && !paused)
		{
			paused = true;
			GetComponent<AudioSource>().Pause();
		}
		else if (paused && !RaceManager.isPaused)
		{
			paused = false;
			GetComponent<AudioSource>().Play();
		}
	}

	// RECUPERADO-AOT MusicPlayer::PlayMusic token 0x060002fd @0x000ed4a8
	public void PlayMusic()
	{
		PlayMusic(string.Empty);
	}

	// RECUPERADO-AOT MusicPlayer::PlayMusic token 0x060002fe @0x000ed4f0
	// Loops the clip named like the level ("bgMusicDefault" when no name is given).
	public void PlayMusic(string levelName)
	{
		AudioSource component = GetComponent<AudioSource>();
		if (component.isPlaying)
		{
			component.Stop();
		}
		AudioClip clip = SoundLibrary.GetClip("bgMusicDefault");
		if (levelName != string.Empty)
		{
			clip = SoundLibrary.GetClip(levelName);
		}
		if (clip == null)
		{
			UnityEngine.Debug.LogWarning("Wrong Clip name for music, passed in levelName was: " + levelName);
			return;
		}
		component.clip = clip;
		component.loop = true;
		component.Play();
	}

	// RECUPERADO-AOT MusicPlayer::StopMusic token 0x060002ff @0x000ed610
	public void StopMusic()
	{
		if (GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().Stop();
		}
	}

	// RECUPERADO-AOT MusicPlayer::UpdateVolume token 0x06000300 @0x000ed66c
	public void UpdateVolume()
	{
		GetComponent<AudioSource>().volume = DataUtility.Instance.localOptions.musicVolumeLevel;
	}

	// RECUPERADO-AOT MusicPlayer::HijackMusicPlayerForSoundStings token 0x06000301 @0x000ed6d0
	// Plays a sting (race win/lose...) on the music source at the effects volume, then restores the music volume.
	public void HijackMusicPlayerForSoundStings(string stingName, bool loop)
	{
		AudioSource component = GetComponent<AudioSource>();
		if (component.isPlaying)
		{
			component.Stop();
		}
		component.clip = SoundLibrary.GetClip(stingName);
		component.loop = loop;
		component.volume = DataUtility.Instance.localOptions.sfxVolumeLevel;
		component.Play();
		StartCoroutine(RestoreVolumeAfterSound());
	}

	// RECUPERADO-AOT MusicPlayer::RestoreVolumeAfterSound token 0x06000302 @0x000ed7e4
	// RECUPERADO-AOT MusicPlayer/<RestoreVolumeAfterSound>c__Iterator25::MoveNext token 0x060008ae @0x0014854c
	[DebuggerHidden]
	private IEnumerator RestoreVolumeAfterSound()
	{
		do
		{
			yield return null;
		}
		while (GetComponent<AudioSource>().isPlaying);
		UpdateVolume();
	}
}
