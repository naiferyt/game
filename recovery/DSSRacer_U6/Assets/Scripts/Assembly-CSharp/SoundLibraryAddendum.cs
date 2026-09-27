using UnityEngine;

// Extra named clips registered in the SoundLibrary while this component is enabled.
// Source listing: recovery/aot_listings/Assembly-CSharp/SoundLibraryAddendum.txt
public class SoundLibraryAddendum : MonoBehaviour
{
	public SoundLibrary.SoundClipReference[] additionalSounds;

	// RECUPERADO-AOT SoundLibraryAddendum::OnEnable token 0x06000327 @0x000eedec
	private void OnEnable()
	{
		for (int i = 0; i < additionalSounds.Length; i++)
		{
			SoundLibrary.ManuallyAddClip(additionalSounds[i].name, additionalSounds[i].clip);
		}
	}

	// RECUPERADO-AOT SoundLibraryAddendum::OnDisable token 0x06000328 @0x000eee70
	private void OnDisable()
	{
		for (int i = 0; i < additionalSounds.Length; i++)
		{
			SoundLibrary.ManuallyRemoveClip(additionalSounds[i].name);
		}
	}

	// RECUPERADO-AOT SoundLibraryAddendum::Dispose token 0x06000329 @0x000eeef0
	public void Dispose()
	{
		OnDisable();
	}
}
