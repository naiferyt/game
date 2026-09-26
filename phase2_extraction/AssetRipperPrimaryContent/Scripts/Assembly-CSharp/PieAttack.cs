using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PieAttack : MonoBehaviour
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

	public void Explode()
	{
	}

	[DebuggerHidden]
	private IEnumerator ExplodeCoroutine()
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
