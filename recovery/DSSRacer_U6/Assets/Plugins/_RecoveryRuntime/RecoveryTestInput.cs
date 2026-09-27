// Stage 1+ test tooling (RECONSTRUIDO: tooling, editor only). Lets the unattended PlayModeRunner "click"
// the original Ugh UI: UghInput consults this in addition to the real mouse/touch input.
// Coordinates are normalized (0..1, origin bottom-left) so tests don't depend on the window size.
// Stage 3: simulated held keys for driving (PlayerKeyboardControl consults Key / KeyDown).
using System.Collections.Generic;
using UnityEngine;

public static class RecoveryTestInput
{
	// Set by RecoveryPlayerTest when a built player runs with -recoveryTest (stage 4 test harness); editor always on.
	public static bool PlayerTestEnabled;

	static bool Active
	{
		get
		{
#if UNITY_EDITOR
			return true;
#else
			return PlayerTestEnabled;
#endif
		}
	}

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
		if (Active && s_Frames > 0) { s_Frames--; return true; }
		return false;
	}

	static readonly HashSet<KeyCode> s_Held = new HashSet<KeyCode>();
	static readonly HashSet<KeyCode> s_PendingDown = new HashSet<KeyCode>();
	static readonly Dictionary<KeyCode, int> s_DownFrame = new Dictionary<KeyCode, int>();

	public static void SetKey(KeyCode key, bool held)
	{
		if (held) { if (s_Held.Add(key)) s_PendingDown.Add(key); }
		else { s_Held.Remove(key); s_PendingDown.Remove(key); }
	}

	// true while a simulated key is held
	public static bool Key(KeyCode key)
	{
		return Active && s_Held.Contains(key);
	}

	// true during the first frame in which a newly held simulated key is queried
	public static bool KeyDown(KeyCode key)
	{
		if (!Active) return false;
		if (s_PendingDown.Remove(key)) { s_DownFrame[key] = Time.frameCount; return true; }
		int f;
		return s_DownFrame.TryGetValue(key, out f) && f == Time.frameCount;
	}
}
