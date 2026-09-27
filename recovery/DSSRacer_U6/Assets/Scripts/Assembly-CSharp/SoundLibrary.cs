using System;
using System.Collections.Generic;
using UnityEngine;

// Persistent bank of named sound clips (plus per-name hashes) and helpers to play them on a source, on the
// player's kart (SoundSequencer), on the chase camera or as UI clicks, at the effects volume of the options.
// Source listing: recovery/aot_listings/Assembly-CSharp/SoundLibrary.txt
public class SoundLibrary : MonoBehaviour
{
	[Serializable]
	public class SoundClipReference
	{
		public string name;

		public AudioClip clip;

		[HideInInspector]
		public int hash;
	}

	public class SoundClipDictionary
	{
		private Dictionary<string, AudioClip> nameToAudioClip;

		// RECUPERADO-AOT SoundLibrary/SoundClipDictionary::get_Item token 0x0600031d @0x000ee88c
		// RECUPERADO-AOT SoundLibrary/SoundClipDictionary::set_Item token 0x0600031e @0x000ee8fc
		// Missing names read as null; assigning null removes the entry.
		public AudioClip this[string name]
		{
			get
			{
				if (!nameToAudioClip.ContainsKey(name))
				{
					return null;
				}
				return nameToAudioClip[name];
			}
			set
			{
				if (value == null)
				{
					if (nameToAudioClip.ContainsKey(name))
					{
						nameToAudioClip[name] = null;
						nameToAudioClip.Remove(name);
					}
				}
				else if (!nameToAudioClip.ContainsKey(name))
				{
					nameToAudioClip.Add(name, value);
				}
				else
				{
					nameToAudioClip[name] = value;
				}
			}
		}

		// RECUPERADO-AOT SoundLibrary/SoundClipDictionary::get_Count token 0x0600031f @0x000ee9dc
		public int Count
		{
			get
			{
				return nameToAudioClip.Count;
			}
		}

		// RECUPERADO-AOT SoundLibrary/SoundClipDictionary::.ctor token 0x0600031c @0x000ee7d0
		public SoundClipDictionary(SoundClipReference[] refs)
		{
			nameToAudioClip = new Dictionary<string, AudioClip>(refs.Length);
			for (int i = 0; i < refs.Length; i++)
			{
				nameToAudioClip[refs[i].name] = refs[i].clip;
			}
		}
	}

	public class ClipHashDictionary
	{
		private Dictionary<string, int> nameToHash;

		// RECUPERADO-AOT SoundLibrary/ClipHashDictionary::get_Item token 0x06000321 @0x000eead8
		// RECUPERADO-AOT SoundLibrary/ClipHashDictionary::set_Item token 0x06000322 @0x000eeb48
		// Missing names read as -1; assigning int.MaxValue removes the entry.
		public int this[string name]
		{
			get
			{
				if (!nameToHash.ContainsKey(name))
				{
					return -1;
				}
				return nameToHash[name];
			}
			set
			{
				if (value == int.MaxValue)
				{
					nameToHash.Remove(name);
				}
				else if (!nameToHash.ContainsKey(name))
				{
					nameToHash.Add(name, value);
				}
				else
				{
					nameToHash[name] = value;
				}
			}
		}

		// RECUPERADO-AOT SoundLibrary/ClipHashDictionary::.ctor token 0x06000320 @0x000eea1c
		public ClipHashDictionary(SoundClipReference[] refs)
		{
			nameToHash = new Dictionary<string, int>(refs.Length);
			for (int i = 0; i < refs.Length; i++)
			{
				nameToHash[refs[i].name] = refs[i].hash;
			}
		}
	}

	public class HashClipDictionary
	{
		private Dictionary<int, string> hashToName;

		// RECUPERADO-AOT SoundLibrary/HashClipDictionary::get_Item token 0x06000324 @0x000eeca8
		// RECUPERADO-AOT SoundLibrary/HashClipDictionary::set_Item token 0x06000325 @0x000eed18
		// Missing hashes read as null; assigning null removes the entry.
		public string this[int hash]
		{
			get
			{
				if (!hashToName.ContainsKey(hash))
				{
					return null;
				}
				return hashToName[hash];
			}
			set
			{
				if (value == null)
				{
					hashToName.Remove(hash);
				}
				else if (!hashToName.ContainsKey(hash))
				{
					hashToName.Add(hash, value);
				}
				else
				{
					hashToName[hash] = value;
				}
			}
		}

		// RECUPERADO-AOT SoundLibrary/HashClipDictionary::.ctor token 0x06000323 @0x000eebec
		public HashClipDictionary(SoundClipReference[] refs)
		{
			hashToName = new Dictionary<int, string>(refs.Length);
			for (int i = 0; i < refs.Length; i++)
			{
				hashToName[refs[i].hash] = refs[i].name;
			}
		}
	}

	public SoundClipReference[] soundClipReferences;

	private AudioSource cameraAudioSource;

	private SoundClipDictionary soundClipDictionary;

	private ClipHashDictionary clipHashDictionary;

	private HashClipDictionary hashClipDictionary;

