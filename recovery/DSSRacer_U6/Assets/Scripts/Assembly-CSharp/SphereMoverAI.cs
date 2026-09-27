using System.Collections.Generic;
using UnityEngine;

// Rigidbody that rolls in a random horizontal direction and picks a new one when it bumps into a
// SphereMoverCollider (turned around if it was heading into the collider's facing).
// Source listing: recovery/aot_listings/Assembly-CSharp/SphereMoverAI.txt
public class SphereMoverAI : MonoBehaviour
{
	private const float EPSILON_DIST = 10f;

	public List<GameObject> targets;

	public GameObject startTarget;

	// RECUPERADO-AOT SphereMoverAI::.ctor token 0x060000a0 @0x000ceecc (field initializer)
	public float moveSpeed = 3f;

	private int targetIndex;

	private Vector3 moveVec;

	// RECUPERADO-AOT SphereMoverAI::Start token 0x060000a1 @0x000cef18
	private void Start()
	{
		Vector2 insideUnitCircle = Random.insideUnitCircle;
		moveVec = new Vector3(insideUnitCircle.x, 0f, insideUnitCircle.y).normalized;
	}

	// RECUPERADO-AOT SphereMoverAI::Update token 0x060000a2 @0x000cefec
	private void Update()
	{
	}

	// RECUPERADO-AOT SphereMoverAI::FixedUpdate token 0x060000a3 @0x000cf018
	private void FixedUpdate()
	{
		DoMovement();
	}

	// RECUPERADO-AOT SphereMoverAI::DoMovement token 0x060000a4 @0x000cf04c
	// ADAPTADO-U6: Component.rigidbody -> GetComponent<Rigidbody>().
	private void DoMovement()
	{
		GetComponent<Rigidbody>().AddForce(moveVec * moveSpeed);
	}

	// RECUPERADO-AOT SphereMoverAI::UpdateTarget token 0x060000a5 @0x000cf0e0
	private void UpdateTarget()
	{
		targetIndex++;
		if (targetIndex >= targets.Count)
		{
			targetIndex = 0;
		}
		moveVec = (targets[targetIndex].transform.position - base.transform.position).normalized;
	}

	// RECUPERADO-AOT SphereMoverAI::OnDrawGizmos token 0x060000a6 @0x000cf1f4
	private void OnDrawGizmos()
	{
	}

	// RECUPERADO-AOT SphereMoverAI::CollisionReflect token 0x060000a7 @0x000cf220
	// ADAPTADO-U6: Rigidbody.velocity is linearVelocity in Unity 6.
	public void CollisionReflect(Transform collider)
	{
		Rigidbody component = GetComponent<Rigidbody>();
#if UNITY_6000_0_OR_NEWER
		if (!(5f >= component.linearVelocity.magnitude))
		{
			component.linearVelocity = component.linearVelocity.normalized * 5f;
		}
#else
		if (!(5f >= component.velocity.magnitude))
		{
			component.velocity = component.velocity.normalized * 5f;
		}
#endif
		Debug.Log("CollisionReflect!!");
		Vector2 insideUnitCircle = Random.insideUnitCircle;
		Vector3 vector = new Vector3(insideUnitCircle.x, 0f, insideUnitCircle.y).normalized;
		if (Vector3.Dot(moveVec, collider.forward) < 0f)
		{
			vector = Quaternion.Euler(0f, 180f, 0f) * vector;
			vector.y = 0f;
		}
		Debug.Log("Old moveVec: " + moveVec.ToString());
		moveVec = vector.normalized;
		Debug.Log("New moveVec: " + moveVec.ToString());
		component.AddForce(moveVec * moveSpeed);
	}
}
