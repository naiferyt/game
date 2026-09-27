using UnityEngine;

// AI state: steer around a harmful terrain trigger ahead, blending "away from it, toward the track line" with the
// track direction, until it is out of the kart's 45-degree cone or behind it.
// Source listing: recovery/aot_listings/Assembly-CSharp/DriveAvoidTerrainAIState.txt
public class DriveAvoidTerrainAIState : BaseCarAIState
{
	public const float MAX_DIST = 40f;

	private GameObject terrainTrigger;

	// RECUPERADO-AOT DriveAvoidTerrainAIState::.ctor token 0x06000031 @0x000c4b04 (field initializer)
	public Vector3 awayfromPoint = Vector3.zero;

	// RECUPERADO-AOT DriveAvoidTerrainAIState::GetAIStateEnum token 0x06000032 @0x000c4b58
	public override CarAI.AIStates GetAIStateEnum()
	{
		return CarAI.AIStates.avoidBadTerrain;
	}

	// RECUPERADO-AOT DriveAvoidTerrainAIState::Init token 0x06000033 @0x000c4b88
	public override void Init()
	{
		Collider[] array = Physics.OverlapSphere(parentAI.gameObject.transform.position, parentAI.personality.awarenessRadius);
		foreach (Collider collider in array)
		{
			TerrainEffectTrigger component = collider.gameObject.GetComponent<TerrainEffectTrigger>();
			if (!(component == null) && !BaseEffect.isBeneficial(component.effectType))
			{
				Vector3 rhs = collider.transform.position - parentAI.transform.position;
				if (!(0f >= Vector3.Dot(parentAI.transform.forward, rhs)))
				{
					terrainTrigger = collider.gameObject;
					break;
				}
			}
		}
	}

	// RECUPERADO-AOT DriveAvoidTerrainAIState::Update token 0x06000034 @0x000c4dcc
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
		Vector3 vector = terrainTrigger.transform.position - parentAI.transform.position;
		float num = Vector3.Angle(parentAI.transform.forward, vector.normalized);
		if (!(45f >= num))
		{
			parentAI.StateDone(this);
		}
	}

	// RECUPERADO-AOT DriveAvoidTerrainAIState::FixedUpdate token 0x06000035 @0x000c4ff0
	public override void FixedUpdate()
	{
		if (!(terrainTrigger == null))
		{
			awayfromPoint = terrainTrigger.GetComponent<Collider>().ClosestPointOnBounds(parentAI.transform.position);
			WaypointLogic waypointLogic = WaypointLogic.FindClosestWaypoint(terrainTrigger.transform.position, false);
			Vector3 vector = waypointLogic.GetTrackPoint(awayfromPoint) - awayfromPoint;
			vector.y = 0f;
			float num = (awayfromPoint - parentAI.transform.position).magnitude / parentAI.personality.awarenessRadius;
			WaypointLogic waypointLogic2 = WaypointLogic.FindNextWaypoint(parentAI.transform.position);
			Vector3 b = waypointLogic2.transform.position - waypointLogic2.backwardPoint.transform.position;
			parentAI.DriveWithFacing(Vector3.Lerp(vector.normalized, b, num / 4f));
		}
	}

	// RECUPERADO-AOT DriveAvoidTerrainAIState::Shutdown token 0x06000036 @0x000c53dc
	public override void Shutdown()
	{
	}
}
