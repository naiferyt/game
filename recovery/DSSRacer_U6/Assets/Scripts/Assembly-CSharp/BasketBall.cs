using UnityEngine;

public class BasketBall : MonoBehaviour
{
	private float bounceTimer;

	private bool bounceBack;

	private Vector3 lastBounce;

	private void Update()
	{
		RecoveryPending.Hit("BasketBall.Update");
	}

	private void PlayBounceSound()
	{
		RecoveryPending.Hit("BasketBall.PlayBounceSound");
	}

	private void OnTriggerEnter(Collider other)
	{
		RecoveryPending.Hit("BasketBall.OnTriggerEnter");
	}
}
