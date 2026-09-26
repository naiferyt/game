using UnityEngine;

public class DrivePickupAIState : BaseCarAIState
{
	public const float MIN_DIST = 40f;

	public GameObject desiredPickup;

	public override CarAI.AIStates GetAIStateEnum()
	{
		return default(CarAI.AIStates);
	}

	public override void Init()
	{
	}

	public override void Update()
	{
	}

	public override void FixedUpdate()
	{
	}

	public override void Shutdown()
	{
	}
}
