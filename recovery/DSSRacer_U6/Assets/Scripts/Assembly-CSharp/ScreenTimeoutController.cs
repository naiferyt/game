using UnityEngine;

public class ScreenTimeoutController : MonoBehaviour
{
	private static float countdown;

	private void Update()
	{
		RecoveryPending.Hit("ScreenTimeoutController.Update");
	}

	private void OnDestroy()
	{
		RecoveryPending.Hit("ScreenTimeoutController.OnDestroy");
	}

	public static void AllowSleep()
	{
		RecoveryPending.Hit("ScreenTimeoutController.AllowSleep");
	}

	public static void SupressSleep(float forSeconds)
	{
		RecoveryPending.Hit("ScreenTimeoutController.SupressSleep");
	}
}
