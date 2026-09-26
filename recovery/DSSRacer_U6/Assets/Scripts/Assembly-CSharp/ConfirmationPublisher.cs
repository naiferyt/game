using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ConfirmationPublisher : UghPublisher
{
	[HideInInspector]
	public bool confirm;

	private void Start()
	{
		RecoveryPending.Hit("ConfirmationPublisher.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("ConfirmationPublisher.Update");
	}

	public void PressedYes()
	{
		RecoveryPending.Hit("ConfirmationPublisher.PressedYes");
	}

	public void PressedNo()
	{
		RecoveryPending.Hit("ConfirmationPublisher.PressedNo");
	}

	[DebuggerHidden]
	private IEnumerator Close()
	{
		RecoveryPending.Hit("ConfirmationPublisher.Close");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		RecoveryPending.Hit("ConfirmationPublisher.DestroyThis");
		yield break;
	}
}
