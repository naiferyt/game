using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class WhoopieCushion : MonoBehaviour
{
	public ParticleSystem whoopieBurst;

	private void Start()
	{
	}

	[DebuggerHidden]
	private IEnumerator Explode()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void OnCollisionEnter(Collision col)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
