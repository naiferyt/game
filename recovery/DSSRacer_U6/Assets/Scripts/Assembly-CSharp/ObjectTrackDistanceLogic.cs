using UnityEngine;

// Stores an object's distance along the track once the race is initialised (used by track props).
// Source listing: recovery/aot_listings/Assembly-CSharp/ObjectTrackDistanceLogic.txt
public class ObjectTrackDistanceLogic : MonoBehaviour
{
	public float trackDistance;

	// RECUPERADO-AOT ObjectTrackDistanceLogic::Start token 0x06000521 @0x0010e0e4 (empty)
	private void Start()
	{
	}

	// RECUPERADO-AOT ObjectTrackDistanceLogic::Update token 0x06000522 @0x0010e110 (empty)
	private void Update()
	{
	}

	// RECUPERADO-AOT ObjectTrackDistanceLogic::OnEnable token 0x06000523 @0x0010e13c
	private void OnEnable()
	{
		RaceManager.raceInitFinishedEvent += CalculateTrackDistance;
	}

	// RECUPERADO-AOT ObjectTrackDistanceLogic::OnDisable token 0x06000524 @0x0010e1cc
	private void OnDisable()
	{
		RaceManager.raceInitFinishedEvent -= CalculateTrackDistance;
	}

	// RECUPERADO-AOT ObjectTrackDistanceLogic::CalculateTrackDistance token 0x06000525 @0x0010e25c
	private void CalculateTrackDistance()
	{
		trackDistance = WaypointLogic.GetTrackDistanceForPoint(base.gameObject.transform.position);
	}
}
