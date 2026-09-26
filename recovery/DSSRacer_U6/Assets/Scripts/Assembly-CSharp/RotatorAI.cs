using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class RotatorAI : MonoBehaviour
{
	public Vector3 rotationSpeed;

	private Quaternion rotator;

	[DebuggerHidden]
	private IEnumerator RotateCoroutine()
	{
		RecoveryPending.Hit("RotatorAI.RotateCoroutine");
		yield break;
	}

	private void Start()
	{
		RecoveryPending.Hit("RotatorAI.Start");
	}
}
