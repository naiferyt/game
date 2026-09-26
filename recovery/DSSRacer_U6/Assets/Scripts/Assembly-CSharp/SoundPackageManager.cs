using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
			RecoveryPending.Hit("SoundPackageManager.get_Instance");
			return default(SoundPackageManager);
		}
	}

	public static bool Present
	{
		get
		{
			RecoveryPending.Hit("SoundPackageManager.get_Present");
			return default(bool);
		}
	}

	[DebuggerHidden]
	private IEnumerator LoadPackageCoroutine(SoundPackageLoadReference loadRef)
	{
		RecoveryPending.Hit("SoundPackageManager.LoadPackageCoroutine");
		yield break;
	}

	public SoundPackageLoadReference LoadPackage(SoundPackageReference packageRef)
	{
		RecoveryPending.Hit("SoundPackageManager.LoadPackage");
		return default(SoundPackageLoadReference);
	}

	public void UnloadPackage(SoundPackageReference packageRef)
	{
		RecoveryPending.Hit("SoundPackageManager.UnloadPackage");
	}

	public void CleaningPass()
	{
		RecoveryPending.Hit("SoundPackageManager.CleaningPass");
	}

	public bool IsClipLoaded(string name)
	{
		RecoveryPending.Hit("SoundPackageManager.IsClipLoaded");
		return default(bool);
	}

	public bool IsPackageLoaded(SoundPackageReference packageRef)
	{
		RecoveryPending.Hit("SoundPackageManager.IsPackageLoaded");
		return default(bool);
	}

	public AudioClip GetClip(string name)
	{
		RecoveryPending.Hit("SoundPackageManager.GetClip");
		return default(AudioClip);
	}
}
