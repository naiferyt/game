using System.Collections;

public class DebugMoreCoinsPublisher : UghPublisher
{
	public int cost;

	public UnlocalizedString identifier;

	public LocalizedString appToggleOffMessage;

	public LocalizedString appPurchasesOffMessage;

	private bool coinButtonPressed;

	private void ReBuyHelper(int tier)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		return default(IEnumerator);
	}

	private void Start()
	{
	}

	public void CoinPackOnePressed()
	{
	}

	public void CoinPackTwoPressed()
	{
	}

	public void CoinPackThreePressed()
	{
	}

	public void CancelPressed()
	{
	}

	private static DebugMoreCoinsPublisher GetInstance()
	{
		return default(DebugMoreCoinsPublisher);
	}

	public static void AddButtonsToLegalControls()
	{
	}
}
