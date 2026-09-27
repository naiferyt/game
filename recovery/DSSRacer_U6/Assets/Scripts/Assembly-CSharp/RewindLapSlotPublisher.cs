// "Redo lap N" slot of the rewind dialog: restarts the race from that lap.
// Source listing: recovery/aot_listings/Assembly-CSharp/RewindLapSlotPublisher.txt
public class RewindLapSlotPublisher : UghPublisher
{
	public int lapNum;

	// RECUPERADO-AOT RewindLapSlotPublisher::PressedRewind token 0x060007b1 @0x001403e4
	private void PressedRewind()
	{
		DataUtility.Instance.CurSettings.lapNumber = lapNum;
		ScreenFader.Instance.LoadLevel("Loading");
	}
}
