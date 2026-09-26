public class RewindLapSlotPublisher : UghPublisher
{
	public int lapNum;

	private void PressedRewind()
	{
		RecoveryPending.Hit("RewindLapSlotPublisher.PressedRewind");
	}
}
