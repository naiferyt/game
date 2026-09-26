using UnityEngine;

public class StreamTest : MonoBehaviour
{
	private void Start()
	{
		RecoveryPending.Hit("StreamTest.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("StreamTest.Update");
	}
}
