using UnityEngine;

public class ForwardForceAI : MonoBehaviour
{
	public Vector3 boost;

	public Vector3 force;

	public Vector3 torque;

	private void Start()
	{
		RecoveryPending.Hit("ForwardForceAI.Start");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("ForwardForceAI.FixedUpdate");
	}
}
