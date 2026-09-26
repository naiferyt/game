using UnityEngine;

public class EnsureGlobals : MonoBehaviour
{
	public GameObject[] globalsList;

	private void Awake()
	{
		RecoveryPending.Hit("EnsureGlobals.Awake");
	}
}
