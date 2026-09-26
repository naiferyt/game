using System.Collections;
using System.Diagnostics;

public class RewindDialogPublisher : UghPublisher
{
	public const int REWIND_COST = 500;

	public int amountToDeduct;

	public static int RewindCost
	{
		get
		{
			RecoveryPending.Hit("RewindDialogPublisher.get_RewindCost");
			return default(int);
		}
	}

	private void Start()
	{
		RecoveryPending.Hit("RewindDialogPublisher.Start");
	}

	private void PressedExit()
	{
		RecoveryPending.Hit("RewindDialogPublisher.PressedExit");
	}

	private void PressedBuy()
	{
		RecoveryPending.Hit("RewindDialogPublisher.PressedBuy");
	}

	private bool MoneyCheck()
	{
		RecoveryPending.Hit("RewindDialogPublisher.MoneyCheck");
		return default(bool);
	}

	private void NeedMoreCoins()
	{
		RecoveryPending.Hit("RewindDialogPublisher.NeedMoreCoins");
	}

	private void FinalizedRewind()
	{
		RecoveryPending.Hit("RewindDialogPublisher.FinalizedRewind");
	}

	[DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		RecoveryPending.Hit("RewindDialogPublisher.DestroyThis");
		yield break;
	}
}
