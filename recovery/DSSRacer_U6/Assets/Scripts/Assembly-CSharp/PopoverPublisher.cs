using UnityEngine;

public class PopoverPublisher : UghPublisher
{
	private Vector3 originOffset;

	private float transitionTimer;

	private float transitionSpeed;

	private bool transitionOut;

	private void Start()
	{
		RecoveryPending.Hit("PopoverPublisher.Start");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("PopoverPublisher.FixedUpdate");
	}

	private void PressedBacking()
	{
		RecoveryPending.Hit("PopoverPublisher.PressedBacking");
	}

	public void SetText(string text)
	{
		RecoveryPending.Hit("PopoverPublisher.SetText");
	}
}
