using UnityEngine;

public class DebugTrackStrapper : MonoBehaviour
{
	public RaceSettings debugSettings;

	public CartSlot[] cartSlots;

	private void Start()
	{
		RecoveryPending.Hit("DebugTrackStrapper.Start");
	}
}
