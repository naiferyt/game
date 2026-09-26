using UnityEngine;

public class PlayerAccelControl : MonoBehaviour
{
	private const float turnSensitivity = 5f;

	private const float deadZone = 0.05f;

	public bool touchTurnTrack;

	private bool isReversingState;

	private CarCollider carCollider;

	public bool isReversing
	{
		get
		{
			RecoveryPending.Hit("PlayerAccelControl.get_isReversing");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("PlayerAccelControl.set_isReversing");
		}
	}

	private void ApplyReverse(bool state)
	{
		RecoveryPending.Hit("PlayerAccelControl.ApplyReverse");
	}

	private void Start()
	{
		RecoveryPending.Hit("PlayerAccelControl.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("PlayerAccelControl.Update");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("PlayerAccelControl.FixedUpdate");
	}
}
