using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Barrel cannon: after initialTimeOffset fires an ExplodingBarrel every ROF seconds.
// Source listing: recovery/aot_listings/Assembly-CSharp/BarrelLauncher.txt
public class BarrelLauncher : MonoBehaviour
{
	public GameObject barrelPrefab;

	// RECUPERADO-AOT BarrelLauncher::.ctor token 0x060004b2 @0x00106d88 (field initializers)
	public float ROF = 10f;

	public float ammoLifetime = 8f;

	public float initialTimeOffset;

	// RECUPERADO-AOT BarrelLauncher::LaunchPump token 0x060004b3 @0x00106dec
	// RECUPERADO-AOT BarrelLauncher/<LaunchPump>c__Iterator33::MoveNext token 0x06000906 @0x0014c504
	[DebuggerHidden]
	private IEnumerator LaunchPump()
	{
		if (initialTimeOffset > 0f)
		{
			yield return new WaitForSeconds(initialTimeOffset);
		}
		while (true)
		{
			LaunchBarrel();
			yield return new WaitForSeconds(ROF);
		}
	}

	// RECUPERADO-AOT BarrelLauncher::Start token 0x060004b4 @0x00106e34
	private void Start()
	{
		StartCoroutine(LaunchPump());
	}

	// RECUPERADO-AOT BarrelLauncher::LaunchBarrel token 0x060004b5 @0x00106e84
	private void LaunchBarrel()
	{
		if (!RaceManager.isPaused)
		{
			GameObject gameObject = (GameObject)Object.Instantiate(barrelPrefab, base.transform.position, base.transform.rotation);
			gameObject.GetComponent<ExplodingBarrel>().lifeTime = ammoLifetime;
		}
	}
}
