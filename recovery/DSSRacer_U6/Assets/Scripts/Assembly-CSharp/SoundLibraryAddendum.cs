using UnityEngine;

public class SoundLibraryAddendum : MonoBehaviour
{
	public SoundLibrary.SoundClipReference[] additionalSounds;

	private void OnEnable()
	{
		RecoveryPending.Hit("SoundLibraryAddendum.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("SoundLibraryAddendum.OnDisable");
	}

	public void Dispose()
	{
		RecoveryPending.Hit("SoundLibraryAddendum.Dispose");
	}
}
