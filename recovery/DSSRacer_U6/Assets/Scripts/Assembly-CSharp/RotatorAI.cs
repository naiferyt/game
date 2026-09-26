using System.Collections;
using UnityEngine;

// Spins an object at a constant rate (boot-screen loading wheel, garage props); halts while a race is paused.
// Source listing: recovery/aot_listings/Assembly-CSharp/RotatorAI.txt
public class RotatorAI : MonoBehaviour
{
	public Vector3 rotationSpeed;

	// RECUPERADO-AOT RotatorAI..ctor token 0x0600009d @0x000ced58 (field initializer)
	private Quaternion rotator = Quaternion.identity;

	// RECUPERADO-AOT RotatorAI.RotateCoroutine token 0x0600009e @0x000cedb8
	// (body: <RotateCoroutine>c__Iterator4.MoveNext token 0x060007e8 @0x00141a04)
	private IEnumerator RotateCoroutine()
	{
		while (true)
		{
			if (!RaceManager.isPaused)
			{
				transform.rotation = transform.rotation * rotator;
			}
			yield return new WaitForSeconds(Time.fixedDeltaTime);
		}
	}

	// RECUPERADO-AOT RotatorAI.Start token 0x0600009f @0x000cee00
	private void Start()
	{
		rotator = Quaternion.Euler(rotationSpeed * Time.fixedDeltaTime);
		StartCoroutine(RotateCoroutine());
	}
}
