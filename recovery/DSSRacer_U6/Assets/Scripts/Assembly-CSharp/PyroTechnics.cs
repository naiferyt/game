using UnityEngine;

public class PyroTechnics : MonoBehaviour
{
	public GameObject pyroPrefab;

	private void Start()
	{
		RecoveryPending.Hit("PyroTechnics.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("PyroTechnics.Update");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("PyroTechnics.OnTriggerEnter");
	}
}
