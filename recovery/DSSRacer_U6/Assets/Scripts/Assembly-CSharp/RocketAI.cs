using UnityEngine;

[RequireComponent(typeof(SoundSequencer))]
public class RocketAI : MonoBehaviour
{
	private const float MAX_VELOCITY = 100f;

	private const float ACCELERATION = 200f;

	private const float CYCLE_WP_DISTANCE_SQR = 25f;

	private const float HUNT_DISTANCE_SQR = 900f;

	private const float KILL_DISTANCE = 1f;

	private float launchTimer;

	private float lifeTimer;

	private WaypointLogic nextWP;

	private GameObject launchOwner;

	public GameObject launchTarget;

	private Vector3 launchVector;

	private float velocity;

	private RocketRideEffect riderEffect;

	public bool isReverse;

	public bool isBoatAnchor;

	public bool rideRocket;

	private GameObject explosionEffectPrefab;

	private SoundSequencer seq;

	private void StrikeTarget(GameObject target)
	{
		RecoveryPending.Hit("RocketAI.StrikeTarget");
	}

	private void LaunchUpdate()
	{
		RecoveryPending.Hit("RocketAI.LaunchUpdate");
	}

	private void BurnUpdate()
	{
		RecoveryPending.Hit("RocketAI.BurnUpdate");
	}

	private void Explode()
	{
		RecoveryPending.Hit("RocketAI.Explode");
	}

	private void Start()
	{
		RecoveryPending.Hit("RocketAI.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("RocketAI.Update");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("RocketAI.FixedUpdate");
	}

	public void SetOwner(GameObject obj)
	{
		RecoveryPending.Hit("RocketAI.SetOwner");
	}

	public void SetTarget(GameObject obj)
	{
		RecoveryPending.Hit("RocketAI.SetTarget");
	}

	public void SetRiderEffect(RocketRideEffect rre)
	{
		RecoveryPending.Hit("RocketAI.SetRiderEffect");
	}
}
