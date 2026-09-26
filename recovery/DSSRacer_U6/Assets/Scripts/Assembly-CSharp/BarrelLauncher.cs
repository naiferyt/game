using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class BarrelLauncher : MonoBehaviour
{
	public GameObject barrelPrefab;

	public float ROF;

	public float ammoLifetime;

	public float initialTimeOffset;

	[DebuggerHidden]
	private IEnumerator LaunchPump()
	{
		RecoveryPending.Hit("BarrelLauncher.LaunchPump");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("BarrelLauncher.Start");
	}

	private void LaunchBarrel()
	{
		RecoveryPending.Hit("BarrelLauncher.LaunchBarrel");
	}
}
