using UnityEngine;

// One kart part (body, wheels, spoiler, character...) with its cost, lock state and alternate body forms.
// Source listing: recovery/aot_listings/Assembly-CSharp/CartPart.txt
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

	// RECUPERADO-AOT CartPart::get_IsLocked token 0x0600021b @0x000e1e90
	public bool IsLocked
	{
		get
		{
			if (cost == 0)
			{
				return false;
			}
			return !DataUtility.Instance.IsUnlocked(UIName.baseText);
		}
	}

	// RECUPERADO-AOT CartPart::get_AreAllAlternateFormsLocked token 0x0600021c @0x000e1f00
	public bool AreAllAlternateFormsLocked
	{
		get
		{
			if (alternateForms != null)
			{
				AlternateForm.FormData[] forms = alternateForms.forms;
				for (int i = 0; i < forms.Length; i++)
				{
					if (!forms[i].part.IsLocked)
					{
						return false;
					}
				}
			}
			return IsLocked;
		}
	}

	// RECUPERADO-AOT CartPart::get_bodyFormType token 0x0600021d @0x000e1fb4
	public AlternateForm.BodyForm bodyFormType
	{
		get
		{
			if (alternateForms == null || alternateForms.forms.Length == 0)
			{
				return AlternateForm.BodyForm.Normal;
			}
			AlternateForm.FormData[] forms = alternateForms.forms;
			foreach (AlternateForm.FormData formData in forms)
			{
				if (formData.part == this)
				{
					return formData.form;
				}
			}
			return AlternateForm.BodyForm.Normal;
		}
	}

	// RECUPERADO-AOT CartPart::GetAlternatePartOfForm token 0x0600021e @0x000e207c
	public CartPart GetAlternatePartOfForm(AlternateForm.BodyForm form)
	{
		if (alternateForms != null && alternateForms.forms != null && alternateForms.forms.Length > 0)
		{
			AlternateForm.FormData[] forms = alternateForms.forms;
			foreach (AlternateForm.FormData formData in forms)
			{
				if (formData.form == form)
				{
					return formData.part;
				}
			}
		}
		return this;
	}
}
