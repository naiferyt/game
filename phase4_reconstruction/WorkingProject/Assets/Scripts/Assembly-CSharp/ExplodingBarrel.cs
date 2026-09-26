using System.Collections;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
	public float lifeTime;

	public bool stationary;

	private Vector3 velocityForPause;

	private bool paused;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LifeCountdown()
	{
		return default(IEnumerator);
	}

	private void Update()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Explode()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}

	private void OnCollisionEnter(Collision col)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
