using UnityEngine;

public class CartPart : MonoBehaviour
{
	public LocalizedString UIName;

	public int cost;

	public UnlocalizedString bundlePath;

	public UnlocalizedString resourcePath;

	public CartSlot.Slots cartSlot;

	public AlternateForm alternateForms;

	public CartAttributes cartAttributeMods;

	public PaintJob[] validPaintJobs;

	public bool IsLocked
	{
		get
		{
			RecoveryPending.Hit("CartPart.get_IsLocked");
			return default(bool);
		}
	}

	public bool AreAllAlternateFormsLocked
	{
		get
		{
			RecoveryPending.Hit("CartPart.get_AreAllAlternateFormsLocked");
			return default(bool);
		}
	}

	public AlternateForm.BodyForm bodyFormType
	{
		get
		{
			RecoveryPending.Hit("CartPart.get_bodyFormType");
			return default(AlternateForm.BodyForm);
		}
	}

	public CartPart GetAlternatePartOfForm(AlternateForm.BodyForm form)
	{
		RecoveryPending.Hit("CartPart.GetAlternatePartOfForm");
		return default(CartPart);
	}
}
