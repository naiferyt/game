using UnityEngine;

// Sound-effects volume (PlayerPrefs "SoundEffectsVol") and the dialog in/out sounds.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/AudioManager.txt
public class AudioManager : MonoBehaviour
{
	private static AudioManager s_Instance;

	// RECUPERADO-AOT AudioManager::.ctor token 0x060000c2 @0x00012f70 (field initializers)
	private bool dirty = true;

	private float volume = 1f;

	public AudioCrumb dialogIn;

	public AudioCrumb dialogOut;

	// RECUPERADO-AOT AudioManager::get_instance token 0x060000c4 @0x00012fe8
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static AudioManager instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(AudioManager)) as AudioManager;
				if (s_Instance == null)
				{
					Debug.Log("Error: There needs to be exactly one AudioManager in the scene.");
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT AudioManager::get_SoundEffectsVolume token 0x060000c7 @0x00013168
	// RECUPERADO-AOT AudioManager::set_SoundEffectsVolume token 0x060000c8 @0x000131f8
	public float SoundEffectsVolume
	{
		get
		{
			if (dirty)
			{
				volume = PlayerPrefs.GetFloat("SoundEffectsVol", 1f);
				dirty = false;
			}
			return volume;
		}
		set
		{
			PlayerPrefs.SetFloat("SoundEffectsVol", value);
			volume = value;
		}
	}

	// RECUPERADO-AOT AudioManager::OnDisable token 0x060000c5 @0x000130e0
	private void OnDisable()
	{
		s_Instance = null;
	}

	// RECUPERADO-AOT AudioManager::OnEnable token 0x060000c6 @0x00013124
	private void OnEnable()
	{
		s_Instance = this;
	}
}
