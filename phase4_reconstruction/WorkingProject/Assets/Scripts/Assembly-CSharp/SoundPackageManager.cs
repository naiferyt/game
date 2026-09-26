using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPackageManager : MonoBehaviour
{
	private static SoundPackageManager s_instance;

	public static Action<string> OnSoundPackageLoaded;

	private List<SoundPackageLoadReference> loadedPackages;

	private Dictionary<string, AudioClip> clipMap;

	public static SoundPackageManager Instance
	{
		get
		{
			return default(SoundPackageManager);
		}
	}

	public static bool Present
	{
		get
		{
			return default(bool);
		}
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LoadPackageCoroutine(SoundPackageLoadReference loadRef)
	{
		return default(IEnumerator);
	}

	public SoundPackageLoadReference LoadPackage(SoundPackageReference packageRef)
	{
		return default(SoundPackageLoadReference);
	}

	public void UnloadPackage(SoundPackageReference packageRef)
	{
	}

	public void CleaningPass()
	{
	}

	public bool IsClipLoaded(string name)
	{
		return default(bool);
	}

	public bool IsPackageLoaded(SoundPackageReference packageRef)
	{
		return default(bool);
	}

	public AudioClip GetClip(string name)
	{
		return default(AudioClip);
	}
}
