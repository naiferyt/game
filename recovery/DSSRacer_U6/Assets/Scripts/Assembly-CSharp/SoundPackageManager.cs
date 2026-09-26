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

	[DebuggerHidden]
	private IEnumerator LoadPackageCoroutine(SoundPackageLoadReference loadRef)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public SoundPackageLoadReference LoadPackage(SoundPackageReference packageRef)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void UnloadPackage(SoundPackageReference packageRef)
	{
	}

	public void CleaningPass()
	{
	}

	public bool IsClipLoaded(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool IsPackageLoaded(SoundPackageReference packageRef)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public AudioClip GetClip(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
