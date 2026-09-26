using UnityEngine;

public class DriveAvoidTerrainAIState : BaseCarAIState
{
	public const float MAX_DIST = 40f;

	private GameObject terrainTrigger;

	public Vector3 awayfromPoint;

	public override CarAI.AIStates GetAIStateEnum()
	{
		RecoveryPending.Hit("DriveAvoidTerrainAIState.GetAIStateEnum");
		return default(CarAI.AIStates);
	}

	public override void Init()
	{
		RecoveryPending.Hit("DriveAvoidTerrainAIState.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("DriveAvoidTerrainAIState.Update");
	}

	public override void FixedUpdate()
	{
		RecoveryPending.Hit("DriveAvoidTerrainAIState.FixedUpdate");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("DriveAvoidTerrainAIState.Shutdown");
	}
}
