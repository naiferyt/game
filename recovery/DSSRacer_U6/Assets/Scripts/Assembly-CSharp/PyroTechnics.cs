using UnityEngine;

// Fireworks gate: when the player's kart passes, spawns pyroPrefab on every "PyroSlot" child of the kart.
// Source listing: recovery/aot_listings/Assembly-CSharp/PyroTechnics.txt
// RECUPERADO-AOT PyroTechnics::.ctor token 0x060004f4 @0x0010bf3c (trivial constructor)
public class PyroTechnics : MonoBehaviour
{
	public GameObject pyroPrefab;

	// RECUPERADO-AOT PyroTechnics::Start token 0x060004f5 @0x0010bf70
	private void Start()
	{
	}

	// RECUPERADO-AOT PyroTechnics::Update token 0x060004f6 @0x0010bf9c
	private void Update()
	{
	}

	// RECUPERADO-AOT PyroTechnics::OnTriggerEnter token 0x060004f7 @0x0010bfc8
	private void OnTriggerEnter(Collider other)
	{
		if (!RaceManager.IsPlayerCar(other.gameObject))
		{
			return;
		}
		Transform[] componentsInChildren = other.transform.GetComponentsInChildren<Transform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Transform transform = componentsInChildren[i];
			if (transform.name == "PyroSlot")
			{
				GameObject gameObject = Object.Instantiate(pyroPrefab, transform.position, transform.rotation) as GameObject;
				gameObject.transform.parent = transform;
			}
		}
	}
}
