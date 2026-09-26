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
}
