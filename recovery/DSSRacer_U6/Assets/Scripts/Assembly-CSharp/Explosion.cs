using System.Collections;
using System.Diagnostics;
using UnityEngine;

// One-shot explosion: survives scene loads, plays its sound at the SFX volume and destroys itself when
// the sound has finished.
// Source listing: recovery/aot_listings/Assembly-CSharp/Explosion.txt
// RECUPERADO-AOT Explosion::.ctor token 0x060002f2 @0x000ed08c (trivial constructor)
public class Explosion : MonoBehaviour
{
	// RECUPERADO-AOT Explosion::Start token 0x060002f3 @0x000ed0c0
	// ADAPTADO-U6: Component.audio -> GetComponent<AudioSource>().
	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		if (GetComponent<AudioSource>() != null)
		{
			GetComponent<AudioSource>().volume = DataUtility.Instance.localOptions.sfxVolumeLevel;
		}
		StartCoroutine(ExplosionDeath());
	}

	// RECUPERADO-AOT Explosion::Update token 0x060002f4 @0x000ed16c
	private void Update()
	{
	}

	// RECUPERADO-AOT Explosion::ExplosionDeath token 0x060002f5 @0x000ed198
	// RECUPERADO-AOT Explosion/<ExplosionDeath>c__Iterator24::MoveNext token 0x060008a8 @0x00148370
	// ADAPTADO-U6: Component.audio -> GetComponent<AudioSource>().
	[DebuggerHidden]
	private IEnumerator ExplosionDeath()
	{
		do
		{
			yield return 0;
		}
		while (GetComponent<AudioSource>().isPlaying);
		Object.Destroy(base.gameObject);
	}
}
