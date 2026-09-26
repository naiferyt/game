using System;
using System.Collections.Generic;
using UnityEngine;

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

		public AudioClip this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public int Count
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public SoundClipDictionary(SoundClipReference[] refs)
		{
		}
	}

	public class ClipHashDictionary
	{
		private Dictionary<string, int> nameToHash;

		public int this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public ClipHashDictionary(SoundClipReference[] refs)
		{
		}
	}

	public class HashClipDictionary
	{
		private Dictionary<int, string> hashToName;

		public string this[int hash]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public HashClipDictionary(SoundClipReference[] refs)
		{
		}
	}

	public SoundClipReference[] soundClipReferences;

	private AudioSource cameraAudioSource;

	private SoundClipDictionary soundClipDictionary;

	private ClipHashDictionary clipHashDictionary;

	private HashClipDictionary hashClipDictionary;

	private static SoundLibrary s_Instance;

	public static SoundLibrary Instance
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static bool Present
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public SoundClipDictionary SoundBank
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public ClipHashDictionary NameToHashBank
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public HashClipDictionary HashToNameBank
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	private void Awake()
	{
	}

	public static AudioClip GetClip(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static int GetClipHash(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static string GetClipName(int hash)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void ManuallyAddClip(string name, AudioClip clip)
	{
	}

	public static void ManuallyRemoveClip(string name)
	{
	}

	public static AudioClip PlayClipOnSource(string clipName, AudioSource source, bool loop)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static AudioClip PlayOneShotClipOnSource(string clipName, AudioSource source)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void StopClipOnSource(AudioSource source)
	{
	}

	public static AudioSource GetInstanceOfSource(GameObject owner, GameObject parent)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static void ButtonClickPlay(string soundName)
	{
	}

	public static void PlayRandomWhoosh()
	{
	}

	public static void PlaySoundOnPlayer(string soundName, bool oneShot)
	{
	}

	public static void PlaySoundOnCamera(string soundName, bool loop)
	{
	}

	public static void StopSoundOnCamera()
	{
	}

	public static void PauseCameraSound(bool pause)
	{
	}

	private void Update()
	{
	}
}
