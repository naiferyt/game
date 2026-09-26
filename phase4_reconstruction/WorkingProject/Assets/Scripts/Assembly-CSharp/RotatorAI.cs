using System.Collections;
using UnityEngine;

public class RotatorAI : MonoBehaviour
{
	public Vector3 rotationSpeed;

	private Quaternion rotator;

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator RotateCoroutine()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}
}
