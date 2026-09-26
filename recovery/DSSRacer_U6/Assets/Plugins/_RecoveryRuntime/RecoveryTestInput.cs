// Stage 1+ test tooling (RECONSTRUIDO: tooling, editor only). Lets the unattended PlayModeRunner "click"
// the original Ugh UI: UghInput consults this in addition to the real mouse/touch input.
// Coordinates are normalized (0..1, origin bottom-left) so tests don't depend on the window size.
using UnityEngine;

public static class RecoveryTestInput
{
	static int s_Frames;
	static Vector2 s_Pos;

	public static void Click(Vector2 normalized)
	{
		s_Pos = normalized;
		s_Frames = 3;   // held for a few frames so down/up transitions are observed
	}

	// true while a simulated press is active; position in screen pixels
	public static bool Pressed(out Vector3 screenPos)
	{
		screenPos = new Vector3(s_Pos.x * Screen.width, s_Pos.y * Screen.height, 0f);
#if UNITY_EDITOR
		if (s_Frames > 0) { s_Frames--; return true; }
#endif
		return false;
	}
}
