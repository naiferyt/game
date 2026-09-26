using UnityEngine;

// Nudges the control's contents (or the listed transforms) by "offset" while the UghButton is held down.
// Source listing: recovery/aot_listings/Assembly-CSharp/ShiftContentsOnButtonDown.txt
public class ShiftContentsOnButtonDown : MonoBehaviour
{
	// RECUPERADO-AOT ShiftContentsOnButtonDown::.ctor token 0x06000426 @0x000fe64c (field initializers)
	public Vector3 offset = new Vector3(0f, -0.05f, 0f);

	public Transform[] transformsToShift;

	// RECUPERADO-AOT ShiftContentsOnButtonDown::OnEnable token 0x06000427 @0x000fe728
	private void OnEnable()
	{
		UghButton component = GetComponent<UghButton>();
		if ((bool)component)
		{
			component.OnDown = (System.Action<UghButton, bool>)System.Delegate.Combine(component.OnDown, new System.Action<UghButton, bool>(OnDownHandler));
		}
	}

	// RECUPERADO-AOT ShiftContentsOnButtonDown::OnDisable token 0x06000428 @0x000fe838
	private void OnDisable()
	{
		UghButton component = GetComponent<UghButton>();
		if ((bool)component)
		{
			component.OnDown = (System.Action<UghButton, bool>)System.Delegate.Remove(component.OnDown, new System.Action<UghButton, bool>(OnDownHandler));
		}
	}

	// RECUPERADO-AOT ShiftContentsOnButtonDown::OnDownHandler token 0x06000429 @0x000fe948
	private void OnDownHandler(UghButton button, bool isDown)
	{
		if (transformsToShift.Length == 0)
		{
			foreach (Transform item in base.transform)
			{
				if (isDown)
				{
					item.position += offset;
				}
				else
				{
					item.position -= offset;
				}
			}
			return;
		}
		for (int i = 0; i < transformsToShift.Length; i++)
		{
			Transform transform = transformsToShift[i];
			if (transform == null)
			{
				continue;
			}
			if (isDown)
			{
				transform.position += offset;
			}
			else
			{
				transform.position -= offset;
			}
		}
	}
}
