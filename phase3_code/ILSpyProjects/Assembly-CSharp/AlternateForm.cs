using System;
using UnityEngine;

public class AlternateForm : MonoBehaviour
{
	public enum BodyForm
	{
		Normal,
		MonsterTruck,
		Bike
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public CartPart FindFirstWithForm(BodyForm form)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public BodyForm GetBodyForm(CartPart part)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
