using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class BillboardRemover : MonoBehaviour
{
	public Material replacement;

	private void Start()
	{
		RecoveryPending.Hit("BillboardRemover.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("BillboardRemover.Update");
	}

	[DebuggerHidden]
	private IEnumerator RemoveBillboards()
	{
		RecoveryPending.Hit("BillboardRemover.RemoveBillboards");
		yield break;
	}
}
