using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Reference-counted loading of SoundPackage prefabs (named clip lists) from Resources. No scene or script of the
// shipped game instantiates it; recovered for completeness.
// Source listing: recovery/aot_listings/Assembly-CSharp/SoundPackageManager.txt
public class SoundPackageManager : MonoBehaviour
{
	private static SoundPackageManager s_instance;

	public static Action<string> OnSoundPackageLoaded;

	// RECUPERADO-AOT SoundPackageManager::.ctor token 0x06000487 @0x00104650 (field initializers)
	private List<SoundPackageLoadReference> loadedPackages = new List<SoundPackageLoadReference>();

	private Dictionary<string, AudioClip> clipMap = new Dictionary<string, AudioClip>();

	public static SoundPackageManager Instance
	{
		// RECUPERADO-AOT SoundPackageManager::get_Instance token 0x06000489 @0x001046fc
		get
		{
			if (s_instance == null)
			{
				s_instance = U4Compat.FindObjectOfType(typeof(SoundPackageManager)) as SoundPackageManager;
				if (s_instance == null)
				{
					UnityEngine.Debug.LogError("A SoundPackageManager is required in this scene!");
				}
			}
			return s_instance;
		}
	}

	public static bool Present
	{
		// RECUPERADO-AOT SoundPackageManager::get_Present token 0x0600048a @0x001047f4
		get
		{
			return s_instance != null;
		}
	}

	// RECUPERADO-AOT SoundPackageManager::LoadPackageCoroutine token 0x0600048b @0x00104834
	// RECUPERADO-AOT SoundPackageManager/<LoadPackageCoroutine>c__Iterator31::MoveNext token 0x060008fa @0x0014bdc8
	// ADAPTADO-U6: the Application.isWebPlayer branch (asset bundle from packageRef.webURL) is dropped (always false).
	[DebuggerHidden]
	private IEnumerator LoadPackageCoroutine(SoundPackageLoadReference loadRef)
	{
		loadedPackages.Add(loadRef);
		StreamManager.Asset asset = StreamManager.RequestAsset(loadRef.packageRef.name, loadRef.packageRef.resourcePath, StreamManager.StreamType.RESOURCE);
		while (!asset.isDone)
		{
			yield return null;
		}
		GameObject spGO = asset.mainAsset as GameObject;
		// The original never stores the package in loadRef.loadedPackage (CleaningPass therefore never frees it).
		SoundPackage sp = spGO.GetComponent<SoundPackage>();
		ClipReference[] clipList = sp.clipList;
		foreach (ClipReference clipRef in clipList)
		{
			if (clipMap.ContainsKey(clipRef.name))
			{
				UnityEngine.Debug.LogWarning("SoundPackage " + sp.name + " contains an already-loaded clip " + clipRef.name);
			}
			else
			{
				clipMap.Add(clipRef.name, clipRef.clip);
			}
		}
		if (OnSoundPackageLoaded != null)
		{
			OnSoundPackageLoaded(loadRef.packageRef.name);
		}
	}

	// RECUPERADO-AOT SoundPackageManager::LoadPackage token 0x0600048c @0x0010488c
	// RECUPERADO-AOT SoundPackageManager/<LoadPackage>c__AnonStorey94::<>m__F token 0x06000b3c @0x001667fc (predicate)
	public SoundPackageLoadReference LoadPackage(SoundPackageReference packageRef)
	{
		SoundPackageLoadReference soundPackageLoadReference = loadedPackages.Find((SoundPackageLoadReference x) => x.packageRef.name == packageRef.name);
		if (soundPackageLoadReference != null)
		{
			soundPackageLoadReference.refCount++;
		}
		else
		{
			soundPackageLoadReference = new SoundPackageLoadReference();
			soundPackageLoadReference.packageRef = packageRef;
			soundPackageLoadReference.refCount = 1;
			StartCoroutine(LoadPackageCoroutine(soundPackageLoadReference));
		}
		return soundPackageLoadReference;
	}

	// RECUPERADO-AOT SoundPackageManager::UnloadPackage token 0x0600048d @0x001049bc
	// RECUPERADO-AOT SoundPackageManager/<UnloadPackage>c__AnonStorey95::<>m__10 token 0x06000b3e @0x00166874 (predicate)
	public void UnloadPackage(SoundPackageReference packageRef)
	{
		SoundPackageLoadReference soundPackageLoadReference = loadedPackages.Find((SoundPackageLoadReference x) => x.packageRef.name == packageRef.name);
		if (soundPackageLoadReference != null)
		{
			soundPackageLoadReference.refCount--;
		}
	}

	// RECUPERADO-AOT SoundPackageManager::CleaningPass token 0x0600048e @0x00104aa0
	// Kept as compiled: the removal list is never filled, so released packages stay in loadedPackages.
	public void CleaningPass()
	{
		List<SoundPackageLoadReference> list = new List<SoundPackageLoadReference>();
		foreach (SoundPackageLoadReference loadedPackage in loadedPackages)
		{
			if (loadedPackage.refCount <= 0 && loadedPackage.loadedPackage != null)
			{
				for (int i = 0; i < loadedPackage.loadedPackage.clipList.Length; i++)
				{
					clipMap.Remove(loadedPackage.loadedPackage.clipList[i].name);
				}
				StreamManager.ReleaseAsset(loadedPackage.packageRef.name);
			}
		}
		foreach (SoundPackageLoadReference item in list)
		{
			loadedPackages.Remove(item);
		}
	}

	// RECUPERADO-AOT SoundPackageManager::IsClipLoaded token 0x0600048f @0x00104dac
	public bool IsClipLoaded(string name)
	{
		return clipMap.ContainsKey(name);
	}

	// RECUPERADO-AOT SoundPackageManager::IsPackageLoaded token 0x06000490 @0x00104df4
	// RECUPERADO-AOT SoundPackageManager/<IsPackageLoaded>c__AnonStorey96::<>m__11 token 0x06000b40 @0x001668ec (predicate)
	public bool IsPackageLoaded(SoundPackageReference packageRef)
	{
		return loadedPackages.Find((SoundPackageLoadReference x) => x.packageRef.name == packageRef.name) != null;
	}

	// RECUPERADO-AOT SoundPackageManager::GetClip token 0x06000491 @0x00104edc
	public AudioClip GetClip(string name)
	{
		if (clipMap.ContainsKey(name))
		{
			return clipMap[name];
		}
		return null;
	}
}
