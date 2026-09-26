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
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void DoMovement()
	{
	}

	private void UpdateTarget()
	{
	}

	private void OnDrawGizmos()
	{
	}

	public void CollisionReflect(Transform collider)
	{
	}
}
