using UnityEngine;

public class DrivePickupAIState : BaseCarAIState
{
	public const float MIN_DIST = 40f;

	public GameObject desiredPickup;

	public override CarAI.AIStates GetAIStateEnum()
	{
		RecoveryPending.Hit("DrivePickupAIState.GetAIStateEnum");
		return default(CarAI.AIStates);
	}

	public override void Init()
	{
		RecoveryPending.Hit("DrivePickupAIState.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("DrivePickupAIState.Update");
	}

	public override void FixedUpdate()
	{
		RecoveryPending.Hit("DrivePickupAIState.FixedUpdate");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("DrivePickupAIState.Shutdown");
	}
}
