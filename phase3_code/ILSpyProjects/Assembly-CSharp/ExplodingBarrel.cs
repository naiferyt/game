using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
	public float lifeTime;

	public bool stationary;

	private Vector3 velocityForPause;

	private bool paused;

	[DebuggerHidden]
	private IEnumerator LifeCountdown()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void Update()
	{
	}

	[DebuggerHidden]
	private IEnumerator Explode()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
