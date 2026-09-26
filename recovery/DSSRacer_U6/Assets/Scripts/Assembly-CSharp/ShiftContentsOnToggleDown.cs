using UnityEngine;

// Nudges the control's contents (or the listed transforms) by "offset" while the UghToggle is held down.
// Source listing: recovery/aot_listings/Assembly-CSharp/ShiftContentsOnToggleDown.txt
public class ShiftContentsOnToggleDown : MonoBehaviour
{
	// RECUPERADO-AOT ShiftContentsOnToggleDown::.ctor token 0x0600042a @0x000fee1c (field initializers)
	public Vector3 offset = new Vector3(0f, -0.05f, 0f);

	public Transform[] transformsToShift;

	// RECUPERADO-AOT ShiftContentsOnToggleDown::OnEnable token 0x0600042b @0x000feef8
	private void OnEnable()
	{
		UghToggle component = GetComponent<UghToggle>();
		if ((bool)component)
		{
			component.OnDown = (System.Action<UghToggle, bool>)System.Delegate.Combine(component.OnDown, new System.Action<UghToggle, bool>(OnDownHandler));
		}
	}

	// RECUPERADO-AOT ShiftContentsOnToggleDown::OnDisable token 0x0600042c @0x000ff008
	private void OnDisable()
	{
		UghToggle component = GetComponent<UghToggle>();
		if ((bool)component)
		{
			component.OnDown = (System.Action<UghToggle, bool>)System.Delegate.Remove(component.OnDown, new System.Action<UghToggle, bool>(OnDownHandler));
		}
	}

	// RECUPERADO-AOT ShiftContentsOnToggleDown::OnDownHandler token 0x0600042d @0x000ff118
	private void OnDownHandler(UghToggle button, bool isDown)
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
