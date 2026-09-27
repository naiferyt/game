using UnityEngine;

// Default AI state: follow the SpeedPoint chain, picking a random weighted branch ahead, and steer toward a blend of
// the current and the next speed point.
// Source listing: recovery/aot_listings/Assembly-CSharp/DriveWaypointsCarAIState.txt
public class DriveWaypointsCarAIState : BaseCarAIState
{
	// RECUPERADO-AOT DriveWaypointsCarAIState::.ctor token 0x06000043 @0x000c6170 (field initializer)
	public Vector3 desiredFacing = Vector3.zero;

	public SpeedPoint targetSP;

	private SpeedPoint preferedBranch;

	// RECUPERADO-AOT DriveWaypointsCarAIState::GetAIStateEnum token 0x06000044 @0x000c61c4
	public override CarAI.AIStates GetAIStateEnum()
	{
		return CarAI.AIStates.driveWaypoints;
	}

	// RECUPERADO-AOT DriveWaypointsCarAIState::Init token 0x06000045 @0x000c61f4
	public override void Init()
	{
		targetSP = SpeedPoint.FindClosestSpeedPoint(parentAI.transform.position);
	}

	// RECUPERADO-AOT DriveWaypointsCarAIState::Update token 0x06000046 @0x000c6264
	public override void Update()
	{
		if (targetSP == null)
		{
			return;
		}
		while (targetSP.IsPointForward(parentAI.transform.position))
		{
			if (preferedBranch != null)
			{
				targetSP = preferedBranch;
				preferedBranch = null;
			}
			else
			{
				targetSP = targetSP.forwardPoint;
			}
		}
		Vector3 a = targetSP.transform.position - parentAI.transform.position;
		a.y = 0f;
		if (preferedBranch == null)
		{
			preferedBranch = targetSP.forwardPoint;
			SpeedPoint.SpeedBranchStruct[] branches = targetSP.branches;
			for (int i = 0; i < branches.Length; i++)
			{
				SpeedPoint.SpeedBranchStruct speedBranchStruct = branches[i];
				if (speedBranchStruct.weight >= Random.value)
				{
					preferedBranch = speedBranchStruct.target;
					break;
				}
			}
		}
		Vector3 b = preferedBranch.forwardPoint.transform.position - parentAI.transform.position;
		b.y = 0f;
		float t = 1f - a.sqrMagnitude / targetSP.backwardPoint.GetSPLine().sqrMagnitude;
		desiredFacing = Vector3.Lerp(a, b, t).normalized;
	}

	// RECUPERADO-AOT DriveWaypointsCarAIState::FixedUpdate token 0x06000047 @0x000c6640
	public override void FixedUpdate()
	{
		parentAI.DriveWithFacing(desiredFacing);
	}

	// RECUPERADO-AOT DriveWaypointsCarAIState::Shutdown token 0x06000048 @0x000c66a8
	public override void Shutdown()
	{
	}
}
