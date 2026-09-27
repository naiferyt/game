// Stage 2 recovery infrastructure (RECONSTRUIDO: local replacement for dead remote switches).
// Pranksgiving was enabled by a JSON file downloaded from http://datg-apps.com/ss/pranksgiving.txt
// (TrackUnlockHelper.Start; server gone, ELIMINADO). Decision D2 (RECOVERY_REPORT.md 12.2): local switch, on by default.
// Turn it off with PlayerPrefs "DSSR_Pranksgiving" = 0.
using UnityEngine;

public static class RecoverySwitches
{
	public const string PranksgivingKey = "DSSR_Pranksgiving";

	public static bool PranksgivingEnabled
	{
		get { return PlayerPrefs.GetInt(PranksgivingKey, 1) != 0; }
	}

	// MODIFICADO (petición del usuario, 2026-09-27): more human rivals (RivalTuning, used by GimpedCarAI). On by default;
	// PlayerPrefs "DSSR_CompetitiveRivals" = 0 restores the original rival driving exactly.
	public const string CompetitiveRivalsKey = "DSSR_CompetitiveRivals";

	public static bool CompetitiveRivals
	{
		get { return PlayerPrefs.GetInt(CompetitiveRivalsKey, 1) != 0; }
	}
}
