using UnityEngine;

public class LiftControlAI : MonoBehaviour
{
	private Vector3 desiredPosition;

	private float duration;

	private Vector3 initialPosition;

	private float timer;

	private void Start()
	{
		RecoveryPending.Hit("LiftControlAI.Start");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("LiftControlAI.FixedUpdate");
	}

	public void SetTransition(Vector3 newPosition, float time)
	{
		RecoveryPending.Hit("LiftControlAI.SetTransition");
	}
}
