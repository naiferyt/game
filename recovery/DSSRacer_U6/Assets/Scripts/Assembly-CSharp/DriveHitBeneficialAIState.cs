using UnityEngine;

// AI state: aim for the closest point of a visible beneficial terrain trigger (boost pad...) until passed.
// Source listing: recovery/aot_listings/Assembly-CSharp/DriveHitBeneficialAIState.txt
public class DriveHitBeneficialAIState : BaseCarAIState
{
	public const float MIN_DIST = 40f;

	public GameObject terrainTrigger;

	// RECUPERADO-AOT DriveHitBeneficialAIState::.ctor token 0x06000037 @0x000c5408 (field initializer)
	public Vector3 aimPoint = Vector3.zero;

	// RECUPERADO-AOT DriveHitBeneficialAIState::GetAIStateEnum token 0x06000038 @0x000c545c
	public override CarAI.AIStates GetAIStateEnum()
	{
		return CarAI.AIStates.hitBeneficialTerrain;
	}

	// RECUPERADO-AOT DriveHitBeneficialAIState::Init token 0x06000039 @0x000c548c
	public override void Init()
	{
		Collider[] array = Physics.OverlapSphere(parentAI.gameObject.transform.position, parentAI.personality.awarenessRadius);
		foreach (Collider collider in array)
		{
			Vector3 vector = collider.transform.position - parentAI.transform.position;
			Ray ray = new Ray(parentAI.transform.position, vector.normalized);
			if (Physics.Raycast(ray, vector.magnitude, 2048))
			{
				continue;
			}
			TerrainEffectTrigger component = collider.gameObject.GetComponent<TerrainEffectTrigger>();
			if (!(component == null) && BaseEffect.isBeneficial(component.effectType) && !(vector.sqrMagnitude < 1600f))
			{
				terrainTrigger = collider.gameObject;
				break;
			}
		}
	}

	// RECUPERADO-AOT DriveHitBeneficialAIState::Update token 0x0600003a @0x000c5758
	public override void Update()
	{
		if (terrainTrigger == null)
		{
			parentAI.StateDone(this);
			return;
		}
		ObjectTrackDistanceLogic component = terrainTrigger.GetComponent<ObjectTrackDistanceLogic>();
		if (component != null && component.trackDistance < WaypointLogic.GetTrackDistanceForPoint(parentAI.transform.position))
		{
			parentAI.StateDone(this);
			return;
		}
		Vector3 rhs = terrainTrigger.transform.position - parentAI.transform.position;
		float num = Vector3.Dot(parentAI.transform.forward, rhs);
		if (!(num >= 0f))
		{
			parentAI.StateDone(this);
		}
	}

	// RECUPERADO-AOT DriveHitBeneficialAIState::FixedUpdate token 0x0600003b @0x000c5970
	public override void FixedUpdate()
	{
		if (!(terrainTrigger == null))
		{
			aimPoint = terrainTrigger.GetComponent<Collider>().ClosestPointOnBounds(parentAI.transform.position);
			parentAI.DriveTowardPoint(aimPoint);
			if (!((aimPoint - parentAI.transform.position).magnitude >= parentAI.DistEpsilon))
			{
				terrainTrigger = null;
			}
		}
	}

	// RECUPERADO-AOT DriveHitBeneficialAIState::Shutdown token 0x0600003c @0x000c5b20
	public override void Shutdown()
	{
	}
}
