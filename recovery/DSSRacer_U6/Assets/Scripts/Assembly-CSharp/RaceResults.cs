using UnityEngine;

// Results of the last race, kept across the scene change (DontDestroyOnLoad "Stats Object") for RaceResultsPublisher.
// Source listing: recovery/aot_listings/Assembly-CSharp/RaceResults.txt
public class RaceResults : MonoBehaviour
{
	public CarProgress[] ordredResultList;

	// RECUPERADO-AOT RaceResults::.ctor token 0x0600055a @0x00113a7c (field initializer)
	public int playerCarIndex = -1;

	public CarMetrics playerMetrics;

	public float raceRewindTime;

	public int rewindCoinsToSpawn;
}
