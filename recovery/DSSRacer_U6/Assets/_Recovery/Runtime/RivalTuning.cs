// MODIFICADO (petición del usuario, 2026-09-27; no está en el original).
// The original rivals (GimpedCarAI) replay recorded lines at one fixed top speed per difficulty (Easy 39, Medium 45.5,
// Hard 47, while the basic player kart does 45): every rival leaves the grid at the same instant with the same
// acceleration, converges on the same recorded lines and, in Newbie, can never keep up. The user asked for rivals that
// behave like real opponents. Each rival gets its own profile:
//   - launch: reaction time 0..0.45 s after "Go" and a launch push that differs per rival for the first seconds;
//   - skill: -3%..+5% on top speed and acceleration;
//   - line: a lateral offset of up to 2 units from the recorded line that drifts slowly (none in the air / on jumps);
//   - pace: up to +10% top speed (+20% acceleration) when behind the player, up to -6% when far ahead;
//   - Easy base top speed 39 -> 42.5 (x1.09), Medium and Hard x1.02.
// RecoverySwitches.CompetitiveRivals (PlayerPrefs "DSSR_CompetitiveRivals" = 0) turns all of it off.
using UnityEngine;

public class RivalTuning
{
	public readonly float skill;

	public readonly float launchDelay;

	public readonly float launchPush;

	private readonly float laneBase;

	private readonly float laneSeed;

	private float raceStart = -1f;

	public RivalTuning()
	{
		skill = Random.Range(0.97f, 1.05f);
		launchDelay = Random.Range(0f, 0.45f);
		launchPush = Random.Range(0.85f, 1.2f);
		laneBase = Random.Range(-1.5f, 1.5f);
		laneSeed = Random.Range(0f, 1000f);
	}

	public static bool Enabled
	{
		get { return RecoverySwitches.CompetitiveRivals; }
	}

	// Called every physics step once the kart is unlocked; returns false while the rival is still "reacting" to the start.
	public bool Launched()
	{
		if (raceStart < 0f)
		{
			raceStart = Time.time;
		}
		return Time.time - raceStart >= launchDelay;
	}

	private float SinceStart
	{
		get { return raceStart < 0f ? 0f : Time.time - raceStart; }
	}

	private static float DifficultyFactor()
	{
		if (!RaceManager.Exists)
		{
			return 1f;
		}
		switch (RaceManager.Instance.raceDifficulty)
		{
		case RaceManager.RaceDifficultyLevel.EASY:
			return 1.09f;
		case RaceManager.RaceDifficultyLevel.MEDIUM:
		case RaceManager.RaceDifficultyLevel.HARD:
			return 1.02f;
		default:
			return 1f;
		}
	}

	// Gap along the track to the player (positive = rival ahead); 0 when unknown.
	private static float GapToPlayer(GameObject rival)
	{
		GameObject player = RaceManager.GetPlayerCar();
		if (player == null || player == rival || RaceManager.GetCarLastProgressTrigger(player) == null || RaceManager.GetCarLastProgressTrigger(rival) == null)
		{
			return 0f;
		}
		return RaceManager.GetCarLastTrackDistance(rival) - RaceManager.GetCarLastTrackDistance(player);
	}

	public float MaxSpeedFactor(GameObject rival)
	{
		float gap = GapToPlayer(rival);
		float pace = gap < 0f ? 1f + 0.10f * Mathf.Clamp01(-gap / 150f) : 1f - 0.06f * Mathf.Clamp01(gap / 250f);
		return DifficultyFactor() * skill * pace;
	}

	public float AccelerationFactor(GameObject rival)
	{
		float gap = GapToPlayer(rival);
		float pace = gap < 0f ? 1f + 0.20f * Mathf.Clamp01(-gap / 150f) : 1f;
		// launch push fades out over the first 4 seconds after "Go"
		float launch = Mathf.Lerp(launchPush, 1f, Mathf.Clamp01(SinceStart / 4f));
		return skill * pace * launch;
	}

	// Lateral offset from the recorded line (units, + = right of the direction of travel).
	public float LaneOffset()
	{
		return Mathf.Clamp(laneBase + (Mathf.PerlinNoise(laneSeed, Time.time * 0.15f) - 0.5f) * 2f, -2f, 2f);
	}
}
