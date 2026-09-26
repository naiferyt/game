using UnityEngine;

public class AutoDestructParticleSystem : MonoBehaviour
{
	private void Start()
	{
		RecoveryPending.Hit("AutoDestructParticleSystem.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("AutoDestructParticleSystem.Update");
	}

	private void LateUpdate()
	{
		RecoveryPending.Hit("AutoDestructParticleSystem.LateUpdate");
	}
}
