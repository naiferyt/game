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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
