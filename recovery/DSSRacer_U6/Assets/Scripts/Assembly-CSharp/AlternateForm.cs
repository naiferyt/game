using System;
using UnityEngine;

// Links the Kart / Monster Truck / Bike variants of the same body so the other parts can follow the body form.
// Source listing: recovery/aot_listings/Assembly-CSharp/AlternateForm.txt
public class AlternateForm : MonoBehaviour
{
	public enum BodyForm
	{
		Normal = 0,
		MonsterTruck = 1,
		Bike = 2
	}

	[Serializable]
	public class FormData
	{
		public BodyForm form;

		public CartPart part;
	}

	public FormData[] forms;

	// RECUPERADO-AOT AlternateForm::IndexOf token 0x06000209 @0x000e0e34
	public int IndexOf(CartPart part)
	{
		for (int i = 0; i < forms.Length; i++)
		{
			if (forms[i].part == part)
			{
				return i;
			}
		}
		return -1;
	}

	// RECUPERADO-AOT AlternateForm::FindFirstWithForm token 0x0600020a @0x000e0ed0
	public CartPart FindFirstWithForm(BodyForm form)
	{
		for (int i = 0; i < forms.Length; i++)
		{
			if (forms[i].form == form)
			{
				return forms[i].part;
			}
		}
		return null;
	}

	// RECUPERADO-AOT AlternateForm::GetBodyForm token 0x0600020b @0x000e0f84
	public BodyForm GetBodyForm(CartPart part)
	{
		int num = IndexOf(part);
		if (num == -1)
		{
			return BodyForm.Normal;
		}
		return forms[num].form;
	}
}
