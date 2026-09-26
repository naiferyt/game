using UnityEngine;

// Keeps the screen awake for a while (SupressSleep) and restores the system sleep setting afterwards.
// Source listing: recovery/aot_listings/Assembly-CSharp/ScreenTimeoutController.txt
public class ScreenTimeoutController : MonoBehaviour
{
	private static float countdown;

	// RECUPERADO-AOT ScreenTimeoutController::Update token 0x060007c1 @0x00140cd8
	private void Update()
	{
		if (countdown > 0f)
		{
			countdown = Mathf.MoveTowards(countdown, 0f, Time.deltaTime);
			if (countdown == 0f)
			{
				Screen.sleepTimeout = -2; // SleepTimeout.SystemSetting
				Debug.Log("Sleeping again");
			}
		}
	}

	// RECUPERADO-AOT ScreenTimeoutController::OnDestroy token 0x060007c2 @0x00140e18
	private void OnDestroy()
	{
		AllowSleep();
	}

	// RECUPERADO-AOT ScreenTimeoutController::AllowSleep token 0x060007c3 @0x00140e48
	public static void AllowSleep()
	{
		countdown = 0f;
		Screen.sleepTimeout = -2; // SleepTimeout.SystemSetting
	}

	// RECUPERADO-AOT ScreenTimeoutController::SupressSleep token 0x060007c4 @0x00140e9c
	public static void SupressSleep(float forSeconds)
	{
		if (!(forSeconds > 0f))
		{
			AllowSleep();
			return;
		}
		Debug.Log("Not sleeping");
		Screen.sleepTimeout = -1; // SleepTimeout.NeverSleep
		countdown = forSeconds;
	}
}
