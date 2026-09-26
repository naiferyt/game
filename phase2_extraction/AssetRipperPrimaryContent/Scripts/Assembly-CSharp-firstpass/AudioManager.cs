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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public float SoundEffectsVolume
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
