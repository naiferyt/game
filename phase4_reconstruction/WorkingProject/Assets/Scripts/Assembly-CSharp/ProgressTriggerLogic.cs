using UnityEngine;

public class ProgressTriggerLogic : MonoBehaviour
{
	public ProgressTriggerLogic nextTrigger;

	public bool isLapLine;

	public float trackDistance;

	private bool CanTriggerForCar(GameObject car)
	{
		return default(bool);
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
