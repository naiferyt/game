using UnityEngine;

public class CloudStrap : MonoBehaviour
{
	private void ContinueToFrontEnd()
	{
		RecoveryPending.Hit("CloudStrap.ContinueToFrontEnd");
	}

	private void Start()
	{
		RecoveryPending.Hit("CloudStrap.Start");
	}
}
