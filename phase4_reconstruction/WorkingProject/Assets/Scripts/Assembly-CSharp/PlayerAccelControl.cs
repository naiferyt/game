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
			return default(bool);
		}
		set
		{
		}
	}

	private void ApplyReverse(bool state)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}
}
