using UnityEngine;

public class WindowIDs : MonoBehaviour
{
	private static int id;

	private void OnDisable()
	{
		RecoveryPending.Hit("WindowIDs.OnDisable");
	}

	public static int FetchID()
	{
		RecoveryPending.Hit("WindowIDs.FetchID");
		return default(int);
	}
}
