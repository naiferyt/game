using UnityEngine;

public class PaintSlotPublisher : UghPublisher
{
	private enum States
	{
		locked,
		forSale,
		open
	}

	private States state;

	private int viewingIndex;

	private Texture2D texture;

	private CartCustomizerPublisher publisher;

	private void PressedPaintButton()
	{
	}

	private void Start()
	{
	}

	public void SetPaint(PaintJob paint, int index)
	{
	}

	private void OnDestroy()
	{
	}
}
