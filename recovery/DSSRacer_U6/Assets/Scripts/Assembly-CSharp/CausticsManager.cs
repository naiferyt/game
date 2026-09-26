using System.Collections;
using System.Diagnostics;
using UnityEngine;

[ExecuteInEditMode]
public class CausticsManager : MonoBehaviour
{
	public Vector4 causticsVector;

	private void Start()
	{
		RecoveryPending.Hit("CausticsManager.Start");
	}

	[DebuggerHidden]
	private IEnumerator UpdateCausticsCoroutine()
	{
		RecoveryPending.Hit("CausticsManager.UpdateCausticsCoroutine");
		yield break;
	}
}
