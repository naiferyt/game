using System.Collections;

public class RewindDialogPublisher : UghPublisher
{
	public const int REWIND_COST = 500;

	public int amountToDeduct;

	public static int RewindCost
	{
		get
		{
			return default(int);
		}
	}

	private void Start()
	{
	}

	private void PressedExit()
	{
	}

	private void PressedBuy()
	{
	}

	private bool MoneyCheck()
	{
		return default(bool);
	}

	private void NeedMoreCoins()
	{
	}

	private void FinalizedRewind()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		return default(IEnumerator);
	}
}
