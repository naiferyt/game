using UnityEngine;

public class DriveHitBeneficialAIState : BaseCarAIState
{
	public const float MIN_DIST = 40f;

	public GameObject terrainTrigger;

	public Vector3 aimPoint;

	public override CarAI.AIStates GetAIStateEnum()
	{
		RecoveryPending.Hit("DriveHitBeneficialAIState.GetAIStateEnum");
		return default(CarAI.AIStates);
	}

	public override void Init()
	{
		RecoveryPending.Hit("DriveHitBeneficialAIState.Init");
	}

	public override void Update()
	{
		RecoveryPending.Hit("DriveHitBeneficialAIState.Update");
	}

	public override void FixedUpdate()
	{
		RecoveryPending.Hit("DriveHitBeneficialAIState.FixedUpdate");
	}

	public override void Shutdown()
	{
		RecoveryPending.Hit("DriveHitBeneficialAIState.Shutdown");
	}
}
