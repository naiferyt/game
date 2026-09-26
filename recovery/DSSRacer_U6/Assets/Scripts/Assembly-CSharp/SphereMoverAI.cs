using System.Collections.Generic;
using UnityEngine;

public class SphereMoverAI : MonoBehaviour
{
	private const float EPSILON_DIST = 10f;

	public List<GameObject> targets;

	public GameObject startTarget;

	public float moveSpeed;

	private int targetIndex;

	private Vector3 moveVec;

	private void Start()
	{
		RecoveryPending.Hit("SphereMoverAI.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("SphereMoverAI.Update");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("SphereMoverAI.FixedUpdate");
	}

	private void DoMovement()
	{
		RecoveryPending.Hit("SphereMoverAI.DoMovement");
	}

	private void UpdateTarget()
	{
		RecoveryPending.Hit("SphereMoverAI.UpdateTarget");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("SphereMoverAI.OnDrawGizmos");
	}

	public void CollisionReflect(Transform collider)
	{
		RecoveryPending.Hit("SphereMoverAI.CollisionReflect");
	}
}