	private static SoundLibrary s_Instance;

	// RECUPERADO-AOT SoundLibrary::get_Instance token 0x06000305 @0x000ed884
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat.
	public static SoundLibrary Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(SoundLibrary)) as SoundLibrary;
				if (s_Instance == null)
				{
					Debug.LogWarning("There must be at least one SoundLibrary in the scene!");
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT SoundLibrary::get_Present token 0x06000306 @0x000ed97c
	public static bool Present
	{
		get
		{
			return s_Instance != null;
		}
	}

	// RECUPERADO-AOT SoundLibrary::get_SoundBank token 0x06000307 @0x000ed9bc
	public SoundClipDictionary SoundBank
	{
		get
		{
			return soundClipDictionary;
		}
	}

	// RECUPERADO-AOT SoundLibrary::get_NameToHashBank token 0x06000308 @0x000ed9f0
	public ClipHashDictionary NameToHashBank
	{
		get
		{
			return clipHashDictionary;
		}
	}

	// RECUPERADO-AOT SoundLibrary::get_HashToNameBank token 0x06000309 @0x000eda24
	public HashClipDictionary HashToNameBank
	{
		get
		{
			return hashClipDictionary;
		}
	}

	// RECUPERADO-AOT SoundLibrary::Awake token 0x0600030a @0x000eda58
	// The first library survives scene loads; later copies destroy themselves.
	private void Awake()
	{
		if (s_Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		UnityEngine.Object.DontDestroyOnLoad(Instance);
		for (int i = 0; i < soundClipReferences.Length; i++)
		{
			soundClipReferences[i].hash = soundClipReferences[i].name.GetHashCode();
		}
		soundClipDictionary = new SoundClipDictionary(soundClipReferences);
		clipHashDictionary = new ClipHashDictionary(soundClipReferences);
		hashClipDictionary = new HashClipDictionary(soundClipReferences);
	}

	// RECUPERADO-AOT SoundLibrary::GetClip token 0x0600030b @0x000edbdc
	public static AudioClip GetClip(string name)
	{
		if (!Present || name == null)
		{
			return null;
		}
		return Instance.soundClipDictionary[name];
	}

	// RECUPERADO-AOT SoundLibrary::GetClipHash token 0x0600030c @0x000edc48
	public static int GetClipHash(string name)
	{
		if (!Present || name == null)
		{
			return -1;
		}
		return Instance.clipHashDictionary[name];
	}

	// RECUPERADO-AOT SoundLibrary::GetClipName token 0x0600030d @0x000edcb4
	public static string GetClipName(int hash)
	{
		if (!Present || hash == -1)
		{
			return null;
		}
		return Instance.hashClipDictionary[hash];
	}

	// RECUPERADO-AOT SoundLibrary::ManuallyAddClip token 0x0600030e @0x000edd24
	public static void ManuallyAddClip(string name, AudioClip clip)
	{
		if (Present)
		{
			Instance.soundClipDictionary[name] = clip;
			Instance.clipHashDictionary[name] = name.GetHashCode();
			Instance.hashClipDictionary[name.GetHashCode()] = name;
		}
	}

	// RECUPERADO-AOT SoundLibrary::ManuallyRemoveClip token 0x0600030f @0x000edddc
	public static void ManuallyRemoveClip(string name)
	{
		if (Present)
		{
			Instance.soundClipDictionary[name] = null;
			Instance.clipHashDictionary[name] = int.MaxValue;
			Instance.hashClipDictionary[name.GetHashCode()] = null;
		}
	}

	// RECUPERADO-AOT SoundLibrary::PlayClipOnSource token 0x06000310 @0x000ede7c
	// A looping request on a source already playing a loop leaves it running (only the clip is swapped).
	public static AudioClip PlayClipOnSource(string clipName, AudioSource source, bool loop)
	{
		AudioClip clip = GetClip(clipName);
		if (clip == null || source == null)
		{
			return null;
		}
		source.volume = DataUtility.Instance.localOptions.sfxVolumeLevel;
		source.clip = clip;
		if (loop && source.isPlaying)
		{
			if (!source.loop)
			{
				source.Stop();
				source.loop = loop;
				source.Play();
			}
			return source.clip;
		}
		source.loop = loop;
		source.Play();
		return source.clip;
	}

	// RECUPERADO-AOT SoundLibrary::PlayOneShotClipOnSource token 0x06000311 @0x000edfb4
	public static AudioClip PlayOneShotClipOnSource(string clipName, AudioSource source)
	{
		AudioClip clip = GetClip(clipName);
		if (clip == null || source == null)
		{
			return null;
		}
		source.volume = DataUtility.Instance.localOptions.sfxVolumeLevel;
		source.PlayOneShot(clip);
		return clip;
	}

	// RECUPERADO-AOT SoundLibrary::StopClipOnSource token 0x06000312 @0x000ee058
	public static void StopClipOnSource(AudioSource source)
	{
		if (source != null)
		{
			source.Stop();
		}
	}

	// RECUPERADO-AOT SoundLibrary::GetInstanceOfSource token 0x06000313 @0x000ee0a4
	// Reuses the parent's child named like owner (destroying owner) or turns owner into a 3D source under
	// parent; either way the source is set to linear rolloff up to 40 units.
	// ADAPTADO-U6: Transform.FindChild -> Find; Object.DestroyObject -> Destroy.
	public static AudioSource GetInstanceOfSource(GameObject owner, GameObject parent)
	{
		AudioSource audioSource = null;
		Transform transform = parent.transform.Find(owner.name);
		if ((bool)transform)
		{
			audioSource = transform.gameObject.GetComponent<AudioSource>();
			UnityEngine.Object.Destroy(owner);
		}
		if (audioSource == null)
		{
			audioSource = owner.GetComponent<AudioSource>();
			if (audioSource == null)
			{
				audioSource = owner.AddComponent<AudioSource>();
			}
			owner.transform.parent = parent.transform;
			owner.transform.localPosition = Vector3.zero;
		}
		audioSource.playOnAwake = false;
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.maxDistance = 40f;
		audioSource.enabled = true;
		return audioSource;
	}

	// RECUPERADO-AOT SoundLibrary::ButtonClickPlay token 0x06000314 @0x000ee278
	// ADAPTADO-U6: Component.audio -> GetComponent<AudioSource>().
	public static void ButtonClickPlay(string soundName)
	{
		AudioSource component = Camera.main.GetComponent<AudioSource>();
		if (component == null)
		{
			Debug.LogError("Could not play button sound because there was no audio source on main camera!");
		}
		else
		{
			PlayOneShotClipOnSource(soundName, component);
		}
	}

	// RECUPERADO-AOT SoundLibrary::PlayRandomWhoosh token 0x06000315 @0x000ee2ec
	// (switch targets decoded with forensics/scripts/switch_tables.py, GOT[596])
	public static void PlayRandomWhoosh()
	{
		if (!Present)
		{
			return;
		}
		string soundName = string.Empty;
		switch (UnityEngine.Random.Range(0, 3))
		{
		case 0:
			soundName = "Whoosh 1";
			break;
		case 1:
			soundName = "Whoosh 2";
			break;
		case 2:
			soundName = "Whoosh 3";
			break;
		}
		ButtonClickPlay(soundName);
	}

	// RECUPERADO-AOT SoundLibrary::PlaySoundOnPlayer token 0x06000316 @0x000ee3a8
	public static void PlaySoundOnPlayer(string soundName, bool oneShot)
	{
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar != null)
		{
			SoundSequencer component = playerCar.GetComponent<SoundSequencer>();
			if (component != null)
			{
				if (oneShot)
				{
					component.RequestPlay(soundName);
				}
				else
				{
					component.RequestPlayLoop(soundName);
				}
			}
		}
	}

	// RECUPERADO-AOT SoundLibrary::PlaySoundOnCamera token 0x06000317 @0x000ee454
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat; GameObject.audio -> GetComponent<AudioSource>().
	public static void PlaySoundOnCamera(string soundName, bool loop)
	{
		FollowCamera followCamera = U4Compat.FindObjectOfType(typeof(FollowCamera)) as FollowCamera;
		if (followCamera != null)
		{
			AudioSource component = followCamera.gameObject.GetComponent<AudioSource>();
			component.Stop();
			if (loop)
			{
				PlayClipOnSource(soundName, component, loop);
			}
			else
			{
				PlayOneShotClipOnSource(soundName, component);
			}
		}
	}

	// RECUPERADO-AOT SoundLibrary::StopSoundOnCamera token 0x06000318 @0x000ee54c
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat; GameObject.audio -> GetComponent<AudioSource>().
	public static void StopSoundOnCamera()
	{
		FollowCamera followCamera = U4Compat.FindObjectOfType(typeof(FollowCamera)) as FollowCamera;
		if (followCamera != null)
		{
			StopClipOnSource(followCamera.gameObject.GetComponent<AudioSource>());
		}
	}

	// RECUPERADO-AOT SoundLibrary::PauseCameraSound token 0x06000319 @0x000ee5fc
	// ADAPTADO-U6: Object.FindObjectOfType -> U4Compat; GameObject.audio -> GetComponent<AudioSource>().
	public static void PauseCameraSound(bool pause)
	{
		if (Instance.cameraAudioSource == null)
		{
			FollowCamera followCamera = U4Compat.FindObjectOfType(typeof(FollowCamera)) as FollowCamera;
			if (followCamera == null)
			{
				return;
			}
			Instance.cameraAudioSource = followCamera.gameObject.GetComponent<AudioSource>();
		}
		if (pause)
		{
			if (Instance.cameraAudioSource.isPlaying)
			{
				Instance.cameraAudioSource.Pause();
			}
		}
		else if (!Instance.cameraAudioSource.isPlaying)
		{
			Instance.cameraAudioSource.Play();
		}
	}

	// RECUPERADO-AOT SoundLibrary::Update token 0x0600031a @0x000ee758
	private void Update()
	{
		if (RaceManager.isPaused)
		{
			PauseCameraSound(true);
		}
		else
		{
			PauseCameraSound(false);
		}
	}
}
