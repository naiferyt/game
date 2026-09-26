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
				RecoveryPending.Hit("SoundLibrary.SoundClipDictionary.get_Item");
				return default(AudioClip);
			}
			set
			{
				RecoveryPending.Hit("SoundLibrary.SoundClipDictionary.set_Item");
			}
		}

		public int Count
		{
			get
			{
				RecoveryPending.Hit("SoundLibrary.SoundClipDictionary.get_Count");
				return default(int);
			}
		}

		public SoundClipDictionary(SoundClipReference[] refs)
		{
			RecoveryPending.Hit("SoundLibrary.SoundClipDictionary..ctor");
		}
	}

	public class ClipHashDictionary
	{
		private Dictionary<string, int> nameToHash;

		public int this[string name]
		{
			get
			{
				RecoveryPending.Hit("SoundLibrary.ClipHashDictionary.get_Item");
				return default(int);
			}
			set
			{
				RecoveryPending.Hit("SoundLibrary.ClipHashDictionary.set_Item");
			}
		}

		public ClipHashDictionary(SoundClipReference[] refs)
		{
			RecoveryPending.Hit("SoundLibrary.ClipHashDictionary..ctor");
		}
	}

	public class HashClipDictionary
	{
		private Dictionary<int, string> hashToName;

		public string this[int hash]
		{
			get
			{
				RecoveryPending.Hit("SoundLibrary.HashClipDictionary.get_Item");
				return default(string);
			}
			set
			{
				RecoveryPending.Hit("SoundLibrary.HashClipDictionary.set_Item");
			}
		}

		public HashClipDictionary(SoundClipReference[] refs)
		{
			RecoveryPending.Hit("SoundLibrary.HashClipDictionary..ctor");
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
			RecoveryPending.Hit("SoundLibrary.get_Instance");
			return default(SoundLibrary);
		}
	}

	public static bool Present
	{
		get
		{
			RecoveryPending.Hit("SoundLibrary.get_Present");
			return default(bool);
		}
	}

	public SoundClipDictionary SoundBank
	{
		get
		{
			RecoveryPending.Hit("SoundLibrary.get_SoundBank");
			return default(SoundClipDictionary);
		}
	}

	public ClipHashDictionary NameToHashBank
	{
		get
		{
			RecoveryPending.Hit("SoundLibrary.get_NameToHashBank");
			return default(ClipHashDictionary);
		}
	}

	public HashClipDictionary HashToNameBank
	{
		get
		{
			RecoveryPending.Hit("SoundLibrary.get_HashToNameBank");
			return default(HashClipDictionary);
		}
	}

	private void Awake()
	{
		RecoveryPending.Hit("SoundLibrary.Awake");
	}

	public static AudioClip GetClip(string name)
	{
		RecoveryPending.Hit("SoundLibrary.GetClip");
		return default(AudioClip);
	}

	public static int GetClipHash(string name)
	{
		RecoveryPending.Hit("SoundLibrary.GetClipHash");
		return default(int);
	}

	public static string GetClipName(int hash)
	{
		RecoveryPending.Hit("SoundLibrary.GetClipName");
		return default(string);
	}

	public static void ManuallyAddClip(string name, AudioClip clip)
	{
		RecoveryPending.Hit("SoundLibrary.ManuallyAddClip");
	}

	public static void ManuallyRemoveClip(string name)
	{
		RecoveryPending.Hit("SoundLibrary.ManuallyRemoveClip");
	}

	public static AudioClip PlayClipOnSource(string clipName, AudioSource source, bool loop)
	{
		RecoveryPending.Hit("SoundLibrary.PlayClipOnSource");
		return default(AudioClip);
	}

	public static AudioClip PlayOneShotClipOnSource(string clipName, AudioSource source)
	{
		RecoveryPending.Hit("SoundLibrary.PlayOneShotClipOnSource");
		return default(AudioClip);
	}

	public static void StopClipOnSource(AudioSource source)
	{
		RecoveryPending.Hit("SoundLibrary.StopClipOnSource");
	}

	public static AudioSource GetInstanceOfSource(GameObject owner, GameObject parent)
	{
		RecoveryPending.Hit("SoundLibrary.GetInstanceOfSource");
		return default(AudioSource);
	}

	public static void ButtonClickPlay(string soundName)
	{
		RecoveryPending.Hit("SoundLibrary.ButtonClickPlay");
	}

	public static void PlayRandomWhoosh()
	{
		RecoveryPending.Hit("SoundLibrary.PlayRandomWhoosh");
	}

	public static void PlaySoundOnPlayer(string soundName, bool oneShot)
	{
		RecoveryPending.Hit("SoundLibrary.PlaySoundOnPlayer");
	}

	public static void PlaySoundOnCamera(string soundName, bool loop)
	{
		RecoveryPending.Hit("SoundLibrary.PlaySoundOnCamera");
	}

	public static void StopSoundOnCamera()
	{
		RecoveryPending.Hit("SoundLibrary.StopSoundOnCamera");
	}

	public static void PauseCameraSound(bool pause)
	{
		RecoveryPending.Hit("SoundLibrary.PauseCameraSound");
	}

	private void Update()
	{
		RecoveryPending.Hit("SoundLibrary.Update");
	}
}
