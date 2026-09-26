using UnityEngine;

public class AnimationTire : MonoBehaviour
{
	public GameObject[] tires;

	private CarCollider owner;

	private float velocity;

	private GimpedCarAI gimped;

	private void Start()
	{
		RecoveryPending.Hit("AnimationTire.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("AnimationTire.Update");
	}
}
