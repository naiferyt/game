using UnityEngine;

public class DriveWaypointsCarAIState : BaseCarAIState
{
	public Vector3 desiredFacing;

	public SpeedPoint targetSP;

	private SpeedPoint preferedBranch;

	public override CarAI.AIStates GetAIStateEnum()
	{
		RecoveryPending.Hit("DriveWaypointsCarAIState.GetAIStateEnum");
		return default(CarAI.AIStates);
	}

	public override void Init()
	{
		RecoveryPending.Hit("DriveWaypointsCarAIState.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("DriveWaypointsCarAIState.Update");
	}

	public override void FixedUpdate()
	{
		RecoveryPending.Hit("DriveWaypointsCarAIState.FixedUpdate");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("DriveWaypointsCarAIState.Shutdown");
	}
}
