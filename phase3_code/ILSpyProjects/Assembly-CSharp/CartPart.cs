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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool AreAllAlternateFormsLocked
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public AlternateForm.BodyForm bodyFormType
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public CartPart GetAlternatePartOfForm(AlternateForm.BodyForm form)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
