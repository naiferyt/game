using System.Collections;
using UnityEngine;

public class BarrelLauncher : MonoBehaviour
{
	public GameObject barrelPrefab;

	public float ROF;

	public float ammoLifetime;

	public float initialTimeOffset;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LaunchPump()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}

	private void LaunchBarrel()
	{
	}
}
