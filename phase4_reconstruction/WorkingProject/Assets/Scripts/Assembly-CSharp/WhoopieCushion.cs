using System.Collections;
using UnityEngine;

public class WhoopieCushion : MonoBehaviour
{
	public ParticleSystem whoopieBurst;

	private void Start()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Explode()
	{
		return default(IEnumerator);
	}

	private void OnCollisionEnter(Collision col)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
