using System;
using UnityEngine;

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

	public int IndexOf(CartPart part)
	{
		RecoveryPending.Hit("AlternateForm.IndexOf");
		return default(int);
	}

	public CartPart FindFirstWithForm(BodyForm form)
	{
		RecoveryPending.Hit("AlternateForm.FindFirstWithForm");
		return default(CartPart);
	}

	public BodyForm GetBodyForm(CartPart part)
	{
		RecoveryPending.Hit("AlternateForm.GetBodyForm");
		return default(BodyForm);
	}
}
