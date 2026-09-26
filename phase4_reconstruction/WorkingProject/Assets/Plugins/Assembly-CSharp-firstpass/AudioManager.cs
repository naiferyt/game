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
			return default(AudioManager);
		}
	}

	public float SoundEffectsVolume
	{
		get
		{
			return default(float);
		}
		set
		{
		}
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}
}
