using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private static AudioManager s_Instance;

	private bool dirty;

	private float volume;

	public AudioCrumb dialogIn;

	public AudioCrumb dialogOut;

	public static AudioManager instance
	{
		get
		{
			RecoveryPending.Hit("AudioManager.get_instance");
			return default(AudioManager);
		}
	}

	public float SoundEffectsVolume
	{
		get
		{
			RecoveryPending.Hit("AudioManager.get_SoundEffectsVolume");
			return default(float);
		}
		set
		{
			RecoveryPending.Hit("AudioManager.set_SoundEffectsVolume");
		}
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("AudioManager.OnDisable");
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("AudioManager.OnEnable");
	}
}
