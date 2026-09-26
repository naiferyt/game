using System.Collections;
using UnityEngine;

public class ConfirmationPublisher : UghPublisher
{
	[HideInInspector]
	public bool confirm;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void PressedYes()
	{
	}

	public void PressedNo()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Close()
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator DestroyThis()
	{
		return default(IEnumerator);
	}
}
