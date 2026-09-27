// Stage 4.1 (ADAPTADO-U6, plataforma PC): frame rate.
// The original ran on iOS at Unity 4's default 30 fps (no Application.targetFrameRate call in the game code)
// with physics at 60 Hz (Fixed Timestep 0.0167, QualityControl.DoPhysicsAt30fps folded to false).
// On PC the display is locked to 60 fps with vSync off, so frame pacing matches the 60 Hz physics on any
// monitor refresh rate. Runs before the first scene loads.
using UnityEngine;

public static class PcFrameRate
{
	public const int TargetFps = 60;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Apply()
	{
		if (Application.isMobilePlatform)
		{
			return;
		}
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = TargetFps;
	}
}
