using UnityEngine;

public class MissionDialogPublisher : UghPublisher
{
	public AchievementPanelPublisher[] panels;

	private bool rolledOut;

	private Vector3 outPos;

	private Vector3 inPos;

	private bool canAct;

	private void Start()
	{
		RecoveryPending.Hit("MissionDialogPublisher.Start");
	}

	private void PressedTab()
	{
		RecoveryPending.Hit("MissionDialogPublisher.PressedTab");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("MissionDialogPublisher.FixedUpdate");
	}

	public void SetRollState(bool state)
	{
		RecoveryPending.Hit("MissionDialogPublisher.SetRollState");
	}

	private void Update()
	{
		RecoveryPending.Hit("MissionDialogPublisher.Update");
	}
}
