using UnityEngine;

public class BreakableObject : MonoBehaviour
{
	public float breakSpeed;

	private void CollideBreak(float speed)
	{
		RecoveryPending.Hit("BreakableObject.CollideBreak");
	}

	private void Start()
	{
		RecoveryPending.Hit("BreakableObject.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("BreakableObject.Update");
	}
}
