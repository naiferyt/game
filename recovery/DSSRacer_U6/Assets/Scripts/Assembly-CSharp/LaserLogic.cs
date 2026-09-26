using UnityEngine;

public class LaserLogic : MonoBehaviour
{
	private const float maxLife = 1f;

	private GameObject parentObject;

	private GameObject targetObject;

	private float lifetime;

	private Vector3 error;

	private void Update()
	{
		RecoveryPending.Hit("LaserLogic.Update");
	}

	private void SetParent(GameObject parent)
	{
		RecoveryPending.Hit("LaserLogic.SetParent");
	}

	private void SetTarget(GameObject target)
	{
		RecoveryPending.Hit("LaserLogic.SetTarget");
	}

	private void ApplyError()
	{
		RecoveryPending.Hit("LaserLogic.ApplyError");
	}
}
